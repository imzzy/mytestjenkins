using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.IO;

#if TEST
namespace ReplayEngine
{
    [TestClass]
    public class VideoHelperTest
    {
        //[TestMethod]
        public void VideoRecordingTest()
        {
            VideoHelper.StartRecordingVideo();
            Thread.Sleep(2000);
            VideoHelper.StopRecordingVideo();
            //TODO validate whether the recorded file exists
            //Assert.IsTrue(File.Exists("xxx"));
        }
    }
}

#endif