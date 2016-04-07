using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LPSpy.UIA
{

    public class KeyboardHook
    {
        [DllImport("user32.dll ", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);

        [DllImport("user32.dll ", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern bool UnhookWindowsHookEx(int idHook);

        [DllImport("user32.dll ", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int CallNextHookEx(int idHook, int nCode, Int32 wParam, IntPtr lParam);

        [DllImport("user32 ")]
        public static extern int ToAscii(int uVirtKey, int uScanCode, byte[] lpbKeyState, byte[] lpwTransKey, int fuState);

        [DllImport("user32 ")]
        public static extern int GetKeyboardState(byte[] pbKeyState);

        [DllImport("kernel32.dll")]
        public static extern IntPtr GetModuleHandle(string name);

        public delegate int HookProc(int nCode, Int32 wParam, IntPtr lParam);

        private const int WM_KEYDOWN = 0x100;
        private const int WM_KEYUP = 0x101;
        private const int WM_SYSKEYDOWN = 0x104;
        private const int WM_SYSKEYUP = 0x105;
        private const int WM_LBUTTONDOWN = 0x0201;

        public event KeyEventHandler OnKeyDownEvent;
        public event KeyEventHandler OnKeyUpEvent;
        public event KeyPressEventHandler OnKeyPressEvent;
        public event MouseEventHandler OnMouseClickedEvent;

        public int hKeyboardHook = 0;
        private int hookType;

        public const int WH_KEYBOARD_LL = 13;
        public const int WH_MOUSE_LL = 14;
        HookProc KeyboardHookProcedure;

        [StructLayout(LayoutKind.Sequential)]

        public class KeyboardHookStruct
        {
            public int vkCode;
            public int scanCode;
            public int flags;
            public int time;
            public int dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MouseHookStruct
        {
            public POINT Point;
            public UInt32 MouseData;
            public UInt32 Flags;
            public UInt32 Time;
            public UInt32 ExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;
        }



        public KeyboardHook(int keytype)
        {
            hookType = keytype;
        }

        ~KeyboardHook()
        {
            try
            {
                Stop();
            }
            catch
            { }
        }
        public void Start()
        {
            if (hKeyboardHook == 0)
            {
                KeyboardHookProcedure = new HookProc(KeyboardHookProc);
                hKeyboardHook = SetWindowsHookEx(hookType, KeyboardHookProcedure, GetModuleHandle(System.Diagnostics.Process.GetCurrentProcess().MainModule.ModuleName), 0);
                if (hKeyboardHook == 0)
                {
                    Stop();
                    //throw new Exception("SetWindowsHookEx is failed.");
                }
            }
        }
        public void Stop()
        {
            bool retKeyboard = true;
            if (hKeyboardHook != 0)
            {
                retKeyboard = UnhookWindowsHookEx(hKeyboardHook);
                hKeyboardHook = 0;
            }
            else
            {
                retKeyboard = true;
            }
            //if (!(retKeyboard)) throw new Exception("UnhookWindowsHookEx   failed. ");
        }

        private int KeyboardHookProc(int nCode, Int32 wParam, IntPtr lParam)
        {
            if ((nCode >= 0) && (OnKeyDownEvent != null || OnKeyUpEvent != null || OnKeyPressEvent != null))
            {
                KeyboardHookStruct MyKeyboardHookStruct = (KeyboardHookStruct)Marshal.PtrToStructure(lParam, typeof(KeyboardHookStruct));
                if (OnKeyDownEvent != null && (wParam == WM_KEYDOWN || wParam == WM_SYSKEYDOWN))
                {
                    Keys keyData = (Keys)MyKeyboardHookStruct.vkCode;
                    KeyEventArgs e = new KeyEventArgs(keyData);
                    OnKeyDownEvent(this, e);
                }

                if (OnKeyPressEvent != null && wParam == WM_KEYDOWN)
                {
                    byte[] keyState = new byte[256];
                    GetKeyboardState(keyState);
                    byte[] inBuffer = new byte[2];
                    if (ToAscii(MyKeyboardHookStruct.vkCode,
                      MyKeyboardHookStruct.scanCode,
                      keyState,
                      inBuffer,
                      MyKeyboardHookStruct.flags) == 1)
                    {
                        KeyPressEventArgs e = new KeyPressEventArgs((char)inBuffer[0]);
                        OnKeyPressEvent(this, e);
                    }
                }

                if (OnKeyUpEvent != null && (wParam == WM_KEYUP || wParam == WM_SYSKEYUP))
                {
                    Keys keyData = (Keys)MyKeyboardHookStruct.vkCode;
                    KeyEventArgs e = new KeyEventArgs(keyData);
                    OnKeyUpEvent(this, e);
                }
            }

            if (nCode >= 0 && OnMouseClickedEvent != null)
            {
                MouseHookStruct MyMSLLHOOKSTRUCT = (MouseHookStruct)Marshal.PtrToStructure(lParam, typeof(MouseHookStruct));
                if (wParam == WM_LBUTTONDOWN)
                {
                    MouseEventArgs ee = new MouseEventArgs(MouseButtons.Left, 1, MyMSLLHOOKSTRUCT.Point.X, MyMSLLHOOKSTRUCT.Point.Y, 0);
                    OnMouseClickedEvent.BeginInvoke(this, ee, null, null);
                    return 1;
                    //stop calling the next hook, so that mouse click action won't be actually performed.
                    
                }
            }
            return CallNextHookEx(hKeyboardHook, nCode, wParam, lParam);
        }
    }
}
