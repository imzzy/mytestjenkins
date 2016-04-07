using LPReplayCore.Interfaces;
using LPReplayCore.UIA;
using LPReplayCore.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPReplayCore.Model
{
    class TestObjectFactory: ITOFactory<ITestObject>
    {
        public ITestObject CreateTestObject(ObjectDescriptor descriptor, ModelLoadLevel loadLevel = ModelLoadLevel.ReplayOnly)
        {
            if (descriptor.Type == NodeType.UIAControl)
            {
                ITestObject testObject = UIAUtility.CreateTestObject(descriptor, loadLevel);

                CreateChildObjects(testObject, descriptor, loadLevel);

                return testObject;
            }
            else if (descriptor.Type == NodeType.VirtualControl)
            {
                //TODO create the virtual control
                ITestObject testObject = VirtualTestObject.CreateTestObject(descriptor, loadLevel);

                CreateChildObjects(testObject, descriptor, loadLevel);

                return testObject;
                //return CreateTestObject(descriptor, loadLevel);
            }
            else if (descriptor.Type == NodeType.Selenium)
            {
                ITestObject testObject = new SETestObject(descriptor);

                CreateChildObjects(testObject, descriptor, loadLevel);

                return testObject;
            }
            
            throw new NotImplementedException();
        }

        private void CreateChildObjects(ITestObject parentTestObject, ObjectDescriptor descriptor, ModelLoadLevel loadLevel)
        {
            foreach (ObjectDescriptor childDescriptor in descriptor.Children)
            {
                ITestObject testObject = CreateTestObject(childDescriptor, loadLevel);
                parentTestObject.AddChild(testObject);
            }
        }
    }
}
