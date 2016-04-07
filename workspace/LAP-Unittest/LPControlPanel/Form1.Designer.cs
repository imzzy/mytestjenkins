namespace LPControlPanel
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnRun = new System.Windows.Forms.Button();
            this.txtScript = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.resControl = new LAPResourceManager.ResourceControl();
            this.SuspendLayout();
            // 
            // btnRun
            // 
            resources.ApplyResources(this.btnRun, "btnRun");
            this.btnRun.Name = "btnRun";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // txtScript
            // 
            resources.ApplyResources(this.txtScript, "txtScript");
            this.txtScript.Name = "txtScript";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // Must to set the BaseName property which is use to get the resource file name.
            // MLUResManager is used to set the custom resource file which in the another resource.dll.
            // 
            // resControl
            // 
            this.resControl.ResAssemblyName = "LAPResources";
            this.resControl.UIComponentName = "LPControlPanel.Form1";
            this.resControl.reInitResManger(ref resources);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtScript);
            this.Controls.Add(this.btnRun);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.TextBox txtScript;
        private System.Windows.Forms.Label label1;
        private LAPResourceManager.ResourceControl resControl;
    }
}