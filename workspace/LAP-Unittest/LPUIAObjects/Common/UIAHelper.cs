using LPReplayCore.Interfaces;
using LPReplayCore.Model;
using LPReplayCore.UIA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace LPUIAObjects.Common
{
    class UIAHelper
    {

        public static ITestObject ConvertStringToTestObject(string conditionString)
        {
            string[] propertiesStrings = conditionString.Split(new string[] { DescriptionString.LeftRightPropertySplitString }, StringSplitOptions.RemoveEmptyEntries);

            ITestObject descriptor = new UIATestObject();

            foreach (string propertyString in propertiesStrings)
            {
                string[] temp = propertyString.Split(new string[] { DescriptionString.LeftRightQtpString }, StringSplitOptions.RemoveEmptyEntries);
                if (temp.Length >= 2)
                {
                    descriptor.AddProperty(temp[0], temp[1]);
                }
            }
            return descriptor;
            //conditionString = conditionString.Replace(DescriptionString.LeftRightQtpString, DescriptionString.AssignOperator);
            //conditionString = conditionString.Replace(DescriptionString.LeftRightPropertySplitString, DescriptionString.PropertySplitString);

        }

    }
}
