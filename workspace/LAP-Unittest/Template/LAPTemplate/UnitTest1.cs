using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LPUIAObjects;
using LPReplayCore;
using LPReplayCore.Interfaces;
using System.Windows.Automation;

namespace LAPUnitTest
{
    [TestClass]
    public class LAPTemplate
    {
        [ClassInitialize]
        public static void Init(TestContext context)
        {
            AppModel.Initialize("UnitTestObjectModel1.json");
            
            
        }

        [TestMethod]
        public void LAPTest1()
        {
            UIAWindow window = UIAManager.UIAWindow("LAP (Running) - Microsoft Visual Studio");

            UIAEdit searchBox = (UIAEdit)UIAManager.UIAWindow("LAP (Running) - Microsoft Visual Studio").UIAEdit("Search");

            searchBox.Set("abcdef");

            string text = searchBox.Text;

            Assert.AreEqual("abcdef", text);

        }

        [TestMethod]
        public void LAPTest2()
        {
            //UIAWindow window = UIA.UIAWindow("LAP (Running) - Microsoft Visual Studio");

            UIAEdit searchBox = UIAManager.UIAEdit("Search");

            searchBox.Set("abcdef");

            string text = searchBox.Text;

            Assert.AreEqual("abcdef", text);

        }

        [TestMethod]
        public void LAPTest3()
        {
            UIAManager.UIAWindow("LAP (Running) - Microsoft Visual Studio").UIAPane("Test Explorer").UIACustom("Search Control").UIAEdit("Search").Set("123456");
            string text = UIAManager.UIAWindow("LAP (Running) - Microsoft Visual Studio").UIAPane("Test Explorer").UIACustom("Search Control").UIAEdit("Search").Text;
            Assert.AreEqual("123456", text);

            //ITestObject testObject = ControlSearcher.GetTO(null, ControlType.Button, condition1, condition2);
        }

        [TestMethod]
        public void LAPTest4()
        {
            UIAModel calcModel = UIAManager.GetManager("CalcAppModel.json");

            
            UIAManager.UIAWindow("LAP (Running) - Microsoft Visual Studio").UIAPane("Test Explorer").UIACustom("Search Control").UIAEdit("Search").Set("123456");
            string text = UIAManager.UIAWindow("LAP (Running) - Microsoft Visual Studio").UIAPane("Test Explorer").UIACustom("Search Control").UIAEdit("Search").Text;
            Assert.AreEqual("123456", text);

            //ITestObject testObject = ControlSearcher.GetTO(null, ControlType.Button, condition1, condition2);

        }


        [TestMethod]
        public void LAPTest5()
        {
            UIAModel model = UIAManager.GetManager("CalcAppModel.json");
            model.UIAWindow("Calculator").UIAButton("Clear").Click();
            model.UIAWindow("Calculator").UIAButton("2").Click();
            model.UIAWindow("Calculator").UIAButton("+").Click();
            model.UIAWindow("Calculator").UIAButton("1").Click(); 
            model.UIAWindow("Calculator").UIAButton("=").Click();

            string result = model.UIAWindow("Calculator").UIAEdit("Edit").Text;

            Assert.AreEqual("3", result);
        }

    }
}
