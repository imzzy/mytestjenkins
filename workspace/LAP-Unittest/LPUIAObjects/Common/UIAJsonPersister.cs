using LPReplayCore;
using LPReplayCore.Interfaces;
using LPReplayCore.Model;
using LPReplayCore.UIA;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Xml;

namespace LPUIAObjects
{
    public static class UIAJsonPersister
    {
        public static AppModel model = new AppModel();


        public static ITestObject LoadData(string name, ITestObject parentTestObject)
        {
            ITestObject testObject = null;
            if (parentTestObject == null)
            {
                testObject = model.FindFirst(ControlKeys.Name, name);
            }
            else
            {
                parentTestObject.Find(ControlKeys.Name, name);
            }

            return testObject;
        }



        //for relation
        /*
        public static string LoadData(string name)
        {
            string searchConditions = "";

            List<ObjectDescriptor> nodes = model.FindAll("name", name);

            if (nodes != 0)
            {

            }
            foreach (XmlNode x in mycondtion)
            {
                searchConditions = searchConditions + DescriptionString.PropertySplitString + x.Name + ":=" + x.InnerText.Trim();
            }

            return searchConditions;
        }*/
    }

}
