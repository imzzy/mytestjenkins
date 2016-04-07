using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LPReplayCore.UnitTest;
using System.Windows.Automation;
using System.Collections.Generic;
using System.Diagnostics;

#if TEST
namespace LPSpy.UnitTest
{
    [TestClass]
    public class BatchAddWindowTest
    {

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            TestUtility.LaunchWindowsCalc();
        }

        [TestMethod]
        public void BatchAddWindow_BuildBreadcrumbControl()
        {
            List<AutomationElement> elementList = TestUtility.GetAncestorsList(TestUtility.GetCalculatorButton1Element());

            Assert.AreEqual(3, elementList.Count);
            
            BreadcrumbControl breadControl = new BreadcrumbControl();

            BatchAddWindow.BuildBreadcrumbControl(elementList, breadControl);

            Assert.AreEqual(elementList.Count, breadControl.Count);
        }



        [TestMethod]
        public void BatchAddWindow_BuildListviewControl()
        {
            List<AutomationElement> elementList = TestUtility.GetPeerList(TestUtility.GetCalculatorButton1Element());
            Debug.WriteLine(elementList.Count);

            Assert.IsTrue(elementList.Count > 30);

            LAPListViewControl listView = new LAPListViewControl();

            BatchAddWindow.BuildListviewControl(elementList, listView, ((sender, e) => { }));
        }

    }
}

#endif