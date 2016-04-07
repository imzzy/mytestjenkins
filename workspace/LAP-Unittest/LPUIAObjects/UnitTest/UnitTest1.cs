using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LPReplayCore.UnitTest;
using LPReplayCore.Model;
using LPReplayCore.UIA;
using LPReplayCore.Interfaces;

#if TEST
namespace LPUIAObjects.UnitTest
{
    [TestClass]
    public class UIAEditTest
    {
        [ClassInitialize]
        public static void Init(TestContext context)
        {
            TestUtility.LaunchQTCalculator();
        }

        string calcJsonString = 
@"{
      ""ntype"": ""uia"",
      ""nname"": ""Calculator"",
      ""description"": """",
      ""identifyProperties"": {
        ""type"": ""Window"",
        ""title"": ""Calculator""
      },
    ""children"": [
        {
          ""ntype"": ""uia"",
          ""nname"": ""1"",
          ""description"": """",
          ""identifyProperties"": {
            ""type"": ""Button"",
            ""name"": ""1""
          }
        },
        {
          ""ntype"": ""uia"",
          ""nname"": ""Edit"",
          ""description"": """",
          ""identifyProperties"": {
            ""type"": ""Edit"",
            ""text"": ""2""
          }
        }
     ]
}";
        [TestMethod]
        public void UIAEdit_Text()
        {
            ObjectDescriptor descriptor = ObjectDescriptor.FromJson(calcJsonString);
            ITestObject parentObject = descriptor.GetObject();

            UIATestObject button1Object = (UIATestObject) parentObject.FindRecursive(DescriptorKeys.NodeName, "1");
            UIATestObject resultObject = (UIATestObject)parentObject.FindRecursive(DescriptorKeys.NodeName, "1");

            UIAEdit uiaEdit = new UIAEdit(new UIACondition(resultObject));
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            TestUtility.ExitQTCalculator();
        }
    }
}
#endif