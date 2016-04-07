using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LPReplayCore.Common;
using System.Collections.Generic;
using System.IO;

#if TEST
namespace LPReplayCore.UnitTest
{
    [TestClass]
    public class LPConfigLoadTest
    {
        static LPConfig _config;

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            _config = new LPConfig("AppConfig.json");
        }

        [TestMethod]
        public void LPConfig_KeyExists()
        {
            string appName = _config["AppName"];

            Assert.AreEqual("LAP", appName);
        }

        [TestMethod]
        public void LPConfig_KeyNotExists()
        {
            string appName = _config["SomeMissingKey"];

            Assert.AreEqual(appName, null);
        }

        [TestMethod]
        public void LPConfig_GetValueExists()
        {
            List<string> tools = _config.GetSetting<List<string>>("SupportTools");

            Assert.AreEqual(2, tools.Count, "should have 2 values in the SupportTools array");

            Assert.AreEqual("UIA", tools[0]);
            Assert.AreEqual("Selenium", tools[1]);
        }

        [TestMethod]
        public void LPConfig_GetValueNotExists()
        {
            List<string> tools = _config.GetSetting<List<string>>("SomeMissingKey");

            Assert.AreEqual(null, tools);
        }

        [TestMethod]
        public void LPConfig_GetUserConfigPath()
        {
            string path = LPConfig.GetUserConfigPath();

            bool result = path.StartsWith("C:\\Users") && path.EndsWith("LAPUserConfig.json");

            Assert.IsTrue(result, "returned path is " + path);
        }

        [TestMethod]
        public void LPConfig_SaveSettings()
        {
            string userConfigPath = LPConfig.GetUserConfigPath().Replace(".json", "UnitTest.json");

            if (File.Exists(userConfigPath))
            {
                File.Delete(userConfigPath);
            }

            string testValue = "Test value " + Guid.NewGuid().ToString();
            _config.SetSettings("TestKey", testValue);

            _config.SaveSettings(userConfigPath);

            Assert.IsTrue(File.Exists(userConfigPath), "File exists " + userConfigPath);

            LPConfig newConfig = new LPConfig(userConfigPath);
            string value = newConfig.GetSetting<string>("TestKey");

            Assert.AreEqual(testValue, value, "Get value should be the same as saved value");
        }
    }
}

#endif