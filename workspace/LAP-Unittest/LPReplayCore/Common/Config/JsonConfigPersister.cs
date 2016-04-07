using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPReplayCore.Common
{
    //read and write 
    public static class JsonConfigPersister
    {
        public static JObject LoadConfig(string filePath)
        {
            string content = Utility.ReadFileContent(filePath);

            JObject obj = (JObject) JsonConvert.DeserializeObject(content);

            return obj;
        }

        public static void SaveConfig(JObject config, string filePath)
        {
            string contentToSave = JsonUtil.SerializeObject(config);

            Utility.WriteFileContent(filePath, contentToSave);

        }
    }
}
