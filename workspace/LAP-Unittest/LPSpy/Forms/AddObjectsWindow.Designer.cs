namespace LPSpy
{
    partial class AddObjectsWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddObjectsWindow));
            this.objectTree = new System.Windows.Forms.TreeView();
            this.btnAddObject = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.resourceControl1 = new LAPResourceManager.ResourceControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // objectTree
            // 
            resources.ApplyResources(this.objectTree, "objectTree");
            this.objectTree.CheckBoxes = true;
            this.objectTree.Name = "objectTree";
            this.objectTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.objectTree_AfterSelect);
            // 
            // btnAddObject
            // 
            resources.ApplyResources(this.btnAddObject, "btnAddObject");
            this.btnAddObject.Name = "btnAddObject";
            this.btnAddObject.UseVisualStyleBackColor = true;
            this.btnAddObject.Click += new System.EventHandler(this.btnAddObject_Click);
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
            this.resourceControl1.UIComponentName = "LPSpy.AddObjectsWindow";
            this.resourceControl1.reInitResManger(ref resources);
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.listView1);
            this.panel1.Controls.Add(this.btnAddObject);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Name = "panel1";
            // 
            // listView1
            // 
            resources.ApplyResources(this.listView1, "listView1");
            this.listView1.Name = "listView1";
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listView1_ItemChecked);
            // 
            // columnName
            // 
            resources.ApplyResources(this.columnName, "columnName");
            // 
            // columnValue
            // 
            resources.ApplyResources(this.columnValue, "columnValue");
            // 
            // AddObjectsWindow
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.objectTree);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AddObjectsWindow";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AddObjectsWindow_FormClosed);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView objectTree;
        private System.Windows.Forms.Button btnAddObject;
        private System.Windows.Forms.Button btnCancel;
        private LAPResourceManager.ResourceControl resourceControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnName;
        private System.Windows.Forms.ColumnHeader columnValue;
    }
}