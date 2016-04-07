using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Automation;
using LPUIAObjects;
using System.Reflection;
using System.Diagnostics;
using System.Collections.Generic;
using LPReplayCore.Common;
using System.Windows.Forms;
using LPReplayCore;
using LPReplayCore.UIA;

#if TEST
namespace LPSpy.UnitTest
{
    [TestClass]
    public class SpyMainWindowTest
    {
        internal SpyMainWindow window;

        [TestInitialize]
        public void Init()
        {
            window = new SpyMainWindow();

        }

        //[TestMethod] 
        public void LPSpy_MinWindow()
        {
            window.ShowDialog();
        }

        //[TestMethod]
        /*
        public void LPSpy_MenuEditWindowClick()
        {
            object sender = null;
            EventArgs args = new EventArgs();

            TreeView treeView = window.TreeObjects;

            TreeNode virtualNode = populateTree(treeView, "VirtualNode1").TreeNode;

            window.TreeObjects.SelectedNode = virtualNode;

            window.mnuEditVirtualControls_Click(sender, args);

        }*/

        public TestObjectNurse populateTree(TreeView treeView, string nodeToSelect)
        {
            TestObjectNurse rootNurse = TestObjectNurse.FromTree(treeView);
            TestObjectNurse parentNurse = new TestObjectNurse(new UIATestObject() { NodeName = "RootNode1" }) { ImageFile = "test_snapshot.png"};
            TestObjectNurse virtualNurse1 = new TestObjectNurse(new VirtualTestObject() { NodeName = "VirtualNode1" });
            TestObjectNurse virtualNurse2 = new TestObjectNurse(new VirtualTestObject() { NodeName = "VirtualNode2" });

            rootNurse.AddChild(parentNurse); 
            parentNurse.AddChildren(virtualNurse1, virtualNurse2);

            switch (nodeToSelect)
            {
                case "RootNode1":
                    return parentNurse;
                case "VirtualNode1":
                    return virtualNurse1;
                case "VirtualNode2":
                    return virtualNurse2;
            }

            return null;
        }
    }
}

#endif