using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using LPReplayCore.Common;
using System.Diagnostics;
using LPReplayCore.Model;

#if TEST

namespace LPReplayCore.UnitTest
{
    using PropertyEntry = System.Collections.Generic.Dictionary<string, string>;
    using LPReplayCore.UIA;
    using System.Windows.Automation;
    using System.IO;
    using LPReplayCore.Interfaces;

    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class JsonSerializerTest
    {
        public JsonSerializerTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void JsonDeserializeModelTest()
        {
            string filePath = "CalcAppModel.json";
            string content = Utility.ReadFileContent(filePath);
            AppDescriptor descriptor = JsonUtil.DeserializeObject<AppDescriptor>(content);

            Assert.AreEqual(descriptor.Children.Count, 1);
            Assert.AreEqual(TestUtility.Count(descriptor.Children[0].Children), 10);
            Assert.AreEqual(descriptor.ProcessName, "calculator.exe");
        }


        [TestMethod]
        public void JsonSerializeModelTest()
        {
            string filePath = "CalcAppModel.json";
            string content = Utility.ReadFileContent(filePath);
            AppModel model = JsonUtil.DeserializeObject<AppModel>(content);

            string serializedContent = JsonUtil.SerializeObject(model, true, true);

            Utility.WriteFileContent("CalcAppModel1.json", serializedContent);
            //TODO validate the content
        }

        [TestMethod]
        public void AppModelManager_LoadReplayOnly()
        {
            AppModel model;
            //default is replay only
            model = AppModelManager.Load("CalcAppModel.json");
            ITestObject resultObject = model.FindFirst(DescriptorKeys.NodeName, "result");
            Assert.AreNotEqual(null, resultObject);

            Assert.IsNotNull(model.ModelFile);

            Assert.IsTrue(model.ModelFile.FilePath.EndsWith("CalcAppModel.json", StringComparison.InvariantCultureIgnoreCase));
            //TODO: do some more validation on the content
        }

        [TestMethod]
        public void AppModelManager_LoadFileMissing()
        {
            AppModel model;
            try
            {
                model = AppModelManager.Load("SomeFileDoesntExist.json");

                Assert.IsNull(model.ModelFile);

            }
            catch (FileNotFoundException ex)
            {
                Assert.IsTrue(true);
                return;
            }
            Assert.Fail("Should throw FileNotFoundException if file doesn't exist");
        }


        [TestMethod]
        public void AppModelManager_Save()
        {
            string filePath = "CalcAppModel.json";
            string content = Utility.ReadFileContent(filePath);
            AppModel model = JsonUtil.DeserializeObject<AppModel>(content);

            AppModelManager.Save(model, "CalcAppModel2.json");

            Assert.IsTrue(model.ModelFile.FilePath.EndsWith("CalcAppModel2.json"));
            //TODO validate the content
        }

        [TestMethod]
        public void AppModelManager_HierarchySave()
        {
            UIATestObject d1 = new UIATestObject()
            {
                NodeName = "rootWindow1",
                ControlName = "rootWindow1_controlName",
                ControlType = ControlType.Window,
                Description = "this is root window"
            };
            UIATestObject d2 = new UIATestObject()
            {
                ControlName = "Panel1",
                ControlType = ControlType.TitleBar
            };
            UIATestObject d3 = new UIATestObject()
            {
                ControlName = "Button",
                ControlType = ControlType.Tree
            };

            /*                    {
                        {"name", "Button1"},
                        {"index", "0"},
                        {"helpText", "Some help Text"}
                    };

            d3.AddProperty("name", "Button1");
            d3.AddProperty("index", "0");
            d3.AddProperty("helpText", "Some help Text");
            */
            UIATestObject d4 = new UIATestObject()
            {
                ControlType = ControlType.Text
            };
            d4.AddProperty("id", "Text1");
            /*
            d4.SetItem<UIAPropertyItem>(new UIAPropertyItem()
            {
                Properties = new PropertyEntry()
                    {
                        {"id", "Text1"}
                    }
            });*/

            d1.AddChild(d2);
            d2.AddChild(d4);

            d2.AddChild(d3);
            AppModel model = new AppModel()
            {
                ProcessName = "calc.exe"
            };
            model.Add(d1);

            AppModelManager.Save(model, "CalcAppModel3.json");
            
            TestUtility.LaunchNotepad(Path.Combine(System.Environment.CurrentDirectory, "CalcAppModel3.json"));
            //TODO validate the content
        }
    }
}

#endif