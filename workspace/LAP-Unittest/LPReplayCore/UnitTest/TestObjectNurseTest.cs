using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
using LPReplayCore.UIA;
using LPReplayCore.Interfaces;
using System.Collections.ObjectModel;
using System.Windows.Automation;
using LPReplayCore.Model;
using System.IO;
using LPCommon;
using System.Drawing;
using System.Collections.Generic;
using System.Diagnostics;

#if TEST

namespace LPReplayCore.UnitTest
{

    [TestClass]
    public class TestObjectNurseTest
    {
        TreeView _treeView;
        UIATestObject _rootTestObject;
        UIATestObject _parentTestObject;
        UIATestObject _childTestObject;
        VirtualTestObject _grandChildTestObject;

        [TestInitialize]
        public void PrepareTree()
        {
            _treeView = new TreeView();

            _rootTestObject = new UIATestObject();
            _parentTestObject = new UIATestObject();
            _childTestObject = new UIATestObject();
            _grandChildTestObject = new VirtualTestObject();
        }

        [TestMethod]
        public void TestObjectNurse_ctor()
        {
            UIATestObject testObject = new UIATestObject();

            testObject.NodeName = "MyTestObject";
            testObject.ControlType = ControlType.CheckBox;
            TestObjectNurse nurseObject = new TestObjectNurse(testObject);


            Assert.AreEqual(testObject.NodeName, nurseObject.NodeName);
            Assert.AreEqual(testObject.ControlTypeString, nurseObject.ControlTypeString);
            string displayName = testObject.ControlTypeString + ": " + testObject.NodeName;
            Assert.AreEqual(displayName, nurseObject.TreeNode.Text);

            CachedPropertyGroup cachedGroup = new CachedPropertyGroup();
            cachedGroup.Properties[UIAControlKeys.ImagePath] = "pathToImage.png";
            testObject.SetContext<CachedPropertyGroup>(cachedGroup);

            TestObjectNurse nurseObject2 = new TestObjectNurse(testObject);
            Assert.AreEqual("pathToImage.png", nurseObject2.ImageFile);
        }

        [TestMethod]
        public void TestObjectNurse_Clear()
        {
            _childTestObject.AddChild(_grandChildTestObject);
            _parentTestObject.AddChild(_childTestObject);

            //root Nurse doesn't contain valid testObject, valid test objects start from its children
            TestObjectNurse rootNurse = TestObjectNurse.AddTree(_treeView, _parentTestObject);

            rootNurse.Clear();

            Assert.AreEqual(0, rootNurse.Children.Count);
            Assert.AreEqual(0, rootNurse.Nodes.Count);
        }

        [TestMethod]
        public void TestObjectNurse_AddChild_TestObject()
        {
            TestObjectNurse parentNurse = new TestObjectNurse(_parentTestObject);


            //Add the child test object to the tree, 
            TestObjectNurse childNurse = parentNurse.AddChild(_childTestObject) as TestObjectNurse;

            Assert.AreEqual(_childTestObject, childNurse.TestObject);

            //Assert hierarchy
            Assert.AreEqual(childNurse, parentNurse.Children[0]);
            Assert.AreEqual(parentNurse, childNurse.Parent);

            Assert.AreEqual(_parentTestObject, _childTestObject.Parent);
            Assert.AreEqual(_childTestObject, _parentTestObject.Children[0]);
        }

        [TestMethod]
        public void TestObjectNurse_AddChild_NurseObject()
        {
            UIATestObject grandParentTestObject = new UIATestObject();
            TestObjectNurse grandParentNurse = new TestObjectNurse(grandParentTestObject);
 
            TestObjectNurse parentNurse = new TestObjectNurse(_parentTestObject);
            grandParentNurse.AddChild(parentNurse);

            //Add the child test object to the tree, 
            TestObjectNurse childNurse = new TestObjectNurse(_childTestObject);

            parentNurse.AddChild(childNurse);

            Assert.AreEqual(_childTestObject, childNurse.TestObject);

            //Assert hierarchy
            Assert.AreEqual(childNurse, parentNurse.Children[0]);
            Assert.AreEqual(parentNurse, childNurse.Parent);

            Assert.AreEqual(_parentTestObject, _childTestObject.Parent);
            Assert.AreEqual(_childTestObject, _parentTestObject.Children[0]);

            Assert.AreEqual(grandParentNurse.TreeNode, parentNurse.TreeNode.Parent);

            Assert.AreEqual(parentNurse.TreeNode, childNurse.TreeNode.Parent);
            Assert.AreEqual(childNurse.TreeNode, parentNurse.TreeNode.Nodes[0]);
        }

        [TestMethod]
        public void TestObjectNurse_AddTree()
        {
            _childTestObject.AddChild(_grandChildTestObject);
            _parentTestObject.AddChild(_childTestObject);

            //root Nurse doesn't contain valid testObject, valid test objects start from its children
            TestObjectNurse rootNurse = TestObjectNurse.AddTree(_treeView, _parentTestObject);
            Assert.IsNull(_parentTestObject.Parent);

            TestObjectNurse parentNurse = rootNurse.Children[0] as TestObjectNurse;
            TestObjectNurse childNurse = parentNurse.Children[0] as TestObjectNurse;
            TestObjectNurse grandNurse = childNurse.Children[0] as TestObjectNurse;

            Assert.IsNotNull(grandNurse);
        }



