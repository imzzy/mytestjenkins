using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LPSpy.UIA;
using System.Windows.Automation;
using System.Diagnostics;
using LPReplayCore.Model;
using LPReplayCore.UIA;
using LPUIAObjects;
using LPReplayCore;
using LPReplayCore.UnitTest;

#if TEST

namespace LPSpy
{
    [TestClass]
    public class HighlightTest
    {

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            TestUtility.LaunchWindowsCalc();
        }

        [TestMethod]
        public void LPSpy_HighlightTest()
        {
            AutomationElement element = TestUtility.GetCalculatorButton1Element();
            Assert.AreNotEqual(null, element, "Cannot find the element to highlight");

            DateTime begin = DateTime.Now;
            UIAHighlight.HighlightAutomationElement(element);
            DateTime end = DateTime.Now;

            long tickCount = end.Ticks - begin.Ticks;

            double seconds = (double)tickCount / 10000000;

            Assert.IsTrue(seconds >= 1,
                string.Format("Should need at least 1 second to highlight the element, the actual time is {0}", seconds));
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            TestUtility.ExitQTCalculator();
        }
    }
}

#endif
