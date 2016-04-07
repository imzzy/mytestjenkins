using LPReplayCore.Interfaces;
using LPReplayCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertiesDictionary = System.Collections.Generic.Dictionary<string, string>;

namespace LPReplayCore
{
    using System.Collections.ObjectModel;
    using TestObjectList = List<ITestObject>;

    //TODO implement VirtualTestObject
    public class TestObjectBase: ITestObject
    {
        protected PropertiesDictionary _properties;

        public TestObjectBase()
        {
            _properties = new PropertiesDictionary();
        }

        public virtual object GetAutomationObject()
        {
            throw new NotImplementedException();
        }

        public virtual ObjectDescriptor GetDescriptor()
        {
            ObjectDescriptor descriptor = new ObjectDescriptor();
            descriptor.Name = this.NodeName;
            descriptor.Description = this.Description;

            
            foreach (ITestObject to in Children)
            {
                ObjectDescriptor childDescriptor = to.GetDescriptor();
                descriptor.Children.Add(childDescriptor);
                childDescriptor.Parent = descriptor;
            }

            return descriptor;
        }

        protected string _nodeName;
        public virtual string NodeName
        {
            get
            {
                return _nodeName;
            }
            set
            {
                //update the entry in the parent table
                /*if (_parent != null)
                {
                    _parent.RemoveChild(this);
                }*/
                _nodeName = value;
                /*
                if (_parent != null)
                {
                    _parent.AddChild(this);
                }*/
            }
        }

        static ReadOnlyCollection<ITestObject> _emptyChildren = (new List<ITestObject>()).AsReadOnly();

        //cached readonly reference, because AsReadOnly will return different objects with different calls.
        protected ReadOnlyCollection<ITestObject> _readonlyChildren;

        public ReadOnlyCollection<ITestObject> Children
        {
            get
            {
                if (_children == null || _children.Count == 0)
                {
                    return _emptyChildren;
                }

                if (_readonlyChildren == null)
                {
                    _readonlyChildren = _children.AsReadOnly();
                }
                return _readonlyChildren;
            }
        }

        protected string _description;
        public virtual string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }

        protected ITestObject _parent;
        public ITestObject Parent
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

        public virtual string this[string key]
        {
            get
            {
                return _properties[key];
            }
        }

        public virtual bool Contains(string key)
        {
            return _properties.ContainsKey(key);
        }

        public virtual string ControlName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// find in the direct children
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual ITestObject Find(string key, string value)
        {
            if (_children == null) return null;

            if (key == DescriptorKeys.NodeName)
            {
                return _children.Find(to => to.NodeName == value);
            }
            return _children.First(child => child.Contains(key) && child[key] == value);
        }

        protected TestObjectList _children;

        public ITestObject rootObject
        {
            get 
            {
                ITestObject parentObj = this;
                while ( null != parentObj.Parent)
                {
                    parentObj = parentObj.Parent;
                }
                return parentObj;
            }
            
        }
        public virtual ITestObject FindRecursive(string key, string value)
        {
            ITestObject testObject = Find(key, value);
            if (testObject != null) return testObject;

            if (_children == null) return null;

            foreach (ITestObject childObject in _children)
            {
                testObject = childObject.FindRecursive(key, value);
                if (testObject != null) return testObject;
            }
            return null;
        }

        public virtual void AddProperty(string key, string value)
        {
            throw new NotImplementedException();
        }

        public virtual void RemoveProperty(string key)
        {
            throw new NotImplementedException();
        }

        public virtual PropertiesDictionary Properties
        {
            get
            {
                return _properties;
            }
        }

        public virtual string ControlTypeString
        {
            get { throw new NotImplementedException(); }
        }

        public virtual ITestObject AddChild(ITestObject childObject)
        {
            if (_children == null)
            {
                _children = new TestObjectList();
            }
            _children.Add(childObject);
            childObject.Parent = this;

            return childObject;
        }

        public virtual bool RemoveChild(ITestObject testObject)
        {
            int index;
            if (_children == null) return false;

            if ((index = _children.FindIndex(to => to == testObject)) >= 0)
            {
                _children.RemoveAt(index);//.Remove(testObject.NodeName);
                return true;
            }
            else
            {
                return false;
            }
        }

        public virtual IRelation Relation
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public virtual int Index
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public virtual bool HasProperty(string key)
        {
            throw new NotImplementedException();
        }

        public virtual string AutomationId
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }


        private object[] _contexts;

        public virtual T GetContext<T>() where T : class
        {
            if (_contexts == null) return default(T);
            foreach (object obj in _contexts)
            {
                T context = obj as T;
                if (context != null) return context;
            }
            return default(T);
        }

        public virtual void SetContext<T>(T context) where T : class
        {
            if (_contexts != null)
            {
                //remove the existing object
                int i = 0;
                foreach (object obj in _contexts)
                {
                    if ((obj as T) != null)
                    {
                        _contexts[i] = null;
                        break;
                    }
                    i++;
                }
            }
            if (context != null)
            {
                //add or update the context
                if (_contexts == null)
                {
                    _contexts = new object[2]; //only supports 2 objects for the moment
                    _contexts[0] = context;
                }
                else
                {
                    int i = 0;
                    foreach (object obj in _contexts)
                    {
                        if (obj == null)
                        {
                            _contexts[i] = context;
                            break;
                        }
                        i++;
                    }
                }
            }
        }

    }
}
