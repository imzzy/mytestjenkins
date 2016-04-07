using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Interactions;


namespace LPWebObjects.UnitTest
{
    [TestClass]
    public class SeleniumTest
    {
        private ChromeDriver _chromeDriver = new ChromeDriver(LPReplayCore.Common.Utility.GetBinDirectory());

        [TestInitialize]
        public void TestInitialize()
        {
            //_chromeDriver.Navigate().GoToUrl("https://jqueryui.com/droppable/");
            _chromeDriver.Navigate().GoToUrl("https://jqueryui.com/resources/demos/droppable/default.html");
            //_chromeDriver.Navigate().GoToUrl(@"D:\Git\AUT\AUT.html");
            _chromeDriver.Manage().Window.Maximize();
        }

        [TestMethod]
        public void TestDragAndDrop()
        {
            RemoteWebElement dragElement = _chromeDriver.FindElementById("draggable") as RemoteWebElement;
            Assert.AreNotEqual(dragElement, null);

            RemoteWebElement dropElement = _chromeDriver.FindElementById("droppable") as RemoteWebElement;
            Assert.AreNotEqual(dragElement, null);

            Actions actions = new Actions(_chromeDriver);

            actions.DragAndDrop(dragElement, dropElement).Perform();

       
        }

        [TestMethod]
        public void TestDragAndDrop2()
        {

            RemoteWebElement dragElement = _chromeDriver.FindElementById("draggable") as RemoteWebElement;
            Assert.AreNotEqual(dragElement, null);

            RemoteWebElement dropElement = _chromeDriver.FindElementById("droppable") as RemoteWebElement;
            Assert.AreNotEqual(dragElement, null);

            System.Threading.Thread.Sleep(2000);
            Actions actions = new Actions(_chromeDriver);

            actions.ClickAndHold(dragElement);

            actions.MoveToElement(dropElement);//, dragElement.Size.Width / 2, dragElement.Size.Height / 2);

            actions.Perform();

            System.Threading.Thread.Sleep(250);

            actions.Release(dropElement); actions.Perform();
     

        }

        [TestMethod]
        public void TestDragAndDrop3()
        {

            RemoteWebElement dragElement = _chromeDriver.FindElementById("draggable") as RemoteWebElement;
            Assert.AreNotEqual(dragElement, null);

            RemoteWebElement dropElement = _chromeDriver.FindElementById("droppable") as RemoteWebElement;
            Assert.AreNotEqual(dragElement, null);

            Actions actions = new Actions(_chromeDriver);

            IHasInputDevices inputDevices = (IHasInputDevices)_chromeDriver;

            

            inputDevices.Mouse.MouseMove(dragElement.Coordinates);
            
            inputDevices.Mouse.MouseDown(dragElement.Coordinates);

            inputDevices.Mouse.MouseMove(dragElement.Coordinates, 1, 1);

            
            //
            inputDevices.Mouse.MouseMove(dropElement.Coordinates);
            inputDevices.Mouse.MouseUp(dropElement.Coordinates);


        }

        private const string jsDragStart = "window.dragstartArg = new Event('dragstart', {bubbles: true});" +
            " window.dragstartArg.dataTransfer = { data: {}, setData: function(type, val){ this.data[type] = val; }, getData: function(type){} };" +
       // "syntheticDragStartEvent.pageX = arguments[0].offsetLeft;" +
       // "syntheticDragStartEvent.pageY = arguments[0].offsetTop;" +
        "arguments[0].dispatchEvent(window.dragstartArg);";

        private const string jsDrag2 = "var syntheticDragEvent = new Event('drag', {bubbles: true});" +
            //"syntheticDragStartEvent.type='drop'" +
             "syntheticDragEvent.dataTransfer = window.dragstartArg.dataTransfer; alert(window.dragstartArg.dataTransfer.getData(\"text\"));" +
             "arguments[0].dispatchEvent(syntheticDragEvent);";



        private const string jsDrag = "/*var syntheticDragEvent = new Event('drag', {bubbles: true});*/" +
            "syntheticDragStartEvent.type='drop'" + 
             "syntheticDragEvent.pageX = arguments[1];" +
             "syntheticDragEvent.pageY = arguments[2];" +
             "arguments[0].dispatchEvent(syntheticDragEvent);";

        private const string jsDragOver = " var syntheticDragoverEvent = new Event('dragover', {bubbles: true});" +
            "var ableToDrop = false;" +
            "var oldPreventDefault = syntheticDragoverEvent.preventDefault;" +
           // "syntheticDragoverEvent.preventDefault = function () { ableToDrop = true; oldPreventDefault(syntheticDragoverEvent);}" +
            "syntheticDragoverEvent.pageX = arguments[1];" +
            "syntheticDragoverEvent.pageY = arguments[2];" +
            "arguments[0].dispatchEvent(syntheticDragoverEvent);";


        private const string jsDrop = "  var syntheticDropEvent = new Event('drop', {bubbles: true});" +
            "syntheticDropEvent.pageX = arguments[1];" +
            "syntheticDropEvent.pageY = arguments[2];" +
            "arguments[0].dispatchEvent(syntheticDropEvent);";


