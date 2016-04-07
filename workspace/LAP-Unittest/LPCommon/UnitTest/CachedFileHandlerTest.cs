using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.IO;

namespace LPCommon
{
#if TEST
    [TestClass]
    public class CachedFileHandlerTest
    {
        
        [ClassInitialize]
        public static void Init(TestContext TestContext)
        {
            
        }

        [TestMethod]
        public void CachedFile_Save()
        {
            CacheHandler handler = new CacheHandler(Environment.CurrentDirectory);

            string cachedFolder = handler.GetCachedFolder();
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write("This is test string");
            writer.Flush();

            string token = Guid.NewGuid().ToString();

            handler.SaveCachedItem(stream, token);

            string targetPath = Path.Combine(Environment.CurrentDirectory, "test.txt");

            handler.MoveCachedItemToFile(token, targetPath);

            Assert.IsTrue(File.Exists(targetPath));

            StreamReader reader = new StreamReader(targetPath);

            string resultText = reader.ReadToEnd();

            Assert.AreEqual("This is test string", resultText);

            handler.Dispose();
            Assert.IsTrue(!Directory.Exists(cachedFolder));
        }

    }

#endif
}
