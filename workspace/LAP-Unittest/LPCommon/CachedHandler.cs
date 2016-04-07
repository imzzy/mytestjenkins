using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPCommon
{
    public class CacheHandler: IDisposable
    {
        const string cacheFolderName = "~cache";

        private string baseFolder;
        private string cachedFolder;

        public CacheHandler(string folderPath)
        {
            baseFolder = folderPath;
            cachedFolder = GetCachedFolder();
            if (!Directory.Exists(cachedFolder))
            {
                Directory.CreateDirectory(cachedFolder);
            }
        }
        
        public string GetCachedFolder()
        {
            return Path.Combine(baseFolder, cacheFolderName);
        }

        public void SaveCachedItem(MemoryStream stream, string token)
        {
            string filePath = GetFilePath(token);
            
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                fileStream.Write(stream.GetBuffer(), 0, (int)stream.Length);
            }
        }

        /// <summary>
        /// Move the cached file to the specified file path
        /// </summary>
        /// <param name="token"></param>
        /// <param name="filePath"></param>
        public void MoveCachedItemToFile(string token, string filePath)
        {
            string tempFilePath = GetFilePath(token);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            else
            {
                EnsureFileDirectoryExists(filePath);
            }
            File.Move(tempFilePath, filePath);
        }


        public static void EnsureFileDirectoryExists(string filePath)
        {
            FileInfo fileInfo = new FileInfo(filePath);
            DirectoryInfo directoryInfo = fileInfo.Directory;

            if (!Directory.Exists(directoryInfo.FullName))
            {
                Directory.CreateDirectory(directoryInfo.FullName);
            }
        }

        public string GetFilePath(string token)
        {
            string filePath = Path.Combine(cachedFolder, token);
            return filePath;
        }

        public void Dispose()
        {
 	        if (Directory.Exists(cachedFolder))
            {
                try
                {
                    Directory.Delete(cachedFolder, true);
                }
                catch
                {
                }
            }
        }
    }
}
