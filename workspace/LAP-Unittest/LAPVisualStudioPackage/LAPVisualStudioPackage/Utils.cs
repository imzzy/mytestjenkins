using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace LAPInc.LAPVisualStudioPackage
{
    public class Utils
    {
        #region private fields
        private const string _LAPSpyAppName = "LPSpy.exe";
        private static string _LAPSpyAppFolder = string.Empty ;
        private static string _LAPSpyAppPath = string.Empty;
        #endregion

        #region public Methods
        public static Process LaunchtheSpyApp(LaunchInfo info)
        {
            string arguments = HandleInfo(info);
            Process appProcess = null;
            try
            {
                appProcess = LaunchtheSpyAppWithArg(arguments);
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message.ToString());
            }
            return appProcess;
        }

        public static void GetLPSpyAppPath()
        {
            string appPaths = @"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\";
            string strKeyName = string.Empty; 
            RegistryKey regKey = Registry.LocalMachine;
            RegistryKey regSubKey = regKey.OpenSubKey(appPaths + _LAPSpyAppName,  false);
            object objResult = regSubKey.GetValue(strKeyName);
            RegistryValueKind regValueKind = regSubKey.GetValueKind(strKeyName);
            if (regValueKind == Microsoft.Win32.RegistryValueKind.String)
            {
                _LAPSpyAppPath = objResult.ToString(); ;
                _LAPSpyAppFolder = regSubKey.GetValue("Path").ToString();
            }
        }

        #endregion

        #region private Methods
        private static string HandleInfo(LaunchInfo info)
        {
            return string.Empty;
        }

        private static Process LaunchtheSpyAppWithArg(string arguments)
        {
            Process appProcess = null;
            GetLPSpyAppPath();
            if (_LAPSpyAppFolder == string.Empty || _LAPSpyAppPath == string.Empty)
                return null;
            try
            {
                var startInfo = new ProcessStartInfo
                {
                    Arguments = arguments,
                    FileName = _LAPSpyAppPath,
                    WorkingDirectory = _LAPSpyAppFolder

                };
                appProcess = Process.Start(startInfo);
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message.ToString());
            }
            return appProcess;
        }
        #endregion
    }
}
