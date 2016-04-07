using LPReplayCore.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPReplayCore.UnitTest
{
#if TEST
    [TestClass]
    public class ControlKeysManagerTest
    {
        [TestMethod]
        public void ControlKeysManager_GetDisplayString()
        {

            //UIA
            string displayString = ControlKeysManager.GetDisplayString("automationId");
            Assert.AreEqual("AutomationId", displayString);

            //common
            displayString = ControlKeysManager.GetDisplayString("title");
            Assert.AreEqual("Title", displayString);

            //web
            displayString = ControlKeysManager.GetDisplayString("role", "Web");
            Assert.AreEqual("Role", displayString);


            displayString = ControlKeysManager.GetDisplayString("imgPath");
            Assert.AreEqual("ImagePath", displayString);
        }

        [TestMethod]
        public void ControlKeysManager_GetKeyString()
        {

        }
    }
#endif
}
