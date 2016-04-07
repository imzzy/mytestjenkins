using LPReplayCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LPReplayCore.Model
{
    /// <summary>
    /// used to serialize and deserialize App Objects
    /// </summary>
    class AppDescriptor : ISerializable, IDescriptor<AppModel>
    {
        public string ProcessName { get; set; }

        public List<ObjectDescriptor> Children
        {
            get
            {
                if (_descriptors == null)
                {
                    _descriptors = new List<ObjectDescriptor>();
                }
                return _descriptors;
            }
            set
            {
                _descriptors = value;
            }
        }

        private List<ObjectDescriptor> _descriptors;

        public AppDescriptor()
        {
        }

        public AppDescriptor(SerializationInfo info, StreamingContext context)
        {
            string ntype = info.GetString(DescriptorKeys.NodeType);
            Trace.Assert(ntype == NodeType.AppModel); //should be AppModel

            ProcessName = info.GetString(DescriptorKeys.Process);

            _descriptors = (List<ObjectDescriptor>)info.GetValue(DescriptorKeys.Controls, typeof(List<ObjectDescriptor>));

            Debug.WriteLine(_descriptors.Count);
        }

        public AppDescriptor(AppModel model)
        {
            // TODO: Complete member initialization

            this.ProcessName = model.ProcessName;

            List<ObjectDescriptor> descriptors = new List<ObjectDescriptor>();

            foreach (ITestObject testObject in model.Items)
            {
                ObjectDescriptor desriptor = testObject.GetDescriptor();
                descriptors.Add(desriptor);
            }

            _descriptors = descriptors;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(DescriptorKeys.NodeType, NodeType.AppModel);

            info.AddValue(DescriptorKeys.Process, ProcessName);

            info.AddValue(DescriptorKeys.Controls, _descriptors);
        }

        public AppModel GetObject()
        {
            AppModel model = new AppModel();
            model.ProcessName = this.ProcessName;
            TestObjectFactory factory = new TestObjectFactory();
            
            foreach (ObjectDescriptor descriptor in _descriptors)
            {
                ITestObject testObject = factory.CreateTestObject(descriptor,ModelLoadLevel.Full);
                model.Add(testObject);
            }

            return model;
        }
    }
}
