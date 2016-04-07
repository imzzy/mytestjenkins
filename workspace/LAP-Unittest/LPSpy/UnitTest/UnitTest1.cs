using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LPReplayCore.UnitTest;
using LPReplayCore.Model;
using LPReplayCore.UIA;
using System.Windows.Automation;
using System.Collections.Generic;
using LPReplayCore.Common;
using System.Diagnostics;

#if TEST
namespace LPSpy.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [ClassInitialize]
        public static void Init(TestContext context)
        {
            TestUtility.LaunchWindowsCalc();

        }
        /*
        public static AutomationElement ButtonToAutomationElement()
        {
            ObjectDescriptor descriptor = ObjectDescriptor.FromJson(
                @"
                 {
			        ntype: ""uia"",
			        nname: ""button1"",
			        ""identifyProperties"": {
                        ""name"": """"
                    }
		        }");

            UIATestObject testObject = UIATestObject.ToTestObject(descriptor);
            return testObject.AutomationElement;
        }*/

        Dictionary<string, string> GetProperties(AutomationElement element)
        {
            Dictionary<string, string> pairs = new Dictionary<string, string>();
            pairs.Add("Name", element.Current.Name);
            pairs.Add("ControlType", element.Current.ControlType.ControlTypeToString());
            pairs.Add("Class", element.Current.ClassName);
            pairs.Add("AutomationId", element.Current.AutomationId);
            pairs.Add("AccessKey", element.Current.AccessKey);
            return pairs;
        }

        [TestMethod]
        public void DumpProperties()
        {

            AutomationElement element = TestUtility.GetCalculatorButton1Element();
            Assert.AreNotEqual(null, element);

            Dictionary<string, string> pairs = GetProperties(element);

            foreach (KeyValuePair<string, string> pair in pairs)
            {
                Debug.WriteLine(string.Format("{0}:{1}", pair.Key, pair.Value));
            }

        }
    }
}

#endif