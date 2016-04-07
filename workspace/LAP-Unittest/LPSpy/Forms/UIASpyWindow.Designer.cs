namespace LPSpy
{
    partial class UIASpyWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UIASpyWindow));
            this.resourceControl1 = new LAPResourceManager.ResourceControl();
            this.treeObjects = new System.Windows.Forms.TreeView();
            this.propertiesTable = new System.Windows.Forms.DataGridView();
            this.Properties = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.panelLower = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnPin = new System.Windows.Forms.ToolStripButton();
            this.btnSpy = new System.Windows.Forms.ToolStripButton();
            this.btnHighlight = new System.Windows.Forms.ToolStripButton();
            this.panelUpper = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.propertiesTable)).BeginInit();
            this.panelLower.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panelUpper.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // Must to set the BaseName property which is use to get the resource file name.
            // MLUResManager is used to set the custom resource file which in the another resource.dll.
            // 
            // resourceControl1
            // 
            this.resourceControl1.ResAssemblyName = "LAPResources";
            this.resourceControl1.UIComponentName = "LPSpy.UIASpyWindow";
            this.resourceControl1.reInitResManger(ref resources);
            // 
            // treeObjects
            // 
            resources.ApplyResources(this.treeObjects, "treeObjects");
            this.treeObjects.Name = "treeObjects";
            // 
            // propertiesTable
            // 
            resources.ApplyResources(this.propertiesTable, "propertiesTable");
            this.propertiesTable.AllowUserToAddRows = false;
            this.propertiesTable.AllowUserToDeleteRows = false;
            this.propertiesTable.AllowUserToResizeColumns = false;
            this.propertiesTable.AllowUserToResizeRows = false;
            this.propertiesTable.BackgroundColor = System.Drawing.SystemColors.Window;
            this.propertiesTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.propertiesTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Properties,
            this.Value});
            this.propertiesTable.Name = "propertiesTable";
            this.propertiesTable.ReadOnly = true;
            this.propertiesTable.RowHeadersVisible = false;
            this.propertiesTable.RowTemplate.Height = 24;
            // 
            // Properties
            // 
            this.Properties.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.Properties, "Properties");
            this.Properties.Name = "Properties";
            this.Properties.ReadOnly = true;
            this.Properties.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Value
            // 
            this.Value.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.Value, "Value");
            this.Value.Name = "Value";
            this.Value.ReadOnly = true;
            this.Value.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // panelLower
            // 
            resources.ApplyResources(this.panelLower, "panelLower");
            this.panelLower.Controls.Add(this.toolStrip1);
            this.panelLower.Controls.Add(this.treeObjects);
            this.panelLower.Name = "panelLower";
            // 
            // toolStrip1
            // 
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPin,
            this.btnSpy,
            this.btnHighlight});
            this.toolStrip1.Name = "toolStrip1";
            // 
            // btnPin
            // 
            resources.ApplyResources(this.btnPin, "btnPin");
            this.btnPin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPin.Name = "btnPin";
            this.btnPin.Click += new System.EventHandler(this.btnPin_Click);
            // 
            // btnSpy
            // 
            resources.ApplyResources(this.btnSpy, "btnSpy");
            this.btnSpy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSpy.Name = "btnSpy";
            this.btnSpy.Click += new System.EventHandler(this.btnSpy_Click);
            // 
            // btnHighlight
            // 
            resources.ApplyResources(this.btnHighlight, "btnHighlight");
            this.btnHighlight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnHighlight.Name = "btnHighlight";
            this.btnHighlight.Click += new System.EventHandler(this.btnHighlight_Click);
            // 
            // panelUpper
            // 
            resources.ApplyResources(this.panelUpper, "panelUpper");
            this.panelUpper.Controls.Add(this.propertiesTable);
            this.panelUpper.Controls.Add(this.label2);
            this.panelUpper.Name = "panelUpper";
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.panelUpper, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelLower, 0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // UIASpyWindow
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UIASpyWindow";
            this.Resize += new System.EventHandler(this.UIASpyWindow_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.propertiesTable)).EndInit();
            this.panelLower.ResumeLayout(false);
            this.panelLower.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelUpper.ResumeLayout(false);
            this.panelUpper.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private LAPResourceManager.ResourceControl resourceControl1;
        private System.Windows.Forms.TreeView treeObjects;
        private System.Windows.Forms.DataGridView propertiesTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Properties;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelLower;
        private System.Windows.Forms.Panel panelUpper;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnHighlight;
        private System.Windows.Forms.ToolStripButton btnPin;
        private System.Windows.Forms.ToolStripButton btnSpy;
    }
}