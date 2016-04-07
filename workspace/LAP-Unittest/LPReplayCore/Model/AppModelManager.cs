using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LPReplayCore.Common;
using LPReplayCore.Model;

namespace LPReplayCore
{
    public static class AppModelManager
    {

        public static AppModel Load(string filePath, ModelLoadLevel level = ModelLoadLevel.ReplayOnly)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException(string.Format("File {0} does not exist", filePath));
            }
            string content = Utility.ReadFileContent(filePath);

            AppDescriptor appDescriptor = JsonUtil.DeserializeObject<AppDescriptor>(content, level);

            AppModel model = appDescriptor.GetObject();

            model.ModelFile = new AppModelFile(filePath);

            return model;
        }

        public static bool Save(AppModel model, StreamWriter stream)
        {
            AppDescriptor appDescriptor = new AppDescriptor(model);

            string serializedContent = JsonUtil.SerializeObject(appDescriptor, true, true);

            stream.Write(serializedContent);

            return true;
        }


        public static bool Save(AppModel model, string filePath)
        {
            AppDescriptor appDescriptor = new AppDescriptor(model);

            string serializedContent = JsonUtil.SerializeObject(appDescriptor, true, true);

            Utility.WriteFileContent(filePath, serializedContent);

            model.ModelFile = new AppModelFile(filePath);

            return true;
        }
    
    }
}
