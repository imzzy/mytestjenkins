using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LPReplayCore.Model;
using System.Diagnostics;
using System.Collections.Generic;
using LPReplayCore.Interfaces;
using LPReplayCore.UnitTest;
using LPReplayCore.UIA;

#if TEST

namespace LPReplayCore
{
    //check AppModel is loaded correctly
    [TestClass]
    public class AppModelLoadTest
    {
        static AppModel _calcModel;

        [ClassInitialize]
        public static void InializeModel(TestContext context)
        {
            string appModelPath = "CalcAppModel.json";
            _calcModel = AppModelManager.Load(appModelPath);

            //context model
            AppModel.Initialize("UnitTestObjectModel1.json");

        }

        [TestMethod]
        public void AppModel_ObjectCountTest()
        {
            Assert.AreEqual(11, _calcModel.AllItems.Count);
        }

        [TestMethod]
        public void AppModel_FindAddTest()
        {
            string value = "+";
            ITestObject testObject = _calcModel.FindFirst(obj => obj.ControlName == value);
            Assert.AreNotEqual(null, testObject);
            Assert.AreEqual("Add", testObject.Description);
        }

        [TestMethod]
        public void AppModel_FindClearButtonTest()
        {
            string key = "clear";
            ITestObject clearButton = _calcModel[key];

            Assert.AreNotEqual(null, clearButton);
            Assert.AreEqual("Clear button", clearButton.Description);
            Assert.AreEqual("Clear", clearButton.ControlName);
        }

        [TestMethod]
        public void AppModel_AllItems()
        {
            List<ITestObject> descriptors = _calcModel.AllItems;

            List<string> result = descriptors.ConvertAll<string>(delegate(ITestObject descriptor) {
                return descriptor.NodeName;
            });
            string output = string.Join("\n", result.ToArray());
            Assert.AreEqual(11, descriptors.Count, output);
        }

        [TestMethod]
        public void AppModel_AllNames()
        {
            List<ITestObject> descriptors = _calcModel.AllItems;

            List<string> result = descriptors.ConvertAll<string>(delegate(ITestObject descriptor)
            {
                return descriptor.NodeName;
            });

            string output = string.Join("\n", result.ToArray());
             
            Assert.AreEqual(11, descriptors.Count, output);
        }

        [TestMethod]
        public void AppModel_CheckHierarchy()
        {
            ITestObject windowObject = _calcModel.Items[0];
            Assert.AreEqual("calculator", windowObject.NodeName);
            Assert.AreEqual("Calculator", windowObject["name"]);
            Assert.AreEqual(null, windowObject.Parent);
            Assert.AreEqual(10, TestUtility.Count(windowObject.Children));

            //find the button in the hierarchy
            string key = "name";
            string value = "+";
            ITestObject btnAddObject = windowObject.Find(key, value);

            Assert.AreEqual("plus", btnAddObject.NodeName);
            Assert.AreEqual("Add", btnAddObject.Description);
            Assert.AreEqual(windowObject, btnAddObject.Parent);

        }

        [TestMethod]
        public void AppModel_Add()
        {
            AppModel model = new AppModel();
            ITestObject obj = new UIATestObject();
            model.Add(obj);
        }

        [TestMethod]
        public void AppModel_GetTestObject()
        {
            ITestObject testObject = AppModel.Current.GetTestObject("LAP (Running) - Microsoft Visual Studio");

            Assert.AreNotEqual(null, testObject);
        }

        [TestMethod]
        public void AppModel_Load()
        {
            AppModel model = AppModelManager.Load("UnitTestObjectModel1.json");
            ITestObject obj = new UIATestObject();
            model.Add(obj);
            Assert.IsTrue(true);
        }
    }
}

#endif