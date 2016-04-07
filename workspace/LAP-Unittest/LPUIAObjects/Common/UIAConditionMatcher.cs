using LPReplayCore.Common;
using LPReplayCore.Interfaces;
using LPReplayCore.Model;
using LPReplayCore.UIA;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using LPReplayCore;

namespace LPUIAObjects
{
    public class UIAConditionMatcher
    {
        static Dictionary<string, Func<ITestObject, AutomationElement, bool?>> matcher;


        static UIAConditionMatcher()
        {
            matcher = new Dictionary<string, Func<ITestObject, AutomationElement, bool?>>
            {
                {UIAControlKeys.Name, (to, element) => to.ControlName == element.Current.Name},
                {UIAControlKeys.Type, (to, element) => to.ControlTypeString == element.Current.ControlType.ControlTypeToString()},
                {UIAControlKeys.Text, UIAConditionMatcher.Text_Validator},
                {UIAControlKeys.Title, UIAConditionMatcher.Title_Validator},
                {UIAControlKeys.HWnd, (to, element) => to.Properties[UIAControlKeys.HWnd] == element.Current.NativeWindowHandle.ToString()},
                {UIAControlKeys.ProcessId, (to, element) => to.Properties[UIAControlKeys.ProcessId] == element.Current.ProcessId.ToString()},
                {UIAControlKeys.Url, UIAConditionMatcher.Hyperlink_Validator},
                {UIAControlKeys.AttachedText, UIAConditionMatcher.LabelBy_Validator},
                {UIAControlKeys.HelpText, (to, element) => to.Properties[UIAControlKeys.HelpText] == element.Current.HelpText},
                {UIAControlKeys.AutomationId, (to, element) => to.AutomationId == element.Current.AutomationId},
            };
        }

        public bool Match(ITestObject to, AutomationElement element)
        {
            try
            {
                if (element.Current.BoundingRectangle.IsEmpty)
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

            foreach (KeyValuePair<string, string> pair in to.Properties)
            {
                string key = pair.Key;
                string value = pair.Value;

                Func<ITestObject, AutomationElement, bool?> func;
                matcher.TryGetValue(key, out func);

                bool? ret = func(to, element);

                if (ret == false) return false;
            }

            if (false == LocateByRelation(to, element))
            {
                return false;
            }

            return true;
        }

        public bool? LocateByRelation(ITestObject to, AutomationElement element)
        {
            IRelation relation = to.Relation;

            if (relation == null) return null;

            ITestObject leftTO = relation.Left;
            ITestObject rightTO = relation.Right;

            if (leftTO == null && rightTO == null)
            {
                return null;
            }

            if (leftTO != null)
            {
                AutomationElement leftElement = UIAUtility.GetPreviousElement(element);
                if (!Match(leftTO, leftElement))
                {
                    return false;
                }
            }
            if (rightTO != null)
            {
                AutomationElement rightElement = UIAUtility.GetNextElement(element);
                if (!Match(rightTO, rightElement))
                {
                    return false;
                }
            }
            return true;
        }

        private static bool? Hyperlink_Validator(ITestObject to, AutomationElement element)
        {

            if (to.ControlTypeString == ControlType.Hyperlink.ControlTypeToString())
            {
                string name = UIAUtility.GetName(element);

                if (!String.IsNullOrEmpty(name))
                {
                    return to.Properties[ControlKeys.Url] == name;
                }
            }

            return null;
        }

        private static bool? String_Validator(ITestObject to, AutomationElement element, string key)
        {
            string name = UIAUtility.GetName(element);

            if (name != null)
            {
                return to.Properties[key] == name;
            }

            return null;
        }

        private static bool? Text_Validator(ITestObject to, AutomationElement element)
        {
            string name = UIAUtility.GetName(element);

            if (name != null)
            {
                return to.Properties[ControlKeys.Text] == name;
            }

            return null;
        }

        private static bool? Title_Validator(ITestObject to, AutomationElement element)
        {
            string name = UIAUtility.GetName(element);

            if (name != null)
            {
                return to.Properties[ControlKeys.Title] == element.Current.Name;
            }

            return null;
        }

        private static bool? LabelBy_Validator(ITestObject to, AutomationElement element)
        {
            if (element.Current.LabeledBy != null)
            {
                if (!string.IsNullOrEmpty(element.Current.LabeledBy.Current.Name))
                {
                    string attachedText = to.Properties[UIAControlKeys.AttachedText];
                    return (attachedText == element.Current.LabeledBy.Current.Name);
                }
            }
            return false;
        }

    }
}
