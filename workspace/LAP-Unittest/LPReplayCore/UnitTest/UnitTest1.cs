using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LPReplayCore;

#if TEST

namespace LPReplayCore.UnitTest
{
    [TestClass]
    public class ScreenCaptureTest
    {
        [TestMethod]
        public void ScreenCapture_Capture()
        {
            ScreenCapture.Capture();
        }
    }
}

#endif