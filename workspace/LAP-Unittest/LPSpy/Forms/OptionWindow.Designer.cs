namespace LPSpy
{
    partial class OptionWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionWindow));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.resourceControl1 = new LAPResourceManager.ResourceControl();
            this.highlightColorSelector = new LPSpy.ColorSelector();
            this.lblHighlightColor = new System.Windows.Forms.Label();
            this.chkCaptureScreenshots = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            resources.ApplyResources(this.btnOk, "btnOk");
            this.btnOk.Name = "btnOk";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // Must to set the BaseName property which is use to get the resource file name.
            // MLUResManager is used to set the custom resource file which in the another resource.dll.
            // 
            // resourceControl1
            // 
            this.resourceControl1.ResAssemblyName = "LAPResources";
            this.resourceControl1.UIComponentName = "LPSpy.OptionWindow";
            this.resourceControl1.reInitResManger(ref resources);
            // 
            // highlightColorSelector
            // 
            this.highlightColorSelector.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.highlightColorSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.highlightColorSelector.FormattingEnabled = true;
            resources.ApplyResources(this.highlightColorSelector, "highlightColorSelector");
            this.highlightColorSelector.Name = "highlightColorSelector";
            this.highlightColorSelector.SelectedValueChanged += new System.EventHandler(this.highlightColorSelector_SelectedValueChanged);
            // 
            // lblHighlightColor
            // 
            resources.ApplyResources(this.lblHighlightColor, "lblHighlightColor");
            this.lblHighlightColor.Name = "lblHighlightColor";
            // 
            // chkCaptureScreenshots
            // 
            resources.ApplyResources(this.chkCaptureScreenshots, "chkCaptureScreenshots");
            this.chkCaptureScreenshots.Name = "chkCaptureScreenshots";
            this.chkCaptureScreenshots.UseVisualStyleBackColor = true;
            this.chkCaptureScreenshots.CheckedChanged += new System.EventHandler(this.chkCaptureScreenshots_CheckedChanged);
            // 
            // OptionWindow
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkCaptureScreenshots);
            this.Controls.Add(this.lblHighlightColor);
            this.Controls.Add(this.highlightColorSelector);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "OptionWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LAPResourceManager.ResourceControl resourceControl1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        internal ColorSelector highlightColorSelector;
        private System.Windows.Forms.Label lblHighlightColor;
        internal System.Windows.Forms.CheckBox chkCaptureScreenshots;
    }
}