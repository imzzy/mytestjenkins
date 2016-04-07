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
    public class LPLoggerTest
    {
        private static ILogger _Logger = null;

        private const string _ConfigPath = @"LPLogger.config.xml";

        private const string _logPath = @"LPLoggerTest.log";

        [ClassInitialize]
        public static void LPLoggerTestinitialize(TestContext TestContext)
        {
            if (File.Exists(_logPath)) File.Delete(_logPath);
            LogFactory.LoadLogConfigFile(_ConfigPath);
            _Logger = LogFactory.GetLogger("LPLogger");
        }

        [TestMethod]
        public void LPLogger_Test()
        {
            int a = 1; string b = "b";
            TestMethod(a, b);
            Assert.AreEqual(true, File.Exists(_logPath));
        }


        private void TestMethod(int a, string b)
        {
            _Logger.Entry("TestMethod");
            _Logger.DebugMethodEntrance();
            _Logger.DebugMethodExit();
            _Logger.Exit("TestMethod");
        }

        [TestMethod]
        public void LPLogger_WriteWarning()
        {
            _Logger = LogFactory.GetLogger("LPLogger");
            _Logger.Warn("This is a warning");
        }

        [TestMethod]
        public void LPLogger_WriteError()
        {
            _Logger = LogFactory.GetLogger("LPLogger");
            _Logger.Error("This is an error");
        }

        [TestMethod]
        public void LPLogger_WriteInfo()
        {
            _Logger = LogFactory.GetLogger("LPLogger");
            _Logger.Info("This is an info");
        }

        [TestMethod]
        public void LPLogger_WriteDebug()
        {
            _Logger = LogFactory.GetLogger("LPLogger");
            _Logger.Debug("This is a debug message");
        }

        [TestMethod]
        public void LPLogger_WriteMessage()
        {
            _Logger = LogFactory.GetLogger("LPLogger");
            _Logger.WriteLog(LogTypeEnum.Error, "This is error message using WriteLog");
            _Logger.WriteLog(LogTypeEnum.Warning, "This is warning message using WriteLog");
            _Logger.WriteLog(LogTypeEnum.Info, "This is info message using WriteLog");
            _Logger.WriteLog(LogTypeEnum.Debug, "This is debug message using WriteLog");

        }
    }

#endif
}
