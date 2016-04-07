namespace LPSpy
{
    partial class NodeViewControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NodeViewControl));
            this.panel1 = new System.Windows.Forms.Panel();
            this.snapshotBox = new LPSpy.SnapshotPictureBox();
            this.txtNodeName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUIAType = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.tabProperties = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.propertyGrid = new LPSpy.TestObjectPropertyGrid();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnAddProperty = new System.Windows.Forms.ToolStripButton();
            this.btnRemoveProperty = new System.Windows.Forms.ToolStripButton();
            this.btnHighlight = new System.Windows.Forms.ToolStripButton();
            this.toolStripbtnUpdate = new System.Windows.Forms.ToolStripButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.snapshotBox2 = new LPSpy.SnapshotPictureBox();
            this.resourceControl1 = new LAPResourceManager.ResourceControl();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.snapshotBox)).BeginInit();
            this.tabProperties.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.snapshotBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.snapshotBox);
            this.panel1.Controls.Add(this.txtNodeName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtUIAType);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Name = "panel1";
            // 
            // snapshotBox
            // 
            resources.ApplyResources(this.snapshotBox, "snapshotBox");
            this.snapshotBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.snapshotBox.Name = "snapshotBox";
            this.snapshotBox.TabStop = false;
            // 
            // txtNodeName
            // 
            resources.ApplyResources(this.txtNodeName, "txtNodeName");
            this.txtNodeName.Name = "txtNodeName";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // txtUIAType
            // 
            resources.ApplyResources(this.txtUIAType, "txtUIAType");
            this.txtUIAType.Name = "txtUIAType";
            // 
            // lblName
            // 
            resources.ApplyResources(this.lblName, "lblName");
            this.lblName.Name = "lblName";
            // 
            // tabProperties
            // 
            resources.ApplyResources(this.tabProperties, "tabProperties");
            this.tabProperties.Controls.Add(this.tabPage1);
            this.tabProperties.Controls.Add(this.tabPage2);
            this.tabProperties.Name = "tabProperties";
            this.tabProperties.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Controls.Add(this.propertyGrid);
            this.tabPage1.Controls.Add(this.toolStrip2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // propertyGrid
            // 
            resources.ApplyResources(this.propertyGrid, "propertyGrid");
            this.propertyGrid.CategoryForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.propertyGrid.Name = "propertyGrid";
            // 
            // toolStrip2
            // 
            resources.ApplyResources(this.toolStrip2, "toolStrip2");
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddProperty,
            this.btnRemoveProperty,
            this.btnHighlight,
            this.toolStripbtnUpdate});
            this.toolStrip2.Name = "toolStrip2";
            // 
            // btnAddProperty
            // 
            resources.ApplyResources(this.btnAddProperty, "btnAddProperty");
            this.btnAddProperty.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddProperty.Image = global::LPSpy.Properties.Resources.plus;
            this.btnAddProperty.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddProperty.Name = "btnAddProperty";
            this.btnAddProperty.Click += new System.EventHandler(this.btnAddProperty_Click);
            // 
            // btnRemoveProperty
            // 
            resources.ApplyResources(this.btnRemoveProperty, "btnRemoveProperty");
            this.btnRemoveProperty.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRemoveProperty.Image = global::LPSpy.Properties.Resources.cross__1_;
            this.btnRemoveProperty.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRemoveProperty.Name = "btnRemoveProperty";
            this.btnRemoveProperty.Click += new System.EventHandler(this.btnDelectProperty_Click);
            // 
            // btnHighlight
            // 
            resources.ApplyResources(this.btnHighlight, "btnHighlight");
            this.btnHighlight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnHighlight.Name = "btnHighlight";
            this.btnHighlight.Click += new System.EventHandler(this.btnHighlight_Click);
            // 
            // toolStripbtnUpdate
            // 
            resources.ApplyResources(this.toolStripbtnUpdate, "toolStripbtnUpdate");
            this.toolStripbtnUpdate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripbtnUpdate.Name = "toolStripbtnUpdate";
            // 
            // tabPage2
            // 
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Controls.Add(this.snapshotBox2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // snapshotBox2
            // 
            resources.ApplyResources(this.snapshotBox2, "snapshotBox2");
            this.snapshotBox2.DrawBorder = true;
            this.snapshotBox2.Name = "snapshotBox2";
            this.snapshotBox2.TabStop = false;
            // Must to set the BaseName property which is use to get the resource file name.
            // MLUResManager is used to set the custom resource file which in the another resource.dll.
            // 
            // resourceControl1
            // 
            this.resourceControl1.ResAssemblyName = "LAPResources";
            this.resourceControl1.UIComponentName = "LPSpy.NodeViewControl";
            this.resourceControl1.reInitResManger(ref resources);
            // 
            // NodeViewControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabProperties);
            this.Controls.Add(this.panel1);
            this.Name = "NodeViewControl";
            this.Resize += new System.EventHandler(this.NodeViewControl_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.snapshotBox)).EndInit();
            this.tabProperties.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.snapshotBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private SnapshotPictureBox snapshotBox;
        private System.Windows.Forms.TextBox txtNodeName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUIAType;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TabControl tabProperties;
        private System.Windows.Forms.TabPage tabPage1;
        private TestObjectPropertyGrid propertyGrid;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnAddProperty;
        private System.Windows.Forms.ToolStripButton btnRemoveProperty;
        private System.Windows.Forms.ToolStripButton btnHighlight;
        private System.Windows.Forms.ToolStripButton toolStripbtnUpdate;
        private System.Windows.Forms.TabPage tabPage2;
        private SnapshotPictureBox snapshotBox2;
        private LAPResourceManager.ResourceControl resourceControl1;
    }
}
