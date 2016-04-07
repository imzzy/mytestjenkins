using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Runtime.Serialization;
using LPReplayCore.Model;
using LPReplayCore.Interfaces;
using LPReplayCore.Common;

namespace LPReplayCore
{
    using DescriptorDictionary = Dictionary<string, ObjectDescriptor>;
    using TestObjectDictionary = SortedList<string, ITestObject>;
    using LPReplayCore.UIA;
    using System.Collections.ObjectModel;
    using System.Threading;

    /// <summary>
    /// AppModelSettings controls the set of objects to create
    /// from simplest replay only object, to the object that contains richer properties for
    /// authoring
    /// </summary>
    public enum ModelLoadLevel
    {
        ReplayOnly,
        Full
    }

    public class AppModel
    {
        TestObjectDictionary _testObjects;

        AppModelFile _modelFile;

        static ThreadLocal<AppModel> localThreadModel;

        public static void Initialize(string pathToModel)
        {
            localThreadModel = new ThreadLocal<AppModel>(()=> AppModelManager.Load(pathToModel));
        }

        public AppModelFile ModelFile
        {
            get
            {
                return _modelFile;
            }
            set
            {
                _modelFile = value;
            }
        }

        /// <summary>
        /// The current thread instance
        /// </summary>
        public static AppModel Current
        {
            get
            {
                if (localThreadModel == null)
                    throw new InvalidOperationException("Call \"Initialize\" before access the model, have you called Initialize on the current thread?");

                return localThreadModel.Value;
            }
        }

        public AppModel()
        {
            //_descriptors = new DescriptorDictionary();
            _testObjects = new SortedList<string, ITestObject>(new DuplicateComparer()); 
        }

        /// <summary>
        /// this overload function only search object using control properties
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="recursive"></param>
        /// <returns></returns>
        public ITestObject FindFirst(string key, string value, bool recursive = true)
        {
            //NodeName is not in properties list
            if (key == DescriptorKeys.NodeName)
            {
                return FindFirst(obj => obj.NodeName == value, recursive);
            }

            if (!recursive)
            {
                return _testObjects.Values.FirstOrDefault(o => o.Contains(key) && o[key] == value);
            }

            //recursive
            return AllItems.FirstOrDefault(o => o.Contains(key) && o[key] == value);
        }

        public ITestObject FindFirst(Func<ITestObject, bool> func, bool recursive = true)
        {
            if (!recursive)
            {
                return _testObjects.Values.FirstOrDefault(func);
            }

            //recursive
            return AllItems.FirstOrDefault(func);
        }

        public List<ITestObject> FindAll(string key, string value, bool recursive = true)
        {
            if (!recursive)
            {
                return new List<ITestObject>(_testObjects.Values).FindAll(o => o.Contains(key) && o[key] == value);
            }

            //recursive
            return AllItems.FindAll(o => o.Contains(key) && o[key] == value);
        }

        public ITestObject GetByNodeName(string name)
        {
            try
            {
                return FindFirst(to => to.NodeName == name);
            }
            catch (KeyNotFoundException)
            {
                throw new KeyNotFoundException(String.Format("The given key \"{0}\" is not in the dictionary", name));
            }
        }

        public List<ITestObject> AllItems
        {
            get
            {
                //TODO return all items in the list
                List<ITestObject> fullList = new List<ITestObject>();

                Func<IEnumerable<ITestObject>, IEnumerable<ITestObject>> recurse = null;
                //recursively find children
                recurse = delegate(IEnumerable<ITestObject> items)
                     {
                         foreach (ITestObject testObject in items)
                         {
                             fullList.Add(testObject);
                             if (testObject.Children != null)
                             {
                                 recurse(testObject.Children);
                             }
                         }
                         return null;
                     };

                recurse(new List<ITestObject>(_testObjects.Values));

                return fullList;
            }
        }

        public ITestObject this[string name]
        {
            get
            {
                return GetByNodeName(name);
            }
            set
            {
                _testObjects[name] = value;
            }
        }

        //return the direct child items
        public ReadOnlyCollection<ITestObject> Items
        {
            get
            {
                return new List<ITestObject>(_testObjects.Values).AsReadOnly();
            }
        }

        public string ProcessName { get; set; }

        public void Add(ITestObject obj)
        {
            _testObjects.Add(obj.NodeName?? string.Empty, obj);
        }

        public ITestObject GetTestObject(string name)
        {
            return FindFirst(to => to.NodeName == name);
        }
    }
}
