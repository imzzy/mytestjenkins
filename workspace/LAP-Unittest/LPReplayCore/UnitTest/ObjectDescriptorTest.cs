using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using LPReplayCore.Model;
using LPReplayCore.UIA;
using LPReplayCore.Common;
using LPReplayCore.Interfaces;
using System.Runtime.Serialization;
using System.Drawing;
using System.Windows;

#if TEST
namespace LPReplayCore.UnitTest
{
    /// <summary>
    /// Summary description for ObjectDescriptorTest
    /// </summary>
    [TestClass]
    public class ObjectDescriptorTest
    {
        public ObjectDescriptorTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void ObjectDescriptor_EqualsPositive()
        {
            ObjectDescriptor descriptor1 = new ObjectDescriptor();
            descriptor1.Add("property1", "value1");
            descriptor1.Add("property2", "value2");

            ObjectDescriptor descriptor2 = new ObjectDescriptor();
            descriptor2.Add("property2", "value2");
            descriptor2.Add("property1", "value1");

            bool result = descriptor1.Equals(descriptor2);

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ObjectDescriptor_EqualsNegative()
        {
            ObjectDescriptor descriptor1 = new ObjectDescriptor();
            descriptor1.Add("property1", "value1");
            descriptor1.Add("property2", "value2");

            ObjectDescriptor descriptor2 = new ObjectDescriptor();
            descriptor2.Add("property2", "value2");
            descriptor2.Add("property1", "value1");
            descriptor2.Add("property3", "value3");

            bool result = descriptor1.Equals(descriptor2);

            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ObjectDescriptor_EqualsEmpty()
        {
            ObjectDescriptor descriptor1 = new ObjectDescriptor();
           
            ObjectDescriptor descriptor2 = new ObjectDescriptor();

            bool result = descriptor1.Equals(descriptor2);

            Assert.AreEqual(true, result);


            ObjectDescriptor descriptor3 = null;

            result = descriptor1.Equals(descriptor3);

            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ObjectDescriptor_GetTestObject()
        {
            ObjectDescriptor windowDescriptor = ObjectDescriptor.FromJson(@"
                {ntype:""uia"", identifyProperties: {name: ""Calculator""}}
                ");

            ObjectDescriptor buttonDescriptor = ObjectDescriptor.FromJson(@"
                {ntype:""uia"", identifyProperties: {name: ""1""}}
                ", windowDescriptor);

            Assert.AreEqual(1, windowDescriptor.Children.Count, "This top descriptor should contain one child");

            ITestObject windowObject = windowDescriptor.GetObject();

            Assert.AreEqual(1, windowObject.Children.Count);
            Assert.AreEqual("Calculator", windowObject.ControlName);

            UIATestObject uiaObject = (UIATestObject)windowObject.Children[0];
            Assert.AreEqual("1", uiaObject.ControlName);
        }

        [TestMethod]
        public void ObjectDescriptor_GetVirtualTestObject()
        {
            //TODO
            ObjectDescriptor windowDescriptor = ObjectDescriptor.FromJson(@"
                {""ntype"": ""uia"", identifyProperties: {name: ""Calculator""}}
                ");
            ObjectDescriptor virtualDescriptor = ObjectDescriptor.FromJson(@"
                {""ntype"": ""virtual"", identifyProperties: {""boundingRectangle"": ""12, 185, 201, 80""}}
                ", windowDescriptor);

            Assert.AreEqual(1, windowDescriptor.Children.Count, "This top descriptor should contain one child");

            ITestObject windowObject = windowDescriptor.GetObject();

            Assert.AreEqual(1, windowObject.Children.Count);
            Assert.AreEqual("Calculator", windowObject.ControlName);

            ITestObject virtualObject = (ITestObject)windowObject.Children[0];
            Assert.IsTrue(virtualObject is VirtualTestObject);
            

        }

        [TestMethod]
        public void ObjectDescriptor_Serialization()
        {
            ObjectDescriptor descriptor = new ObjectDescriptor();
            descriptor.Properties.Add("property1", "value1");
            descriptor.Properties.Add("property2", "value2");

            string serializedObject = JsonUtil.SerializeObject(descriptor);
            Debug.WriteLine(serializedObject);
            //TODO check the serialized JSON content;
        }

        [TestMethod]
        public void ObjectDescriptor_SerializeVirtualTestObject()
        {
            //TODO
            ObjectDescriptor descriptor = new ObjectDescriptor();
            VirtualTestObject testObject = new VirtualTestObject();

            descriptor.Properties.Add(UIAControlKeys.BoundingRectangle, "1003,364,167,28");

            string serializedObject = JsonUtil.SerializeObject(descriptor);
            Debug.WriteLine(serializedObject);
        }

        [TestMethod]
        public void ObjectDescriptor_PropertyGroup()
        {
            ObjectDescriptor descriptor = new ObjectDescriptor();
            descriptor.Properties.Add("property1", "value1");

            IdentifyPropertyGroup identifyGroup = new IdentifyPropertyGroup();
            identifyGroup.Properties.Add("property3", "value3");
            identifyGroup.Properties.Add("property4", "value4");
            descriptor.SetItem<IdentifyPropertyGroup>(identifyGroup);

            CachedPropertyGroup cachedGroup = new CachedPropertyGroup();
            cachedGroup.Properties.Add("property5", "value5");
            cachedGroup.Properties.Add("property6", "value6");
            cachedGroup.Properties.Add("imageFile", "testImageFile.png");
            descriptor.SetItem<CachedPropertyGroup>(cachedGroup);

            string serializedObject = JsonUtil.SerializeObject(descriptor);
            Debug.WriteLine(serializedObject);

            Assert.IsTrue(serializedObject.IndexOf("property6") > 0);
            Assert.IsTrue(serializedObject.IndexOf("value6") > 0);

            Assert.IsTrue(serializedObject.IndexOf("testImageFile.png") > 0);
            Assert.IsTrue(serializedObject.IndexOf("imageFile") > 0);
            //TODO check the serialized JSON content;
        }

        [TestMethod]
        public void ObjectDescriptor_GetObjectData()
        {
            FormatterConverter formatConverter = new FormatterConverter();
            SerializationInfo serializationInfo = new SerializationInfo(typeof(ObjectDescriptor), formatConverter);

            VirtualTestObject virtualTestObject = new VirtualTestObject() { BoundingRect = new Rect(10, 20, 30, 40) };
            ObjectDescriptor descriptor = virtualTestObject.GetDescriptor();

            StreamingContext context = new StreamingContext();
            IdentifyPropertyGroup group = descriptor.GetItem<IdentifyPropertyGroup>();
            Assert.AreEqual("10,20,30,40", group.Properties[UIAControlKeys.BoundingRectangle]);
            descriptor.GetObjectData(serializationInfo, context);

            string typeString = null;
            
            foreach (SerializationEntry entry in serializationInfo)
            {
                if (entry.Name == DescriptorKeys.NodeType)
                {
                    typeString = (string)entry.Value;
                    break;
                }
                else if (entry.Name == IdentifyPropertyGroup.Key)
                {
                    group = (IdentifyPropertyGroup)entry.Value;
                    break;
                }
            }
            Assert.AreEqual(NodeType.VirtualControl, typeString);
            Assert.AreEqual("10,20,30,40", group.Properties[UIAControlKeys.BoundingRectangle]);
        }
    }
}

#endif