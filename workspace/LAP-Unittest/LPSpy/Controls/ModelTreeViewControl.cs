using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LPCommon;
using LPReplayCore;
using LAPResources;
using LPUIAObjects;

namespace LPSpy.Controls
{
    public partial class ModelTreeViewControl : UserControl, IModelTreeView
    {
        private TreeNode _selectedNode = null;

        private TestObjectNurse _dragUIAcon = null;

        private IDataObject _dragDataObject = new DataObject();

        public ModelTreeViewControl()
        {
            InitializeComponent();

            treeObjects.ImageList = TreeNodeHelper.TreeImageList;
            tvSearchResult.ImageList = TreeNodeHelper.TreeImageList;
            tvSearchResult.VisibleTreeControl(false);

            ModelFileHandler.AfterFileLoad += (path) =>
            {
                treeObjects.ExpandAll();
            };

        }

        private void AdjustSize()
        {
            const int borderSize = 5;

            treeObjects.Height = treeObjects.Parent.Height;
            tvSearchResult.Height = treeObjects.Height;
            tvSearchResult.Width = treeObjects.Width;
            
        }


        public TestObjectNurse RootNurseObject
        {
            get
            {
                return TestObjectNurse.FromTree(treeObjects);
            }
        }
        
        private void treeObjects_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SelectedNodesChanged(e.Node);
        }

        private void treeObjects_DragItemToEditor(object sender, ItemDragEventArgs e)
        {
            const string prefix = "UIAManager.";
            if (e.Item is TreeNode)
            {
                TreeNode treeNode = (TreeNode)e.Item;
                _dragUIAcon = TestObjectNurse.FromTreeNode(treeNode);
                TestObjectNurse nurseObject = TestObjectNurse.FromTreeNode(treeNode);

                _dragDataObject.SetData(DataFormats.Text, true, prefix + CodeGenerator.GetFullPathName(nurseObject.TestObject));
                ((TreeView)sender).DoDragDrop(_dragDataObject, DragDropEffects.Copy);
            }
        }

