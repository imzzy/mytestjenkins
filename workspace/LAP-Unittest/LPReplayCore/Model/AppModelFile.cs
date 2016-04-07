using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPReplayCore
{

    public class AppModelFile
    {

        private string _modelFileName;
        private string _currentModelFilePath;
        private string _folderPath;


        public AppModelFile(string modelFilePath)
        {
            if (!Path.IsPathRooted(modelFilePath))
            {
                _currentModelFilePath = Path.GetFullPath(modelFilePath);
            }
            else
            {
                _currentModelFilePath = modelFilePath;
            }
            
            FileInfo fileInfo = new FileInfo(_currentModelFilePath);
            _modelFileName = fileInfo.Name;
            _folderPath = fileInfo.Directory.FullName;
        }

        public static AppModelFile Create(string modelFilePath)
        {
            AppModelFile modelFile = new AppModelFile(modelFilePath);

            if (!Directory.Exists(modelFile.ResourceFolderPath))
            {
                Directory.CreateDirectory(modelFile.ResourceFolderPath);
            }
            return modelFile;
        }

        public string ResourceFolderPath
        {
            get
            {
                int index = _modelFileName.LastIndexOf(".");
                string modelNameWithoutExtension = index >= 0 ? _modelFileName.Substring(0, index) : _modelFileName;
                return _folderPath + "\\" + modelNameWithoutExtension + "_files";
            }
        }


        public string FileName
        {
            get
            {
                return _modelFileName;
            }
        }

        public string FilePath
        {
            get
            {
                return _currentModelFilePath;
            }
        }


        public string GetResourceFilePath(string imageFile)
        {
            string path = Path.Combine(this.ResourceFolderPath, imageFile);
            return path;
        }

        public string FolderPath
        {
            get
            {
                return _folderPath;
            }
        }
    }
}
