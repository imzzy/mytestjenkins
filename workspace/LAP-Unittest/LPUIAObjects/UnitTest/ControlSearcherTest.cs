using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Automation;
using LPReplayCore.Model;
using LPReplayCore.Interfaces;
using LPReplayCore.UIA;
using LPReplayCore;

#if TEST

namespace LPUIAObjects
{
    [TestClass]
    public class ControlSearcherTest
    {
        [TestMethod]
        public void ControlSearcher_GetTOTest()
        {
            string condition1 = "name := button1";
            string condition2 = "index := 0";

            ITestObject testObject = ControlSearcher.GetTO(null, ControlType.Button, condition1, condition2);

            Assert.AreEqual("Button", testObject.ControlTypeString);

            Assert.AreEqual(3, testObject.Properties.Count, UIAUtility.DumpTestObject(testObject));

            Assert.AreEqual("button1", testObject.Properties["name"]);
            Assert.AreEqual("0", testObject.Properties["index"]);

        }

        [TestMethod]
        public void ControlSearcher_GetCondition()
        {
            AppModel.Initialize("UnitTestObjectModel1.json");
            UIATestObject parentObject = (UIATestObject)AppModel.Current.GetTestObject("LAP (Running) - Microsoft Visual Studio");

            //UIATestObject testObject = (UIATestObject)parentObject.FindRecursive(DescriptorKeys.NodeName, "Search");

            Assert.IsNotNull(parentObject, "Should find the parent test object in the model");

            UIACondition parentCondition = UIACondition.GetCondition(parentObject);

            UIACondition childCondition = ControlSearcher.GetCondition(parentCondition, ControlType.Edit, "Search");

            Assert.IsNotNull(childCondition, "Should not be able to find the child condition");
        }
    }
}

#endif
