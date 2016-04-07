using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using System.Windows;
using LPReplayCore.Model;
using LPReplayCore.UIA;
using System.Windows.Automation;

#if TEST
namespace LPReplayCore.UnitTest
{
    [TestClass]
    public class UIAHighlightTest
    {
        ObjectDescriptor descriptor = ObjectDescriptor.FromJson(@"{
                  ""ntype"": ""uia"",
                  ""identifyProperties"": {
                    ""type"": ""Window"",
                    ""className"": ""QWidget"",
                    ""name"": ""Calculator""
                  }
            }");

        [ClassInitialize]
        public static void Init(TestContext context)
        {
            TestUtility.LaunchQTCalculator();
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            TestUtility.ExitQTCalculator();
        }

        [TestMethod]
        public void UIAHighlight_HighlightRectangle()
        {
            UIAHighlight.HighlightRect(new Rect(0, 0, 100, 200), Color.Green);
        }

        [TestMethod]
        public void UIAHighlight_HighlightVirtualControl()
        {
            UIAHighlight.HighlightRect(new Rect(0, 0, 100, 200), Color.Green);
        }

        [TestMethod]
        public void UIAHighlight_SearchandHighlight_UIA()
        {
            
            UIATestObject testObject = descriptor.GetObject() as UIATestObject;

            bool result = UIAHighlight.SearchAndHighlight(testObject);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void UIAHighlight_SearchandHighlight_ProgramRestarted()
        {
            UIATestObject testObject = descriptor.GetObject() as UIATestObject;

            AutomationElement firstElement = testObject.AutomationElement;

            //close and start another calculator
            TestUtility.ExitQTCalculator();
            TestUtility.LaunchQTCalculator();

            //this should also succeed
            bool result = UIAHighlight.SearchAndHighlight(testObject);

            Assert.IsTrue(result);
        }


        [TestMethod]
        public void UIAHighlight_SearchandHighlight_Virtual()
        {
            UIATestObject testObject = descriptor.GetObject() as UIATestObject;

            VirtualTestObject virtualButton7 = new VirtualTestObject("button7", new Rect(76, 139, 34, 34));
            VirtualTestObject virtualButton4 = new VirtualTestObject("button4", new Rect(74, 177, 36, 40));

            testObject.AddChild(virtualButton7);
            testObject.AddChild(virtualButton4);


            //this should also succeed
            bool result = UIAHighlight.SearchAndHighlight(virtualButton7);
            Assert.IsTrue(result);
            result = UIAHighlight.SearchAndHighlight(virtualButton4);
            Assert.IsTrue(result);
        }


    }
}
#endif