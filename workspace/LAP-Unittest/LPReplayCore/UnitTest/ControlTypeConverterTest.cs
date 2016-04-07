using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LPReplayCore.Common;
using System.Collections.Generic;
using System.Windows.Automation;

#if TEST

namespace LPReplayCore.UnitTest
{
    [TestClass]
    public class ControlTypeConverterTest
    {

        [TestMethod]
        public void ControlTypeConverter_CountTest()
        {
            Dictionary<string, ControlType> mapping = ControlTypeConverter.GetControlTypeMappings();
            Assert.AreEqual(39, mapping.Count);
        }


        [TestMethod]
        public void ControlTypeConverter_EqualTest()
        {
            ControlType expected = ControlType.Window;

            Assert.AreEqual(ControlType.Window, ToControlType("Window"));
            Assert.AreEqual(ControlType.Edit, ToControlType("Edit"));

        }

        public ControlType ToControlType(string name)
        {
            return name.ToControlType();
        }

    }
}

#endif