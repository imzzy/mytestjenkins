using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
using System.Drawing;
using LPReplayCore.UIA;
using LPReplayCore;

#if TEST

namespace LPSpy
{
    [TestClass]
    public class TreeNodeHelperTest
    {
        /*
         *             
         *  Window = 0,
            Button = 1,
            CheckBox = 2,s
	        Calendar = 3,
	        ComboBox = 4,
            Dialog = 5,
            Edit = 6,
            Editor = 7,
            Image = 8,
            Label = 9,
            Link = 10,
            List = 11,
            Menu = 12,
            RadioButton = 13,
            ScrollBar = 14,
            Tab = 15,
            ToolBar = 15,
            Tree = 17,
            Custom = 18
         */
        [TestMethod]
        public void TreeNodeHelper_FixTreeImage()
        {
            TreeNode node = new TreeNode();
            TreeNodeHelper.FixTreeNodeImage(node, "Window");
            Assert.AreEqual(0, node.ImageIndex);

            TreeNodeHelper.FixTreeNodeImage(node, "ScrollBar");
            Assert.AreEqual(14, node.ImageIndex);

            TreeNodeHelper.FixTreeNodeImage(node, "SomethingElse");
            Assert.AreEqual((int)TreeNodeHelper.TreeNodeImage.Custom, node.ImageIndex);
        }

        
        [TestMethod]
        public void TreeNodeHelper_MergeVirtualControlsToTree()
        {
            TreeView treeView = new TreeView();

            UIATestObject parentTestObject = new UIATestObject();
            TestObjectNurse parentNurse = new TestObjectNurse(parentTestObject);

            parentNurse.AddChild(new VirtualTestObject("all", new Rectangle(11, 16, 200, 84)));
            parentNurse.AddChild(new VirtualTestObject("salary", new Rectangle(11, 102, 199, 74)));
            parentNurse.AddChild(new UIATestObject());

            Assert.AreEqual(3, parentNurse.Children.Count);

            VirtualTestObject[] controls = initVirtualControls(); // in total 6 controls.
            bool ret = TreeNodeHelper.MergeVirtualControlsToTree(controls, parentNurse.TreeNode);

            Assert.IsTrue(ret);

            Assert.AreEqual(7, parentNurse.Children.Count);

            Assert.IsTrue(parentNurse[0].TestObject is UIATestObject);
        }

        [TestMethod]
        public void TreeNodeHelper_MergeVirtualControlsToTree_TheSame()
        {
            TreeView treeView = new TreeView();

            UIATestObject parentTestObject = new UIATestObject();
            TestObjectNurse parentNurse = new TestObjectNurse(parentTestObject);

            parentNurse.AddChild(new VirtualTestObject("all", new Rectangle(11, 16, 200, 84)));
            parentNurse.AddChild(new VirtualTestObject("salary", new Rectangle(11, 102, 199, 74)));

            Assert.AreEqual(2, parentNurse.Children.Count);

            VirtualTestObject[] controls = new VirtualTestObject[]
                {
                    new VirtualTestObject("all", new Rectangle(11, 16, 200, 84)),
                    new VirtualTestObject("salary", new Rectangle(11, 102, 199, 74))
                }; // in total 6 controls.
            bool ret = TreeNodeHelper.MergeVirtualControlsToTree(controls, parentNurse.TreeNode);

            Assert.IsFalse(ret);

        }


        private VirtualTestObject[] initVirtualControls()
        {
            VirtualTestObject[] controls = new VirtualTestObject[]
            { 
                new VirtualTestObject("all", new Rectangle(11, 16, 200, 84)),
                new VirtualTestObject("salary", new Rectangle(11, 102, 199, 74)),
                new VirtualTestObject("commission", new Rectangle(12, 185, 201, 80)),
                new VirtualTestObject("contract", new Rectangle(14, 275, 197, 74)),
                new VirtualTestObject("Terminated", new Rectangle(17, 358, 191, 75)),
                new VirtualTestObject("OnLeave", new Rectangle(13, 443, 196, 80))

            };
            return controls;

        }
    }
}

#endif