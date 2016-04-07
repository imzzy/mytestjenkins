using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LPWebObjects.Controls;

namespace LPWebObjects
{
    using ReplayObjectDictionary = Dictionary<string, IWebElement>;
    using ReplayObjectPair = KeyValuePair<string, IWebElement>;
    internal class ControlCollections
    {
        private ReplayObjectDictionary _collections = new ReplayObjectDictionary(); 
        internal ControlCollections()
        {

        }


        public void Put_ReplayObject(string nodeName, IWebElement webControl)
        {
            _collections[nodeName] = webControl;
        }

        public IWebElement Get_ReplayObject(string nodeName)
        {
            IWebElement webElement = null;
            if (!_collections.TryGetValue(nodeName, out webElement))
                return null;
            return webElement;
        }


        public IWebElement this[string nodeName] 
        {
            get
            {
                return Get_ReplayObject(nodeName);
            }
            set
            {
                Put_ReplayObject(nodeName, value);
            }
        }
    }
}
