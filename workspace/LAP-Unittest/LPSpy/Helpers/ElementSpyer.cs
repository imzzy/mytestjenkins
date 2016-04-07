using LPReplayCore;
using LPReplayCore.Common;
using LPSpy.UIA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using LPCommon;

namespace LPSpy
{

    public class ElementSpyer
    {
        public delegate void SpyEndDelegate(bool successful);
        public delegate void PointCapturedDelegate(Point pointCaptured);

        private KeyboardHook _mouseClick, _keyPress;

        private bool _controlClicked = false;

        public event SpyEndDelegate SpyEnd;
        public event PointCapturedDelegate PointCaptured;

        public ElementSpyer()
        {

            _keyPress = new KeyboardHook(KeyboardHook.WH_KEYBOARD_LL);
            _mouseClick = new KeyboardHook(KeyboardHook.WH_MOUSE_LL);


            _mouseClick.OnMouseClickedEvent += EndSpy;
            _keyPress.OnKeyDownEvent += ExitSpy;
            _keyPress.OnKeyUpEvent += keypress_OnKeyUpEvent;
        }


        internal void Start()
        {
            _mouseClick.Start();
            _keyPress.Start();
        }


        void keypress_OnKeyUpEvent(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.LControlKey || e.KeyCode == Keys.RControlKey)
            {
                this._controlClicked = false;
            }
        }

        private void ExitSpy(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Escape)
            {
                _mouseClick.Stop();
                _keyPress.Stop();
                SpyEnd(false);
            }

            if (e.KeyCode == Keys.LControlKey || e.KeyCode == Keys.RControlKey)
            {
                this._controlClicked = true;
            }

            if (e.KeyCode == Keys.LShiftKey || e.KeyCode == Keys.RShiftKey)
            {
                _mouseClick.Stop();
                _keyPress.Stop();
                Thread.Sleep(350);
                PointCaptured(SafeNativeMethods.GetCursorPos());
                //PointToSpiedData();
                SpyEnd(true);
            }
        }

        private void EndSpy(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && !this._controlClicked)
            {
                _mouseClick.Stop();
                _keyPress.Stop();

                //Have to call this asynchronously. Otherwise it will has COMException "An outgoing call cannot be made since the application is dispatching an input-synchronous call.”"
                Utility.AsyncCall(() => PointCaptured(SafeNativeMethods.GetCursorPos())); //PointToSpiedData(new Point(e.X, e.Y)));
                SpyEnd(true);
            }
        }


    }
}
