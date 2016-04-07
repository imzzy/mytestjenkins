using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
using LPReplayCore;
using LPReplayCore.UIA;
using System.Drawing;
using System.Windows.Automation;

#if TEST
namespace LPSpy.UnitTest
{
    [TestClass]
    public class SearchTreeViewTest
    {
        static TreeView _treeView;

        [ClassInitialize]
        public static void InitTest(TestContext context)
        {
            _treeView = new TreeView();

            TestObjectNurse treeNurse = TestObjectNurse.FromTree(_treeView);

            UIATestObject rootObject = new UIATestObject("root node", ControlType.Pane, null);
            UIATestObject parentObject = new UIATestObject("parent node",ControlType.Pane, null);
            UIATestObject childObject = new UIATestObject("child1 node", ControlType.Button, null);
            VirtualTestObject childObject1 = new VirtualTestObject("child2 node", new Rectangle(10, 20, 30, 40));

            TestObjectNurse tempNurse = treeNurse.AddChild(rootObject) as TestObjectNurse;
            tempNurse = tempNurse.AddChild(parentObject) as TestObjectNurse;
            tempNurse.AddChild(childObject);
            tempNurse.AddChild(childObject1);

            UIATestObject rootObject1 = new UIATestObject("root1 node", ControlType.Pane, null);
            UIATestObject parentObject2 = new UIATestObject("parent2 node", ControlType.Pane, null);

            tempNurse = treeNurse.AddChild(rootObject1) as TestObjectNurse;
            treeNurse.AddChild(parentObject2);
        }

        public void ShowTree(TreeView treeView)
        {
            Form form1 = new Form();
            form1.Controls.Add(treeView);

            form1.ShowDialog();
        }

        [TestMethod]
        public void SearchTreeView_Search_root()
        {
            SearchTreeView searchTreeView = new SearchTreeView(_treeView);
            
            searchTreeView.Search("root");
            Assert.AreEqual(2, searchTreeView.Nodes.Count);

            TreeNode rootNode = searchTreeView.Nodes[0];
            Assert.AreEqual("Pane: root node", rootNode.Text);
        }

        [TestMethod]
        public void SearchTreeView_Search2()
        {
            SearchTreeView searchTreeView = new SearchTreeView(_treeView);
            searchTreeView.VisibleTreeControl(true);
            searchTreeView.Search("child");

            Assert.AreEqual(1, searchTreeView.Nodes.Count);

            TreeNode rootNode = searchTreeView.Nodes[0];
            Assert.AreEqual("Pane: root node", rootNode.Text);

            Assert.AreEqual(1, rootNode.Nodes.Count);

            TreeNode parentNode = rootNode.Nodes[0];
            Assert.AreEqual(2, parentNode.Nodes.Count);
        }
    }
}

#endif