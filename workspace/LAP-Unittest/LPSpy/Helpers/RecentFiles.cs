using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace LPSpy
{
    public class RecentFile
    {
        readonly string _filePath;
        readonly string _displayName;

        public RecentFile(string filePath)
        {
            _filePath = filePath;
            FileInfo info = new FileInfo(filePath);
            _displayName = info.Name;
        }

        public string DisplayName
        {
            get
            {
                return _displayName;
            }
        }

        public string FilePath
        {
            get
            {
                return _filePath;
            }
        }

    }

    public class RecentFiles
    {
        List<RecentFile> _recentFiles;
        public const int MaxCount = 4;

        public RecentFiles()
        {
            _recentFiles = new List<RecentFile>();
        }

        public void Load()
        {
            //TODO initialize from settings
        }

        public List<RecentFile> GetFilesList()
        {
            return _recentFiles;
        }

        public void AddFile(string filePath)
        {
            if (filePath == null)
                throw new ArgumentNullException("filename");

            if (filePath.Length == 0)
                throw new ArgumentException("filename");

            RecentFile recentFile = new RecentFile(filePath);
            _recentFiles.Insert(0, recentFile);
            if (_recentFiles.Count > MaxCount)
            {
                _recentFiles.RemoveAt(_recentFiles.Count - 1);
            }
        }

        public int Count
        {
            get
            {
                return _recentFiles.Count;
            }
        }

        public virtual int StartIndex
        {
            get
            {
                return 0;
            }
        }

        public virtual int EndIndex
        {
            get
            {
                return _recentFiles.Count;
            }
        }

        public void SetFirstFile(int number)
        {
            if (number > 0 && Count > 1 && number < Count)
            {
                RecentFile menuItem = (RecentFile)_recentFiles[StartIndex + number];

                _recentFiles.RemoveAt(StartIndex + number);
                _recentFiles.Insert(StartIndex, menuItem);

                //FixupPrefixes(0);
            }
        }


        public void Save()
        {
            //TODO save the settings to config
            throw new NotImplementedException();
        }

        public bool RemoveFile(string filePath)
        {
            int i = 0;
            foreach (RecentFile recent in _recentFiles)
            {
                if (string.Compare(filePath, recent.FilePath, true) == 0)
                {
                    break;
                }
                ++i;
            }
            if (i == _recentFiles.Count)
            {
                return false; //did not found
            }
            _recentFiles.RemoveAt(i);
            return true;
        }


        public virtual void RemoveAll()
        {
            if (Count > 0)
            {
                // remove all items in the recentFiles
                _recentFiles.Clear();
            }
        }

        protected string registryKeyName;

        protected Mutex mruStripMutex;
        public void LoadFromRegistry()
        {
            if (registryKeyName != null)
            {
                mruStripMutex.WaitOne();

                RemoveAll();

                RegistryKey regKey = Registry.CurrentUser.OpenSubKey(registryKeyName);
                if (regKey != null)
                {
                    for (int number = MaxCount; number > 0; number--)
                    {
                        string filename = (string)regKey.GetValue("File" + number.ToString());
                        if (filename != null)
                            AddFile(filename);
                    }

                    regKey.Close();
                }
                mruStripMutex.ReleaseMutex();
            }
        }

        public void SaveToRegistry()
        {
            if (registryKeyName != null)
            {
                mruStripMutex.WaitOne();

                RegistryKey regKey = Registry.CurrentUser.CreateSubKey(registryKeyName);
                if (regKey != null)
                {
                    int number = 1;
                    int i = StartIndex;
                    for (; i < EndIndex; i++, number++)
                    {
                        regKey.SetValue("File" + number.ToString(), (_recentFiles[i]).FilePath);
                    }

                    for (; number <= 16; number++)
                    {
                        regKey.DeleteValue("File" + number.ToString(), false);
                    }

                    regKey.Close();
                }
                mruStripMutex.ReleaseMutex();
            }
        }
    }
}
