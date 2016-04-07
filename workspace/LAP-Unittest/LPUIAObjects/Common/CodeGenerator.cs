using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LPReplayCore.Common;
using LPReplayCore.Interfaces;
using System.Diagnostics;
using LPReplayCore.UIA;

namespace LPUIAObjects
{
    public static class CodeGenerator
    {
        private const string ControlPrefix = "UIA";

        public static string GetFullPathName(ITestObject testObject)
        {
            Debug.Assert(testObject is UIATestObject || testObject is VirtualTestObject);

            string fullPath = "";

            string currentPath = string.Format(@"{0}{1}(""{2}"")", ControlPrefix, 
                testObject.ControlTypeString,
                testObject.NodeName);

            if (testObject.Parent != null)
            {
                fullPath = GetFullPathName(testObject.Parent) + "." + currentPath;
            }
            else
            {
                fullPath = currentPath;
            }

            return fullPath;
        }
    }
}
