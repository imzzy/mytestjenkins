using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Collections;
using LPCommon;
using LPReplayCore.Common;
using LPReplayCore.Interfaces;
using LPReplayCore.Model;

namespace LPReplayCore.UIA
{
    
    using LocatorFunc = Func<UIATestObject, List<AutomationElement>, List<AutomationElement>>;

    public enum ElementFindingStatusEnum
    {
        Searching,
        Found,
        NotFound,
    }

    public delegate void StatusUpdateDelegate(UIATestObject testObject, ElementFindingStatusEnum findStatus);

    public static class UIAFinder
    {
        static ILogger _Logger = LogFactory.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);//"LPReplayCore.UIA.UIAFinder");

        public static ReplayCoreSettings.IndentificationLevelEnum identificationLevel = ReplayCoreSettings.IndentificationLevel;
        public static SortedList<string, LocatorFunc> locators;

        public static event StatusUpdateDelegate StatusUpdate;


        static UIAFinder()
        {
            locators = new SortedList<string, LocatorFunc>()
            {
                {"TopWindowLocator", TopWindowTitleLocator},
                {"LeftRightLocator", LeftRightLocator},
                {"IndexLocator", IndexLocator}
            };
        }

        private static void UpdateStatus(UIATestObject testObject, ElementFindingStatusEnum findStatus)
        {
            if (StatusUpdate != null)
            {
                StatusUpdate(testObject, findStatus);
            }
        }

        //get the automation object from testObject
        public static AutomationElement Find(UIATestObject testObject)
        {
            UpdateStatus(testObject, ElementFindingStatusEnum.Searching);

            List<AutomationElement> matchedElements = FindAll(testObject);

            if (matchedElements.Count >= 1)
            {
                UpdateStatus(testObject, ElementFindingStatusEnum.Found);
                return matchedElements[0];
            }
            else
            {
                UpdateStatus(testObject, ElementFindingStatusEnum.NotFound);
            }

            return null;
        }

        public static List<AutomationElement> FindAll(UIATestObject testObject)
        {
            _Logger.WriteLog(LogTypeEnum.Debug, () => "FindAll:\r\n" + UIAUtility.DumpTestObject(testObject));

            List<AutomationElement> matchedElements =
                ConditionLocator(testObject);

            if (matchedElements.Count == 0)
            {
                _Logger.WriteWarning("Can not find child in the parent container:" + testObject.ControlName);
                return matchedElements;
            }

            /*
            // if window, just check the caption, 60% match will be recognized.
             * call the following lines in sequence
             * matchedElements = TopWindowLocator(testObject, matchedElements);
             * matchedElements = LeftRightLocator(testObject, matchedElements);
             * matchedElements = IndexLocator(testObject, matchedElements);
            */
            matchedElements = FilterWithLocators(testObject, matchedElements);

            if (matchedElements.Count == 1) return matchedElements; //ignore other optional parameters

            matchedElements = FindInMatchedCollection(testObject, matchedElements);

            _Logger.WriteDebug("FindAll returns count:" + matchedElements.Count);

            return matchedElements;
        }

        private static List<AutomationElement> FilterWithLocators(UIATestObject testObject, List<AutomationElement> elements)
        {
            List<AutomationElement> matchedElements = elements;
            foreach (KeyValuePair<string, LocatorFunc> pair in locators)
            {
                string locatorName = pair.Key;
                LocatorFunc locator = pair.Value;

                matchedElements = locator(testObject, elements);

                //TODO refine the logging
                _Logger.WriteDebug(locatorName + " returns count: " + matchedElements.Count.ToString());
            }

            return matchedElements;
        }

        private static void Retry3Times(Func<bool> method)
        {
            int matchtime = 3;

            bool allmatch = method();

            while (!allmatch && matchtime > 0)
            {
                _Logger.WriteLog("Object no found, try again, time:" + matchtime);
                Thread.Sleep(1000);
                allmatch = method();
                matchtime--;
            }
        }

