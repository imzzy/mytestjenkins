using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.IO;
using Microsoft.Deployment.WindowsInstaller;

namespace Install_CA
{
#if TEST
    [TestClass]
    public class InstallUnitTest
    {

        [ClassInitialize]
        public static void InstallUnitTestinitialize(TestContext TestContext)
        {
           
        }

       
        [TestMethod]
        public void Install_CA_ChangeLanguage()
        {
//            data["Codepage"] = "936";
            string testFolder = Environment.CurrentDirectory + "\\TestFolder";
            string filePath = testFolder + "\\AppConfig.json";

            if (!Directory.Exists(testFolder))
            {
                Directory.CreateDirectory(testFolder);
            }

            File.Copy(Environment.CurrentDirectory + "\\AppConfig.json", filePath, true);
            CustomActions.ChangeLanguage(testFolder, "Chinese");

            string content = CustomActions.ReadFileContent(filePath);
            Assert.IsTrue(content.IndexOf("Chinese") > 0);
            Assert.IsTrue(content.IndexOf("English") < 0);
        }
    }

#endif
}
