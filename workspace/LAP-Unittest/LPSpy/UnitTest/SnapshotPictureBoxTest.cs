using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LPReplayCore.UIA;
using System.Drawing;
using LPCommon;
using LPReplayCore;
using System.IO;
using LPReplayCore.Model;

#if TEST

namespace LPSpy.UnitTest
{
    [TestClass]
    public class SnapshotPictureBoxTest
    {

        int margin = Snapshot.Margin;

        [ClassInitialize]
        public static void Init(TestContext context)
        {
            CreatePicture();
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            File.Delete("..\\SnapshotPictureBoxTest.png");
        }

        private static void CreatePicture()
        {
            Snapshot.CaptureImageToFile(new Rectangle(0, 0, 100, 200), "SnapshotPictureBoxTest.png");
        }

        [TestMethod]
        public void SnapshotPictureBox_TestObject_UIA()
        {

            UIATestObject testObject = new UIATestObject();

            TestObjectNurse nurseObject = new TestObjectNurse(testObject);
            nurseObject.ImageFile = "..\\SnapshotPictureBoxTest.png";

            SnapshotPictureBox pictureBox = new SnapshotPictureBox();

            pictureBox.TestObject = nurseObject;

            Assert.AreEqual(new Rectangle(0 + margin, 0 + margin, 100 - 2 * margin, 200 - 2 * margin)
                , pictureBox.BorderRect);

            
            UIATestObject testObject_Null_Image = new UIATestObject();

            TestObjectNurse nurseObject_Null_Image = new TestObjectNurse(testObject_Null_Image);
            
            pictureBox.TestObject = nurseObject_Null_Image;

            Assert.IsNull(pictureBox.Image);

        }


        [TestMethod]
        public void SnapshotPictureBox_TestObject_Virtual()
        {

            UIATestObject testObject = new UIATestObject();

            TestObjectNurse nurseObject = new TestObjectNurse(testObject);
            nurseObject.ImageFile = "..\\SnapshotPictureBoxTest.png";

            VirtualTestObject virtualTestObject = new VirtualTestObject("virtual1", new Rectangle(10, 20, 30, 40) );
            TestObjectNurse virtualNurseObject = nurseObject.AddChild(virtualTestObject) as TestObjectNurse;

            SnapshotPictureBox pictureBox = new SnapshotPictureBox();

            pictureBox.TestObject = virtualNurseObject;

            Rectangle[] virtualRects = pictureBox.VirtualRectangles;

            Assert.AreEqual(1, virtualRects.Length);
            Assert.AreEqual(new Rectangle(10, 20, 30, 40), virtualRects[0]);


            VirtualTestObject virtualTestObject2 = new VirtualTestObject("virtual2", new Rectangle(100, 200, 300, 400));
            TestObjectNurse virtualNurseObject2 = nurseObject.AddChild(virtualTestObject2) as TestObjectNurse;

            pictureBox.TestObject = virtualNurseObject2;

            virtualRects = pictureBox.VirtualRectangles;

            Assert.AreEqual(1, virtualRects.Length);
            Assert.AreEqual(new Rectangle(100, 200, 300, 400), virtualRects[0]);


            pictureBox.TestObject = nurseObject;

            virtualRects = pictureBox.VirtualRectangles;

            Assert.AreEqual(0, virtualRects.Length); 
            Assert.AreEqual(new Rectangle(0 + margin, 0 + margin, 100 - 2 * margin, 200 - 2 * margin)
                 , pictureBox.BorderRect);
        }
    }
}

#endif