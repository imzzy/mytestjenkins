using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LPSpy
{
    //public class LAPSize
    //{
    //    public LAPSize(SizeF sf)
    //    {
    //        this.sf = sf;
    //    }
    //   public SizeF sf{ get; set; } 
    //}
    public partial class LAPListViewControl : ChkBoxHeaderListView
    {
        public LAPListViewControl()
        {
            this.OwnerDraw = true;
            InitializeComponent();
        }

        private const int WM_PAINT=0x000F;
        private const int WM_SETCURSOR = 0x00200; 
        protected override void WndProc(ref Message m) 
        {
            switch (m.Msg)
            {
                case WM_PAINT:
                    {
                        foreach (Control control in this.Controls)
                        {
                            if (control.Name.IndexOf("linkLabel") >= 0)
                            {
                                control.Visible = false;					// make sure the controls that aren't visible aren't shown
                            }
                        }
                    }
                    break;
                default:
                    break;
        
            }
            base.WndProc(ref m);
        }

        /// <summary>
        /// http://stackoverflow.com/questions/1778600/listview-header-check-box
        /// </summary>
        /// <param name="e"></param>
        protected override void OnDrawSubItem(DrawListViewSubItemEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0:
                    {
                        e.DrawDefault = true;
                    }
                    break;
                case 1:
                    {
                        LinkLabel linkLabel = e.SubItem.Tag as LinkLabel;
                        if (!this.Controls.Contains(linkLabel))
                        {
                            linkLabel.AutoSize = true;
                            this.Controls.Add(linkLabel);
                            linkLabel.Tag = e.Item;
                        }
                        if ((e.ItemState & ListViewItemStates.Selected) != 0)
                        {
                            linkLabel.BackColor = SystemColors.Highlight;
                            e.Graphics.SetClip(e.Bounds);
                            using (SolidBrush brush = new SolidBrush(SystemColors.Highlight))
                            {
                                e.Graphics.FillRectangle(brush, e.Bounds);
                            }
                        }
                        else
                            linkLabel.BackColor = this.BackColor;
                        linkLabel.Location = new System.Drawing.Point(e.SubItem.Bounds.X, e.SubItem.Bounds.Y + 5);
                        linkLabel.Visible = true;
                    }
                    break;
                case 2:
                    {
                        if ((e.ItemState & ListViewItemStates.Selected) != 0)
                        {
                            // Draw the background and focus rectangle for a selected item.
                            e.Graphics.SetClip(e.Bounds);
                            using (SolidBrush brush = new SolidBrush(SystemColors.Highlight))
                            {
                                e.Graphics.FillRectangle(brush, e.Bounds);
                            }
                        }
                        using (StringFormat sf = new StringFormat())
                        {
                            sf.LineAlignment = StringAlignment.Center;
                            e.Graphics.DrawString(e.SubItem.Text,
                                     this.Font, Brushes.Black, e.Bounds, sf);
                        };
                        e.DrawDefault = false;
                    }
                    break;
                default:
                    break;
            }
            base.OnDrawSubItem(e);
        }

        protected override void OnDrawColumnHeader(DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true;
            base.OnDrawColumnHeader(e);
            return;
        }

        public int[] CheckedIndicesArray
        {
            get
            {
                return this.CheckedIndices.Cast<int>().ToArray();
            }
        }

    }
}
