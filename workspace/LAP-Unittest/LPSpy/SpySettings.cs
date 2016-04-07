using LPReplayCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPSpy
{
    public static class SpySettings
    {
        private static string _lastModelPath;
        class Keys
        {
            public const string AppLanguage = "AppLanguage";
            public const string Chinese = "Chinese";
            
            public const string LastModelPath = "LastModelPath";
            public const string CaptureSnapshots = "CaptureSnapshots";
        }

        public static void Init()
        {
        }

        public static string LastModelPath
        {
            get
            {
                _lastModelPath = LPConfig.GetUserSetting<string>(Keys.LastModelPath);
                return _lastModelPath;
            }
            set
            {
                _lastModelPath = value;
                LPConfig.SetUserSetting(Keys.LastModelPath, _lastModelPath);
            }
        }

        public static string SetupPath { get; set; }

        public static string StartWith { get; set; }

        internal static void Persist()
        {
            //TODO: save config files
            //throw new NotImplementedException();
        }

        public static AppLanguageEnum Language 
        {
            get
            {
                string language = LPConfig.GetUserSetting<string>(Keys.AppLanguage);
                if (language == Keys.Chinese)
                {
                    return AppLanguageEnum.Chinese;
                }
                else
                {
                    return AppLanguageEnum.English;
                }
            }
            set
            {
                LPConfig.SetUserSetting(Keys.AppLanguage, value.ToString());
            }
        }

        public static bool CaptureSnapshots
        {
            get
            {
                bool? isCapture = LPConfig.GetUserSetting<bool?>(Keys.CaptureSnapshots);

                //default value
                if (isCapture == null) return true;

                return (bool)isCapture;
            }
            set
            {
                LPConfig.SetUserSetting(Keys.CaptureSnapshots, value.ToString());
            }
        }

        public static void SaveUserSettings()
        {
            LPConfig.SaveUserSettings();
        }
    }


    public enum AppLanguageEnum
    {
        Chinese,
        English
    }
}
