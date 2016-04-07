using LPReplayCore.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#if TEST
namespace LPReplayCore.UnitTest
{
    [TestClass]
    public class UtilityTest
    {
        [TestMethod]
        public void Utility_GetBinDirectory()
        {
            Console.WriteLine(Utility.GetBinDirectory());
        }
    }
}
#endif