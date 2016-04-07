using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
using LPUIAObjects;
using LPReplayCore.Interfaces;
using LPReplayCore;
using LPCommon;
using System.IO;
using System.Drawing;
using LPReplayCore.Model;

namespace LPSpy.UnitTest
{
    [TestClass]
    public class ModelFileHandlerTest
    {

        [ClassInitialize]
        public static void Init(TestContext context)
        {
            CreatePicture();
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            string imagePath = Path.Combine(AppEnvironment.CurrentDirectory, "TestObjectNurseTest.png");
            File.Delete(imagePath);

            string imagePath1 = Path.Combine(AppEnvironment.CurrentDirectory, "TestObjectNurseTest1.png");
            File.Delete(imagePath1);
        }

        private static void CreatePicture()
        {
            string imagePath = Path.Combine(AppEnvironment.CurrentDirectory, "TestObjectNurseTest.png");
            Snapshot.CaptureImageToFile(new Rectangle(0, 0, 100, 200), imagePath);
            string imagePath1 = Path.Combine(AppEnvironment.CurrentDirectory, "TestObjectNurseTest1.png");
            Snapshot.CaptureImageToFile(new Rectangle(0, 0, 100, 200), imagePath1);
        }

        [TestMethod]
        public void ModelFileHandler_LoadJsonData()
        {
            TreeView treeView = new TreeView();

            TestObjectNurse rootNurse = TestObjectNurse.FromTree(treeView);

            ModelFileHandler.LoadModelFile("ObjectModel2.json", rootNurse);

            Assert.AreEqual(1, rootNurse.Children.Count, "only one root node");


            Assert.AreEqual(1, rootNurse.Children.Count);

            TestObjectNurse parentNurse = rootNurse[0];
            ITestObject testObject = parentNurse.TestObject;

            Assert.AreEqual(1, parentNurse.Children.Count);
            Assert.AreEqual("Window", testObject.ControlTypeString);

            TestObjectNurse childNurse = parentNurse[0];

            ITestObject testObject2 = childNurse.TestObject;

            Assert.AreEqual("Document", testObject2.ControlTypeString, "only one child node");
        }

        [TestMethod]
        public void ModelFileHandler_SaveJson()
        {
            TreeView treeView = new TreeView();

            TestObjectNurse rootNurse = TestObjectNurse.FromTree(treeView);

            AppModel model = ModelFileHandler.LoadModelFile("UnitTestObjectModel1.json", rootNurse);

            ModelFileHandler.SaveToModelFile(rootNurse, "ObjectModel2.json");
        }

        [TestMethod]
        public void ModelFileHandler_SaveToModelFile()
        {
            TreeView treeView = new TreeView();

            TestObjectNurse rootNurse = TestObjectNurse.FromTree(treeView);

            AppModel model = ModelFileHandler.LoadModelFile("UnitTestObjectModel1.json", rootNurse);


            TestObjectNurse nurseNode = (TestObjectNurse)rootNurse.FindRecursive(DescriptorKeys.NodeName, "Test Explorer");

            string imageFilePath = AppEnvironment.GetModelResourceFilePath("TestObjectNurseTest.png");

            CacheHandler.EnsureFileDirectoryExists(imageFilePath);

            Snapshot.CaptureImageToFile(new Rectangle(0, 0, 100, 200), imageFilePath);

            Assert.IsTrue(File.Exists(imageFilePath));

            nurseNode.ImageFile = "TestObjectNurseTest.png";

            //remove from root
            nurseNode.Remove();

            AppEnvironment.DumpRecyclingBin(rootNurse);
        }
    }
}
