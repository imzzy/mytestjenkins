using LPReplayCore;
using LPReplayCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LPSpy
{
    
    public class SearchTreeView: TreeView
    {
        string _keyword;
        TreeView _treeObjects;

        public SearchTreeView()
        {
        }

        public SearchTreeView(TreeView treeViewToSearch)
        {
            this._treeObjects = treeViewToSearch;
        }

        public TreeView TreeViewToSearch
        {
            get
            {
                return _treeObjects;
            }
            set
            {
                _treeObjects = value;
            }
        }

        public void VisibleTreeControl(bool showSearchTree = false)
        {
            if (!showSearchTree)
            {
                this.Nodes.Clear();
            }
            this.Visible = showSearchTree;
            this._treeObjects.Visible = !showSearchTree;
        }

        private bool whereCondition(TestObjectNurse nurseObject)
        {
            ITextSearch searchObject = nurseObject as ITextSearch;

            return (searchObject.ContainsKeyword(_keyword));

        }

        public void Search(string text)
        {
            //get text
            _keyword = text.Trim();
            if (string.IsNullOrEmpty(_keyword))
            {
                VisibleTreeControl(false);
                return;
            }
            this.Nodes.Clear();
            VisibleTreeControl(true);

            List<TreeNode> nodes = new List<TreeNode>();
            foreach (TreeNode rootNode in _treeObjects.Nodes)
            {
                TreeNode topNode = (TreeNode)rootNode.Clone();
                nodes.Add(topNode);
            }
            this.Nodes.AddRange(nodes.ToArray());
            TreeNodeCollection treeNodes = this.Nodes;
            RecursiveTreeViewSearch(treeNodes);
            this.ExpandAll();
        }

        private void RecursiveTreeViewSearch(TreeNodeCollection treeNodes)
        {
            TreeNode[] nodes = treeNodes.Cast<TreeNode>().ToArray();
            foreach (var node in nodes)
            {
                if (whereCondition(node.Tag as TestObjectNurse))
                {
                    RecursiveTreeViewSearch(node.Nodes);
                    node.ForeColor = Color.Red;
                    node.BackColor = Color.Yellow;
                }
                else
                {
                    if (node.GetNodeCount(false) == 0)
                    {
                        node.Remove();
                    }
                    else
                    {
                        RecursiveTreeViewSearch(node.Nodes);
                        if (node.GetNodeCount(false) == 0)
                        {
                            node.Remove();
                        }
                    }
                }
            }
        }
    }
}
