using LPCommon;
using LPReplayCore;
using LPReplayCore.Common;
using LPReplayCore.Interfaces;
using LPReplayCore.Model;
using LPReplayCore.UIA;
using LPUIAObjects.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;

namespace LPUIAObjects
{

    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("E574A6E7-9DA2-4D4B-9EBC-655337CEE7CA")]
    [ProgId("LAP.ControlSearcher")]
    [TypeLibType((short)2)]
    [Description("UI Automation Controls Searcher")]
    public class ControlSearcher
    {
        static ILogger _Logger = LogFactory.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);//"LPReplayCore.UIA.UIAFinder");

        public ControlSearcher()
        {
        }

        // return the current object condtion array to string;
        public static UIATestObject GetTO(ITestObject parentTestObject, ControlType controlType, params string[] conditionStrings)
        {
            UIATestObject testObject = new UIATestObject();

            testObject.ControlType = controlType;

            foreach (string condition in conditionStrings)
            {
                if (!string.IsNullOrEmpty(condition))
                {
                    string[] values = condition.Split(new string[] {DescriptionString.AssignOperator}, StringSplitOptions.None);
                    if (values.Length == 1)
                    {
                        string name = values[0];
                        if (parentTestObject == null)
                        {
                            return (UIATestObject)AppModel.Current.GetTestObject(name);
                        }
                        else
                        {
                            return (UIATestObject)parentTestObject.FindRecursive(DescriptorKeys.NodeName, name);
                        }
                    }
                    else
                        testObject.AddProperty(values[0].Trim(), values[1].Trim());
                }
            }

            return testObject;
        }

        public static UIACondition GetCondition(UIACondition parentCondition, ControlType controlType, params string[] conditionStrings)
        {
            UIATestObject testObject = GetTO(parentCondition.TestObject, controlType, conditionStrings);

            //UIACondition currentCondition = parentCondition.CheckUIAConditionExists(testObject, controlType);

            //TODO, handle more conditionStrings
            return UIACondition.GetCondition(testObject);

            //if (currentCondition != null)
            //    return currentCondition;

            //return GetCondition(parentCondition, testObject, controlType);
        }

        public static UIACondition GetCondition(UIACondition parentCondition, ITestObject testObject, ControlType controlType)
        {
            string controlName = "";
            UIATestObject beforeAnalyzeConditions = (UIATestObject)testObject;

            //TODO find the xmlname
            /*
            string[] splitcondtion = conditions.Split(new string[] { DescriptionString.PropertySplitString }, StringSplitOptions.None);

            foreach (string c in splitcondtion)
            {
                if (!c.Contains(DescriptionString.AssignOperator))
                {
                    xmlname = c;
                    break;
                }
            }*/

            if (controlName != "")
            {
                throw new NotImplementedException();
                //testObject = UIAJsonPersister.LoadData(controlName, parentCondition.TestObject);
            }

            UIACondition selfCondition = new UIACondition(beforeAnalyzeConditions, parentCondition);

            AutomationElement element = null;
            element = FindAutomationElement(selfCondition);

            if (element != null)
            {
                selfCondition.AutomationElement = element;
                selfCondition.ParentCondition.AddChild(selfCondition);
            }
            else
            {
                _Logger.WriteWarning("Object no found:" + controlType.ToString() + " ,Condition:" + testObject);
            }
            return selfCondition;
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

        public static AutomationElement FindAutomationElement(UIACondition selfCondition)
        {
           // no longer used
            /*
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
                rightElement = FindAutomationElement(rightCondition);
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
                leftElement = FindAutomationElement(leftCondition);
            }


            AutomationElementCollection matchedElements = null;
            Logger.WriteLog("Start to find the UIAObject by condition");

            if (selfCondition.Condition != null)
            {
                Retry3Times(() => {
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

            int matchIndex = 0;

            //check all of the element which match the type condition and attached text
            foreach (AutomationElement element in matchedElements)
            {
                // if window, just check the caption, 60% match will be recognized.
                if (selfCondition.IsWindow)
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
                // if object, will check the left and right element.
                else
                {
                    int sameCount = 0;
                    LeftRightCheck(selfCondition, leftElement, rightElement, ref sameCount, element);


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
             */
            return null;
        }

        private static AutomationElement LeftRightCheck(UIACondition selfCondition, AutomationElement leftExpected, 
            AutomationElement rightExpected, ref int sameCount, AutomationElement element)
        {
            // if the same count is big than 0, will return the object.
            sameCount = 0;
            if (rightExpected != null)
            {
                AutomationElement rightElement = UIAUtility.GetNextElement(element);
                if (UIAUtility.AreEqual2(rightExpected, rightElement)) sameCount++;
            }
            if (leftExpected != null)
            {
                AutomationElement leftElement = UIAUtility.GetPreviousElement(element);
                if (UIAUtility.AreEqual2(leftExpected, leftElement)) sameCount++;
            }

            return null;
        }

        public static void ThrowError(ErrorType errorType, string Message = "")
        {
            switch (errorType)
            {
                case ErrorType.ObjectNotExist:
                    throw new Exception("The runtime object does not exist");
                case ErrorType.ObjectIsReadOnly:
                    throw new Exception("Object is read-only");
                case ErrorType.ObjectIsOutOfScreen:
                    throw new Exception("The test object is not visible on the screen");
                case ErrorType.NotItemExistinthelist:
                    throw new Exception("Item in list or menu not found");
                case ErrorType.CannotPerformThisOperation:
                    throw new Exception("The operation can not be performed");
                case ErrorType.OutRange:
                    throw new Exception("Function argument out of range");
                default:
                    throw new Exception("Unknown exception:" + Message);
            }
        }

        public static void ReplayForWindow(AutomationElement ae)
        {

        }

        public static bool CheckObjectExist(UIACondition condition)
        {
            _Logger.WriteLog("Check if the objest is exist in the Object list.");

            bool found = false;
            for (int i = 0; i <= 3; i++)
            {
                if (found == true)
                    return found;
                else
                {
                    try
                    {
                        if (condition.AutomationElement == null)
                        {
                            found = false;
                        }
                        Rect value = condition.AutomationElement.Current.BoundingRectangle;
                        if (value.Right == 0 && value.Left == 0 && value.Top == 0 && value.Bottom == 0)
                            found = false;
                        else
                            found = true;
                    }
                    catch
                    {
                        found = false;
                    }
                }
                if (!found)
                {
                    Console.WriteLine("This object is not exist and find it again: " + condition.TestObject);
                    //search it again
                    UIACondition c = GetCondition(condition.ParentCondition, condition.TestObject, condition.ControlType);
                    if (c.AutomationElement != null)
                    {
                        condition = c;
                        found = true;
                    }
                }
            }
            return found;
        }
    }
}
