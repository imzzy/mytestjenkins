using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LPReplayCore.UIA;
using System.Drawing;
using LPReplayCore.Model;
using System.Diagnostics;
using System.Windows;
using LPReplayCore.Interfaces;

#if TEST
namespace LPReplayCore.UnitTest
{
    [TestClass]
    public class VirtualTestObjectTest
    {
        [TestMethod]
        public void VirtualTestObject_StringRectToRect()
        {
            Rect rect = VirtualTestObject.StringRectToRect("11, 16, 200, 84");

            Assert.AreEqual(new Rect(11, 16, 200, 84), rect);
        }

        [TestMethod]
        public void VirtualTestObject_Properties()
        {
            VirtualTestObject virtualObject = new VirtualTestObject();

            virtualObject.Properties.Add(ControlKeys.Text, "Some text");

            Assert.AreEqual("Some text", virtualObject.Properties[ControlKeys.Text]);
        }

        [TestMethod]
        public void VirtualTestObject_ctor()
        {
            VirtualTestObject virtualObject = new VirtualTestObject();
            Assert.AreEqual(NodeType.VirtualControl, virtualObject.ControlTypeString);
            virtualObject.BoundingRect = new Rect(10, 10, 100, 200);
            virtualObject.NodeName = "test control";
            Assert.AreEqual(1, virtualObject.Properties.Count);
            Assert.IsTrue(virtualObject.Properties.ContainsKey(UIAControlKeys.BoundingRectangle));
            Assert.AreEqual("10,10,100,200", virtualObject.Properties[UIAControlKeys.BoundingRectangle]);
        }


        [TestMethod]
        public void VirtualTestObject_CreateTestObject()
        {
            ObjectDescriptor descriptor = ObjectDescriptor.FromJson(
            @"
            {
              ""ntype"": ""virtual"",
              ""nname"": ""commission"",
              ""identifyProperties"": {
			    ""boundingRectangle"": ""12, 185, 201, 80""
              }
            }");

            VirtualTestObject virtualObject = VirtualTestObject.CreateTestObject(descriptor, ModelLoadLevel.Full);
            Assert.AreEqual("commission", virtualObject.NodeName);

            Rectangle expectedRect = new Rectangle(12, 185, 201, 80);

            Assert.AreEqual(expectedRect, virtualObject.BoundingRectangle);
        }

        [TestMethod]
        public void VirtualTestObject_GetDescriptor()
        {
            VirtualTestObject virtualObject = new VirtualTestObject("Rect1", new Rectangle(10, 11, 110, 220));
            ObjectDescriptor descriptor = virtualObject.GetDescriptor();

            Debug.WriteLine(descriptor.ToString());

        }

        [TestMethod]
        public void VirtualTestObject_AreEqual()
        {
            VirtualTestObject virtualObject1 = new VirtualTestObject("control1", new Rectangle(10, 11, 110, 220));
            VirtualTestObject virtualObject1_1 = new VirtualTestObject("control1", new Rectangle(10, 11, 110, 220));
            VirtualTestObject virtualObject2 = new VirtualTestObject("another_control", new Rectangle(10, 11, 110, 220));
            VirtualTestObject virtualObject3 = new VirtualTestObject("another_control", new Rectangle(20, 31, 210, 320));
            VirtualTestObject virtualObject4 = null;

            Assert.IsTrue(virtualObject1 == virtualObject1_1);

            Assert.IsTrue(virtualObject1 != virtualObject2);
            Assert.IsTrue(virtualObject2 != virtualObject3);
            Assert.IsTrue(virtualObject1 != virtualObject4);
        }
    }
}

#endif