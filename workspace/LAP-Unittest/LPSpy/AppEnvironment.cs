using LPReplayCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPSpy
{

    public static class AppEnvironment
    {
        static string _currentDirectory;
        static AppModelFile _modelFile;


        //default name
        const string DefaultModelFileName = "ObjectModel1.json";

        static AppEnvironment()
        {
            string modelPath = SpySettings.LastModelPath;
            if (string.IsNullOrEmpty(modelPath))
            {
                CurrentModelPath = GetDefaultContentDirectory() + "\\" + DefaultModelFileName;
            }
            else
            {
                CurrentModelPath = modelPath;
            }
            FileInfo fileInfo = new FileInfo(CurrentModelPath);
            EnsureDirectoryExists(fileInfo.Directory);

        }
        private static void EnsureDirectoryExists(DirectoryInfo directoryInfo)
        {
            if (!Directory.Exists(directoryInfo.FullName))
            {
                Directory.CreateDirectory(directoryInfo.FullName);
            }
        }
        private static string GetDefaultContentDirectory()
        {
            //if it start from visual studio, using the current folder
            String defaultDirectory = Environment.CurrentDirectory;

            //if it is installed to Program Files folder, use "My Documents\LAP" folder
            string programFiles = System.Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            string programFilesX86 = System.Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
            if (defaultDirectory.StartsWith(programFiles) || defaultDirectory.StartsWith(programFilesX86))
            {
                defaultDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\LAP";
                if (!Directory.Exists(defaultDirectory)) Directory.CreateDirectory(defaultDirectory);
            }
            return defaultDirectory;
        }

        public static string CurrentDirectory
        {
            get
            {
                if (_currentDirectory == null)
                {
                    return GetDefaultContentDirectory();
                }
                return _currentDirectory;
            }
            set
            {
                _currentDirectory = value;
            }
        }

        public static void Reset()
        {
            _modelFile = null;
            _currentDirectory = null;

            CurrentModelPath = SpySettings.LastModelPath;
        }

        public static string CurrentModelPath
        {
            set
            {
                if (value == null)
                {
                    return;
                }

                _modelFile = new AppModelFile(value);
                _currentDirectory = _modelFile.FolderPath;

                SpySettings.LastModelPath = _modelFile.FilePath;
            }
            get
            {
                return (_modelFile == null)? null: _modelFile.FilePath;
            }
        }

        public static AppModelFile CurrentModelFile
        {
            get
            {
                return _modelFile;
            }
            set
            {
                if (value == null)
                {
                    return;
                }
                _modelFile = value;

                _currentDirectory = _modelFile.FolderPath;

                SpySettings.LastModelPath = _modelFile.FilePath;
            }
        }


        public delegate void ModelChangedDelegate(bool status);

        public static event ModelChangedDelegate ModelChanged;

        static bool _status;

        public static void SetModelChanged(bool status)
        {
            _status = status;

            if (ModelChanged != null)
            {
                ModelChanged(status);
            }
        }

        public static bool ModelStatus
        {
            get
            {
                return _status;
            }
        }

        public static object ModelFileName
        {
            get
            {
                return _modelFile.FileName;
            }
        }

        public static string ModelResourceFolder {
            get
            {
                return _modelFile.ResourceFolderPath;
            }
        }

        internal static string GetModelResourceFilePath(string imageFile)
        {
            return _modelFile.GetResourceFilePath(imageFile);
        }


        public static void DumpRecyclingBin(TestObjectNurse nurse)
        {
            TestObjectNurse.CleanupDeletedItems(nurse,
                (imageFilePath) => { File.Delete(AppEnvironment.GetModelResourceFilePath(imageFilePath)); });
        }
    }
}
