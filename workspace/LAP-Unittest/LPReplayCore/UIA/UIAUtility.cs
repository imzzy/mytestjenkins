using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using LPReplayCore.Model;
using LPReplayCore.Common;
using System.Threading;
using LPReplayCore.Interfaces;
using System.Windows;
using System.Diagnostics;
using LPCommon;
using System.Runtime.InteropServices;

namespace LPReplayCore.UIA
{
    public static partial class UIAUtility
    {
        static ILogger _Logger = LogFactory.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);//"LPReplayCore.UIA.UIAFinder");

        public static UIATestObject CreateTestObject(ObjectDescriptor descriptor, ModelLoadLevel loadLevel)
        {
            UIATestObject uia = new UIATestObject(descriptor);

            //if (loadLevel == null)
            //{
                //TODO: load additional details into context objects
                //1.Load cached properties
                //2.Load recorded images
            //}

            return uia;
        }

        public static AutomationElement GetRootWindow(string windowName)
        {
            AutomationElement windowElement = AutomationElement.RootElement.FindFirst(TreeScope.Children,
                    new PropertyCondition(AutomationElement.NameProperty, windowName));

            return windowElement;
        }
        
        public static AutomationElement GetRootWindow(AutomationElement element)
        {
            Condition windowCondition = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Window);

            TreeWalker walker = new TreeWalker(windowCondition);

            AutomationElement parentWindow = null, tempWindow = element;

            while (tempWindow != null)
            {
                parentWindow = tempWindow;
                tempWindow = walker.GetParent(parentWindow);
            }


            AutomationElementCollection rootWindows = AutomationElement.RootElement.FindAll(TreeScope.Children, windowCondition);

