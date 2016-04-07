using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LPSpy
{
    /// <summary>
    /// http://stackoverflow.com/questions/4080719/placing-images-and-strings-with-a-c-sharp-combobox
    /// </summary>
    class ColorSelector : ComboBox
    {
        public ColorSelector()
        {
            DrawMode = DrawMode.OwnerDrawFixed;
            DropDownStyle = ComboBoxStyle.DropDownList;
        }

        // Draws the items into the ColorSelector object
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();

            if (e.Index >= 0 && e.Index < Items.Count)
            {
                DropDownItem item = new DropDownItem(Items[e.Index].ToString());

                e.Graphics.DrawImage(item.Image, e.Bounds.Left, e.Bounds.Top);

                e.Graphics.DrawString(item.Value, e.Font, new SolidBrush(e.ForeColor), e.Bounds.Left + item.Image.Width, e.Bounds.Top + 2);
            }

            base.OnDrawItem(e);
        }

        internal bool SelectColor(Color color)
        {
            string colorName = color.Name;

            int i = 0;
            foreach (string item in this.Items)
            {
                if (item == colorName)
                {
                    this.SelectedIndex = i;
                    return true;
                }
                ++i;
            }
            return false;
        }

        public Color ColorSelected
        {
            get
            {
                if (this.SelectedIndex < 0) return Color.Red; //default color
                return Color.FromName((string)this.Items[this.SelectedIndex]);
            }
        }
    }

    public class DropDownItem
    {
        public string Value { get; set; }

        public Image Image { get; set; }

        public DropDownItem()
            : this("", Color.Empty)
        { }

        public DropDownItem(string val, Color color)
        {
            Value = val;
            Image = new Bitmap(16, 16);
            using (Graphics g = Graphics.FromImage(Image))
            {
                using (Brush b = new SolidBrush(color))
                {
                    g.DrawRectangle(Pens.White, 0, 0, Image.Width, Image.Height);
                    g.FillRectangle(b, 1, 1, Image.Width - 1, Image.Height - 1);
                }
            }
        }

        public DropDownItem(string val)
        {
            Value = val;
            Image = new Bitmap(16, 16);
            using (Graphics g = Graphics.FromImage(Image))
            {
                using (Brush b = new SolidBrush(Color.FromName(val)))
                {
                    g.DrawRectangle(Pens.White, 0, 0, Image.Width, Image.Height);
                    g.FillRectangle(b, 1, 1, Image.Width - 1, Image.Height - 1);
                }
            }
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
