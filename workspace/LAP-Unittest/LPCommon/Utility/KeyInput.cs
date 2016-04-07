using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Automation;
using System.Windows.Forms;
using System.Windows;

namespace LPCommon
{
    public static class KeyInput
    {
        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint SendInput(uint nInputs, ref INPUT pInputs, int cbSize);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetWindowRect(int hWnd, ref RECT lpRect);

        [DllImport("kernel32.dll")]
        private static extern int GetTickCount();

        [DllImport("user32.dll")]
        private static extern IntPtr GetMessageExtraInfo();

        [DllImport("User32.DLL")]
        public static extern int SendMessage(int hWnd, uint Msg, int wParam, string lParam);

        public const uint WM_SETTEXT = 0x000C;

        [StructLayout(LayoutKind.Sequential)]
        struct INPUT
        {
            public SendInputEventType type;
            public MouseKeybdhardwareInputUnion mkhi;
        }

        [StructLayout(LayoutKind.Explicit)]
        struct MouseKeybdhardwareInputUnion
        {
            [FieldOffset(0)]
            public MouseInputData mi;

            [FieldOffset(0)]
            public KEYBDINPUT ki;

            [FieldOffset(0)]
            public HARDWAREINPUT hi;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct KEYBDINPUT
        {
            public ushort wVk;
            public ushort wScan;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct HARDWAREINPUT
        {
            public int uMsg;
            public short wParamL;
            public short wParamH;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        struct MouseInputData
        {
            public int dx;
            public int dy;
            public uint mouseData;
            public MouseEventFlags dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [Flags]
        enum MouseEventFlags : uint
        {
            MOUSEEVENTF_MOVE = 0x0001,
            MOUSEEVENTF_LEFTDOWN = 0x0002,
            MOUSEEVENTF_LEFTUP = 0x0004,
            MOUSEEVENTF_RIGHTDOWN = 0x0008,
            MOUSEEVENTF_RIGHTUP = 0x0010,
            MOUSEEVENTF_MIDDLEDOWN = 0x0020,
            MOUSEEVENTF_MIDDLEUP = 0x0040,
            MOUSEEVENTF_XDOWN = 0x0080,
            MOUSEEVENTF_XUP = 0x0100,
            MOUSEEVENTF_WHEEL = 0x0800,
            MOUSEEVENTF_VIRTUALDESK = 0x4000,
            MOUSEEVENTF_ABSOLUTE = 0x8000
        }

        [Flags]
        enum KeyBoardInputEventFlags : uint
        {
            KEYEVENTF_EXTENDEDKEY = 0x0001,
            KEYEVENTF_KEYUP = 0x0002,
            KEYEVENTF_UNICODE = 0x0004,
            KEYEVENTF_SCANCODE = 0x0008
        }

        enum SendInputEventType : int
        {
            InputMouse,
            InputKeyboard,
            InputHardware
        }

        public enum MouseClickType
        {
            LClick = 1,
            LDClick = 2,
            RClick = 3,
            RDClcik = 4
        }

        public static void Click(MouseClickType t, int hwnd, int x = 0, int y = 0)
        {
            if (hwnd != 0)
            {
                Point Location = GetLocation(hwnd);
                MoveCursor(Location.X + x, Location.Y + y);
            }

            switch (t)
            {
                case MouseClickType.LClick:
                    {
                        ClickLeftButton();
                        break;
                    }
                case MouseClickType.RClick:
                    {
                        ClickRightButton();
                        break;
                    }
                case MouseClickType.LDClick:
                    {
                        ClickLeftButton();
                        ClickLeftButton();
                        break;
                    }
                case MouseClickType.RDClcik:
                    {
                        ClickRightButton();
                        ClickRightButton();
                        break;
                    }
            }

        }
        /*
        public static void Click(MouseClickType t, System.Windows.Point location)
        {
            Click(t, new System.Drawing.Point((int)location.X, (int)location.Y));
        }*/

        public static bool IsEmpty(Point point)
        {
            return (point.X == 0 && point.Y == 0);
        }

        public static void Click(MouseClickType t, Point location)
        {
            if (!IsEmpty(location))
            {
                MoveCursor(location.X, location.Y);
            }

            switch (t)
            {
                case MouseClickType.LClick:
                    {
                        ClickLeftButton();
                        break;
                    }
                case MouseClickType.RClick:
                    {
                        ClickRightButton();
                        break;
                    }
                case MouseClickType.LDClick:
                    {
                        ClickLeftButton();
                        ClickLeftButton();
                        break;
                    }
                case MouseClickType.RDClcik:
                    {
                        ClickRightButton();
                        ClickRightButton();
                        break;
                    }
            }

        }

        public static void Click(MouseClickType t, AutomationElement iae, int x = 0, int y = 0)
        {
            int handle = 0;
            try
            {
                handle = iae.Current.NativeWindowHandle;
            }
            catch { }

            if (x == 0 && y == 0)
            {
                try
                {
                    Rect tr_point = iae.Current.BoundingRectangle;
                    x = (int) (tr_point.Right - tr_point.Left) / 2;
                    y = (int) (tr_point.Bottom - tr_point.Top) / 2;
                }
                catch { }
            }

            if (handle != 0)
            {
                KeyInput.Click(t, handle, x, y);
            }
            else
            {
                //using Point to click
                try
                {
                    Point p = new Point();
                    Rect tr = iae.Current.BoundingRectangle;
                    p.X = (int)tr.Left + x;
                    p.Y = (int)tr.Top + y;
                    KeyInput.Click(t, p);
                    return;
                }
                catch { }
            }      
        }

        public static void Drag(int hwnd, int x = 0, int y = 0)
        {
            if (hwnd != 0)
            {
                Point Location = GetLocation(hwnd);
                MoveCursor(Location.X + x, Location.Y + y);
            }

            INPUT mouseDownInput = new INPUT();
            mouseDownInput.type = SendInputEventType.InputMouse;
            mouseDownInput.mkhi.mi.dwFlags = MouseEventFlags.MOUSEEVENTF_LEFTDOWN;
            SendInput(1, ref mouseDownInput, Marshal.SizeOf(new INPUT()));
        }

        public static void Drag(Point location)
        {
            if (!IsEmpty(location))
            {
                MoveCursor(location.X, location.Y);
            }

            INPUT mouseDownInput = new INPUT();
            mouseDownInput.type = SendInputEventType.InputMouse;
            mouseDownInput.mkhi.mi.dwFlags = MouseEventFlags.MOUSEEVENTF_LEFTDOWN;
            SendInput(1, ref mouseDownInput, Marshal.SizeOf(new INPUT()));
        }

        public static void Drop(int hwnd, int x = 0, int y = 0)
        {
            if (hwnd != 0)
            {
                Point Location = GetLocation(hwnd);
                MoveCursor(Location.X + x, Location.Y + y);
            }

            INPUT mouseUpInput = new INPUT();
            mouseUpInput.type = SendInputEventType.InputMouse;
            mouseUpInput.mkhi.mi.dwFlags = MouseEventFlags.MOUSEEVENTF_LEFTUP;
            SendInput(1, ref mouseUpInput, Marshal.SizeOf(new INPUT()));
        }

        public static void Drop(Point location)
        {
            if (!IsEmpty(location))
            {
                MoveCursor(location.X, location.Y);
            }

            INPUT mouseUpInput = new INPUT();
            mouseUpInput.type = SendInputEventType.InputMouse;
            mouseUpInput.mkhi.mi.dwFlags = MouseEventFlags.MOUSEEVENTF_LEFTUP;
            SendInput(1, ref mouseUpInput, Marshal.SizeOf(new INPUT()));
        }

        public static void Sendkeys(string strings)
        {
            if (strings.Length > 0)
                SendKeys.SendWait(strings);
        }

        public static void SendKeys_A(int hwnd, string strings)
        {
            if (strings.Length > 0 && hwnd != 0)
            {
                SendMessage(hwnd, WM_SETTEXT, 0, strings);
            }
        }

        private static void ClickLeftButton()
        {
            INPUT mouseDownInput = new INPUT();
            mouseDownInput.type = SendInputEventType.InputMouse;
            mouseDownInput.mkhi.mi.dwFlags = MouseEventFlags.MOUSEEVENTF_LEFTDOWN;
            SendInput(1, ref mouseDownInput, Marshal.SizeOf(new INPUT()));

            INPUT mouseUpInput = new INPUT();
            mouseUpInput.type = SendInputEventType.InputMouse;
            mouseUpInput.mkhi.mi.dwFlags = MouseEventFlags.MOUSEEVENTF_LEFTUP;
            SendInput(1, ref mouseUpInput, Marshal.SizeOf(new INPUT()));
        }

        private static void ClickRightButton()
        {
            INPUT mouseDownInput = new INPUT();
            mouseDownInput.type = SendInputEventType.InputMouse;
            mouseDownInput.mkhi.mi.dwFlags = MouseEventFlags.MOUSEEVENTF_RIGHTDOWN;
            SendInput(1, ref mouseDownInput, Marshal.SizeOf(new INPUT()));

            INPUT mouseUpInput = new INPUT();
            mouseUpInput.type = SendInputEventType.InputMouse;
            mouseUpInput.mkhi.mi.dwFlags = MouseEventFlags.MOUSEEVENTF_RIGHTUP;
            SendInput(1, ref mouseUpInput, Marshal.SizeOf(new INPUT()));
        }

        private static void MoveCursor(double x, double y)
        {
            Cursor.Position = new System.Drawing.Point((int)x, (int)y);
        }

        private static void MouseMove(Point destination)
        {
            MoveCursor((int)destination.X, (int)destination.Y);
        }

        private static Point GetLocation(int hwnd)
        {

            if (hwnd != 0)
            {
                RECT R = new RECT();
                GetWindowRect(hwnd, ref R);
                return new Point(R.Left, R.Top);
            }
            else
            {
                return new Point(0, 0);
            }
        }

        private static void KeyDown(short keyname)
        {
            INPUT[] inputs = new INPUT[1];
            inputs[0].type = SendInputEventType.InputKeyboard;
            inputs[0].mkhi.ki.wVk = (ushort)keyname;
            inputs[0].mkhi.ki.dwFlags = (int)KeyBoardInputEventFlags.KEYEVENTF_EXTENDEDKEY;
            inputs[0].mkhi.ki.time = (uint)GetTickCount();
            inputs[0].mkhi.ki.dwExtraInfo = GetMessageExtraInfo();
            SendInput(1, ref inputs[0], Marshal.SizeOf(new INPUT()));
        }

        private static void KeyUp(short keyname)
        {
            INPUT[] inputs = new INPUT[1];
            inputs[0].type = SendInputEventType.InputKeyboard;
            inputs[0].mkhi.ki.wVk = (ushort)keyname;
            inputs[0].mkhi.ki.dwFlags = (int)KeyBoardInputEventFlags.KEYEVENTF_KEYUP;
            inputs[0].mkhi.ki.time = (uint)GetTickCount();
            inputs[0].mkhi.ki.dwExtraInfo = GetMessageExtraInfo();
            SendInput(1, ref inputs[0], Marshal.SizeOf(new INPUT()));
        }

    }
}
