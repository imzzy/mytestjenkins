using System;
using System.Windows.Automation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LPReplayCore.UIA;
using LPReplayCore.Model;
using LPReplayCore.Common;
using LPReplayCore.Interfaces;

#if TEST
namespace LPReplayCore.UnitTest
{
    [TestClass]
    public class UIATestObjectTest
    {
        [TestMethod]
        public void UIATestObject_ControlTypeAssign()
        {
            UIATestObject testObject = new UIATestObject();
            Assert.AreEqual(0, testObject.Properties.Count);
            testObject.ControlType = ControlType.Window;

            Assert.AreEqual("Window", testObject.ControlTypeString);

            Assert.AreEqual(1, testObject.Properties.Count);

        }

        [TestMethod]
        public void UIATestObject_ControlTypeInit()
        {
            UIATestObject testObject = new UIATestObject();

            testObject.AddProperty(ControlKeys.Type, ControlType.Slider.ControlTypeToString());

            Assert.AreEqual(1, testObject.Properties.Count);
            Assert.AreEqual(ControlType.Slider, testObject.ControlType);
        }

        public class MockContextClass
        {
            public string ContextName;
        }

        public class MockContextClass2
        {
            public string ContextName;
        }

        [TestMethod]
        public void UIATestObject_GetContext()
        {
            UIATestObject testObject = new UIATestObject();
            testObject.SetContext(new MockContextClass() { ContextName = "MockContext1" });

            MockContextClass context = testObject.GetContext<MockContextClass>();
            Assert.AreEqual("MockContext1", context.ContextName);
        }

        [TestMethod]
        public void UIATestObject_FindRecursive()
        {
            AppModel.Initialize("UnitTestObjectModel1.json");
            UIATestObject parentObject = (UIATestObject)AppModel.Current.GetTestObject("LAP (Running) - Microsoft Visual Studio");

            UIATestObject testObject = (UIATestObject)parentObject.FindRecursive(DescriptorKeys.NodeName, "Search");

            Assert.IsNotNull(testObject, "Should find the test object in the model");

            testObject = (UIATestObject)parentObject.FindRecursive(DescriptorKeys.NodeName, "NotExistObject");
            Assert.IsNull(testObject, "Should not the test object with a random name");

        }

        [TestMethod]
        public void UIATestObject_CachedProperties()
        {
            AppModel model = AppModelManager.Load("UnitTestObjectModel1.json", ModelLoadLevel.Full);
            ITestObject testObject = model.FindFirst(o => o.NodeName == "CachedPropertyTestNode");

            CachedPropertyGroup cachedObject = testObject.GetContext<CachedPropertyGroup>();

            Assert.AreNotEqual(null, cachedObject);

            Assert.AreEqual("asdfasfdasdfasdf.png", cachedObject.Properties["imageFile"]);

        }

        [TestMethod]
        public void UIATestObject_NoCachedProperties()
        {
            AppModel model = AppModelManager.Load("UnitTestObjectModel1.json", ModelLoadLevel.ReplayOnly);
            ITestObject testObject = model.FindFirst(o => o.NodeName == "CachedPropertyTestNode");

            CachedPropertyGroup cachedObject = testObject.GetContext<CachedPropertyGroup>();

            Assert.AreEqual(null, cachedObject);
        }

        [TestMethod]
        public void UIATestObject_SetContext()
        {
            UIATestObject testObject = new UIATestObject();
            testObject.SetContext(new MockContextClass() { ContextName = "MockContext1" });
            testObject.SetContext(new MockContextClass2() { ContextName = "MockContext2" });

            MockContextClass context = testObject.GetContext<MockContextClass>();
            MockContextClass2 context2 = testObject.GetContext<MockContextClass2>();
            Assert.AreEqual("MockContext1", context.ContextName);
            Assert.AreEqual("MockContext2", context2.ContextName);
        }
    }
}

#endif