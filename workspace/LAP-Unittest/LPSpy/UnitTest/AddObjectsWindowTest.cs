using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LPReplayCore.UnitTest;
using LPReplayCore.UIA;
using LPReplayCore.Model;
using System.Windows.Automation;
using LPCommon;
using System.IO;
using System.Diagnostics;
using System.Drawing;

#if TEST
namespace LPSpy.UnitTest
{
    [TestClass]
    public class AddObjectsWindowTest
    {
        [ClassInitialize]
        public static void Init(TestContext context)
        {
            TestUtility.LaunchQTCalculator();
        }

        [TestMethod]
        public void AddObjectsWindow_CaptureTempSnapshot()
        {
            ObjectDescriptor descriptor = ObjectDescriptor.FromJson(@"
            {
                ""ntype"": ""uia"",
                ""nname"": ""Window: Calculator"",
                ""identifyProperties"": {
                    ""type"": ""Window"",
                    ""className"": ""QWidget"",
                    ""title"": ""Calculator""
                }
            }");
            UIATestObject testObject = (UIATestObject)descriptor.GetObject();
            AutomationElement element = testObject.AutomationElement;

            string elementInfo = UIAUtility.DumpAutomationElement(element);

            Debug.WriteLine(elementInfo);

            AddObjectsWindow window = new AddObjectsWindow(null);

            string token;

            SnapshotHelper.CaptureTempSnapshot(element, out token);

            CacheHandler handler = new CacheHandler(AppEnvironment.CurrentDirectory);

            string targetPath = Path.Combine(Environment.CurrentDirectory, "calculator.png");
            handler.MoveCachedItemToFile(token, targetPath);
            Assert.IsTrue(File.Exists(targetPath));

            Image image = Image.FromFile(targetPath);

            Assert.AreEqual(302 + 20, image.Size.Width);
            Assert.AreEqual(317 + 20, image.Size.Height);
        }
    }
}
#endif