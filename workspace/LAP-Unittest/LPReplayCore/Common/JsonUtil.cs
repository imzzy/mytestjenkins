using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPReplayCore.Common
{
    public static class JsonUtil
    {
        /*
        /// <summary>
        /// Gets object of any type and serialize it to a java script object
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string SerializeObject(object value)
        {
            string jsonString = JsonConvert.SerializeObject(value);
            return jsonString;
        }*/

        private static JsonSerializerSettings deserializeSettings = new JsonSerializerSettings()
        {
            NullValueHandling = NullValueHandling.Ignore,
            MissingMemberHandling = MissingMemberHandling.Ignore

        };

        /// <summary>
        /// Gets object of any type and serialize it to a java script object, by specifying 
        /// whether ignoring Null values as well as formatting to a friendly readable indented string.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="ignoreNullValues"></param>
        /// <param name="indentedFormatting"></param>
        /// <returns></returns>
        public static string SerializeObject(object value, bool ignoreNullValues = true, bool indentedFormatting = true)
        {
            // prepare formatting
            Newtonsoft.Json.Formatting formatting = Newtonsoft.Json.Formatting.None;
            if (indentedFormatting)
                formatting = Newtonsoft.Json.Formatting.Indented;

            JsonSerializerSettings serializeSettings = new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize
            };
            // ignore null values
            serializeSettings.NullValueHandling = ignoreNullValues ? NullValueHandling.Ignore : NullValueHandling.Include;

            string jsonString = JsonConvert.SerializeObject(value, formatting, serializeSettings);
            return jsonString;
        }

        /// <summary>
        /// Gets a string to deserialize to an object Type
        /// </summary>
        /// <typeparam name="Type"></typeparam>
        /// <param name="value"></param>
        /// <param name="additionalParameters"></param>
        /// <returns></returns>
        public static Type DeserializeObject<Type>(string value, object additionalParameters = null)
        {
            deserializeSettings.MissingMemberHandling = MissingMemberHandling.Ignore;
            if (additionalParameters != null)
            {
                //pass parameter to context property, to be used by object being serialized.
                deserializeSettings.Context = new System.Runtime.Serialization.StreamingContext(System.Runtime.Serialization.StreamingContextStates.Other, additionalParameters);
            }
            return JsonConvert.DeserializeObject<Type>(value, deserializeSettings);
        }

    }
}
