using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LPReplayCore;
using LPReplayCore.UIA;
using LPReplayCore.Model;
using LPReplayCore.Interfaces;
using System.Collections.Generic;

#if TEST
namespace LPUIAObjects.UnitTest
{
    [TestClass]
    public class UIAConditionTest
    {
        /// <summary>
        /// Have to put in this project because it uses UIACondition object
        /// another related object is in JsonSerializerTest
        /// </summary>
        [TestMethod]
        public void AppModelManager_LoadFull()
        {
            AppModel model;
            ModelLoadLevel loadLevel = ModelLoadLevel.Full;
            model = AppModelManager.Load("CalcAppModel.json", loadLevel);
            UIATestObject testObject = (UIATestObject) model.FindFirst(DescriptorKeys.NodeName, "result");
            Assert.AreNotEqual(null, testObject);
            UIACondition condition = testObject.GetContext<UIACondition>();
            
            //TODO validate the content
        }

        void NormalizeCachedProperties(UIACondition uiaCondition)
        {
            ITestObject testObject = uiaCondition.TestObject;

            foreach (KeyValuePair<string, string> pair in testObject.Properties)
            {
                uiaCondition.CachedProperties.Remove(pair.Key);
            }
        }

        [TestMethod]
        public void UIACondition_NormalizeCachedProperties()
        {
            UIACondition uiaCondition = new UIACondition(new UIATestObject());
            uiaCondition.TestObject.AddProperty("property1", "value1");
            uiaCondition.TestObject.AddProperty("property2", "value2");
            uiaCondition.TestObject.AddProperty("property3", "value3");

            NormalizeCachedProperties(uiaCondition);
        }

        [TestMethod]
        public void UIACondition_CachedProperties()
        {
            ObjectDescriptor descriptor = ObjectDescriptor.FromJson(
               @"
                 {
			        ntype: ""uia"",
			        nname: ""button1"",
			        identifyProperties:{""name"": ""1""},
                    cachedProperties:{""className"": ""QWidget""},
			        description: ""button""
		        }");

            UIATestObject testObject = UIATestObject.ToTestObject(descriptor);

            CachedPropertyGroup cachedGroup = testObject.GetContext<CachedPropertyGroup>();

            Assert.AreNotEqual(null, cachedGroup);

            UIACondition condition = new UIACondition(testObject);

            Assert.AreEqual(1, condition.CachedProperties.Count);

        }
    }
}

#endif