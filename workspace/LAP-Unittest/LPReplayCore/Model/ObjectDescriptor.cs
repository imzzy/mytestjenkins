using LPReplayCore.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using PropertyEntry = System.Collections.Generic.Dictionary<string, string>;


namespace LPReplayCore.Model
{
    public struct DescriptorKeys
    {
        public const string NodeType = "ntype";
        public const string NodeName = "nname";
        public const string Children = "children";
        public const string Description = "description";
        public const string Controls = "controls";
        public const string Process = "process";
    }

    //ObjectDescriptor type
    public struct NodeType
    {
        public const string AppModel = "app";
        public const string UIAControl = "uia";
        public const string VirtualControl = "virtual";
        public const string Selenium = "se";
    }

    //the descriptor of the control 
    /// <summary>
    /// IClonable is used to dumping ObjectDescriptor for logging purpose
    /// </summary>
    public class ObjectDescriptor : ISerializable, ICloneable, IDescriptor<ITestObject>
    {

        static Dictionary<Type, object> _factoryTable = new Dictionary<Type, object>();

        //identifying properties
        //use Dictionary<string, string> type instead of StringDictionary, since it contains SequenceEquals method
        PropertyEntry _properties = new PropertyEntry();

        string _nodeName;

        string _descripton;

        List<ObjectDescriptor> _children;

        ObjectDescriptor _parent;

        Dictionary<string, IPropertyGroup> _descriptorItems;

        public ObjectDescriptor()
        {
        }


        #region ISerializable Members

        public ObjectDescriptor(SerializationInfo info, StreamingContext context)
        {
            ModelLoadLevel loadLevel;
            loadLevel = (context.Context != null) ? (ModelLoadLevel)context.Context : ModelLoadLevel.ReplayOnly;

            foreach (SerializationEntry se in info)
            {
                switch (se.Name)
                {
                    case DescriptorKeys.NodeType:
                        {
                            this.Type = se.Value.ToString();
                            Debug.Assert(this.Type == NodeType.UIAControl || this.Type == NodeType.VirtualControl
                                || this.Type == NodeType.Selenium);
                            continue;
                        }
                    case DescriptorKeys.NodeName:
                        {
                            _nodeName = se.Value.ToString();
                            continue;
                        }
                    case DescriptorKeys.Description:
                        {
                            _descripton = se.Value.ToString();
                            continue;
                        }
                    case DescriptorKeys.Children:
                        {
                            _children = (List<ObjectDescriptor>)info.GetValue(DescriptorKeys.Children, typeof(List<ObjectDescriptor>));
                            foreach (ObjectDescriptor child in _children)
                            {
                                child.Parent = this;
                            }
                            break;
                        }
                    case VisualRelationPropertyItem.Key:
                        {
                            if (_descriptorItems == null) _descriptorItems = new Dictionary<string, IPropertyGroup>();

                            _descriptorItems.Add(VisualRelationPropertyItem.Key,
                                (VisualRelationPropertyItem)info.GetValue(VisualRelationPropertyItem.Key, typeof(VisualRelationPropertyItem)));
                            break;
                        }
                    case IdentifyPropertyGroup.Key:
                        {
                            if (_descriptorItems == null) _descriptorItems = new Dictionary<string, IPropertyGroup>();

                            _descriptorItems.Add(IdentifyPropertyGroup.Key,
                                (IdentifyPropertyGroup)info.GetValue(IdentifyPropertyGroup.Key, typeof(IdentifyPropertyGroup)));
                            break;
                        }
                    case CachedPropertyGroup.Key:
                        {
                            if (loadLevel == ModelLoadLevel.ReplayOnly) break; //replay only mode doesn't need this 
                            if (_descriptorItems == null) _descriptorItems = new Dictionary<string, IPropertyGroup>();

                            _descriptorItems.Add(CachedPropertyGroup.Key,
                                (CachedPropertyGroup)info.GetValue(CachedPropertyGroup.Key, typeof(CachedPropertyGroup)));
                            break;
                        }
                    default:
                        {
                            _properties.Add(se.Name, (string)se.Value.ToString());
                            break;
                        }
                }

            }
        }


        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            //TODO: will update this when more tools added
            info.AddValue(DescriptorKeys.NodeType, this.Type);
            info.AddValue(DescriptorKeys.NodeName, this.Name);
            info.AddValue(DescriptorKeys.Description, this.Description);

