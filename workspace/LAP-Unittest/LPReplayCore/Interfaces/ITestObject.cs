using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LPReplayCore.Model;
using System.Collections.ObjectModel;

namespace LPReplayCore.Interfaces
{
    /// <summary>
    /// Generate the test object from the descriptor
    /// AppModelSettings controls the set of objects to create
    /// </summary>
    public interface IObjectDescriptor
    {
        T GetObject<T>(ModelLoadLevel loadLevel) where T : ITOFactory<T>, ITestObject, new();
    }

    /// <summary>
    /// 
    /// </summary>
    public interface IDescriptor<T>
    {
        T GetObject();
    }

    /// <summary>
    /// Test object factory
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ITOFactory<T>
    {
        T CreateTestObject(ObjectDescriptor descriptor, ModelLoadLevel loadLevel = ModelLoadLevel.ReplayOnly);
    }

    public interface IRelation
    {
        ITestObject Left { get; set; }
        ITestObject Right { get; set; }
    }

    public interface IContext
    {
        T GetContext<T>() where T: class;

        void SetContext<T>(T context) where T : class;
    }


    public interface ITestObject : IContext
    {
        object GetAutomationObject();

        ObjectDescriptor GetDescriptor();

        string NodeName
        {
            get;
            set;
        }

        ReadOnlyCollection<ITestObject> Children
        {
            get;
        }

        string Description
        {
            get;
            set;
        }

        ITestObject Parent
        {
            get;
            set;
        }

        string this[string key]
        {
            get;
        }

        bool Contains(string key);

        string ControlName { get; set; }

        ITestObject Find(string key, string value);

        ITestObject FindRecursive(string key, string value);

        void AddProperty(string key, string value);
        void RemoveProperty(string key);

        Dictionary<string, string> Properties { get; }

        string ControlTypeString { get; }

        ITestObject AddChild(ITestObject testObject);

        bool RemoveChild(ITestObject testObject);

        IRelation Relation { get; set; }

        int Index { get; set; }

        bool HasProperty(string key);

        string AutomationId { get; set; }
    }
}
