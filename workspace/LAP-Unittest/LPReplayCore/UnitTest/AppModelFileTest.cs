using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Diagnostics;

namespace LPReplayCore.UnitTest
{
    [TestClass]
    public class AppModelFileTest
    {
        [TestMethod]
        public void AppModelFile_Test()
        {
            AppModelFile modelFile = new AppModelFile("UnitTestObjectModel1.json");

            Assert.IsTrue(Path.IsPathRooted(modelFile.FilePath));
            Assert.IsTrue(File.Exists(modelFile.FilePath));
            Assert.IsTrue(modelFile.ResourceFolderPath.EndsWith("files"));

            Debug.WriteLine(modelFile.FolderPath);
        }
    }
}
