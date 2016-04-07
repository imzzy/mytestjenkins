namespace LPSpy
{
    partial class AddPropertiesWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddPropertiesWindow));
            this.propertyGrid = new System.Windows.Forms.DataGridView();
            this.Property = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddButton = new System.Windows.Forms.Button();
            this.CancelAddButton = new System.Windows.Forms.Button();
            this.resourceControl1 = new LAPResourceManager.ResourceControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripHighlight = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.propertyGrid)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // propertyGrid
            // 
            this.propertyGrid.AllowUserToAddRows = false;
            this.propertyGrid.AllowUserToDeleteRows = false;
            this.propertyGrid.AllowUserToResizeRows = false;
            this.propertyGrid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.propertyGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.propertyGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Property,
            this.Value});
            resources.ApplyResources(this.propertyGrid, "propertyGrid");
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.RowHeadersVisible = false;
            this.propertyGrid.RowTemplate.Height = 24;
            this.propertyGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.propertyGrid.ShowEditingIcon = false;
            // 
            // Property
            // 
            this.Property.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.Property, "Property");
            this.Property.Name = "Property";
            this.Property.ReadOnly = true;
            // 
            // Value
            // 
            this.Value.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.Value, "Value");
            this.Value.Name = "Value";
            // 
            // AddButton
            // 
            resources.ApplyResources(this.AddButton, "AddButton");
            this.AddButton.Name = "AddButton";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // CancelAddButton
            // 
            resources.ApplyResources(this.CancelAddButton, "CancelAddButton");
            this.CancelAddButton.Name = "CancelAddButton";
            this.CancelAddButton.UseVisualStyleBackColor = true;
            this.CancelAddButton.Click += new System.EventHandler(this.CancelButton_Click);
            // Must to set the BaseName property which is use to get the resource file name.
            // MLUResManager is used to set the custom resource file which in the another resource.dll.
            // 
            // resourceControl1
            // 
            this.resourceControl1.ResAssemblyName = "LAPResources";
            this.resourceControl1.UIComponentName = "LPSpy.AddPropertiesWindow";
            this.resourceControl1.reInitResManger(ref resources);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripRefresh,
            this.toolStripHighlight});
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Name = "toolStrip1";
            // 
            // toolStripRefresh
            // 
            this.toolStripRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripRefresh, "toolStripRefresh");
            this.toolStripRefresh.Name = "toolStripRefresh";
            this.toolStripRefresh.Click += new System.EventHandler(this.toolStripRefresh_Click);
            // 
            // toolStripHighlight
            // 
            this.toolStripHighlight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripHighlight, "toolStripHighlight");
            this.toolStripHighlight.Name = "toolStripHighlight";
            this.toolStripHighlight.Click += new System.EventHandler(this.toolStripHighlight_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.AddButton);
            this.panel1.Controls.Add(this.CancelAddButton);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // AddPropertiesWindow
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.propertyGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AddPropertiesWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.VisibleChanged += new System.EventHandler(this.LoadData);
            ((System.ComponentModel.ISupportInitialize)(this.propertyGrid)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView propertyGrid;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button CancelAddButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Property;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private LAPResourceManager.ResourceControl resourceControl1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripRefresh;
        private System.Windows.Forms.ToolStripButton toolStripHighlight;
        private System.Windows.Forms.Panel panel1;
    }
}