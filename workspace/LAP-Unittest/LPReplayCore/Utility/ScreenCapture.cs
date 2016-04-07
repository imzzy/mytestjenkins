using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LPReplayCore
{
    class ScreenCapture
    {
        /// <summary>
        /// http://stackoverflow.com/questions/5049122/capture-the-screen-shot-using-net
        /// </summary>
        public static void Capture()
        {
            using (Bitmap bmpScreenCapture = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                                            Screen.PrimaryScreen.Bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bmpScreenCapture))
                {
                    g.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                                     Screen.PrimaryScreen.Bounds.Y,
                                     0, 0,
                                     bmpScreenCapture.Size,
                                     CopyPixelOperation.SourceCopy);
                }
            }
        }

        public static void CaptureDirectX()
        {
            //TODO follow article http://www.mvps.org/vbdx/articles/screenshot/index.html
        }
    }
}
