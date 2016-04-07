using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.IO;
//using System.Windows.Interop;
//using System.Windows;

namespace LPCommon
{
    public class Snapshot
    {
        //10 pixel margins
        public const int Margin = 10;

        public enum TernaryRasterOperations : int
        {
            SRCCOPY =   0x00CC0020,
            SRCPAINT =  0x00EE0086,
            SRCAND =    0x008800C6,
            SRCINVERT = 0x00660046,
            SRCERASE =  0x00440328,
            NOTSRCCOPY = 0x00330008,
            NOTSRCERASE = 0x001100A6,
            MERGECOPY = 0x00C000CA,
            MERGEPAINT = 0x00BB0226,
            PATCOPY =   0x00F00021,
            PATPAINT =  0x00FB0A09,
            PATINVERT = 0x005A0049,
            DSTINVERT = 0x00550009,
            BLACKNESS = 0x00000042,
            WHITENESS = 0x00FF0062,
            CAPTUREBLT = 0x40000000
        }

        delegate bool MonitorEnumDelegate(IntPtr hMonitor, IntPtr hdcMonitor, ref Rect lprcMonitor, IntPtr dwData);

        #region Exported WIN APIs
        [StructLayout(LayoutKind.Sequential)]
        struct Rect
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct MonitorInfo
        {
            public uint size;
            public Rect monitor;
            public Rect work;
            public uint flags;
        }

        [DllImport("user32.dll")]
        static extern bool EnumDisplayMonitors(IntPtr hdc, IntPtr lprcClip, MonitorEnumDelegate lpfnEnum, IntPtr dwData);

        [DllImport("user32.dll")]
        static extern bool GetMonitorInfo(IntPtr hmon, ref MonitorInfo mi);

        [DllImport("GDI32.dll")]
        public static extern bool BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, TernaryRasterOperations dwRop);

        [DllImport("GDI32.dll")]
        public static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);

        [DllImport("GDI32.dll")]
        public static extern IntPtr CreateCompatibleDC(IntPtr hdc);

        [DllImport("GDI32.dll")]
        public static extern bool DeleteDC(IntPtr hdc);

        [DllImport("GDI32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);

        [DllImport("gdi32.dll")]
        static extern IntPtr CreateDC(string lpszDriver, string lpszDevice, string lpszOutput, IntPtr lpInitData);

        [DllImport("GDI32.dll")]
        public static extern int GetDeviceCaps(IntPtr hdc, int nIndex);

        [DllImport("GDI32.dll")]
        public static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

        [DllImport("User32.dll")]
        public static extern int GetDesktopWindow();

        [DllImport("User32.dll")]
        public static extern IntPtr GetWindowDC(int hWnd);

        [DllImport("User32.dll")]
        public static extern int ReleaseDC(int hWnd, IntPtr hDC);
        #endregion

        static Snapshot()
        {
            Snapshot.GetDisplayMonitors();
        }

        public Snapshot()
        {
        }

        #region private properties
        static Rectangle _virtualScreenRectangle = Rectangle.Empty;
        #endregion 

       public static Bitmap GetDeskTopSnapShot()
       {
          return Bitmap.FromHbitmap(CopyScreenToBitmap(_virtualScreenRectangle));
       }

        private static IntPtr CopyScreenToBitmap(Rectangle rect)
        {
            IntPtr hScreenDC = CreateDC("DISPLAY", null, null, IntPtr.Zero);
            IntPtr hMemoryDC = CreateCompatibleDC(hScreenDC);

            /* create a bitmap compatible with the screen DC */
            IntPtr hBitmap = CreateCompatibleBitmap(hScreenDC, (int)rect.Width, (int)rect.Height);

            /* select new bitmap into memory DC */
            IntPtr hOldBitmap = SelectObject(hMemoryDC, hBitmap);

            /* bitblt screen DC to memory DC */
            BitBlt(hMemoryDC, 0, 0, (int)rect.Width, (int)rect.Height, hScreenDC, (int)rect.Left, (int)rect.Top, TernaryRasterOperations.SRCCOPY | TernaryRasterOperations.CAPTUREBLT);

            /*  select old bitmap back into memory DC and get handle to
             *  bitmap of the screen
             */
            hBitmap = SelectObject(hMemoryDC, hOldBitmap);

            /* clean up */
            DeleteObject(hOldBitmap);
            DeleteDC(hScreenDC);
            DeleteDC(hMemoryDC);

            return hBitmap;
        }

        private static void SaveBitmap(Bitmap bmp, string filePath)
        {
            bmp.Save(filePath);
        }

        private static void SaveBitmap(IntPtr hBmpHandle, string filePath)
        {
            using (Bitmap bitmap = Bitmap.FromHbitmap(hBmpHandle))
            {
                SaveBitmap(bitmap, filePath);
            }
        }



        public static void GetDisplayMonitors()
        {
            EnumDisplayMonitors(IntPtr.Zero, IntPtr.Zero,
                (IntPtr hMonitor, IntPtr hdcMonitor, ref Rect lprcMonitor, IntPtr dwData) =>
                {
                    //  var gcHandle = GCHandle.FromIntPtr(dwData);
                //    SnapshotHelper pThis = gcHandle.Target as SnapshotHelper;
                    Rectangle rcReal = Rectangle.FromLTRB(lprcMonitor.left, lprcMonitor.top, lprcMonitor.right, lprcMonitor.bottom);
                    _virtualScreenRectangle = Rectangle.Union(_virtualScreenRectangle, rcReal);
                    return true;
                }, IntPtr.Zero);// GCHandle.ToIntPtr(myHandle));   

        }


        public static void CaptureImageToFile(Rectangle rect, string filePath)
        {
            rect.Intersect(_virtualScreenRectangle);
            IntPtr hBitmap = CopyScreenToBitmap(rect);
            SaveBitmap(hBitmap, filePath);
            DeleteObject(hBitmap);
        }

        public static void CaptureImageToFileInflated(Rectangle rect, string filePath)
        {
            rect.Inflate(Margin, Margin);
            CaptureImageToFile(rect, filePath);
        }

        public MemoryStream GetBitmapStream(IntPtr hBitmap)
        {
            using (Bitmap bitmap = Bitmap.FromHbitmap(hBitmap))
            {
                MemoryStream stream = new MemoryStream();
                bitmap.Save(stream, ImageFormat.Png);
                return stream;
            }
        }

        public static void ValidateRectangle(ref Rectangle rect)
        {
              rect.Intersect(_virtualScreenRectangle);
        }

        public MemoryStream CaptureRectangle(Rectangle rect)
        {
            rect.Intersect(_virtualScreenRectangle);
            IntPtr hBitmap = IntPtr.Zero;
            try
            {
                hBitmap = CopyScreenToBitmap(rect);
                return GetBitmapStream(hBitmap);
            }
            finally
            {
                DeleteObject(hBitmap);
            }
        }

        
        public static MemoryStream GetBitmap(Rectangle rect, Bitmap screenBitmap)
        {
            Rectangle rc = Rectangle.FromLTRB(rect.Left,
                rect.Top, rect.Right, rect.Bottom);

            rc.Inflate(10, 10);

            Snapshot.ValidateRectangle(ref rc);

            if (rc.IsEmpty) return null;

            using (Bitmap bmpObject = screenBitmap.Clone(rc, screenBitmap.PixelFormat))
            {
                MemoryStream stream = new MemoryStream();
                bmpObject.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream;

            }
        }

        public MemoryStream CaptureInflatedRectangle(Rectangle rect)
        {
            rect.Inflate(10, 10);
            return CaptureRectangle(rect);
        }

    }
}
