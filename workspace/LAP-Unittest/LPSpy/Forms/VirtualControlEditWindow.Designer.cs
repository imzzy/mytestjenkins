namespace LPSpy
{
    partial class VirtualControlEditWindow
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
            this.txtLeft = new System.Windows.Forms.TextBox();
            this.txtTop = new System.Windows.Forms.TextBox();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.lblLeft = new System.Windows.Forms.Label();
            this.lblTop = new System.Windows.Forms.Label();
            this.lblWidth = new System.Windows.Forms.Label();
            this.lblHeight = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtControlName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.virtualControlListView1 = new LPSpy.VirtualControlListView();
            this.btnHighlight = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnHighlightAll = new System.Windows.Forms.Button();
            this.btnDone = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtLeft
            // 
            this.txtLeft.Location = new System.Drawing.Point(112, 61);
            this.txtLeft.Name = "txtLeft";
            this.txtLeft.Size = new System.Drawing.Size(50, 20);
            this.txtLeft.TabIndex = 0;
            this.txtLeft.TextChanged += new System.EventHandler(this.PositionChanged);
            // 
            // txtTop
            // 
            this.txtTop.Location = new System.Drawing.Point(112, 99);
            this.txtTop.Name = "txtTop";
            this.txtTop.Size = new System.Drawing.Size(50, 20);
            this.txtTop.TabIndex = 0;
            this.txtTop.TextChanged += new System.EventHandler(this.PositionChanged);
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(230, 60);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(50, 20);
            this.txtWidth.TabIndex = 0;
            this.txtWidth.TextChanged += new System.EventHandler(this.PositionChanged);
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(230, 98);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(50, 20);
            this.txtHeight.TabIndex = 0;
            this.txtHeight.TextChanged += new System.EventHandler(this.PositionChanged);
            // 
            // lblLeft
            // 
            this.lblLeft.AutoSize = true;
            this.lblLeft.Location = new System.Drawing.Point(68, 64);
            this.lblLeft.Name = "lblLeft";
            this.lblLeft.Size = new System.Drawing.Size(28, 13);
            this.lblLeft.TabIndex = 1;
            this.lblLeft.Text = "Left:";
            // 
            // lblTop
            // 
            this.lblTop.AutoSize = true;
            this.lblTop.Location = new System.Drawing.Point(68, 102);
            this.lblTop.Name = "lblTop";
            this.lblTop.Size = new System.Drawing.Size(29, 13);
            this.lblTop.TabIndex = 1;
            this.lblTop.Text = "Top:";
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Location = new System.Drawing.Point(176, 64);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(38, 13);
            this.lblWidth.TabIndex = 1;
            this.lblWidth.Text = "Width:";
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(173, 103);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(41, 13);
            this.lblHeight.TabIndex = 1;
            this.lblHeight.Text = "Height:";
            // 
            // btnAdd
            // 
            this.btnAdd.Enabled = false;
            this.btnAdd.Location = new System.Drawing.Point(15, 140);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(110, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add Control";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtControlName
            // 
            this.txtControlName.Location = new System.Drawing.Point(101, 23);
            this.txtControlName.Name = "txtControlName";
            this.txtControlName.Size = new System.Drawing.Size(180, 20);
            this.txtControlName.TabIndex = 3;
            this.txtControlName.TextChanged += new System.EventHandler(this.txtControlName_TextChanged);
            this.txtControlName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtControlName_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Control Name:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(312, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(633, 536);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.LoadCompleted += new System.ComponentModel.AsyncCompletedEventHandler(this.pictureBox1_LoadCompleted);
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.virtualControlListView1);
            this.panel1.Controls.Add(this.btnHighlight);
            this.panel1.Controls.Add(this.btnDone);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnRemove);
            this.panel1.Controls.Add(this.btnHighlightAll);
            this.panel1.Controls.Add(this.txtTop);
            this.panel1.Controls.Add(this.txtLeft);
            this.panel1.Controls.Add(this.txtControlName);
            this.panel1.Controls.Add(this.txtWidth);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.txtHeight);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblLeft);
            this.panel1.Controls.Add(this.lblHeight);
            this.panel1.Controls.Add(this.lblTop);
            this.panel1.Controls.Add(this.lblWidth);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(312, 536);
            this.panel1.TabIndex = 5;
            // 
            // virtualControlListView1
            // 
            this.virtualControlListView1.Location = new System.Drawing.Point(14, 191);
            this.virtualControlListView1.Name = "virtualControlListView1";
            this.virtualControlListView1.Size = new System.Drawing.Size(266, 260);
            this.virtualControlListView1.TabIndex = 7;
            this.virtualControlListView1.UseCompatibleStateImageBehavior = false;
            this.virtualControlListView1.View = System.Windows.Forms.View.Details;
            this.virtualControlListView1.SelectedIndexChanged += new System.EventHandler(this.virtualControlListView1_SelectedIndexChanged);
            this.virtualControlListView1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.virtualControlListView1_KeyUp);
            // 
            // btnHighlight
            // 
            this.btnHighlight.Location = new System.Drawing.Point(170, 467);
            this.btnHighlight.Name = "btnHighlight";
            this.btnHighlight.Size = new System.Drawing.Size(110, 23);
            this.btnHighlight.TabIndex = 5;
            this.btnHighlight.Text = "Highlight";
            this.btnHighlight.UseVisualStyleBackColor = true;
            this.btnHighlight.Click += new System.EventHandler(this.btnHighlight_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(170, 501);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(170, 140);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(110, 23);
            this.btnRemove.TabIndex = 5;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnHighlightAll_Click);
            // 
            // btnHighlightAll
            // 
            this.btnHighlightAll.Location = new System.Drawing.Point(15, 467);
            this.btnHighlightAll.Name = "btnHighlightAll";
            this.btnHighlightAll.Size = new System.Drawing.Size(110, 23);
            this.btnHighlightAll.TabIndex = 5;
            this.btnHighlightAll.Text = "Mark All";
            this.btnHighlightAll.UseVisualStyleBackColor = true;
            this.btnHighlightAll.Click += new System.EventHandler(this.btnHighlightAll_Click);
            // 
            // btnDone
            // 
            this.btnDone.Location = new System.Drawing.Point(15, 501);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(110, 23);
            this.btnDone.TabIndex = 5;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // VirtualControlEditWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 536);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Name = "VirtualControlEditWindow";
            this.Text = "Virtual Control Edit Window";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtLeft;
        private System.Windows.Forms.TextBox txtTop;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.Label lblLeft;
        private System.Windows.Forms.Label lblTop;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtControlName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnHighlightAll;
        private VirtualControlListView virtualControlListView1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnHighlight;
        private System.Windows.Forms.Button btnDone;

    }
}

