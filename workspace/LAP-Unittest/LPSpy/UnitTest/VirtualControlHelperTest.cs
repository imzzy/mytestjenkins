using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LPReplayCore.UIA;
using LPReplayCore.Interfaces;
using LPReplayCore;

namespace LPSpy.UnitTest
{
    [TestClass]
    public class VirtualControlHelperTest
    {
        [TestMethod]
        public void VirtualControlHelper_GetVirtualControls()
        {
            UIATestObject testObject = new UIATestObject();
            testObject.AddChild(new VirtualTestObject());
            testObject.AddChild(new VirtualTestObject());
            testObject.AddChild(new VirtualTestObject());
            testObject.AddChild(new VirtualTestObject());
            testObject.AddChild(new UIATestObject());

            Assert.AreEqual(5, testObject.Children.Count);


            VirtualTestObject[] virtualObjects = VirtualControlHelper.GetVirtualControls(testObject);

            Assert.AreEqual(4, virtualObjects.Length, "Should only return the direct virtual test objects");
        }


        [TestMethod]
        public void VirtualControlHelper_MergeVirtualControls()
        {
            UIATestObject testObject = new UIATestObject();
            testObject.AddChild(new VirtualTestObject());
            testObject.AddChild(new VirtualTestObject());
            testObject.AddChild(new VirtualTestObject());
            testObject.AddChild(new VirtualTestObject());
            testObject.AddChild(new UIATestObject());
        }

        [TestMethod]
        public void VirtualControlHelper_LoadVirtualControls()
        {
            string appModelPath = "UnitTestVirtualControl.json";
            AppModel virtualModel = AppModelManager.Load(appModelPath);

            Assert.AreEqual(1, virtualModel.Items.Count);

            ITestObject testObject = virtualModel.Items[0];

            Assert.AreEqual(3, testObject.Children.Count);

            VirtualTestObject[] controls = VirtualControlHelper.GetVirtualControls(testObject);

            VirtualControlHelper.DumpVirtualControls(controls);
        }
    }
}