        public static List<AutomationElement> ConditionLocator(UIATestObject testObject)
        {
            _Logger.WriteDebug("ConditionLocator start");
            Condition condition = testObject.GetCondition();

            if (condition == null)
            {
                condition = TreeWalker.ControlViewWalker.Condition;
            }

            List<AutomationElement> elementList = new List<AutomationElement>();

            UIATestObject parentTestObject = (UIATestObject) testObject.Parent;

            if (parentTestObject == null)
            {
                //root object
                AutomationElement windowElement = AutomationElement.RootElement.FindFirst(TreeScope.Children,
                    condition);
                if (windowElement != null)
                {
                    elementList.Add(windowElement);
                }

                /*
                AutomationElementCollection windowElements = AutomationElement.RootElement.FindAll(TreeScope.Children,
                condition);
                if (windowElements != null)
                {
                    foreach (AutomationElement element in windowElements)
                    {
                        elementList.Add(element);
                    }
                }
                else
                {
                    _Logger.WriteLog(LogTypeEnum.Debug, () => "Cannot locate object:\r\n" + UIAUtility.DumpTestObject(testObject));
                }*/
                
                goto ConditionLocatorEnd;
            }

            AutomationElementCollection matchedElements = null;

            AutomationElement parentElement = parentTestObject.AutomationElement;

            if (parentElement == null)
            {
                //TODO, refine log
                _Logger.WriteWarning("Cannot identify the parent object");
                goto ConditionLocatorEnd;
            }

            matchedElements = UIAUtility.FindDescendantElements(parentTestObject.AutomationElement, condition);
            
            elementList.Capacity = matchedElements.Count;
            foreach (AutomationElement element in matchedElements)
            {
                elementList.Add(element);
            }

        ConditionLocatorEnd:
            _Logger.WriteDebug("ConditionLocator end");
            _Logger.WriteDebug("ConditionLocator returns count:" + elementList.Count);
            return elementList;
        }


        public static List<AutomationElement> IndexLocator(ITestObject testObject, List<AutomationElement> matchedElements)
        {
            //if using index only, return the object
            if (!testObject.Contains(UIAControlKeys.Index))
            {
                return matchedElements;
            }

            matchedElements.Clear();

            if (matchedElements.Count - 1 >= testObject.Index)
            {
                AutomationElement element = matchedElements[testObject.Index];
                matchedElements.Clear();
                matchedElements.Add(element);
            }

            return matchedElements;
        }


        public static List<AutomationElement> LeftRightLocator(ITestObject testObject, List<AutomationElement> matchedElements)
        {
            if (testObject.Relation == null) return matchedElements;

            IRelation relation = testObject.Relation;

            if (relation.Left == null && relation.Right == null) return matchedElements;

            AutomationElement leftElementNext  = null, rightElementPrevious = null;
            //check if the left or right condtion exist            
            //get the left and right element
            if (relation.Right != null)
            {
                ITestObject rightTO = relation.Right;

                AutomationElement rightElement = Find((UIATestObject)rightTO);
                if (rightElement == null)
                {
                    //TODO, log error
                    goto errorCase;
                }
                rightElementPrevious = UIAUtility.GetPreviousElement(rightElement);

                if (rightElementPrevious == null)
                {
                    //TODO, log error
                    goto errorCase;
                }
            }

            if (relation.Left != null)
            {

                ITestObject leftTO = relation.Left;

                AutomationElement leftElement = Find((UIATestObject)leftTO);

                if (leftElement == null)
                {
                    //TODO, log error
                    goto errorCase;
                }

                leftElementNext = UIAUtility.GetNextElement(leftElement);
                if (leftElementNext == null)
                {
                    //TODO, log error
                    goto errorCase;
                }
            }

            AutomationElement elementFound = null;

            foreach (AutomationElement element in matchedElements)
            {
                bool leftCriteria = leftElementNext == null || 
                    (leftElementNext != null && UIAUtility.AreEqual2(leftElementNext, element));

                bool rightCriteria = rightElementPrevious == null ||
                    (rightElementPrevious != null && UIAUtility.AreEqual2(rightElementPrevious, element));

                if (leftCriteria && rightCriteria)
                {
                    elementFound = element;
                    break;
                }
            }

            if (elementFound != null)
            {
                matchedElements.Clear();
                matchedElements.Add(elementFound);
            }
            else
            {
                Debug.Assert(false, "Reach here means either the left/right are not null, but cannot found element");
            }

            return matchedElements;

        errorCase:
            matchedElements.Clear();

        return matchedElements;
        }

