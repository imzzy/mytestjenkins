using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using LPReplayCore.UIA;

namespace LPSpy
{
    [TestClass]
    public class VirtualControlEditWindowTest
    {
        VirtualTestObject[] _virtualControls;
        [TestInitialize]
        public void Init()
        {
            _virtualControls = initVirtualControls();
        }

        [TestMethod]
        public void VirtualControlEdit_AddRemove()
        {
            VirtualControlEditWindow editWindow = new VirtualControlEditWindow();

            editWindow.VirtualControls = _virtualControls;

            Assert.AreEqual(4, editWindow.VirtualControls.Length);

            editWindow.AddControl(new VirtualTestObject("Terminated", new Rectangle(17, 358, 191, 75)));
            editWindow.AddControl(new VirtualTestObject("OnLeave", new Rectangle(13, 443, 196, 80)));
                
            Assert.AreEqual(6, editWindow.VirtualControls.Length);
        }

        [TestMethod]
        public void VirtualControlEdit_xxx()
        {
            VirtualControlEditWindow editWindow = new VirtualControlEditWindow();
            editWindow.AddControl(new VirtualTestObject("Terminated", new Rectangle(17, 358, 191, 75)));
            editWindow.AddControl(new VirtualTestObject("OnLeave", new Rectangle(13, 443, 196, 80)));
                
        }


        private VirtualTestObject[] initVirtualControls()
        {
            VirtualTestObject[] controls = new VirtualTestObject[]
            { 
                new VirtualTestObject("all", new Rectangle(11, 16, 200, 84)),
                new VirtualTestObject("salary", new Rectangle(11, 102, 199, 74)),
                new VirtualTestObject("commission", new Rectangle(12, 185, 201, 80)),
                new VirtualTestObject("contract", new Rectangle(14, 275, 197, 74)),

            };
            return controls;
        }

    }
}
