using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using LPReplayCore;

#if TEST
namespace LPSpy.UnitTest
{
    /// <summary>
    /// Summary description for OptionWindowTest
    /// </summary>
    [TestClass]
    public class OptionWindowTest
    {
        public OptionWindowTest()
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
        public void OptionWindow_LoadSetting()
        {
            ReplayCoreSettings.HighlightColor = Color.Yellow;

            SpySettings.CaptureSnapshots = false;

            OptionWindow window = new OptionWindow();

            Assert.AreEqual(Color.Yellow, window.highlightColorSelector.ColorSelected);

            Assert.AreEqual(SpySettings.CaptureSnapshots, window.chkCaptureScreenshots.Checked);

            //Change the setting
            window.chkCaptureScreenshots.Checked = true;

            Assert.IsTrue(SpySettings.CaptureSnapshots);
        }
    }
}
#endif