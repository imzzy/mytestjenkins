using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LPCommon;

namespace LPSpy
{
    public partial class ChkBoxHeaderListView : ListView
    {
        private const int WM_CREATE = 0x0001;
        private readonly Rectangle _rcheaderCheckBox = new Rectangle()
        {
            X = 2,
            Y = 2,
            Width = 16,
            Height = 16
        };

        private CheckState checkboxStatus = CheckState.Unchecked;
        public ChkBoxHeaderListView()
        {
            InitializeComponent();
        }

        protected override void OnCreateControl()
        {
            //Get the header control handle
            IntPtr header = UnsafeNativeMethods.SendMessage(this.Handle,
                        (0x1000 + 31), IntPtr.Zero, IntPtr.Zero);

            UInt32 style = UnsafeNativeMethods.GetWindowLong(header, NativeMethods.GWL_STYLE);
            style |= (UInt32)NativeMethods.WS_CLIPSIBLINGS;
            style |= (UInt32)NativeMethods.WS_CLIPCHILDREN;
            UnsafeNativeMethods.SetWindowLong(header, NativeMethods.GWL_STYLE, style);
            SafeNativeMethods.EnableWindow(header, false);

            style = UnsafeNativeMethods.GetWindowLong(this.Handle, NativeMethods.GWL_STYLE);
            style |= (UInt32)NativeMethods.WS_CLIPSIBLINGS;
            style |= (UInt32)NativeMethods.WS_CLIPCHILDREN;
            UnsafeNativeMethods.SetWindowLong(this.Handle, NativeMethods.GWL_STYLE, style);

            CheckBox checkbox = this.Controls["HeaderCheckBox"] as CheckBox;
            if (checkbox == null)
            {
                checkbox = new CheckBox();
                checkbox.Name = "HeaderCheckBox";
                checkbox.Click += new EventHandler(btnChkAllItems_Click);
                checkbox.BackColor = this.BackColor;
                //          checkbox.UseVisualStyleBackColor = true;
                checkbox.Size = new Size(_rcheaderCheckBox.Width, _rcheaderCheckBox.Height);
                checkbox.Location = new System.Drawing.Point(3, 3);
                checkbox.Visible = true;
                checkbox.BringToFront();
                Controls.Add(checkbox);
            }
            base.OnCreateControl();
        }

     
        private void CheckOrUncheckAllItems(bool Check = true)
        {
            this.BeginUpdate();
            ListView.ListViewItemCollection lvItemCollection = this.Items;
            foreach (ListViewItem lvItem in lvItemCollection)
            {
                lvItem.Checked = Check;
            }
            this.EndUpdate();
        }

        private void btnChkAllItems_Click(object sender, EventArgs e)
        {
            CheckBox checkbox = sender as CheckBox;
            if (checkboxStatus == CheckState.Unchecked)
            {
                checkboxStatus = CheckState.Checked;
            }
            else if (checkboxStatus == CheckState.Checked)
            {
                checkboxStatus = CheckState.Unchecked;
            }
            CheckOrUncheckAllItems(checkboxStatus == CheckState.Checked);
        }
    }
}