        private void treeObjects_OnClickedAndStartEditing(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.TreeView.LabelEdit == true)
            {
                //in search, the node name is not editable
                e.Node.BeginEdit();
            }
        }


        private void treeObjects_OnDropItemIntoTree(object sender, DragEventArgs e)
        {
            TreeNode myNode = null;

            if (e.Data.GetDataPresent(typeof(TreeNode)))
            {
                myNode = (TreeNode)(e.Data.GetData(typeof(TreeNode)));
            }
            else
            {
                return;
            }

            Point position = new Point(e.X, e.Y);

            position = this.treeObjects.PointToClient(position);

            TreeNode dropNode = this.treeObjects.GetNodeAt(position);

            TreeNode dragNode = null;

            bool needUpdate = false;
            if ((dropNode != null && dropNode.Parent != myNode && dropNode != myNode) || (dropNode == null))
            {
                dragNode = myNode;
                myNode.Remove();
                needUpdate = true;
            }

            if (dragNode != null && needUpdate)
            {
                TestObjectNurse dragNurse = TestObjectNurse.FromTreeNode(dragNode);
                string newName = "";
                if (dropNode == null)
                {
                    newName = SpyWindowHelper.DeriveControlName(RootNurseObject, dragNurse.NodeName);
                    treeObjects.Nodes.Add(dragNode);
                }
                else
                {
                    newName = SpyWindowHelper.DeriveControlName(RootNurseObject, dragNurse.NodeName);
                    dropNode.Nodes.Add(dragNode);
                }

                if (newName != dragNurse.NodeName)
                {
                    dragNurse.NodeName = newName;

                    SelectedNodesChanged(dragNode);

                    MessageBox.Show(string.Format(StringResources.LPSpy_SpyMainWindow_ObjNameSameMsg, newName));
                }
                treeObjects.SelectedNode = dragNode;
                AppEnvironment.SetModelChanged(true);
            }
        }

        /// <summary>
        /// https://support.microsoft.com/en-us/kb/810001
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeObjects_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeView tv = sender as TreeView;
                if (tv == null) return;
                // Point where the mouse is clicked.
                Point p = new Point(e.X, e.Y);

                // Get the node that the user has clicked.
                TreeNode node = tv.GetNodeAt(p);
                if (node != null)
                {

                    // Select the node the user has clicked.
                    // The node appears selected until the menu is displayed on the screen.
                    _selectedNode = tv.SelectedNode;
                    tv.SelectedNode = node;

                    contextMenuStrip.Show(treeObjects, p);

                    /*
                    // Find the appropriate ContextMenu depending on the selected node.
                    switch (Convert.ToString(node.Tag))
                    {
                        case "TextFile":
                            mnuTextFile.Show(treeObjects, p);
                            break;
                        case "File":
                            mnuFile.Show(treeObjects, p);
                            break;
                    }
                    */

                    // Highlight the selected node.
                    tv.SelectedNode = _selectedNode;
                }
            }

        }

        private void treeObjects_OnNodeDragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        public delegate void NodeNameChangeDelegate(object sender, NodeLabelEditEventArgs e);

        public event NodeNameChangeDelegate NodeNameChanged;

        private void treeObjects_OnObjectNameChanged(object sender, NodeLabelEditEventArgs e)
        {
            if (e.CancelEdit)
                return;
            if (e.Label == null)
                return;
            TestObjectNurse nurse = TestObjectNurse.FromTreeNode(e.Node);
            if (e.Label == nurse.NodeName)
                return;

            string newName = e.Label;
            if (e.Label.StartsWith(nurse.ControlTypeString + ":"))
            {
                newName = newName.Substring((nurse.ControlTypeString + ":").Length);
                newName = newName.Trim();
            }
            string nameChecker = SpyWindowHelper.DeriveControlName(nurse.ParentNurse, newName);

            if (nameChecker == newName)
            {
                nurse.NodeName = newName;

                if (NodeNameChanged != null)
                {
                    NodeNameChanged(sender, e);
                }

                _presenterModel.SetSelectNodeName(newName);

                AppEnvironment.SetModelChanged(true);

                return;
            }
            else
            {
                MessageBox.Show(string.Format(StringResources.LPSpy_SpyMainWindow_SelectobjMsg, newName));
                e.CancelEdit = true;
                e.Node.Text = TestObjectNurse.FromTreeNode(e.Node).NodeName;
            }
        }


        private void treeObjects_OnPressDelete(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                DeleteSelectedNode();

            if (e.KeyCode == Keys.C && e.Modifiers == Keys.Control)
            {
                if (_selectedNode == null)
                    return;
                Clipboard.Clear();
                TestObjectNurse testObjectNode = TestObjectNurse.FromTreeNode(_selectedNode);
                Clipboard.SetText(GetFullPathNameByTreeNode(testObjectNode));
            }
        }


        private void treeObjects_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
        {
            if (Control.MouseButtons == MouseButtons.None)
            {
                if (e.Action == DragAction.Drop)
                {
                    System.Windows.Point currMousePoint = SafeNativeMethods.GetCursorPos();
                    Point DrawingPoint = new Point()
                    {
                        X = (int)currMousePoint.X,
                        Y = (int)currMousePoint.Y
                    };

                    DrawingPoint = this.PointToClient(DrawingPoint);
                    Rectangle rc = Rectangle.FromLTRB(0, 0, this.Width, this.Height);

                    if (!rc.Contains(DrawingPoint))
                    {
                        ToMethodsViewer toMethodsViewer = new ToMethodsViewer(_dragUIAcon, currMousePoint);
                        if (DialogResult.OK == toMethodsViewer.ShowDialog(this))
                        {
                            string _TestFullPath0 = _dragDataObject.GetData(DataFormats.Text) as string;
                            if (!string.IsNullOrEmpty(_TestFullPath0))
                            {
                                string _TestFullPath = ";\n" + _TestFullPath0 + ".";
                                _dragDataObject.SetData(DataFormats.Text, true, _TestFullPath0 + "." + string.Join(_TestFullPath, toMethodsViewer.TestObjectInfomation.ToArray()));
                            }
                        }
                        else
                        {
                            e.Action = DragAction.Cancel;
                        }
                        toMethodsViewer.Dispose();
                    }
                }
            }
        }


        private void DeleteSelectedNode(TreeNode node = null)
        {
            TreeView tvObject = treeObjects.Visible ? treeObjects : tvSearchResult;
            TreeNode nodeToDelete = node ?? tvObject.SelectedNode;
            if (nodeToDelete == null) return;

            TreeNode parentNode = nodeToDelete.Parent;

            TestObjectNurse nurseObject = TestObjectNurse.FromTreeNode(nodeToDelete);
            nurseObject.Remove();
            if (tvObject == tvSearchResult) nodeToDelete.Remove();
            if (parentNode == null)
            {
                if (tvObject.Nodes.Count > 0)
                    tvObject.SelectedNode = tvObject.TopNode;
            }
            else
            {
                tvObject.SelectedNode = parentNode;
            }
            SelectedNodesChanged(tvObject.SelectedNode);
            AppEnvironment.SetModelChanged(true);
        }

        public delegate void SelectedNodeChangedDelegate(TreeNode treeNode);

        public event SelectedNodeChangedDelegate SelectNodeChanged;

        private void RaiseSelectNodeChangedEvent(TreeNode treeNode)
        {
            if (SelectNodeChanged != null)
            {
                SelectNodeChanged(treeNode);
            }
        }

        private void SelectedNodesChanged(TreeNode treeNode)
        {
            if (_selectedNode == null && treeNode == null)
                return;

            if (treeNode != null)
                _selectedNode = treeNode;

            RaiseSelectNodeChangedEvent(treeNode);

            _presenterModel.SelectNodeChanged(TestObjectNurse.FromTreeNode(treeNode));
        }

        private string _startWithToolStrip = "";

        private string GetFullPathNameByTreeNode(TestObjectNurse nurse)
        {
            string fullPath = "";

            string currentPath = string.Format(@"{0}(""{1}"")", nurse.ControlTypeString,
                nurse.NodeName);

            if (nurse.Parent != null)
            {
                fullPath = GetFullPathNameByTreeNode(nurse.ParentNurse) + "." + currentPath;
            }
            else
            {
                fullPath = _startWithToolStrip + currentPath;
            }

            return fullPath;
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            DeleteSelectedNode();
        }

        private void mnuHighlight_Click(object sender, EventArgs e)
        {
            _presenterModel.Highlight(TestObjectNurse.FromTreeNode(_selectedNode));
        }

        private void mnuCaptureSnapshot_Click(object sender, EventArgs e)
        {
            TestObjectNurse nurseObject = TestObjectNurse.FromTreeNode(_selectedNode);
            SelectedNodesChanged(nurseObject.TreeNode);

            _presenterModel.CaptureSnapshot(nurseObject);
        }

        private void mnuEditVirtualControls_Click(object sender, EventArgs e)
        {
            if (treeObjects.SelectedNode == null)
            {
                MessageBox.Show(StringResources.LPSpy_SpyMainWindow_SelNodeWarningMsg);
                return;
            }

            TreeNode node = treeObjects.SelectedNode;
            _presenterModel.EditVirtualControl(TestObjectNurse.FromTreeNode(node));

        }

        private void validateSubtreeMenuItem_Click(object sender, EventArgs e)
        {
            //validate whether the elements in the subtree, see if they can identify objects
            MessageBox.Show("To be added");
        }

        PresenterModel _presenterModel;

        public void SetPresenter(PresenterModel presenterModel)
        {
            _presenterModel = presenterModel;
        }


        public void DeleteSelectedNode()
        {
            DeleteSelectedNode(null);
        }

        
        private void txtKeyword_TextChanged(object sender, EventArgs e)
        {
            this.timerTxtChg.Stop();
            this.timerTxtChg.Interval = 500;
            this.timerTxtChg.Start();
        }

        private void timerTxtChg_Tick(object sender, EventArgs e)
        {
            this.timerTxtChg.Stop();
            tvSearchResult.Search(this.txtKeyword.Text);
        }

        public TreeView GetTreeView()
        {
            return treeObjects;
        }
    }
}
