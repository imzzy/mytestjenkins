namespace LPSpy
{

    partial class SpyMainWindow
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpyMainWindow));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripNew = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpenLocation = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.menuRecentFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.actionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.learnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.highlightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conditionHighlightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeLanguageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englighMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chineseMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.documentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripNewFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAddObject = new System.Windows.Forms.ToolStripButton();
            this.tootBtnBatchAdd = new System.Windows.Forms.ToolStripButton();
            this.btnRemoveObject = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripHighlight = new System.Windows.Forms.ToolStripButton();
            this.toolStripSpy = new System.Windows.Forms.ToolStripButton();
            this.toolStripbtnBrower = new System.Windows.Forms.ToolStripButton();
            this.lblUIAType = new System.Windows.Forms.Label();
            this.panelRight = new System.Windows.Forms.Panel();
            this.nodeViewControl1 = new LPSpy.NodeViewControl();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.modelTreeViewControl1 = new LPSpy.Controls.ModelTreeViewControl();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.resourceControl1 = new LAPResourceManager.ResourceControl();
            this.propertyContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuPropertyRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.propertyContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.actionsToolStripMenuItem,
            this.helpToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripNew,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.mnuOpenLocation,
            this.toolStripSeparator3,
            this.menuRecentFiles,
            this.toolStripSeparator4,
            this.menuExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // toolStripNew
            // 
            this.toolStripNew.Name = "toolStripNew";
            resources.ApplyResources(this.toolStripNew, "toolStripNew");
            this.toolStripNew.Click += new System.EventHandler(this.newMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            resources.ApplyResources(this.openToolStripMenuItem, "openToolStripMenuItem");
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            resources.ApplyResources(this.saveToolStripMenuItem, "saveToolStripMenuItem");
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            resources.ApplyResources(this.saveAsToolStripMenuItem, "saveAsToolStripMenuItem");
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsMenuItem_Click);
            // 
            // mnuOpenLocation
            // 
            this.mnuOpenLocation.Name = "mnuOpenLocation";
            resources.ApplyResources(this.mnuOpenLocation, "mnuOpenLocation");
            this.mnuOpenLocation.Click += new System.EventHandler(this.mnuOpenLocation_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // menuRecentFiles
            // 
            this.menuRecentFiles.Name = "menuRecentFiles";
            resources.ApplyResources(this.menuRecentFiles, "menuRecentFiles");
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            resources.ApplyResources(this.menuExit, "menuExit");
            // 
            // actionsToolStripMenuItem
            // 
            this.actionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.learnToolStripMenuItem,
            this.highlightToolStripMenuItem,
            this.conditionHighlightToolStripMenuItem,
            this.toolStripSeparator5,
            this.optionsToolStripMenuItem});
            this.actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
            resources.ApplyResources(this.actionsToolStripMenuItem, "actionsToolStripMenuItem");
            // 
            // learnToolStripMenuItem
            // 
            this.learnToolStripMenuItem.Name = "learnToolStripMenuItem";
            resources.ApplyResources(this.learnToolStripMenuItem, "learnToolStripMenuItem");
            this.learnToolStripMenuItem.Click += new System.EventHandler(this.batchAddMenuItem_Click);
            // 
            // highlightToolStripMenuItem
            // 
            this.highlightToolStripMenuItem.Name = "highlightToolStripMenuItem";
            resources.ApplyResources(this.highlightToolStripMenuItem, "highlightToolStripMenuItem");
            this.highlightToolStripMenuItem.Click += new System.EventHandler(this.btnHighlight_Click);
            // 
            // conditionHighlightToolStripMenuItem
            // 
            this.conditionHighlightToolStripMenuItem.Name = "conditionHighlightToolStripMenuItem";
            resources.ApplyResources(this.conditionHighlightToolStripMenuItem, "conditionHighlightToolStripMenuItem");
            this.conditionHighlightToolStripMenuItem.Click += new System.EventHandler(this.btnConditionHighlight_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            resources.ApplyResources(this.optionsToolStripMenuItem, "optionsToolStripMenuItem");
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeLanguageToolStripMenuItem,
            this.documentsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            // 
            // changeLanguageToolStripMenuItem
            // 
            this.changeLanguageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.englighMenuItem,
            this.chineseMenuItem});
            this.changeLanguageToolStripMenuItem.Name = "changeLanguageToolStripMenuItem";
            resources.ApplyResources(this.changeLanguageToolStripMenuItem, "changeLanguageToolStripMenuItem");
            // 
            // englighMenuItem
            // 
            this.englighMenuItem.Name = "englighMenuItem";
            resources.ApplyResources(this.englighMenuItem, "englighMenuItem");
            this.englighMenuItem.Click += new System.EventHandler(this.englighMenuItem_Click);
            // 
            // chineseMenuItem
            // 
            this.chineseMenuItem.Name = "chineseMenuItem";
            resources.ApplyResources(this.chineseMenuItem, "chineseMenuItem");
            this.chineseMenuItem.Click += new System.EventHandler(this.chineseMenuItem_Click);
            // 
            // documentsToolStripMenuItem
            // 
            this.documentsToolStripMenuItem.Name = "documentsToolStripMenuItem";
            resources.ApplyResources(this.documentsToolStripMenuItem, "documentsToolStripMenuItem");
            this.documentsToolStripMenuItem.Click += new System.EventHandler(this.documentsMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripNewFile,
            this.toolStripOpen,
            this.toolStripSave,
            this.toolStripSeparator1,
            this.btnAddObject,
            this.tootBtnBatchAdd,
            this.btnRemoveObject,
            this.toolStripSeparator2,
            this.toolStripHighlight,
            this.toolStripSpy,
            this.toolStripbtnBrower});
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Name = "toolStrip1";
            // 
            // toolStripNewFile
            // 
            this.toolStripNewFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripNewFile, "toolStripNewFile");
            this.toolStripNewFile.Name = "toolStripNewFile";
            this.toolStripNewFile.Click += new System.EventHandler(this.btnNewFile_Click);
            // 
            // toolStripOpen
            // 
            this.toolStripOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripOpen, "toolStripOpen");
            this.toolStripOpen.Name = "toolStripOpen";
            this.toolStripOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // toolStripSave
            // 
            this.toolStripSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripSave, "toolStripSave");
            this.toolStripSave.Name = "toolStripSave";
            this.toolStripSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // btnAddObject
            // 
            this.btnAddObject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddObject.Image = global::LPSpy.Properties.Resources.plus;
            resources.ApplyResources(this.btnAddObject, "btnAddObject");
            this.btnAddObject.Name = "btnAddObject";
            this.btnAddObject.Click += new System.EventHandler(this.btnAddObject_Click);
            // 
            // tootBtnBatchAdd
            // 
            this.tootBtnBatchAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.tootBtnBatchAdd, "tootBtnBatchAdd");
            this.tootBtnBatchAdd.Name = "tootBtnBatchAdd";
            this.tootBtnBatchAdd.Click += new System.EventHandler(this.btnBatchAdd_Click);
            // 
            // btnRemoveObject
            // 
            this.btnRemoveObject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.btnRemoveObject, "btnRemoveObject");
            this.btnRemoveObject.Name = "btnRemoveObject";
            this.btnRemoveObject.Click += new System.EventHandler(this.btnRemoveObject_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // toolStripHighlight
            // 
            this.toolStripHighlight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripHighlight, "toolStripHighlight");
            this.toolStripHighlight.Name = "toolStripHighlight";
            this.toolStripHighlight.Click += new System.EventHandler(this.btnHighlight_Click);
            // 
            // toolStripSpy
            // 
            this.toolStripSpy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripSpy, "toolStripSpy");
            this.toolStripSpy.Name = "toolStripSpy";
            this.toolStripSpy.Click += new System.EventHandler(this.btnSpy_Click);
            // 
            // toolStripbtnBrower
            // 
            this.toolStripbtnBrower.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripbtnBrower, "toolStripbtnBrower");
            this.toolStripbtnBrower.Name = "toolStripbtnBrower";
            this.toolStripbtnBrower.Click += new System.EventHandler(this.toolStripbtnBrowser_Click);
            // 
            // lblUIAType
            // 
            resources.ApplyResources(this.lblUIAType, "lblUIAType");
            this.lblUIAType.Name = "lblUIAType";
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.Transparent;
            this.panelRight.Controls.Add(this.nodeViewControl1);
            resources.ApplyResources(this.panelRight, "panelRight");
            this.panelRight.Name = "panelRight";
            // 
            // nodeViewControl1
            // 
            resources.ApplyResources(this.nodeViewControl1, "nodeViewControl1");
            this.nodeViewControl1.Name = "nodeViewControl1";
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.Transparent;
            this.panelLeft.Controls.Add(this.modelTreeViewControl1);
            resources.ApplyResources(this.panelLeft, "panelLeft");
            this.panelLeft.Name = "panelLeft";
            // 
            // modelTreeViewControl1
            // 
            resources.ApplyResources(this.modelTreeViewControl1, "modelTreeViewControl1");
            this.modelTreeViewControl1.Name = "modelTreeViewControl1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
            // Must to set the BaseName property which is use to get the resource file name.
            // MLUResManager is used to set the custom resource file which in the another resource.dll.
            // 
            // resourceControl1
            // 
            this.resourceControl1.ResAssemblyName = "LAPResources";
            this.resourceControl1.UIComponentName = "LPSpy.SpyMainWindow";
            this.resourceControl1.reInitResManger(ref resources);
            // 
            // propertyContextMenu
            // 
            this.propertyContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuPropertyRemove});
            this.propertyContextMenu.Name = "propertyContextMenu";
            resources.ApplyResources(this.propertyContextMenu, "propertyContextMenu");
            // 
            // mnuPropertyRemove
            // 
            this.mnuPropertyRemove.Name = "mnuPropertyRemove";
            resources.ApplyResources(this.mnuPropertyRemove, "mnuPropertyRemove");
            // 
            // SpyMainWindow
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lblUIAType);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SpyMainWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SpyMainWindow_FormClosing);
            this.Load += new System.EventHandler(this.spyMainWindow_Onload);
            this.Resize += new System.EventHandler(this.SpyMainWindow_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelRight.ResumeLayout(false);
            this.panelLeft.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.propertyContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAddObject;
        private System.Windows.Forms.ToolStripButton btnRemoveObject;
        private System.Windows.Forms.Label lblUIAType;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripNew;
        private System.Windows.Forms.ToolStripButton toolStripNewFile;
        private System.Windows.Forms.ToolStripButton toolStripOpen;
        private System.Windows.Forms.ToolStripButton toolStripSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripHighlight;
        private System.Windows.Forms.ToolStripButton toolStripSpy;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem actionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem highlightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem conditionHighlightToolStripMenuItem;
        private LAPResourceManager.ResourceControl resourceControl1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeLanguageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englighMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chineseMenuItem;
        private System.Windows.Forms.ToolStripMenuItem documentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem learnToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip propertyContextMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuPropertyRemove;
        private System.Windows.Forms.ToolStripButton tootBtnBatchAdd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem menuRecentFiles;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.ToolStripMenuItem mnuOpenLocation;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton toolStripbtnBrower;
        private Controls.ModelTreeViewControl modelTreeViewControl1;
        private NodeViewControl nodeViewControl1;
    }
}