        [TestMethod]
        public void TestObjectNurse_AddDecendants()
        {
            
            _childTestObject.AddChild(_grandChildTestObject);
            _parentTestObject.AddChild(_childTestObject);

            //Add it to tree
            TestObjectNurse rootNurse = new TestObjectNurse(_treeView);

            TestObjectNurse parentNurse = rootNurse.AddDecendants(_parentTestObject);
            TestObjectNurse parentNurse1 = rootNurse.Children[0] as TestObjectNurse;

            Assert.AreEqual(parentNurse, parentNurse1);

            TestObjectNurse childNurse = parentNurse.Children[0] as TestObjectNurse;
            TestObjectNurse grandNurse = childNurse.Children[0] as TestObjectNurse;

            Assert.IsNotNull(grandNurse);
        }

        [TestMethod]
        public void TestObjectNurse_ConvertSubtree()
        {
            _parentTestObject.AddChild(_childTestObject);
            _childTestObject.AddChild(_grandChildTestObject);

            TestObjectNurse parentNurse =
            TestObjectNurse.ConvertSubtree(_parentTestObject);

            Assert.IsNull(parentNurse.Parent);
            Assert.IsNull(parentNurse.TestObject.Parent);

            TestObjectNurse childNurse = parentNurse[0] as TestObjectNurse;
            Assert.IsNotNull(childNurse);
            Assert.IsNotNull(childNurse.Parent = parentNurse);

            TestObjectNurse grandChildNurse = childNurse[0] as TestObjectNurse;
            Assert.IsNotNull(grandChildNurse);
            Assert.IsNotNull(grandChildNurse.Parent = childNurse);
        }

        [TestMethod]
        public void TestObjectNurse_FromTreeNode()
        {
            _childTestObject.AddChild(_grandChildTestObject);
            _parentTestObject.AddChild(_childTestObject);

            //Add it to tree
            TestObjectNurse rootNurse = new TestObjectNurse(_treeView);

            
            TestObjectNurse parentNurse = rootNurse.AddDecendants(_parentTestObject);

            TreeNode treeNode = parentNurse.TreeNode;

            TestObjectNurse nurseObject = TestObjectNurse.FromTreeNode(treeNode);

            Assert.AreEqual(parentNurse, nurseObject);

            TreeNode childNode = treeNode.Nodes[0];


            TestObjectNurse childNurseObject = TestObjectNurse.FromTreeNode(childNode);

            TestObjectNurse childNurse = parentNurse[0];

            Assert.AreEqual(childNurse, childNurseObject);
        }

        [TestMethod]
        public void TestObjectNurse_RemoveChild()
        {
            //init test objects
            UIATestObject childTestObject2 = new UIATestObject();
            UIATestObject childTestObject3 = new UIATestObject();


            _childTestObject.AddChild(_grandChildTestObject);
            _parentTestObject.AddChild(_childTestObject);
            _parentTestObject.AddChild(childTestObject2);
            _parentTestObject.AddChild(childTestObject3);

            //initialize nurse objects
            TestObjectNurse parentNurse = new TestObjectNurse(_parentTestObject);

            TestObjectNurse childNurse = parentNurse.AddChild(_childTestObject) as TestObjectNurse;
            TestObjectNurse childNurse2 = parentNurse.AddChild(childTestObject2) as TestObjectNurse;
            TestObjectNurse childNurse3 = parentNurse.AddChild(childTestObject3) as TestObjectNurse;

            Assert.AreEqual(3, parentNurse.Children.Count);

            parentNurse.RemoveChild(childTestObject2);
            Assert.AreEqual(2, parentNurse.Children.Count);

            parentNurse.RemoveChild(childNurse3);
            Assert.AreEqual(1, parentNurse.Children.Count);
        }


        /*
        private void DeleteFile(string path)
        {
            File.Delete(path);
            Debug.WriteLine(path);
        }*/

        [TestMethod]
        public void TestObjectNurse_Children()
        {
            //init test objects
            UIATestObject childTestObject2 = new UIATestObject();
            UIATestObject childTestObject3 = new UIATestObject();


            _childTestObject.AddChild(_grandChildTestObject);
            _parentTestObject.AddChild(_childTestObject);
            _parentTestObject.AddChild(childTestObject2);
            _parentTestObject.AddChild(childTestObject3);

            //initialize nurse objects
            TestObjectNurse parentNurse = new TestObjectNurse(_parentTestObject);

            TestObjectNurse childNurse = parentNurse.AddChild(_childTestObject) as TestObjectNurse;
            TestObjectNurse childNurse2 = parentNurse.AddChild(childTestObject2) as TestObjectNurse;
            TestObjectNurse childNurse3 = parentNurse.AddChild(childTestObject3) as TestObjectNurse;

            Assert.AreEqual(3, parentNurse.Children.Count);

            Assert.AreEqual(_childTestObject, parentNurse[0].TestObject);
            Assert.AreEqual(childTestObject2, parentNurse[1].TestObject);
            Assert.AreEqual(childTestObject3, parentNurse[2].TestObject);
        }

        [TestMethod]
        public void TestObjectNurse_NodeName()
        {
            UIATestObject testObject = new UIATestObject();
            testObject.ControlType = ControlType.ComboBox;

            TestObjectNurse nurse = new TestObjectNurse(testObject);
            nurse.NodeName = "HelloWorld";
            Assert.AreEqual("ComboBox: HelloWorld", nurse.TreeNode.Text);
        }

        [TestMethod]
        public void TestObjectNurse_ContainsKeyword()
        {
            UIATestObject testObject = new UIATestObject("Hello World", ControlType.Button, null);
            
            TestObjectNurse nurse = new TestObjectNurse(testObject);

            Assert.IsTrue(nurse.ContainsKeyword("Hello"));
            Assert.IsTrue(nurse.ContainsKeyword("WORLD"));

            Assert.IsFalse(nurse.ContainsKeyword("HelloWorld"));

            Assert.IsTrue(nurse.ContainsKeyword("BUTTON"));
        }
    }
}

#endif
