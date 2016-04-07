namespace LPSpy.Controls
{
    partial class ModelTreeViewControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModelTreeViewControl));
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.treeObjects = new System.Windows.Forms.TreeView();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuHighlight = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCaptureSnapshot = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditVirtualControls = new System.Windows.Forms.ToolStripMenuItem();
            this.validateSubtreeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerTxtChg = new System.Windows.Forms.Timer(this.components);
            this.tvSearchResult = new LPSpy.SearchTreeView();
            this.resourceControl1 = new LAPResourceManager.ResourceControl();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();

            // Must to set the BaseName property which is use to get the resource file name.
            // MLUResManager is used to set the custom resource file which in the another resource.dll.
            // 
            // resourceControl1
            // 
            this.resourceControl1.ResAssemblyName = "LAPResources";
            this.resourceControl1.UIComponentName = "LPSpy.ModelTreeViewControl";
            this.resourceControl1.reInitResManger(ref resources);
            // 

            // 
            // txtKeyword
            // 
            resources.ApplyResources(this.txtKeyword, "txtKeyword");
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.TextChanged += new System.EventHandler(this.txtKeyword_TextChanged);
            // 
            // treeObjects
            // 
            resources.ApplyResources(this.treeObjects, "treeObjects");
            this.treeObjects.LabelEdit = true;
            this.treeObjects.Name = "treeObjects";
            this.treeObjects.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeObjects_OnObjectNameChanged);
            this.treeObjects.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeObjects_DragItemToEditor);
            this.treeObjects.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeObjects_AfterSelect);
            this.treeObjects.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeObjects_OnClickedAndStartEditing);
            this.treeObjects.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeObjects_OnDropItemIntoTree);
            this.treeObjects.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeObjects_OnNodeDragEnter);
            this.treeObjects.QueryContinueDrag += new System.Windows.Forms.QueryContinueDragEventHandler(this.treeObjects_QueryContinueDrag);
            this.treeObjects.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeObjects_OnPressDelete);
            this.treeObjects.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeObjects_MouseUp);
            // 
            // contextMenuStrip
            // 
            resources.ApplyResources(this.contextMenuStrip, "contextMenuStrip");
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHighlight,
            this.mnuDelete,
            this.mnuCaptureSnapshot,
            this.mnuEditVirtualControls,
            this.validateSubtreeMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            // 
            // mnuHighlight
            // 
            resources.ApplyResources(this.mnuHighlight, "mnuHighlight");
            this.mnuHighlight.Name = "mnuHighlight";
            this.mnuHighlight.Click += new System.EventHandler(this.mnuHighlight_Click);
            // 
            // mnuDelete
            // 
            resources.ApplyResources(this.mnuDelete, "mnuDelete");
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.Click += new System.EventHandler(this.mnuDelete_Click);
            // 
            // mnuCaptureSnapshot
            // 
            resources.ApplyResources(this.mnuCaptureSnapshot, "mnuCaptureSnapshot");
            this.mnuCaptureSnapshot.Name = "mnuCaptureSnapshot";
            this.mnuCaptureSnapshot.Click += new System.EventHandler(this.mnuCaptureSnapshot_Click);
            // 
            // mnuEditVirtualControls
            // 
            resources.ApplyResources(this.mnuEditVirtualControls, "mnuEditVirtualControls");
            this.mnuEditVirtualControls.Name = "mnuEditVirtualControls";
            this.mnuEditVirtualControls.Click += new System.EventHandler(this.mnuEditVirtualControls_Click);
            // 
            // validateSubtreeMenuItem
            // 
            resources.ApplyResources(this.validateSubtreeMenuItem, "validateSubtreeMenuItem");
            this.validateSubtreeMenuItem.Name = "validateSubtreeMenuItem";
            this.validateSubtreeMenuItem.Click += new System.EventHandler(this.validateSubtreeMenuItem_Click);
            // 
            // timerTxtChg
            // 
            this.timerTxtChg.Interval = 2000;
            this.timerTxtChg.Tick += new System.EventHandler(this.timerTxtChg_Tick);
            // 
            // tvSearchResult
            // 
            resources.ApplyResources(this.tvSearchResult, "tvSearchResult");
            this.tvSearchResult.LabelEdit = true;
            this.tvSearchResult.Name = "tvSearchResult";
            this.tvSearchResult.TreeViewToSearch = this.treeObjects;
            this.tvSearchResult.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeObjects_DragItemToEditor);
            this.tvSearchResult.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeObjects_AfterSelect);
            this.tvSearchResult.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeObjects_OnClickedAndStartEditing);
            this.tvSearchResult.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeObjects_OnDropItemIntoTree);
            this.tvSearchResult.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeObjects_OnNodeDragEnter);
            this.tvSearchResult.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeObjects_OnPressDelete);
           
            // ModelTreeViewControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tvSearchResult);
            this.Controls.Add(this.treeObjects);
            this.Controls.Add(this.txtKeyword);
            this.Name = "ModelTreeViewControl";
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.TreeView treeObjects;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem mnuHighlight;
        private System.Windows.Forms.ToolStripMenuItem mnuDelete;
        private System.Windows.Forms.ToolStripMenuItem mnuCaptureSnapshot;
        private System.Windows.Forms.ToolStripMenuItem mnuEditVirtualControls;
        private System.Windows.Forms.ToolStripMenuItem validateSubtreeMenuItem;
        private SearchTreeView tvSearchResult;
        private System.Windows.Forms.Timer timerTxtChg;
        private LAPResourceManager.ResourceControl resourceControl1;
    }
}