            foreach (KeyValuePair<string, string> pair in _properties)
            {
                Debug.WriteLine(pair.Key);
                info.AddValue((string)pair.Key, (string)pair.Value);
            }
            if (_descriptorItems == null) return;

            foreach (KeyValuePair<string, IPropertyGroup> entry in _descriptorItems)
            {
                info.AddValue(entry.Key, entry.Value);
            }

            if (_children != null)
            {
                info.AddValue(DescriptorKeys.Children, _children);
            }
        }

        #endregion


        public static ObjectDescriptor FromJson(string json)
        {
            return DescriptorSerializer.FromJson(json);
        }

        public static ObjectDescriptor FromJson(string json, ObjectDescriptor parent)
        {
            ObjectDescriptor descriptor = DescriptorSerializer.FromJson(json);
            parent.Children.Add(descriptor);
            descriptor.Parent = parent;
            return descriptor;
        }


        //the name given by the automation user
        public string Name
        {
            get
            {
                return _nodeName;
            }
            set
            {
                _nodeName = value;
            }
        }


        public string Description
        {
            get
            {
                return _descripton;
            }
            set
            {
                _descripton = value;
            }
        }

        public bool Contains(string key)
        {
            return _properties.ContainsKey(key);
        }

        public string this[string key]{
            get
            {
                return _properties[key];
            }
        }

        public List<ObjectDescriptor> Children
        {
            get
            {
                if (_children == null)
                {
                    _children = new List<ObjectDescriptor>();
                }
                return _children;
            }
        }

        public ObjectDescriptor Parent
        {
            get
            {
                return _parent;
            }

            set
            {
                _parent = value;
            }
        }

        public override string ToString()
        {
            //TODO: implement own to string logic
            return base.ToString();
        }


        public T GetItem<T>() where T: class, IPropertyGroup
        {
            if (_descriptorItems == null) return default(T);

            foreach (IPropertyGroup item in _descriptorItems.Values)
            {
                T t = item as T;
                if (t != null) return t;
            }
            return null;
        }

        public void SetItem<T>(T t) where T : class, IPropertyGroup
        {
            if (_descriptorItems == null) _descriptorItems = new Dictionary<string,IPropertyGroup>();

            _descriptorItems[t.GetKey()] = t;
        }


        public ObjectDescriptor Find(string key, string value)
        {
            return _children.First(o => o.Contains(key) && o[key] == value);
        }

        /// <summary>
        /// Add identifying properties
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(string key, string value)
        {
            _properties.Add(key, value);
        }

        /// <summary>
        /// Add identifying properties
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void AddOptional(string key, string value)
        {
            _properties.Add(key, value);
        }

        public PropertyEntry Properties
        {
            get
            {
                //TODO, consider convert it to readonly
                return _properties;
            }
        }

        public override bool Equals(object obj)
        {
            ObjectDescriptor descriptor = obj as ObjectDescriptor;
            if (descriptor == null) return false;

            return _properties.OrderBy(r => r.Key).SequenceEqual(descriptor.Properties.OrderBy(r => r.Key));
        }

        public string Type { get; set; }

        public object Clone()
        {
            ObjectDescriptor descriptor = new ObjectDescriptor();
            descriptor.Type = NodeType.UIAControl;
            descriptor.Name = this.Name;
            descriptor.Description = this.Description;

            foreach (KeyValuePair<string, string> pair in _properties)
            {
                descriptor.Add(pair.Key, pair.Value);
            }

            if (_descriptorItems == null) return descriptor;

            foreach (KeyValuePair<string, IPropertyGroup> entry in _descriptorItems)
            {
                descriptor.SetItem<IPropertyGroup>(entry.Value);
            }
            return descriptor;

            //not clone the children
        }

        public ITestObject GetObject()
        {
            TestObjectFactory factory = new TestObjectFactory();

            return factory.CreateTestObject(this);
        }
    }
}
