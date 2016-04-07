using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LPReplayCore.Model;
using LPReplayCore.UIA;

namespace LPReplayCore.UnitTest
{
    [TestClass]
    public class AppDescriptorTest
    {
        [TestMethod]
        public void AppDescriptor_GetObject()
        {
            AppDescriptor appDescriptor = new AppDescriptor();
            appDescriptor.ProcessName = "TestProcess.exe";
            appDescriptor.Children.Add(new ObjectDescriptor() { Type = NodeType.UIAControl });
            appDescriptor.Children.Add(new ObjectDescriptor() { Type = NodeType.UIAControl });

            AppModel appModel = appDescriptor.GetObject();

            Assert.AreEqual("TestProcess.exe", appModel.ProcessName);

            Assert.AreEqual(2, appModel.AllItems.Count);
            
        }

        [TestMethod]
        public void AppDescriptor_ctor_AppModel()
        {
            AppModel model = new AppModel();
            model.Add(new UIATestObject());
            model.Add(new UIATestObject());

            model.ProcessName = "TestProcess.exe";
            AppDescriptor descriptor = new AppDescriptor(model);

            Assert.AreEqual("TestProcess.exe", descriptor.ProcessName);

            Assert.AreEqual(2, descriptor.Children.Count);
        }
    }
}
