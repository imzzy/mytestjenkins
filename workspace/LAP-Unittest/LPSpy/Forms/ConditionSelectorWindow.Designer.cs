namespace LPSpy
{
    partial class ConditionSelectorWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConditionSelectorWindow));
            this.listViewConditions = new System.Windows.Forms.ListView();
            this.colConditionName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colConditionValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.btnHighlight = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.resourceControl1 = new LAPResourceManager.ResourceControl();
            this.SuspendLayout();
            // 
            // listViewConditions
            // 
            this.listViewConditions.CheckBoxes = true;
            this.listViewConditions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colConditionName,
            this.colConditionValue});
            this.listViewConditions.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("listViewConditions.Items"))),
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("listViewConditions.Items1")))});
            resources.ApplyResources(this.listViewConditions, "listViewConditions");
            this.listViewConditions.Name = "listViewConditions";
            this.listViewConditions.UseCompatibleStateImageBehavior = false;
            this.listViewConditions.View = System.Windows.Forms.View.List;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // btnHighlight
            // 
            resources.ApplyResources(this.btnHighlight, "btnHighlight");
            this.btnHighlight.Name = "btnHighlight";
            this.btnHighlight.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // Must to set the BaseName property which is use to get the resource file name.
            // MLUResManager is used to set the custom resource file which in the another resource.dll.
            // 
            // resourceControl1
            // 
            this.resourceControl1.ResAssemblyName = "LAPResources";
            this.resourceControl1.UIComponentName = "LPSpy.ConditionSelectorWindow";
            this.resourceControl1.reInitResManger(ref resources);
            // 
            // ConditionSelectorWindow
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnHighlight);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listViewConditions);
            this.Name = "ConditionSelectorWindow";
            this.Load += new System.EventHandler(this.ConditionSelectorWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewConditions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnHighlight;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ColumnHeader colConditionName;
        private System.Windows.Forms.ColumnHeader colConditionValue;
        private LAPResourceManager.ResourceControl resourceControl1;

    }
}