using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPReplayCore.Common
{
    public static class Utility
    {
        private static string _binDirectory;

        public static string GetBinDirectory()
        {
            if (_binDirectory != null)
                return _binDirectory;
            FileInfo info = new FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location);
            _binDirectory = info.DirectoryName;
            return _binDirectory;
        }

        public static string ReadFileContent(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath, Encoding.UTF8))
            {
                string content = reader.ReadToEnd();
                return content;
            }
        }


        internal static void WriteFileContent(string filePath, string serializedContent)
        {
            using(StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                writer.Write(serializedContent);
            }
        }

        public static void AsyncCall(Action target)
        {
            Action action = new Action(target);
            IAsyncResult result = action.BeginInvoke(null, null);
            action.EndInvoke(result);
        }

        public static bool StringSimiliarityCompare(string s1, string s2, int percentage)
        {
            if ((s1 == null || s1.Length == 0) || (s2 == null || s2.Length == 0))
                return false;
            string[] first, second;

            if (s1.Split(' ').Length > s2.Split(' ').Length)
            {
                first = s2.Split(' ');
                second = s1.Split(' ');
            }
            else
            {
                first = s1.Split(' ');
                second = s2.Split(' ');
            }

            int temp = 0;
            int same = 0;
            for (int i = 0; i <= first.Length - 1; i++)
            {
                for (int j = temp; j <= second.Length - 1; j++)
                {
                    if (first[i] == second[j])
                    {
                        temp = j + 1;
                        same++;
                        break;
                    }
                }
            }

            if ((Convert.ToDouble(same) / Convert.ToDouble(second.Length)) * 100 >= percentage)
                return true;
            else
                return false;
        }
    }


    public class DuplicateComparer : IComparer<string>
    {
        #region IComparer<int> Members

        public int Compare(string x, string y)
        {
            //return String.Compare(x, y);

            if (String.Compare(x, y) == 1)
                return 1;
            else
                return -1;
        }

        #endregion
    }
}
