using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using LPReplayCore.Model;
using LPReplayCore.UIA;
using LPReplayCore.Common;
using System.Windows.Automation;

#if TEST
namespace LPUIAObjects.UnitTest
{
    [TestClass]
    public class ElementPropertiesTest
    {
        [TestMethod]
        public void ElementProperties_ToNurseObject()
        {
            Dictionary<string, string> properties = new Dictionary<string,string>(){
                {UIAControlKeys.Name, "myName"},
                {UIAControlKeys.AutomationId, "myId"},
                {UIAControlKeys.ClassName, "myClass"},
                {UIAControlKeys.HelpText, "myHelpText"},
                {UIAControlKeys.AccessKey, ""},
                {UIAControlKeys.Type, "Button"}
            };

            ElementProperties element = new ElementProperties(properties);
            LPReplayCore.TestObjectNurse nurseObject = element.ToNurseObject();

            UIATestObject testObject = (UIATestObject) nurseObject.TestObject;
            Assert.AreEqual(3, testObject.Properties.Count); //only 3 recommended properties;

            Assert.AreEqual(4, nurseObject.CachedProperties.Count); //There are suppose 4 cached properties;

            Assert.AreEqual(element.DerivedName, testObject.NodeName);

        }

        [TestMethod]
        public void ElementProperties_ToNurseObject2()
        {
            Dictionary<string, string> properties = new Dictionary<string, string>(){
                {UIAControlKeys.AutomationId, "myId"},
                {UIAControlKeys.AccessKey, ""},
                {UIAControlKeys.ClassName, "CalcClass"}
            };

            ElementProperties element = new ElementProperties(properties);
            LPReplayCore.TestObjectNurse nurseObject = element.ToNurseObject();

            UIATestObject testObject = (UIATestObject)nurseObject.TestObject;
            Assert.AreEqual(2, testObject.Properties.Count); //only 3 recommended properties;

            Assert.AreEqual(2, nurseObject.CachedProperties.Count); //only cached non-empty properties

            Assert.AreEqual(element.DerivedName, testObject.NodeName);

        }

        [TestMethod]
        public void ElementProperties_DeriveName()
        {
            Dictionary<string, string> properties = new Dictionary<string, string>(){
                {ControlKeys.Type, ControlType.Button.ControlTypeToString()},
                {ControlKeys.Name, "OkButton"}
            };

            ElementProperties element = new ElementProperties(properties);
            Assert.AreEqual("OkButton", element.DerivedName);
        }

        [TestMethod]
        public void ElementProperties_DeriveName1()
        {
            ElementProperties.ResetSeed();
            Dictionary<string, string> properties = new Dictionary<string, string>(){
                {UIAControlKeys.Type, ControlType.CheckBox.ControlTypeToString()},
                {UIAControlKeys.ClassName, "CalcClass"} /*any other property*/
            };

            ElementProperties element = new ElementProperties(properties);
            Assert.AreEqual("CheckBox1", element.DerivedName);
            //repeated call generates the same result
            Assert.AreEqual("CheckBox1", element.DerivedName);
        }
    }
}

#endif