        private const string jsDragEnd = "arguments[0].dispatchEvent(new Event('dragend', {bubbles: true}));";

        [TestMethod]
        public void TestDragAndDrop4()
        {
            RemoteWebElement dragElement = _chromeDriver.FindElementById("draggable") as RemoteWebElement;
            Assert.AreNotEqual(dragElement, null);

            RemoteWebElement dropElement = _chromeDriver.FindElementById("droppable") as RemoteWebElement;
            Assert.AreNotEqual(dragElement, null);

            Actions actions = new Actions(_chromeDriver);

            IHasInputDevices inputDevices = (IHasInputDevices)_chromeDriver;

            inputDevices.Mouse.Click(dragElement.Coordinates);

            inputDevices.Mouse.MouseMove(dragElement.Coordinates);

            inputDevices.Mouse.MouseDown(dragElement.Coordinates);

            //
            _chromeDriver.ExecuteScript(jsDragStart, dragElement);

            _chromeDriver.ExecuteScript(jsDrag, dragElement, dragElement.Location.X, dragElement.Location.Y);

            //
            inputDevices.Mouse.MouseMove(dropElement.Coordinates);

            //
            _chromeDriver.ExecuteScript(jsDragOver, dropElement, dropElement.Location.X, dropElement.Location.Y);
            //
            _chromeDriver.ExecuteScript(jsDrop, dropElement, dropElement.Location.X, dropElement.Location.Y);

            //
            _chromeDriver.ExecuteScript(jsDrop, dropElement);
            inputDevices.Mouse.MouseUp(dropElement.Coordinates);
        }


        private const string jsDnD = "var dragstartArg = new Event('dragstart', {bubbles: true});" +
            "dragstartArg.dataTransfer = { data: {},	setData: function(type, val){this.data[type] = val;},getData: function(type){return this.data[type];}};" +
            "arguments[0].dispatchEvent(dragstartArg);" +
            "var dropArg = new Event('drop', {bubbles: true});" +
            "dropArg.dataTransfer = dragstartArg.dataTransfer;" +
            "arguments[1].dispatchEvent(dropArg);" +
            "var dragendArg = new Event('dragend', {bubbles: true});" +
            "arguments[0].dispatchEvent(dragendArg);";


        [TestMethod]
        public void TestDragAndDrop5()
        {
            RemoteWebElement dragElement = _chromeDriver.FindElementById("draggable") as RemoteWebElement;
            Assert.AreNotEqual(dragElement, null);

            RemoteWebElement dropElement = _chromeDriver.FindElementById("droppable") as RemoteWebElement;
            Assert.AreNotEqual(dragElement, null);

            Actions actions = new Actions(_chromeDriver);
            
            _chromeDriver.ExecuteScript(jsDnD, dragElement, dropElement);

       
        }

        private const string jsDnD1 = "window.dragstartArg = new Event('dragstart', {bubbles: true});" +
           "window.dragstartArg.dataTransfer = { data: {},	setData: function(type, val){this.data[type] = val;},getData: function(type){return this.data[type];}};" +
           "arguments[0].dispatchEvent(window.dragstartArg);";

        //private const string jsDnD1 = "var dragstartArg = new Event('dragstart', {bubbles: true});" +
        //   "dragstartArg.dataTransfer = { data: {},	setData: function(type, val){this.data[type] = val;},getData: function(type){return this.data[type];}};" +
        //   "arguments[0].dispatchEvent(dragstartArg);";


        private const string jsDnD2 =
           "var dropArg = new Event('drop', {bubbles: true});" +
           "dropArg.dataTransfer = window.dragstartArg.dataTransfer;" +
           "arguments[1].dispatchEvent(dropArg);" +
           "var dragendArg = new Event('dragend', {bubbles: true});" +
           "window.dragstartArg.srcElement.dispatchEvent(dragendArg);" +
           "window.dragstartArg = null;";

        //private const string jsDnD2 =
        //   "var dropArg = new Event('drop', {bubbles: true});" +
        //   "dropArg.dataTransfer = dragstartArg.dataTransfer;" +
        //   "arguments[1].dispatchEvent(dropArg);" +
        //   "var dragendArg = new Event('dragend', {bubbles: true});" +
        //   "arguments[0].dispatchEvent(dragendArg);";

        [TestMethod]
        public void TestDragAndDrop6()
        {
            RemoteWebElement dragElement = _chromeDriver.FindElementById("draggable") as RemoteWebElement;
            Assert.AreNotEqual(dragElement, null);

            RemoteWebElement dropElement = _chromeDriver.FindElementById("droppable") as RemoteWebElement;
            Assert.AreNotEqual(dragElement, null);

            Actions actions = new Actions(_chromeDriver);

            _chromeDriver.ExecuteScript(jsDnD1, dragElement, dropElement);

            _chromeDriver.ExecuteScript(jsDnD2, dragElement, dropElement);


        }

        [TestCleanup]
        public void TestCleanup()
        {

        }
    }
}
