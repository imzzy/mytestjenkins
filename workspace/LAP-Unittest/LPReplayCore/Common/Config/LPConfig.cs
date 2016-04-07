using LPCommon;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPReplayCore.Common
{
    public class LPConfig
    {
        static ILogger _Logger = LogFactory.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);//"LPReplayCore.UIA.UIAFinder");

        const string globalConfigPath = "AppConfig.json";
        const string userConfigPath = "LAPUserConfig.json";

        static LPConfig _globalConfig;
        static LPConfig _userConfig;

        JObject _config;

        bool _isDirty = false;

        public LPConfig(string path)
        {
            if (File.Exists(path))
            {
                _config = JsonConfigPersister.LoadConfig(path);
            }
            else
            {
                _config = new JObject();
            }
        }

        #region Instance Methods
        public string this[string key] 
        {
            get
            {
                //TODO get the key from _config
                return GetSetting<string>(key);
            }

            set
            {
                _isDirty = true;
                //TODO set the key, value in the configure
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// return null if the key is missing
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T GetSetting<T>(string key)
        {
            //TODO convert config setting to the specified type
            JToken token;
            _config.TryGetValue(key, out token);

            if (token == null) return default(T);
            
            T t = token.ToObject<T>();
            return t;
        }

        //mainly for unit testing purpose, not supposed to be called by user
        public void SetSettings(string key, string value)
        {
            _config[key] = value;
            _isDirty = true;
        }
        
        //return whether the configure is persistented
        public bool IsDirty()
        {
            return _isDirty;
        }

        private bool KeyExists(string key)
        {
            JProperty property = _config.Property(key);
            return (property != null);
        }

        public void SaveSettings(string filePath)
        {
            JsonConfigPersister.SaveConfig(_config, filePath);
        }

        #endregion

        #region Static Methods

        public static LPConfig Global
        {
            get
            {
                if (_globalConfig == null)
                {
                    //TODO: Add lock to avoid multithreading
                    _globalConfig = new LPConfig(globalConfigPath);
                }
                return _globalConfig;
            }
        }

        public static LPConfig User
        {
            get
            {
                if (_userConfig == null)
                {
                    //TODO: Add lock to avoid multithreading
                    string filePath = GetUserConfigPath();
                    _userConfig = new LPConfig(filePath);
                    
                }
                return _userConfig;
            }
        }

        public static string GetUserConfigPath()
        {
            string userAppFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            
            return Path.Combine(userAppFolder, userConfigPath);
        }

        public static T GetUserSetting<T>(string key)
        {
            if (!User.KeyExists(key))
            {
                return Global.GetSetting<T>(key);
            }

            return User.GetSetting<T>(key);
        }

        //mainly for unit testing purpose, not supposed to be called by user
        public static void SetUserSetting(string key, string value)
        {
            if (User.KeyExists(key))
            {
                string oldValue = User.GetSetting<string>(key);
                if (oldValue == value) return;
            }

            User.SetSettings(key, value);
        }

        public static void ReloadConfig()
        {
            //reload the config settings from the file system.
            _userConfig = null;
            _globalConfig = null;
        }
        #endregion


        public static void SaveUserSettings()
        {
            if (User.IsDirty())
            {
                User.SaveSettings(GetUserConfigPath());
            }
        }


        public static void ResetToGlobal()
        {
            File.Delete(GetUserConfigPath());
            ReloadConfig();
        }
    }
}
