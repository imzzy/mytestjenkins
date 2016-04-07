using LPReplayCore;
using LPReplayCore.UIA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace LPSpy
{
    
    /// <summary>
    /// http://stackoverflow.com/questions/2442105/drag-and-drop-rectangle-in-c-sharp
    /// </summary>
    public partial class VirtualControlEditWindow : Form
    {
        public VirtualControlEditWindow()
        {
            InitializeComponent();

            this.DoubleBuffered = true;

        }

        UIATestObject _parentControl;

        public bool _drag = false;
        Rectangle _rect = new Rectangle(0, 0, 0, 0);

        List<Rectangle> _selectedRects = new List<Rectangle>();

        Pen thickPen = new Pen(Color.FromArgb(255, 0, 255, 0), 3);
        Pen thinPen = new Pen(Color.FromArgb(255, 0, 255, 0), 1);
        Pen borderPen = new Pen(Color.Red, 1);

        Rectangle _borderRect = Rectangle.Empty;

        const int threshold = 15; //below 15 pixels, will use thin pen to draw

        #region Public Methods

        public void SetImagePath(string path)
        {
            pictureBox1.ImageLocation = path;
        }

        public void SetImage(Image stream)
        {
            pictureBox1.Image = stream;
        }

        public VirtualTestObject[] VirtualControls
        {
            get
            {
                List<VirtualTestObject> controlList = virtualControlListView1.GetAllItems();
                return controlList.ToArray();
            }
            set
            {
                foreach (VirtualTestObject control in value)
                {
                    virtualControlListView1.AddControl(control);
                }
            }
        }

        public UIATestObject ParentObject
        {
            get
            {
                return _parentControl;
            }
            set
            {
                _parentControl = value;
            }
        }

        public void AddControl(VirtualTestObject control)
        {
            virtualControlListView1.AddControl(control);
        }

        #endregion


        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _rect = new Rectangle(e.X, e.Y, 0, 0);
                Invalidate();
            }

            txtLeft.Text = (Math.Max(0, _rect.Left - 10)).ToString();
            txtTop.Text = (Math.Max(0,_rect.Top - 10)).ToString();

        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            if (_rect.Width == 0 || _rect.Height == 0)
            {
                //reset, because user just click instead of draw circle
                txtLeft.Text = "0";
                txtTop.Text = "0";
                txtWidth.Text = "0";
                txtHeight.Text = "0";
            }
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _rect.Width = e.X - _rect.X;
                _rect.Height = e.Y - _rect.Y;

                pictureBox1.Invalidate();

                txtWidth.Text = Math.Max(0, (_rect.Width - 10)).ToString();
                txtHeight.Text = Math.Max(0, (_rect.Height - 10)).ToString();
            }

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            if (Rectangle.Empty != _borderRect)
            {
                DrawRect(g, _borderRect, borderPen);
            }

            DrawRect(g, _rect);

            foreach(Rectangle rect in _selectedRects)
            {
                DrawRect(g, rect);
            }
        }

        private void DrawRect(Graphics g, Rectangle rect, Pen drawPen = null)
        {
            if (rect.Width == 0 || rect.Height == 0) return;

            Pen pen = drawPen??thickPen;

            if (rect.Width <= threshold || rect.Height <= threshold)
            {
                pen = drawPen??thinPen;
            }

            g.DrawRectangle(pen, rect);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            virtualControlListView1.AddControl(new VirtualTestObject(txtControlName.Text, _rect));
            txtLeft.Text = "";
            txtTop.Text = "";
            txtWidth.Text = "";
            txtHeight.Text = "";
            _rect = Rectangle.Empty;
            pictureBox1.Invalidate();
        }

        private void btnHighlightAll_Click(object sender, EventArgs e)
        {

            bool highlightAll = (btnHighlightAll.Tag == null) || (bool)btnHighlightAll.Tag;

            _selectedRects.Clear();

            if (highlightAll)
            {
                List<VirtualTestObject> virtualControls = virtualControlListView1.GetAllItems();
                _selectedRects.AddRange(virtualControls.ConvertAll(control => control.BoundingRectangle));
            }
            pictureBox1.Invalidate();

            //flip
            btnHighlightAll.Tag = highlightAll = !highlightAll;

            btnHighlightAll.Text = (btnHighlightAll.Text == "Mark All") ? "Unmark All" : "Mark All";
        }


        private void DrawRectangle(Rectangle rect)
        {
            using(Graphics g = this.CreateGraphics())
            {
                Pen pen = thickPen;

                if (_rect.Width <= threshold || _rect.Height <= threshold)
                {
                    pen = thinPen;
                }

                g.DrawRectangle(pen, _rect);
            }
        
        }

        private void txtControlName_TextChanged(object sender, EventArgs e)
        {
            ValidateInput();
        }

        private void PositionChanged(object sender, EventArgs e)
        {
            ValidateInput();
        }

        private void ValidateInput()
        {
            if (string.IsNullOrEmpty(txtControlName.Text)) goto Disable_Button;

            if (_rect.Width == 0 || _rect.Height == 0) goto Disable_Button;

            if (string.IsNullOrEmpty(txtLeft.Text) ||
                string.IsNullOrEmpty(txtTop.Text) ||
                string.IsNullOrEmpty(txtWidth.Text) ||
                string.IsNullOrEmpty(txtHeight.Text)) goto Disable_Button;
            btnAdd.Enabled = true;
            return;

Disable_Button:
            btnAdd.Enabled = false;
                return;
        }

        private void virtualControlListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (virtualControlListView1.SelectedItems.Count == 0) return;

            List<ListViewItem> list = new List<ListViewItem>();

            foreach (ListViewItem item in virtualControlListView1.SelectedItems)
            {
                list.Add(item);
            }
            List<Rectangle> rects = list.ConvertAll(item => ((VirtualTestObject)item.Tag).BoundingRectangle);

            _selectedRects.Clear();
            _selectedRects.AddRange(rects);

            pictureBox1.Invalidate();
        }

        private void txtControlName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAdd_Click(txtControlName, new EventArgs());
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void pictureBox1_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Debug.Assert(pictureBox1.Image == null || pictureBox1.Image.Width > 20);
            Debug.Assert(pictureBox1.Image == null || pictureBox1.Image.Height > 20);
            _borderRect = new Rectangle(10, 10, pictureBox1.Image.Width - 20, pictureBox1.Image.Height - 20);
            pictureBox1.Invalidate();
        }

        private void virtualControlListView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Delete)
            {
                RemoveSelectedItems();
            }
        }

        private void RemoveSelectedItems()
        {
            if (virtualControlListView1.SelectedItems.Count == 0) return;

            List<ListViewItem> list = new List<ListViewItem>();

            foreach (ListViewItem listItem in virtualControlListView1.SelectedItems)
            {
                virtualControlListView1.Items.Remove(listItem);
            }
            _selectedRects.Clear();

            pictureBox1.Invalidate();
        }

        private void btnHighlight_Click(object sender, EventArgs e)
        {
            if (virtualControlListView1.SelectedItems.Count == 0) return;
            VirtualTestObject testObject = (VirtualTestObject)virtualControlListView1.SelectedItems[0].Tag;
            
            UIAHighlight.HighlightVirtualControl(_parentControl.AutomationElement, testObject.BoundingRect);
        }

    }
}
