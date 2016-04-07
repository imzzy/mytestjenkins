using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

#if TEST
namespace LPSpy.UnitTest
{
    [TestClass]
    public class RecentFileTest
    {
        [TestMethod]
        public void RecentFile_ctor()
        {
            RecentFile recentFile = new RecentFile("c:\\temp\\ModelFile.json");
            Assert.AreEqual("c:\\temp\\ModelFile.json", recentFile.FilePath);
            Assert.AreEqual("ModelFile.json", recentFile.DisplayName);
        }


        [TestMethod]
        public void RecentFiles_Test()
        {
            RecentFiles recentFiles = new RecentFiles();

            recentFiles.AddFile("c:\\temp\\ModelFile1.json");

            List<RecentFile> files = recentFiles.GetFilesList();
            Assert.AreEqual(1, files.Count);

            recentFiles.AddFile("c:\\temp\\ModelFile2.json");

            //last add should be the first
            files = recentFiles.GetFilesList();
            Assert.AreEqual("ModelFile2.json", files[0].DisplayName);

            recentFiles.AddFile("c:\\temp\\ModelFile3.json");
            recentFiles.AddFile("c:\\temp\\ModelFile4.json");
            recentFiles.AddFile("c:\\temp\\ModelFile5.json");

            //max stores 5 of them.
            files = recentFiles.GetFilesList();
            Assert.AreEqual(4, RecentFiles.MaxCount);
            Assert.AreEqual(RecentFiles.MaxCount, files.Count);

            
            bool result = recentFiles.RemoveFile("c:\\temp\\ModelFile1.json");

            Assert.AreEqual(false, result, "this item should no longer exists");

            result = recentFiles.RemoveFile("c:\\temp\\ModelFile4.json");

            Assert.AreEqual(true, result, "should remove successful");

            files = recentFiles.GetFilesList();
            Assert.AreEqual(3, files.Count);
        }

        [TestMethod]
        public void RecentFiles_LoadSave()
        {

        }
    }
}

#endif