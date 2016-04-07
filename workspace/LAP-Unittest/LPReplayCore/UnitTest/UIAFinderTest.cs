using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LPReplayCore.Model;
using LPReplayCore.UIA;
using System.Windows.Automation;
using System.Collections.Generic;
using LPReplayCore.Common;
using Newtonsoft.Json;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using LPReplayCore.Interfaces;

#if TEST
namespace LPReplayCore.UnitTest
{
    [TestClass]
    public class UIAFinderTest
    {
        [ClassInitialize]
        public static void Init(TestContext context)
        {
            TestUtility.LaunchWindowsCalc();
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            TestUtility.ExitWindowCalculator();
        }

        [TestMethod]
        public void UIAFinder_Identify1()
        {
            ObjectDescriptor parentDescriptor = ObjectDescriptor.FromJson(@"
                {""ntype"": ""uia"", identifyProperties: {name: ""Calculator""}}
                ");
            /*
            ObjectDescriptor parentDescriptor = ObjectDescriptor.FromJson(@"
                {
                  ""ntype"": ""uia"",
                  ""nname"": ""LAP (Running) - Microsoft Visual Studio"",
                  ""description"": null,
                  ""identifyProperties"": {
                    ""type"": ""Window"",
                    ""title"": ""LAP (Running) - Microsoft Visual Studio""
                  }
                }
            ");

           ObjectDescriptor childDescriptor = ObjectDescriptor.FromJson(@"
                {
                  ""ntype"": ""uia"",
                  ""nname"": ""ToolBarDockTop"",
                  ""description"": null,
                  ""identifyProperties"": {
                    ""type"": ""Pane"",
                    ""name"": ""ToolBarDockTop""
                  }
                }
            ");*/
            ObjectDescriptor childDescriptor = ObjectDescriptor.FromJson(@"
                {ntype:""uia"",identifyProperties: {name: ""1""}}
                ", parentDescriptor);

           parentDescriptor.Children.Add(childDescriptor);

           UIATestObject parentTestObject = (UIATestObject)parentDescriptor.GetObject();
           UIATestObject testObject = (UIATestObject) parentTestObject.Children[0];

           List<AutomationElement> elements = UIAFinder.FindAll(parentTestObject);
           TestUtility.DumpAutomationElements(elements);

           Assert.AreEqual(1, elements.Count, "only 1 parent element");

           elements = UIAFinder.FindAll(testObject);
           TestUtility.DumpAutomationElements(elements);

           Assert.AreEqual(1, elements.Count, "only 1 child element");
        }

        [TestMethod]
        public void JsonTest()
        {
            string jsonString = UIAUtility.DumpAutomationElement(null);

            Debug.WriteLine(jsonString);
        }

    }
}
#endif
