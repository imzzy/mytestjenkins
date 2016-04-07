using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LPReplayCore.UIA;
using LPReplayCore.Model;
using System.Diagnostics;
using System.Collections.Generic;
using System.Windows.Automation;
using System.Windows;

#if TEST

namespace LPReplayCore.UnitTest
{
    [TestClass]
    public class UIAUtilityTest
    {
        [ClassInitialize]
        public void ClassInitialize()
        {
            TestUtility.LaunchQTCalculator();
        }

        [TestMethod]
        public void ButtonToAutomationElementTest()
        {
            ObjectDescriptor descriptor = ObjectDescriptor.FromJson(
                @"
                 {
			        ntype: ""uia"",
			        nname: ""button1"",
			        ""identifyProperties"": {
                        ""name"": ""1""
                    }
			        description: ""button""
		        }");

            UIATestObject testObject = UIATestObject.ToTestObject(descriptor);
            testObject.TryInvoke();
        }

        [TestMethod]
        public void UIAUtility_GetElementLine()
        {
            Point point;
            point = new Point(1, 1);
            AutomationElement clickedElement = AutomationElement.FromPoint(point);
            List<AutomationElement> elements = UIAUtility.GetAutomationElementsLine(clickedElement);
            //TODO check elements
            //Assert.AreEqual(elements);
        }
    }
}

#endif