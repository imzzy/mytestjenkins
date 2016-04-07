using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace LPCommon
{
    public static class NativeMethods
    {
        public const int DLGC_STATIC = 0x100;
        public const int GWL_EXSTYLE = -20;
        public static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        public const uint MOD_ALT = 1;
        public const uint MOD_CONTROL = 2;
        public const uint MOD_SHIFT = 4;
        public const uint OBJ_BITMAP = 7;
        public const int SRCCOPY = 0xcc0020;
        public const int SW_RESTORE = 9;
        public const int SW_SHOWNA = 8;
        public const int SW_Active = 5;
        public const int SW_SHOWMAXIMIZED = 3;
        public const int SW_SHOWMINIMIZED = 2;
        public const int SWP_NOACTIVATE = 0x10;
        public const int TOKEN_ELEVATION = 20;
        public const int TOKEN_ELEVATION_TYPE = 0x12;
        public const int TOKEN_ELEVATION_TYPE_DEFAULT = 1;
        public const int TOKEN_ELEVATION_TYPE_FULL = 2;
        public const int TOKEN_ELEVATION_TYPE_LIMITED = 3;
        public const int TOKEN_QUERY = 8;
        public const int VK_F1 = 0x70;
        public const uint VK_R = 0x52;
        public const int VK_SHIFT = 0x10;
        public const int WM_GETDLGCODE = 0x87;
        public const int WM_HOTKEY = 0x312;
        public const int WM_KEYDOWN = 0x100;
        public const int WM_NCLBUTTONDBLCLK = 0xa3;
        public const int WS_EX_TOOLWINDOW = 0x80;
        public const int WM_SYSKEYDOWN = 0x104;
        public const long VK_LCONTROL = 0xA2;
        public const int VK_LALT = 0xA4;
        public const int EM_SETSEL = 0x00B1;
        public static int GWL_STYLE = -16;
        public static int WS_CLIPSIBLINGS = 0x04000000;
        public static int WS_CLIPCHILDREN = 0x02000000;


        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int x;
            public int y;
        }
    }

    public static class UnsafeNativeMethods
    {
        [DllImport("user32.dll")]
        public static extern int GetClassName(IntPtr hwnd, StringBuilder lpClassName, int nMaxCount);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetCurrentObject(IntPtr hdc, uint objectType);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetWindowDC(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern UInt32 GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("ntdll.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern void NtClose(IntPtr hToken);

        [DllImport("ntdll.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern int NtOpenProcessToken(IntPtr hProcess, uint accessMask, out IntPtr hToken);

        [DllImport("ntdll.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern int NtQueryInformationToken(IntPtr hToken, uint tokenElevationType, out IntPtr elevationInfo, uint bufferSize, out uint tokensize);

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool RegisterHotKey(IntPtr hWnd, int atom, uint fsModifiers, uint vk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, UInt32 dwNewLong);
        
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int atom);
        
        [DllImport("User32.dll")]
        public static extern short GetAsyncKeyState(int vKey);
        
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);


        [StructLayout(LayoutKind.Sequential)]
        public struct TOKEN_ELEVATION_INFO
        {
            [MarshalAs(UnmanagedType.U4)]
            public uint TokenIsElevated;
        }
    }


    public static class SafeNativeMethods
    {
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("gdi32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool BitBlt(IntPtr hDC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC, int xSrc, int ySrc, int dwRop);

        [DllImport("Kernel32.dll", ExactSpelling = true)]
        public static extern int CheckElevationEnabled([MarshalAs(UnmanagedType.Bool)] out bool luaEnabled);

        public static Point GetCursorPos()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                NativeMethods.POINT point;
                GetPhysicalCursorPos(out point);
                return new Point(point.x, point.y);
            }
            return new System.Windows.Point(Cursor.Position.X, Cursor.Position.Y);
        }

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", ExactSpelling = true)]
        private static extern bool GetPhysicalCursorPos(out NativeMethods.POINT pt);

        public static void SetCursorPos(Point pt)
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                SetPhysicalCursorPos((int)pt.X, (int)pt.Y);
            }
            else
            {
                Cursor.Position = new System.Drawing.Point((int)pt.X, (int)pt.Y);
            }
        }

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", ExactSpelling = true)]
        private static extern bool SetPhysicalCursorPos(int x, int y);

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", ExactSpelling = true)]
        public static extern bool SetProcessDPIAware();

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hwndAfter, int x, int y, int width, int height, int flags);

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SetActiveWindow(IntPtr hWnd);

        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool EnableWindow(IntPtr hwnd, bool bEnable);
    }
}
