using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LPReplayCore.UIA;
using LPReplayCore.UnitTest;
using System.Windows.Automation;
using LPUIAObjects.Common;

#if TEST
namespace LPUIAObjects.UnitTest
{
    [TestClass]
    public class UIAConditionMatcherTest
    {
        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            TestUtility.LaunchWindowsCalc();
        }

        [TestMethod]
        public void UIAConditionMatcher_Match_Positive()
        {
            UIATestObject to = new UIATestObject();
            to.ControlName = "Clear";

            UIATestObject rootWindow = new UIATestObject();
            rootWindow.ControlName = "Calculator";
            
            UIATestObject targetTestObject = new UIATestObject();
            targetTestObject.ControlName = "Clear";

            rootWindow.AddChild(targetTestObject);

            AutomationElement element = targetTestObject.AutomationElement;

            Assert.IsNotNull(element, "Target element is not found, has Calculator.exe process launched?");

            UIAConditionMatcher matcher = new UIAConditionMatcher();

            //positive match
            bool matched = matcher.Match(to, element);

            Assert.AreEqual(true, matched);

            to.ControlName = "something else";

            matched = matcher.Match(to, element);

            Assert.AreEqual(false, matched);

        }

        [ClassCleanup]
        public static void Cleanup()
        {
            TestUtility.ExitWindowCalculator();
        }

    }
}

#endif