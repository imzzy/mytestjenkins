using LPReplayCore.Common;
using LPReplayCore.Interfaces;
using LPReplayCore.UIA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace LPUIAObjects.Common
{
    class UIAElementFinder
    {

        static Dictionary<string, Func<UIACondition, AutomationElement, bool?>> matcher;

        static UIAElementFinder()
        {
            matcher = new Dictionary<string, Func<UIACondition, AutomationElement, bool?>>()
            {
               
            };
        }

        public AutomationElement Find(UIACondition selfCondition)
        {
           
            AutomationElementCollection matchedElements =
                ConditionLocator(selfCondition);

            if (matchedElements.Count == 0)
            {
                Logger.WriteWarning("Can not find child in the parent container:" + selfCondition.ControlName);
                return null;
            }
            else
            {
                Logger.WriteDebug("Objects Count:" + matchedElements.Count);
            }

                        //if using index only, return the object
            if (selfCondition.IsIndexOnly)
            {
                return IndexLocator(selfCondition, matchedElements);
            }

            AutomationElement element;

            bool? result = LeftRightLocator(selfCondition, out element); 
            if (result != null) 
            {
                return element;
            }

            // if window, just check the caption, 60% match will be recognized.
            if (selfCondition.IsWindow)
            {
                element = TopWindowLocator(selfCondition, matchedElements);

                return element;
            }

            return FindInMatchedCollection(selfCondition, matchedElements);
        }

        private AutomationElement TopWindowLocator(UIACondition selfCondition, AutomationElementCollection matchedElements)
        {
            int matchIndex = 0;

            foreach (AutomationElement element in matchedElements)
            {
                string caption = element.Current.Name;
                if (Utility.StringSimiliarityCompare(selfCondition.Text, caption, 50))
                {
                    if (selfCondition.Index == matchIndex)
                    {
                        Highlight.HighlightThread(element);
                        selfCondition.AutomationElement = element;
                        return selfCondition.AutomationElement;
                    }
                    else
                    {
                        matchIndex++;
                    }
                }
            }
            return null;
        }

        private AutomationElement FindInMatchedCollection(UIACondition selfCondition, AutomationElementCollection matchedElements)
        {
            int matchIndex = 0;

            //check all of the element which match the type condition and attached text
            foreach (AutomationElement element in matchedElements)
            {
                int sameCount = 0;
                //LeftRightCheck(selfCondition, leftElement, rightElement, ref sameCount, element);


                // object match 80% will be return.
                if (selfCondition.Text != "")
                {
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
                        if (Utility.StringSimiliarityCompare(selfCondition.Text, aName, 80))
                        {
                            sameCount++;
                        }
                    }
                }

                //find object by attached text;
                if (selfCondition.AttachedText != "")
                {
                    AutomationElement attachedElement = (AutomationElement)element.Current.LabeledBy;
                    if (attachedElement != null)
                    {
                        string labelName = attachedElement.Current.Name;
                        if (selfCondition.AttachedText == labelName)
                        {
                            sameCount++;
                        }
                    }
                }

                // if count number bigger than 2, will return the object
                if ((sameCount / selfCondition.ConditionCount) >= 0.5)
                {
                    if (selfCondition.Index == matchIndex)
                    {
                        Highlight.HighlightThread(element);
                        selfCondition.AutomationElement = element;
                        return selfCondition.AutomationElement;
                    }
                    else
                    {
                        matchIndex++;
                    }
                }
            }
        }


        private static void Retry3Times(Func<bool> method)
        {
            int matchtime = 3;

            bool allmatch = method();

            while (!allmatch && matchtime > 0)
            {
                Logger.WriteLog("Object no found, try again, time:" + matchtime);
                Thread.Sleep(1000);
                allmatch = method();
                matchtime--;
            }
        }

        public AutomationElementCollection ConditionLocator(UIACondition selfCondition)
        {
            AutomationElementCollection matchedElements = null;
            Logger.WriteLog("Start to find the UIAObject by condition");

            if (selfCondition.Condition != null)
            {
                Retry3Times(() =>
                {
                    matchedElements = UIAUtility.FindDescendantElements(selfCondition.ParentCondition.AutomationElement, selfCondition.Condition);
                    return matchedElements.Count > 0;
                });
            }
            else
            {
                Retry3Times(() =>
                {
                    matchedElements = UIAUtility.FindDescendantElements(selfCondition.ParentCondition.AutomationElement, TreeWalker.ControlViewWalker.Condition);
                    return matchedElements.Count > 0;
                });
            }

            return matchedElements;
        }

        public AutomationElement IndexLocator(UIACondition selfCondition, AutomationElementCollection matchedElements)
        {

            if (matchedElements.Count - 1 < selfCondition.Index)
            {
                return null;
            }
            else
            {
                Highlight.HighlightThread(matchedElements[selfCondition.Index]);
                selfCondition.AutomationElement = matchedElements[selfCondition.Index];
                return selfCondition.AutomationElement;
            }
            
        }

        public bool? LeftRightLocator(UIACondition selfCondition, out AutomationElement element)
        {
            AutomationElement leftElement = null, rightElement = null;
            //check if the left or right condtion exist            
            //get the left and right element            
            if (selfCondition.Right != "")
            {
                ITestObject rightTO;
                
                if (selfCondition.Right.IndexOf(DescriptionString.LeftRightQtpString) >= 0)
                {
                    //format Right==something
                    rightTO = UIAHelper.ConvertStringToTestObject(selfCondition.Right); 
                }
                else
                {
                    //selfCondition.Right is the name, then use the name to extract descriptor
                    rightTO = UIAJsonPersister.LoadData(selfCondition.Right, selfCondition.ParentCondition.TestObject);
                }

                UIACondition rightCondition = new UIACondition(rightTO);

                rightCondition.ParentCondition = selfCondition.ParentCondition;
                rightElement = Find(rightCondition);
            }

            if (selfCondition.Left != "")
            {
                ITestObject leftDescriptor = null;
                if (selfCondition.Left.IndexOf(DescriptionString.LeftRightQtpString) >= 0)
                {
                    leftDescriptor = UIAHelper.ConvertStringToTestObject(selfCondition.Left);
                }
                else
                {
                    leftDescriptor = UIAJsonPersister.LoadData(selfCondition.Left, selfCondition.ParentCondition.TestObject);
                }
                UIACondition leftCondition = new UIACondition(leftDescriptor);
                leftCondition.ParentCondition = selfCondition.ParentCondition;
                leftElement = Find(leftCondition);
            }

            int sameCount = 0;
            bool? found = LeftRightCheck(selfCondition, leftElement, rightElement, element);

            return found;
        }

        
        private static bool? LeftRightCheck(UIACondition selfCondition, AutomationElement leftExpected, 
            AutomationElement rightExpected, AutomationElement element)
        {
            // if the same count is big than 0, will return the object.
            bool? found = null;

            if (rightExpected != null)
            {
                AutomationElement rightElement = UIAUtility.GetNextElement(element);
                if (UIAUtility.AreEqual2(rightExpected, rightElement))
                    found = true;
                else
                    return false;
            }

            if (leftExpected != null)
            {
                AutomationElement leftElement = UIAUtility.GetPreviousElement(element);
                if (UIAUtility.AreEqual2(leftExpected, leftElement))
                    found = true;
                else
                    return false;
            }

            return found;
        }

    }
}
