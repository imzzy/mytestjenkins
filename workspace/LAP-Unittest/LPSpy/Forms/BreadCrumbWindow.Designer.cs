namespace LPSpy
{
    partial class BatchAddWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BatchAddWindow));
            this.resourceControl1 = new LAPResourceManager.ResourceControl();
            this.CtrlContainer = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolBtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolBtnSpy = new System.Windows.Forms.ToolStripButton();
            this.toolBtnHighlight = new System.Windows.Forms.ToolStripButton();
            this.breadcrumbControl1 = new LPSpy.BreadcrumbControl();
            this.listView1 = new System.Windows.Forms.ListView();
            this.lapListViewObjects = new LPSpy.LAPListViewControl();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.imgListLV = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.CtrlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // Must to set the BaseName property which is use to get the resource file name.
            // MLUResManager is used to set the custom resource file which in the another resource.dll.
            // 
            // resourceControl1
            // 
            this.resourceControl1.ResAssemblyName = "LAPResources";
            this.resourceControl1.UIComponentName = "LPSpy.BreadCrumbWindow";
            this.resourceControl1.reInitResManger(ref resources);
            // 
            // CtrlContainer
            // 
            resources.ApplyResources(this.CtrlContainer, "CtrlContainer");
            this.CtrlContainer.Controls.Add(this.pictureBox1);
            this.CtrlContainer.Controls.Add(this.panel2);
            this.CtrlContainer.Controls.Add(this.listView1);
            this.CtrlContainer.Controls.Add(this.lapListViewObjects);
            this.CtrlContainer.Name = "CtrlContainer";
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Controls.Add(this.toolStrip1);
            this.panel2.Controls.Add(this.breadcrumbControl1);
            this.panel2.Name = "panel2";
            // 
            // toolStrip1
            // 
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolBtnRefresh,
            this.toolBtnSpy,
            this.toolBtnHighlight});
            this.toolStrip1.Name = "toolStrip1";
            // 
            // toolBtnRefresh
            // 
            resources.ApplyResources(this.toolBtnRefresh, "toolBtnRefresh");
            this.toolBtnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolBtnRefresh.Name = "toolBtnRefresh";
            this.toolBtnRefresh.Click += new System.EventHandler(this.toolBtnRefresh_Click);
            // 
            // toolBtnSpy
            // 
            resources.ApplyResources(this.toolBtnSpy, "toolBtnSpy");
            this.toolBtnSpy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolBtnSpy.Image = global::LPSpy.Properties.Resources.plus;
            this.toolBtnSpy.Name = "toolBtnSpy";
            // 
            // toolBtnHighlight
            // 
            resources.ApplyResources(this.toolBtnHighlight, "toolBtnHighlight");
            this.toolBtnHighlight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolBtnHighlight.Name = "toolBtnHighlight";
            // 
            // breadcrumbControl1
            // 
            resources.ApplyResources(this.breadcrumbControl1, "breadcrumbControl1");
            this.breadcrumbControl1.Name = "breadcrumbControl1";
            this.breadcrumbControl1.ShowCheckBox = true;
            // 
            // listView1
            // 
            resources.ApplyResources(this.listView1, "listView1");
            this.listView1.Name = "listView1";
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listView1_ItemChecked);
            // 
            // lapListViewObjects
            // 
            resources.ApplyResources(this.lapListViewObjects, "lapListViewObjects");
            this.lapListViewObjects.CheckBoxes = true;
            this.lapListViewObjects.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lapListViewObjects.FullRowSelect = true;
            this.lapListViewObjects.Name = "lapListViewObjects";
            this.lapListViewObjects.OwnerDraw = true;
            this.lapListViewObjects.UseCompatibleStateImageBehavior = false;
            this.lapListViewObjects.View = System.Windows.Forms.View.Details;
            this.lapListViewObjects.SelectedIndexChanged += new System.EventHandler(this.lvObjects_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            resources.ApplyResources(this.columnHeader1, "columnHeader1");
            // 
            // columnHeader2
            // 
            resources.ApplyResources(this.columnHeader2, "columnHeader2");
            // 
            // columnHeader3
            // 
            resources.ApplyResources(this.columnHeader3, "columnHeader3");
            // 
            // btnAdd
            // 
            resources.ApplyResources(this.btnAdd, "btnAdd");
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // imgListLV
            // 
            this.imgListLV.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            resources.ApplyResources(this.imgListLV, "imgListLV");
            this.imgListLV.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Name = "panel1";
            // 
            // BatchAddWindow
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.CtrlContainer);
            this.Name = "BatchAddWindow";
            this.ShowIcon = false;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BreadCrumbWindow_FormClosed);
            this.CtrlContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel CtrlContainer;
        private LAPResourceManager.ResourceControl resourceControl1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ImageList imgListLV;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolBtnRefresh;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripButton toolBtnSpy;
        private System.Windows.Forms.ToolStripButton toolBtnHighlight;
        private BreadcrumbControl breadcrumbControl1;
        private System.Windows.Forms.Panel panel2;
        private LAPListViewControl lapListViewObjects;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}