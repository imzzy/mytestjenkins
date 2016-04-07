using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LPReplayCore.Common;

namespace LPReplayCore.Model
{
    class DescriptorSerializer
    {
        public static ObjectDescriptor FromJson(string json)
        {
            //FromJson is only for testing purpose, therefore load all content
            ObjectDescriptor descriptor = JsonUtil.DeserializeObject<ObjectDescriptor>(json, ModelLoadLevel.Full);
            return descriptor;
        }

        public static string ToJson(ObjectDescriptor descriptor)
        {
            string serializedContent = JsonUtil.SerializeObject(descriptor, true, true);
            return serializedContent;
        }
    }
}