            foreach (AutomationElement window in rootWindows)
            {
                if (parentWindow.Current.NativeWindowHandle == window.Current.NativeWindowHandle)
                    return window;
            }
            return null;
        }

        /// <summary>
        /// compare 2 test object, whether they have the same identifying properties
        /// </summary>
        /// <param name="to1"></param>
        /// <param name="to2"></param>
        /// <returns></returns>
        public static bool AreEqual(ITestObject to1, ITestObject to2)
        {
            if (to1.Properties.Count != to2.Properties.Count) return false;
            foreach (KeyValuePair<string, string> pair in to1.Properties)
            {
                if (!to2.Properties.ContainsKey(pair.Key)) return false;

                if (to2.Properties[pair.Key] != pair.Value)
                    return false;
            }
            return true;
        }

        public static AutomationElement GetPreviousElement(AutomationElement ae)
        {
            return TreeWalker.ControlViewWalker.GetPreviousSibling(ae);
        }

        public static AutomationElement GetNextElement(AutomationElement ae)
        {
            return TreeWalker.ControlViewWalker.GetNextSibling(ae);
        }

        public static AutomationElement GetParentElement(AutomationElement ae)
        {
            if (IsRootElement(ae))
                return null;
            return TreeWalker.ControlViewWalker.GetParent(ae);
        }

        public static bool AreEqual(AutomationElement first, AutomationElement second)
        {
            if (first == null && second == null)
                return true;

            if (first == null || second == null)
                return false;

            if (first.GetRuntimeId().SequenceEqual(second.GetRuntimeId()))
                return true;
            else
                return false;
        }


        public static AutomationElementCollection FindDescendantElements(AutomationElement element, Condition condition)
        {
            _Logger.WriteLog(LogTypeEnum.Debug, () =>
                {
                    return "FindDescendantElements: finding descendants of \r\n" + DumpAutomationElement(element);
                });

            AutomationElementCollection collection = element.FindAll(TreeScope.Subtree, condition);

            _Logger.WriteDebug(string.Format("FindDescendantElements: Find {0} objects", collection.Count));

            return collection;
        }



        public static bool AreEqual3(AutomationElement rightExpected, AutomationElement rightElement)
        {
            if (rightElement != null)
            {
                if (rightExpected.Current.Name == rightElement.Current.Name &&
                    rightExpected.Current.NativeWindowHandle == rightElement.Current.NativeWindowHandle &&
                    rightExpected.Current.ControlType == rightElement.Current.ControlType
                    )
                {
                    return true;
                }
            }
            return false;
        }

        public static bool AreEqual2(AutomationElement rightExpected, AutomationElement rightElement)
        {
            if (rightElement != null)
            {
                if (rightExpected.Current.Name == rightElement.Current.Name ||
                    rightExpected.Current.NativeWindowHandle == rightElement.Current.NativeWindowHandle ||
                    rightExpected.Current.AutomationId == rightElement.Current.AutomationId
                    )
                {
                    return true;
                }
            }
            return false;
        }


        public static bool CheckObjectExist(AutomationElement element)
        {
            _Logger.WriteInfo("CheckObjectExist: Check if the objest is exist in the Object list.");

            bool found = false;

            if (element == null)
            {
                found = false;
            }
            else
            {
                Rect value = element.Current.BoundingRectangle;
                found = !value.IsEmpty;
            }
            return found;
        }

        
        public static string DumpTestObject(ITestObject testObject)
        {
            UIATestObject to = (UIATestObject)testObject;

            ObjectDescriptor od = to.GetDescriptor();

            ObjectDescriptor descriptor = (ObjectDescriptor)od.Clone();

            string result = JsonUtil.SerializeObject(descriptor, true, true);

            return result;
        }


        //https://weblog.west-wind.com/posts/2012/Aug/30/Using-JSONNET-for-dynamic-JSON-parsing
        public static string DumpAutomationElement(AutomationElement element)
        {
            dynamic json = new Newtonsoft.Json.Linq.JObject();

            if (element == null) goto Exit;

            json.Name = element.Current.Name;
            json.Type = element.Current.ControlType.ControlTypeToString();
            json.Class = element.Current.ClassName;
            json.AutomationId = element.Current.AutomationId;
            json.AccessKey = element.Current.AccessKey;

        Exit:
            return json.ToString();
        }


        public static void InitProperties(string nodeName, AutomationElement element, UIATestObject testObject)
        {
            testObject.AutomationElement = element;
            testObject.ControlType = element.Current.ControlType;
            testObject.NodeName = nodeName;

            string automationId = element.Current.AutomationId;
            if (!string.IsNullOrEmpty(automationId))
            {
                testObject.AddProperty(UIAControlKeys.AutomationId, automationId);
            }

            string className = element.Current.ClassName;
            if (!string.IsNullOrEmpty(className))
            {
                testObject.AddProperty(UIAControlKeys.ClassName, className);
            }

            //"" is different from null. 
            if (element.Current.Name != null)
            {
                if (testObject.ControlType == ControlType.Window)
                {
                    testObject.Properties[UIAControlKeys.Title] = element.Current.Name;
                }
                else
                {
                    testObject.ControlName = element.Current.Name;
                }
            }

            string name = UIAUtility.GetName(element);

            if (!String.IsNullOrEmpty(name))
            {
                if (testObject.ControlType == ControlType.Hyperlink)
                {
                    testObject.Properties[UIAControlKeys.AttachedText] = name;
                }
                else
                {
                    testObject.Properties[ControlKeys.Text] = name;
                }
            }

            if (!String.IsNullOrEmpty(name = element.Current.HelpText))
            {
                testObject.Properties[UIAControlKeys.HelpText] = name;
            }

            //TODO determine the right logic to create index, currently it takes too long
            /*
             * 
            UIATestObject parentTestObject = (UIATestObject) testObject.Parent;

            AutomationElement parentElement;

            if (parentTestObject == null)
            {
                parentElement = AutomationElement.RootElement;
            }
            else
            {
                parentElement = parentTestObject.AutomationElement;
            }

            AutomationElementCollection matchedElement;
            if (testObject.ControlType == ControlType.Custom)
            {
                matchedElement = parentElement.FindAll(TreeScope.Descendants, TreeWalker.ControlViewWalker.Condition);
            }
            else
            {
                Condition c = new PropertyCondition(AutomationElement.ControlTypeProperty, element.Current.ControlType);
                matchedElement = parentElement.FindAll(TreeScope.Descendants, c);
            }

            int objectIndex = -1;
            for (int i = 0; i < matchedElement.Count; i++)
            {
                if (UIAUtility.AreEqual(matchedElement[i], element))
                {
                    objectIndex = i;
                    break;
                }
            }
            if (objectIndex != -1)
            {
                testObject.Properties[ControlKeys.Index] = objectIndex.ToString();
            }
             * */
        }


        private static bool IsRootElement(AutomationElement element)
        {
            AutomationElement rootElement = AutomationElement.RootElement;
            if (element.Current.NativeWindowHandle == rootElement.Current.NativeWindowHandle
                    && rootElement.Current.Name == element.Current.Name)
                return true;
            else
                return false;
        }

        public static bool CollapseMenuItem(AutomationElement element)
        {
            if (ControlType.MenuItem != element.Current.ControlType)
                return false;
            object expandCollapsePatternObject = null;
            ExpandCollapsePattern expandCollapsePattern = null;

            if (element.TryGetCurrentPattern(ExpandCollapsePattern.Pattern, out expandCollapsePatternObject))
            {
                Console.WriteLine("ExpandMenuItem TryGetCachedPattern Current {0}", element.Current.Name);
                expandCollapsePattern = expandCollapsePatternObject as ExpandCollapsePattern;
            }
            else if (element.TryGetCachedPattern(ExpandCollapsePattern.Pattern, out expandCollapsePatternObject))
            {
                Console.WriteLine("ExpandMenuItem TryGetCurrentPattern Cache {0}", element.Cached.Name);
                expandCollapsePattern = expandCollapsePatternObject as ExpandCollapsePattern;
            }

            if (null != expandCollapsePattern && ExpandCollapseState.LeafNode != expandCollapsePattern.Current.ExpandCollapseState)
            {
                try
                {
                    if (expandCollapsePattern.Current.ExpandCollapseState == ExpandCollapseState.Expanded ||
                                expandCollapsePattern.Current.ExpandCollapseState == ExpandCollapseState.PartiallyExpanded)
                    {
                        expandCollapsePattern.Collapse();
                        Thread.Sleep(500);
                    }
                    return true;
                }
                // Object doesn't support the ExpandCollapsePattern control pattern. 
                catch (InvalidOperationException)
                {
                    Console.WriteLine("FindRelevantElements InvalidOperationException {0}", element.Current.Name);
                }
            }
            return false;
        }

        public static bool ExpandMenuItem(AutomationElement element)
        {
            if (ControlType.MenuItem != element.Cached.ControlType)
                return false;
            bool isKeyboardFocusable = false;
            object expandCollapsePatternObject = null;
            ExpandCollapsePattern expandCollapsePattern = null;
            try
            {
                isKeyboardFocusable = (bool)element.GetCurrentPropertyValue(AutomationElement.IsKeyboardFocusableProperty, true);
            }
            // Object doesn't support the ExpandCollapsePattern control pattern. 
            catch (Exception e)
            {
                Console.WriteLine("{1} {0} element is not focusable - the element may be not visible", element.Current.Name, e.Message);  
            }

            try
            {
                if (element.TryGetCurrentPattern(ExpandCollapsePattern.Pattern, out expandCollapsePatternObject))
                {
                    expandCollapsePattern = expandCollapsePatternObject as ExpandCollapsePattern;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("{1} {0} element doesn't have ExpandCollapse pattern", element.Current.Name, e.Message);
                return false;
            }
            

            if (null != expandCollapsePattern && ExpandCollapseState.LeafNode != expandCollapsePattern.Current.ExpandCollapseState)
            {
                try
                {
                    if (expandCollapsePattern.Current.ExpandCollapseState == ExpandCollapseState.Collapsed ||
                                expandCollapsePattern.Current.ExpandCollapseState == ExpandCollapseState.PartiallyExpanded)
                    {

                        if (isKeyboardFocusable)
                            element.SetFocus();
                    //    expandCollapsePattern.Expand();
                        if (element.Current.FrameworkId.Equals("WPF"))
                        {
                            expandCollapsePattern.Expand();
                        }
                        else
                        {
                            AutomationElement aeParent = UIAUtility.GetParentElement(element);
                            if (aeParent.Current.ControlType != ControlType.MenuBar)
                                expandCollapsePattern.Expand();
                        }
                        Thread.Sleep(500);
                    }
                    return true;
                }
                // Object doesn't support the ExpandCollapsePattern control pattern. 
                catch (InvalidOperationException)
                {
                    Console.WriteLine("Expand menu item InvalidOperationException {0}", element.Current.Name);
                }
            }
            else
            {
                Console.WriteLine("{0} element is leaf node", element.Current.Name);             
            }
            return false;
        }

        public static List<AutomationElement> GetAutomationAllChildrenElements(AutomationElement element)
        {
            List<AutomationElement> elementsLine = new List<AutomationElement>();
            AutomationElement child = TreeWalker.ControlViewWalker.GetFirstChild(element);
            if (child == null) return elementsLine;
            AutomationElement Sibling = child;
            elementsLine.Add(Sibling);
            while (null != (Sibling = TreeWalker.ControlViewWalker.GetNextSibling(Sibling)))
                elementsLine.Add(Sibling);
            return elementsLine;
        }

        public static AutomationElement FromPoint(Point point)
        {
            AutomationElement ae = AutomationElement.FromPoint(point);
            return ae;
        }

        public static List<AutomationElement> GetAutomationElementsLine(AutomationElement element)
        {
            AutomationElement parent = TreeWalker.ControlViewWalker.GetParent(element);

            List<AutomationElement> elementsLine = new List<AutomationElement>();
            elementsLine.Add(element);

            while (parent != null)
            {
                if (!IsRootElement(parent))
                {
                    elementsLine.Add(parent);
                }
                parent = TreeWalker.ControlViewWalker.GetParent(parent);
            }
            elementsLine.Reverse();

            return elementsLine;
        }

        public static string GetName(AutomationElement element)
        {
            string name = null;

            object textObject;
            element.TryGetCurrentPattern(TextPattern.Pattern, out textObject);

            if (textObject != null)
            {
                name = ((TextPattern)textObject).DocumentRange.GetText(-1);
            }

            if (name != null) return name;

            object valueObject;
            element.TryGetCurrentPattern(ValuePattern.Pattern, out valueObject);
            if (valueObject != null)
            {
                name = ((ValuePattern)valueObject).Current.Value;
            }

            if (name != null) return name;

            name = (string)element.GetCurrentPropertyValue(LegacyIAccessiblePattern.ValueProperty);

            return name;
        }

        public static UIATestObject CreateTestObject(AutomationElement element, string nodeName = null)
        {
            UIATestObject testObject = new UIATestObject();

            testObject.AutomationElement = element;
            testObject.ControlType = element.Current.ControlType;

            string automationId = element.Current.AutomationId;
            if (!string.IsNullOrEmpty(automationId))
            {
                testObject.AddProperty(UIAControlKeys.AutomationId, automationId);
            }

            string className = element.Current.ClassName;
            if (!string.IsNullOrEmpty(className))
            {
                testObject.AddProperty(UIAControlKeys.ClassName, className);
            }

            //"" is different from null. 
            if (element.Current.Name != null)
            {
                if (testObject.ControlType == ControlType.Window)
                {
                    testObject.Properties[UIAControlKeys.Title] = element.Current.Name;
                }
                else
                {
                    testObject.ControlName = element.Current.Name;
                }
            }

            string name = UIAUtility.GetName(element);

            if (!String.IsNullOrEmpty(name))
            {
                if (testObject.ControlType == ControlType.Hyperlink)
                {
                    testObject.Properties[UIAControlKeys.AttachedText] = name;
                }
                else
                {
                    testObject.Properties[ControlKeys.Text] = name;
                }
            }

            if (!String.IsNullOrEmpty(name = element.Current.HelpText))
            {
                testObject.Properties[UIAControlKeys.HelpText] = name;
            }

            if (!string.IsNullOrEmpty(nodeName))
            {
                testObject.NodeName = nodeName;
            }
            return testObject;
        }
    }
}
