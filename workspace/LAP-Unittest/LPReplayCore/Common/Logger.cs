using LPCommon;
using LPReplayCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPReplayCore.Common
{
    static class Logger_Obsolete
    {

        public static void WriteLog(string message)
        {
            //always write the log, therefore consider it to be error.
            Debug.WriteLine(message);
        }

        public static void WriteLog(LogTypeEnum logType, string message)
        {
            //TODO check error level
            Debug.WriteLine(message);
        }

        public static void WriteLog(LogTypeEnum logType, Func<string> getMessage)
        {
            //TODO: check log level

            string message = getMessage();
            WriteLog(logType, message);
            //throw new NotImplementedException();
        }

        public static void WriteError(string message)
        {
            Debug.WriteLine("Error: " + message);
            //throw new NotImplementedException();
        }

        public static void WriteWarning(string message)
        {
            Debug.WriteLine("Warning: " + message);
            //throw new NotImplementedException();
        }

        public static void WriteInfo(string message)
        {
            Debug.WriteLine("Info: " + message);
            //throw new NotImplementedException();
        }

        public static void WriteDebug(string message)
        {
            Debug.WriteLine("Debug: " + message);
            //throw new NotImplementedException();
        }
    }
}
