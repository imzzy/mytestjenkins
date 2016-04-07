using LPReplayCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LPSpy
{
    public class TestObjectPropertyGrid: PropertyGrid
    {
        private ContextMenuStrip propertyContextMenu;
        private System.ComponentModel.IContainer components;
        private ToolStripMenuItem mnuPropertyRemove;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.propertyContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuPropertyRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.propertyContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // propertyContextMenu
            // 
            this.propertyContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuPropertyRemove});
            this.propertyContextMenu.Name = "propertyContextMenu";
            this.propertyContextMenu.Size = new System.Drawing.Size(166, 26);


            // 
            // mnuPropertyRemove
            // 
            this.mnuPropertyRemove.Name = "mnuPropertyRemove";
            this.mnuPropertyRemove.Size = new System.Drawing.Size(165, 22);
            this.mnuPropertyRemove.Text = "Remove Property";
            this.mnuPropertyRemove.Click += new EventHandler(this.mnuPropertyRemove_Click);
            this.propertyContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            InitializeComponent();
        }


        public void mnuPropertyRemove_Click(object sender, EventArgs e)
        {
            string key = this.SelectedGridItem.PropertyDescriptor.Name;
            TestObjectNurse nurseObject = (TestObjectNurse)this.Tag;
            if (SpyWindowHelper.DeleteSelectedProperties(key, nurseObject.TestObject))
            {
                SetTestObject(nurseObject);

                AppEnvironment.SetModelChanged(true);
            }

        }

        public void SetTestObject(TestObjectNurse testNurse)
        {
            if (testNurse == null)
            {
                this.SelectedObject = null;
                return;
            }
            TestObjectPropertyBag propertyBag = this.SelectedObject as TestObjectPropertyBag;
            if (propertyBag != null)
            {
                //dispose the old object
                propertyBag.Dispose();
            }
            propertyBag = new TestObjectPropertyBag(testNurse);
            propertyBag.PropertyChanged += () => { AppEnvironment.SetModelChanged(true); };
            this.SelectedObject = propertyBag;
            this.Tag = testNurse; //cache5 it for use later (editing properties)

        }

        public void MouseUpHandler(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right && this.SelectedGridItem != null && this.SelectedGridItem.PropertyDescriptor != null)
            {// the user right clicked on a property to see the context menu: 
                try
                {
                    mnuPropertyRemove.Enabled = this.SelectedGridItem.PropertyDescriptor.Category == "Identifying Properties";
                    mnuPropertyRemove.Text = "Remove ";

                    mnuPropertyRemove.Text += " " + this.SelectedGridItem.PropertyDescriptor.DisplayName;
                    propertyContextMenu.Show(this, PointToClient(MousePosition));
                }
                catch
                {
                }
            }
        }
    }


    #region PropertyGridMessageFilter
    /// <summary>
    /// This is the only way to determine if there was a mouse up event on a property in the property grid
    /// </summary>
    public class PropertyGridMessageFilter : IMessageFilter
    {
        /// <summary>
        /// The control to monitor
        /// </summary>
        public Control Control;

        public MouseEventHandler MouseUp;

        public PropertyGridMessageFilter(Control c, MouseEventHandler meh)
        {
            this.Control = c;
            MouseUp = meh;
        }

        #region IMessageFilter Members

        public bool PreFilterMessage(ref Message m)
        {
            if (!this.Control.IsDisposed && m.HWnd == this.Control.Handle && MouseUp != null)
            {
                MouseButtons mb = MouseButtons.None;

                switch (m.Msg)
                {
                    case 0x0202:/*WM_LBUTTONUP, see winuser.h*/
                        mb = MouseButtons.Left;
                        break;
                    case 0x0205:/*WM_RBUTTONUP*/
                        mb = MouseButtons.Right;
                        break;
                }

                if (mb != MouseButtons.None)
                {
                    MouseEventArgs e = new MouseEventArgs(mb, 1, m.LParam.ToInt32() & 0xFFff, m.LParam.ToInt32() >> 16, 0);

                    // you can visit these pages to understand where the above formulas came from 
                    // http://msdn.microsoft.com/library/default.asp?url=/library/en-us/winui/winui/windowsuserinterface/userinput/mouseinput/mouseinputreference/mouseinputmessages/wm_lbuttonup.asp
                    // http://msdn.microsoft.com/library/default.asp?url=/library/en-us/winui/winui/windowsuserinterface/windowing/windows/windowreference/windowmacros/get_x_lparam.asp

                    MouseUp(Control, e);
                }
            }
            return false;
        }

        #endregion
    }
    #endregion PropertyGridMessageFilter
}
