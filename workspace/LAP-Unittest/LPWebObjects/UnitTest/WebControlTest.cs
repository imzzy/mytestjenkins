using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace LPWebObjects.UnitTest
{
    [TestClass]
    public class WebControlTest 
    {
        private ReplayHelper _replayHelper = new ReplayHelper();
       
        [TestInitialize]
        public void TestInitialize()
        {
            _replayHelper.LoadRepository(@"UnitTest\\SeleniumModel1.json");
        }

        [TestMethod]
        public void WebControl_FlightTour_Login()
        {
            Assert.AreNotEqual(_replayHelper.WebPage("Welcome: Mercury Tours").WebEdit("userName"), null);
            Assert.AreNotEqual(_replayHelper.WebPage("Welcome: Mercury Tours").WebEdit("password"), null);
            System.Threading.Thread.Sleep(2000);
        }

        [TestMethod]
        public void WebControl_FlightTour_Book()
        {
            _replayHelper.WebPage("Welcome: Mercury Tours").WebEdit("userName").TypeText("yi-bin");
            _replayHelper.WebPage("Welcome: Mercury Tours").WebEdit("password").TypeText("123");
            _replayHelper.WebPage("Welcome: Mercury Tours").WebImage("Sign-In").Click();
            System.Threading.Thread.Sleep(2000);
            _replayHelper.WebPage("Find a Flight: Mercury Tours:").WebList("fromPort").SelectByIndex(2);
            _replayHelper.WebPage("Find a Flight: Mercury Tours:").WebList("fromMonth").SelectByName("August");
            //_replayHelper.WebPage("Find a Flight: Mercury Tours:").WebList("fromDay").SelectByName("25");
            _replayHelper.WebPage("Find a Flight: Mercury Tours:").WebRadioGroup("servClass").Select(1);
            _replayHelper.WebPage("Find a Flight: Mercury Tours:").WebImage("/images/forms/continue.gif").Click();
            System.Threading.Thread.Sleep(2000);

            _replayHelper.WebPage("Select a Flight: Mercury Tours").WebRadioGroup("outFlight").Select(2);
            _replayHelper.WebPage("Select a Flight: Mercury Tours").WebImage("/images/forms/continue.gif_2").Click();
        }

         [TestMethod]
        public void WebControl_DragDrop()
        {
            _replayHelper.WebPage("jQuery UI Droppable - Default functionality").WebObject("draggable").Drag();
            _replayHelper.WebPage("jQuery UI Droppable - Default functionality").WebObject("droppable").Drop();

            _replayHelper.WebPage("jQuery UI Droppable - Default functionality").Refresh();

            _replayHelper.WebPage("jQuery UI Droppable - Default functionality").WebObject("draggable").Drag();
            _replayHelper.WebPage("jQuery UI Droppable - Default functionality").WebObject("droppable").Drop();

            _replayHelper.WebPage("jQuery UI Droppable - Default functionality").Navigate("http://www.tutorialspoint.com/html5/src/dropping-object.htm");

            _replayHelper.WebPage("http://www.tutorialspoint.com/html5/src/dropping-object.htm").WebObject("dragDIV").Drag();
            _replayHelper.WebPage("http://www.tutorialspoint.com/html5/src/dropping-object.htm").WebObject("dropDIV").Drop();


            _replayHelper.WebPage("http://www.tutorialspoint.com/html5/src/dropping-object.htm").Back();

            _replayHelper.WebPage("jQuery UI Droppable - Default functionality").WebObject("draggable").Drag();
            _replayHelper.WebPage("jQuery UI Droppable - Default functionality").WebObject("droppable").Drop();

            _replayHelper.WebPage("jQuery UI Droppable - Default functionality").Forward();

            _replayHelper.WebPage("http://www.tutorialspoint.com/html5/src/dropping-object.htm").WebObject("dragDIV").Drag();
            _replayHelper.WebPage("http://www.tutorialspoint.com/html5/src/dropping-object.htm").WebObject("dropDIV").Drop();
         }

            
            
        
         [TestMethod]
        public void TestMethod4()
        {
            _replayHelper.WebPage("http://www.tutorialspoint.com/html5/src/dropping-object.htm").WebObject("dragDIV").Drag();
            _replayHelper.WebPage("http://www.tutorialspoint.com/html5/src/dropping-object.htm").WebObject("dropDIV").Drop();
         }
            
      


        [TestCleanup]
        public void TestCleanup()
        {

        }

       
    }
}
