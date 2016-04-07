using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using LPReplayCore.Interfaces;

namespace LPReplayCore
{
    using PropertyEntry = System.Collections.Generic.Dictionary<string, string>;
    
    public class PropertyGroup : IPropertyGroup
    {
        PropertyEntry _properties = new PropertyEntry();

        public PropertyGroup()
        {
        }

        public PropertyGroup(SerializationInfo info, StreamingContext context)
        {
            foreach (SerializationEntry se in info)
            {
                _properties.Add(se.Name, se.Value.ToString());
            }
        }

        public virtual string GetKey() { throw new NotImplementedException(); }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            foreach (KeyValuePair<string, string> pair in _properties)
            {
                info.AddValue(pair.Key, pair.Value);
            }
        }

        public PropertyEntry Properties 
        { 
            get {return _properties;}
            set { _properties = value; }
        }
    }


    public class IdentifyPropertyGroup : PropertyGroup
    {
        public IdentifyPropertyGroup() { }

        public const string Key = "identifyProperties";

        public override string GetKey() { return IdentifyPropertyGroup.Key; }

        public IdentifyPropertyGroup(SerializationInfo info, StreamingContext context) : base(info, context) { }

    }

    public class CachedPropertyGroup : PropertyGroup
    {
        public CachedPropertyGroup() { }

        public const string Key = "cachedProperties";

        public override string GetKey() { return CachedPropertyGroup.Key; }

        public CachedPropertyGroup(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
