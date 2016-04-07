using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LPCommon;

namespace LPReplayCore
{
    public class HighlightRectangle: IDisposable
    {
        private Form _bottomForm = new Form();
        private Form _leftForm = new Form();
        private Form _rightForm = new Form();
        private Form _topForm = new Form();

        private Color _color;
        private Rectangle _location;

        private bool _show = false;

        private ToolTip _toolTipBottom;
        private ToolTip _toolTipLeft;
        private ToolTip _toolTipRight;
        private ToolTip _toolTipTop;

        private string _tooltipText;
        private int _width = 2;
        private System.Drawing.Color _highlightColor = ReplayCoreSettings.HighlightColor;

        /// <summary>
        /// _instance is per thread, since form members should be accessed in its own thread
        /// </summary>
        [ThreadStatic]
        private static HighlightRectangle _instance;

        public static HighlightRectangle Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new HighlightRectangle();
                }
                return _instance;
            }
        }

        public HighlightRectangle()
        {
            Form[] formArray = new Form[] { _leftForm, _topForm, _rightForm, _bottomForm };

            foreach (Form form in formArray)
            {
                form.FormBorderStyle = FormBorderStyle.None;
                form.ShowInTaskbar = false;
                form.TopMost = true;
                form.Visible = false;
                form.Left = 0;
                form.Top = 0;
                form.Width = 1;
                form.Height = 1;
                form.Show();
                form.Hide();
                form.Opacity = 0.5;

                UInt32 windowLong = UnsafeNativeMethods.GetWindowLong(form.Handle, -20);
                UnsafeNativeMethods.SetWindowLong(form.Handle, -20, windowLong | 0x80);
            }

            _toolTipLeft = new ToolTip();
            _toolTipTop = new ToolTip();
            _toolTipRight = new ToolTip();
            _toolTipBottom = new ToolTip();

            _toolTipLeft.ShowAlways = true;
            _toolTipTop.ShowAlways = true;
            _toolTipRight.ShowAlways = true;
            _toolTipBottom.ShowAlways = true;
            Color = _highlightColor;
        }

        private void Layout()
        {
            
            SafeNativeMethods.SetWindowPos(_leftForm.Handle, NativeMethods.HWND_TOPMOST, _location.Left - _width, _location.Top, _width, _location.Height, 0x10);
            SafeNativeMethods.SetWindowPos(_topForm.Handle, NativeMethods.HWND_TOPMOST, _location.Left - _width, _location.Top - _width, _location.Width + (2 * _width), _width, 0x10);
            SafeNativeMethods.SetWindowPos(_rightForm.Handle, NativeMethods.HWND_TOPMOST, _location.Left + _location.Width, _location.Top, _width, _location.Height, 0x10);
            SafeNativeMethods.SetWindowPos(_bottomForm.Handle, NativeMethods.HWND_TOPMOST, _location.Left - _width, _location.Top + _location.Height, _location.Width + (2 * _width), _width, 0x10);
            /*
             * inner bound highlight rectangle
            SafeNativeMethods.SetWindowPos(_leftForm.Handle, NativeMethods.HWND_TOPMOST, _location.Left, _location.Top, _width, _location.Height, 0x10);
            SafeNativeMethods.SetWindowPos(_topForm.Handle, NativeMethods.HWND_TOPMOST, _location.Left, _location.Top, _location.Width + (2 * _width), _width, 0x10);
            SafeNativeMethods.SetWindowPos(_rightForm.Handle, NativeMethods.HWND_TOPMOST, _location.Left + _location.Width - _width, _location.Top, _width, _location.Height, 0x10);
            SafeNativeMethods.SetWindowPos(_bottomForm.Handle, NativeMethods.HWND_TOPMOST, _location.Left, _location.Top + _location.Height -_width, _location.Width, _width, 0x10);
            */
        }

        private void Show(bool show)
        {
            if (show)
            {
                SafeNativeMethods.ShowWindow(_leftForm.Handle, 8);
                SafeNativeMethods.ShowWindow(_topForm.Handle, 8);
                SafeNativeMethods.ShowWindow(_rightForm.Handle, 8);
                SafeNativeMethods.ShowWindow(_bottomForm.Handle, 8);
            }
            else
            {
                _leftForm.Hide();
                _topForm.Hide();
                _rightForm.Hide();
                _bottomForm.Hide();
            }
        }

        public Color Color
        {
            set
            {
                if (value == null) return;

                _color = value;
                _leftForm.BackColor = value;
                _topForm.BackColor = value;
                _rightForm.BackColor = value;
                _bottomForm.BackColor = value;
            }
        }

        public Rectangle Location
        {
            set
            {
                _location = value;
                Layout();
            }
        }

        public string ToolTipText
        {
            set
            {
                _tooltipText = value;
                _toolTipLeft.SetToolTip(_leftForm, _tooltipText);
                _toolTipTop.SetToolTip(_topForm, _tooltipText);
                _toolTipRight.SetToolTip(_rightForm, _tooltipText);
                _toolTipBottom.SetToolTip(_bottomForm, _tooltipText);
            }
        }

        public bool Visible
        {
            set
            {
                if (_show != value)
                {
                    _show = value;
                    if (_show)
                    {
                        Layout();
                        Show(true);
                    }
                    else
                    {
                        Show(false);
                    }
                }
            }
            get
            {
                return _show;
            }
        }

        public int Width
        {
            set
            {
                if (_width != value)
                {
                    _width = value;
                    Layout();
                }
            }
        }

        internal void Init(Rectangle rect, bool visible = true)
        {
            Location = rect;
            Visible = visible;
        }

        public void Dispose()
        {
            _bottomForm.Dispose();
            _leftForm.Dispose();
            _rightForm.Dispose();
            _topForm.Dispose();
        }
    }
      
}
