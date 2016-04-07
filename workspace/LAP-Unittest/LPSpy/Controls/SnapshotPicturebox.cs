using LPCommon;
using LPReplayCore;
using LPReplayCore.Interfaces;
using LPReplayCore.UIA;
using LPReplayCore.Web;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LPSpy
{
    public class SnapshotPictureBox: PictureBox
    {
        Rectangle _borderRect = Rectangle.Empty;

        Pen _borderPen = new Pen(Color.Red, 1);
        Pen thickPen = new Pen(Color.FromArgb(255, 0, 255, 0), 3);

        List<Rectangle> _virtualRects = new List<Rectangle>();

#if TEST
        internal Rectangle BorderRect
        {
            get
            {
                return _borderRect;
            }
        }
#endif

        public SnapshotPictureBox()
        {
            DrawBorder = false;
        }

        [Browsable(true)]
        [DefaultValue(false)]
        public bool DrawBorder
        {
            get;
            set;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            Graphics g = pe.Graphics;

            if (DrawBorder && Rectangle.Empty != _borderRect)
            {
                DrawRect(g, _borderRect, _borderPen);
            }

            foreach (Rectangle rect in _virtualRects)
            {
                DrawRect(g, rect, thickPen);
            }
        }

        private void DrawRect(Graphics g, Rectangle rect, Pen drawPen)
        {
            if (rect.Width == 0 || rect.Height == 0) return;

            g.DrawRectangle(drawPen, rect);
        }

        public TestObjectNurse TestObject
        {
            set
            {
                if (value == null)
                {
                    goto Null_Image;
                }

                TestObjectNurse nurseObject = value;
                TestObjectNurse uiaNurseObject = null;

                _virtualRects.Clear();

                if (nurseObject.TestObject is VirtualTestObject)
                {
                    uiaNurseObject = nurseObject.ParentNurse;
                    VirtualTestObject testObject = nurseObject.TestObject as VirtualTestObject;
                    
                    _virtualRects.Add(testObject.BoundingRectangle);
                }
                else if (nurseObject.TestObject is UIATestObject)
                {
                    uiaNurseObject = nurseObject;
                }
                else if (nurseObject.TestObject is SETestObject)
                {
                    uiaNurseObject = nurseObject;
                }
                else
                {
                    Debug.Assert(false, "Invalidate test object detected");
                    goto Null_Image;
                }

                string imageFile = uiaNurseObject.ImageFile;
                if (!string.IsNullOrEmpty(imageFile))
                {
                    ReadImageFile(imageFile);
                    return;
                }
            Null_Image:
                this.Image = null;
                _borderRect = Rectangle.Empty;
                
            }
        }

        private void ReadImageFile(string imageFile)
        {
            int margin = Snapshot.Margin;

            string path = AppEnvironment.GetModelResourceFilePath(imageFile);

            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                this.Image = System.Drawing.Image.FromStream(fs);

                Debug.Assert(this.Image == null || this.Image.Width >= margin);
                Debug.Assert(this.Image == null || this.Image.Height >= margin);
                _borderRect = new Rectangle(margin, margin,
                    Math.Max(0, this.Image.Width - 2 * margin),
                    Math.Max(0, this.Image.Height - 2 * margin));
            }
        }

#if TEST
        public Rectangle[] VirtualRectangles
        {
            get
            {
                return _virtualRects.ToArray();
            }
        }
#endif

    }
}