        private static List<AutomationElement> TopWindowTitleLocator(UIATestObject testObject, List<AutomationElement> elements)
        {
            _Logger.WriteDebug("TopWindowTitleLocator enter");
            if (testObject.ControlType != ControlType.Window)
            {
                return elements;
            }

            string title = testObject.HasProperty(UIAControlKeys.Title) ? testObject.Properties[UIAControlKeys.Title] : null;
            if (string.IsNullOrEmpty(title)) return elements;

            _Logger.WriteDebug("title is " + title);

            List<AutomationElement> matchedElements = new List<AutomationElement>();

            int index = testObject.Index;
            int matchIndex = 0;
            foreach (AutomationElement element in elements)
            {

                string caption = element.Current.Name;
                if (Utility.StringSimiliarityCompare(title, caption, 50))
                {
                    if (index < 0 || index == matchIndex)
                    {
                        _Logger.WriteDebug("matched caption is " + caption);
                        matchedElements.Add(element);
                    }
                    else
                    {
                        matchIndex++;
                    }
                }
            }
            return matchedElements;
        }



        private static List<AutomationElement> FindInMatchedCollection(ITestObject testObject, List<AutomationElement> elements)
        {
            int matchIndex = 0;

            List<AutomationElement> matchedElements = new List<AutomationElement>();

            //check all of the element which match the type condition and attached text
            foreach (AutomationElement element in elements)
            {
                int matchCount = 0, propertyCount = 0;
                //LeftRightCheck(selfCondition, leftElement, rightElement, ref sameCount, element);


                // object match 80% will be return.
                if (testObject.HasProperty(ControlKeys.Text))
                {
                    propertyCount++;
                    string aName = "";
                    try
                    {
                        aName = ((TextPattern)element.GetCurrentPattern(TextPattern.Pattern)).DocumentRange.GetText(-1);
                    }
                    catch { }

                    try
                    {
                        aName = ((ValuePattern)element.GetCurrentPattern(ValuePattern.Pattern)).Current.Value;
                    }
                    catch { }

                    try
                    {

                        aName = (string)element.GetCurrentPropertyValue(LegacyIAccessiblePattern.ValueProperty);
                    }
                    catch { }

                    if (aName == null || aName == "")
                    {
                        aName = element.Current.Name;
                    }
                    if (aName != "")
                    {
                        if (Utility.StringSimiliarityCompare(testObject[ControlKeys.Text], aName, 80))
                        {
                            matchCount++;
                        }
                    }
                }

                //find object by attached text;
                if (testObject.HasProperty(UIAControlKeys.AttachedText))
                {
                    propertyCount++;
                    AutomationElement attachedElement = (AutomationElement)element.Current.LabeledBy;
                    if (attachedElement != null)
                    {
                        string labelName = attachedElement.Current.Name;
                        if (testObject.Properties[UIAControlKeys.AttachedText] == labelName)
                        {
                            matchCount++;
                        }
                    }
                }

                // if count number bigger than 2, will consider object as match
                if (propertyCount == 0 || (matchCount / propertyCount) >= 0.5)
                {
                    if (testObject.Index == -1 || testObject.Index == matchIndex)
                    {
                        matchedElements.Add(element);
                    }
                    else
                    {
                        matchIndex++;
                    }
                }
            }

            return matchedElements;
        }

    }
}
