using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LPReplayCore.UnitTest;
using System.Windows.Automation;

#if TEST
namespace LPSpy.UnitTest
{
    [TestClass]
    public class SnapshotHelperTest
    {
        [ClassInitialize]
        public static void Init(TestContext context)
        {
            TestUtility.LaunchWindowsCalc();
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            TestUtility.ExitWindowCalculator();
        }

        [TestMethod]
        public void SnapshotHelper_CaptureTempSnapshot()
        {
            AutomationElement element = TestUtility.GetCalculatorButton1Element();
            string token = null;

            SnapshotHelper.CaptureTempSnapshot(element, out token);

            Assert.IsNotNull(token);

            TestUtility.ExitWindowCalculator();

            try
            {
                SnapshotHelper.CaptureTempSnapshot(element, out token);
                Assert.Fail("element not available, should throw ElementNotAvailableException");
            }
            catch (ElementNotAvailableException)
            {
                Assert.IsTrue(true); //succeed
            }
        }

    }
}
#endif