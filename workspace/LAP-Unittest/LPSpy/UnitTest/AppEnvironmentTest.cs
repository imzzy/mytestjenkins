using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using LPReplayCore.UIA;
using LPReplayCore;
using LPCommon;
using System.Windows.Forms;
using System.Drawing;

#if TEST
namespace LPSpy.UnitTest
{
    [TestClass]
    public class AppEnvironmentTest
    {
        [TestInitialize]
        public void TestInit()
        {
            AppEnvironment.CurrentModelPath = Path.Combine(Environment.CurrentDirectory, "ObjectModel1.json");
        }

        [TestMethod]
        public void AppEnvironment_ModelFile()
        {
            Assert.AreEqual("ObjectModel1.json", AppEnvironment.ModelFileName);
        }

        [TestMethod]
        public void AppEnvironment_ModelResourceFolder()
        {
            Assert.AreEqual(Environment.CurrentDirectory + "\\ObjectModel1_files", AppEnvironment.ModelResourceFolder);
        }

        [TestMethod]
        public void AppEnvironment_CurrentDirectory()
        {
            Assert.AreEqual(Environment.CurrentDirectory, AppEnvironment.CurrentDirectory);
        }


        private static void CreatePicture(AppModelFile modelFile)
        {
            Snapshot.CaptureImageToFile(new Rectangle(0, 0, 100, 200), 
                modelFile.GetResourceFilePath("TestObjectNurseTest.png"));

            Snapshot.CaptureImageToFile(new Rectangle(0, 0, 100, 200), 
                modelFile.GetResourceFilePath("TestObjectNurseTest1.png"));
        }

        [TestMethod]
        public void AppEnvironment_DumpRecyclingBin()
        {
            string modelFilePath = "TempModelFile.json";
            try
            {
                AppEnvironment.CurrentModelFile = AppModelFile.Create(modelFilePath);

                //init test objects
                UIATestObject _parentTestObject = new UIATestObject();
                UIATestObject _childTestObject = new UIATestObject();
                UIATestObject childTestObject2 = new UIATestObject();
                VirtualTestObject _grandChildTestObject = new VirtualTestObject();

                CreatePicture(AppEnvironment.CurrentModelFile);


                //initialize nurse objects
                TestObjectNurse parentNurse = new TestObjectNurse(_parentTestObject);

                TestObjectNurse childNurse = parentNurse.AddChild(_childTestObject) as TestObjectNurse;
                TestObjectNurse childNurse2 = parentNurse.AddChild(childTestObject2) as TestObjectNurse;
                TestObjectNurse grandChildNurse = childNurse.AddChild(_grandChildTestObject) as TestObjectNurse;

                string imagePath1 = AppEnvironment.GetModelResourceFilePath("TestObjectNurseTest.png");
                string imagePath2 = AppEnvironment.GetModelResourceFilePath("TestObjectNurseTest1.png");

                Assert.IsTrue(File.Exists(imagePath1));
                Assert.IsTrue(File.Exists(imagePath2));

                childNurse2.ImageFile = "TestObjectNurseTest.png";
                grandChildNurse.ImageFile = "TestObjectNurseTest1.png";

                parentNurse.RemoveChild(childNurse);
                Assert.IsTrue(File.Exists(imagePath1));
                parentNurse.RemoveChild(childNurse2);
                Assert.IsTrue(File.Exists(imagePath2));

                AppEnvironment.DumpRecyclingBin(parentNurse);

                Assert.IsFalse(File.Exists(imagePath1));
                Assert.IsFalse(File.Exists(imagePath2));
            }
            finally
            {

                File.Delete("TestObjectNurseTest.png");
                File.Delete("TestObjectNurseTest1.png");
            }
            
        }
    }
}
#endif