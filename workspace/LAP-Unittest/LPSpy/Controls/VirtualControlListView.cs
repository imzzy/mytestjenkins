using LPReplayCore.UIA;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LPSpy
{
    public class VirtualControlListView: ListView
    {
        public VirtualControlListView()
        {
            this.View = System.Windows.Forms.View.Details;
            
            System.Windows.Forms.ColumnHeader controlName;
            System.Windows.Forms.ColumnHeader left;
            System.Windows.Forms.ColumnHeader top;

            controlName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            left = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            top = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));

            controlName.Text = "Control Name";
            controlName.Width = 150;
            // 
            // Left
            // 
            left.Text = "Left";
            // 
            // Top
            // 
            top.Text = "Top";
            // 

            this.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            controlName,
            left,
            top});
            
        }
        public void AddControl(VirtualTestObject control)
        {
            if (string.IsNullOrEmpty(control.NodeName))
            {
                throw new ArgumentException("Control name cannot be empty");
            }
            VirtualTestObject findResult = FindItem(control.NodeName);
            if (findResult != null)
            {
                RemoveControl(findResult.NodeName);
            }

            string controlName = control.NodeName;
            Rectangle rect = control.BoundingRectangle;

            ListViewItem item = new ListViewItem(new string[] { controlName, rect.Left.ToString(), rect.Height.ToString() });

            item.Tag = control;
            this.Items.Add(item);

        }

        public void RemoveControl(string controlName)
        {
            foreach (ListViewItem item in this.Items)
            {
                if (item.Text == controlName)
                {
                    this.Items.Remove(item);
                    break;
                }
            }
        }

        public VirtualTestObject FindItem(string controlName)
        {
            foreach (ListViewItem item in this.Items)
            {
                if (item.Text == controlName)
                {
                    return (VirtualTestObject)item.Tag;
                }
            }
            return null;
        }

        public List<VirtualTestObject> GetAllItems()
        {
            List<VirtualTestObject> controls = new List<VirtualTestObject>(this.Items.Count);
            foreach(ListViewItem item in this.Items)
            {
                controls.Add((VirtualTestObject)item.Tag);
            }
            return controls;
        }
    }
}
