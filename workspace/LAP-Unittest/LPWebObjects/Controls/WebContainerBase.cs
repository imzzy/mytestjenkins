using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using LPReplayCore.Web;
using LPReplayCore;
using LPReplayCore.Interfaces;

namespace LPWebObjects.Controls
{

    public abstract class WebContainerBase
    {
        protected RemoteWebElement _webElement = null;

        private string _objectName = string.Empty;

        private ControlCollections _ccs = new ControlCollections(); 
        public WebContainerBase() { }

        public virtual WebButton WebButton(string nodeName)
        {
            return GetTo<WebButton>(nodeName);
        }

        public virtual WebEdit WebEdit(string nodeName)
        {
            return GetTo<WebEdit>(nodeName);
        }

        public virtual WebLink WebLink(string nodeName)
        {
            return GetTo<WebLink>(nodeName);
        }

        public virtual WebImageLink WebImageLink(string nodeName)
        {
            return GetTo<WebImageLink>(nodeName);
        }

        public virtual WebImage WebImage(string nodeName)
        {
            return GetTo<WebImage>(nodeName);
        }

        public virtual WebList WebList(string nodeName)
        {
            return GetTo<WebList>(nodeName);
        }

        public virtual WebCheckBox WebCheckBox(string nodeName)
        {
            return GetTo<WebCheckBox>(nodeName);
        }

        public virtual WebRadioGroup WebRadioGroup(string nodeName)
        {
            return GetTo<WebRadioGroup>(nodeName);
        }

        public virtual WebFile WebFile(string nodeName)
        {
            return GetTo<WebFile>(nodeName);
        }

        public virtual WebArea WebArea(string nodeName)
        {
            return GetTo<WebArea>(nodeName);
        }

        public virtual WebVideo WebVideo(string nodeName)
        {
            return GetTo<WebVideo>(nodeName);
        }

        public virtual WebTable WebTable(string nodeName)
        {
            return GetTo<WebTable>(nodeName);
        }

        public virtual WebForm WebForm(string nodeName)
        {
            return GetTo<WebForm>(nodeName);
        }

        public virtual WebPlugin WebPlugin(string nodeName)
        {
            return GetTo<WebPlugin>(nodeName);
        }

        public virtual WebObject WebObject(string nodeName)
        {
            return GetTo<WebObject>(nodeName);
        }

        protected T GetTo<T>(string nodeName) where T : IWebElement, new()
        {
            IWebElement webElement = _ccs[nodeName];
            if ( webElement == null)
            {
                AppModel model = AppModel.Current;
                SETestObject seTO = model.GetTestObject(nodeName) as SETestObject;
                seTO.WebDriver = BrowserHoster.getInstance().WebDriver;
                webElement = new T();
                webElement.RelayObject = seTO;
            }
            return (T)webElement;
        }


        public virtual string GetRoProperty(string propertyname)
        {
            RemoteWebElement webElement = RelayObject.SEWebElement;
            propertyname = propertyname.ToLower();
            string returnValue = string.Empty;
            switch(propertyname)
            {
                case "x":
                    {
                        returnValue = webElement.Location.X.ToString();
                    }
                    break;
                case "y":
                    {
                        returnValue = webElement.Location.Y.ToString();
                    }
                    break;
                case "tagName":
                    {
                        returnValue = webElement.TagName;
                    }
                    break;
                case "width":
                    {
                        returnValue = webElement.Size.Width.ToString();
                    }
                    break;
                case "height":
                    {
                        returnValue = webElement.Size.Height.ToString();
                    }
                    break;
                default:
                    {
                        returnValue = webElement.GetAttribute(propertyname);
                    }
                    break;
            }


            return returnValue;
        }

        public virtual bool Enabled
        {
            get 
            { 
                RemoteWebElement webElement = RelayObject.SEWebElement;
                return webElement.Enabled;
            }
        }

        public virtual bool Displayed
        {
            get
            {
                RemoteWebElement webElement = RelayObject.SEWebElement;
                return webElement.Displayed;
            }
        }
 
        public virtual string GetToProperty(string propertyname)
        {
            string returnValue = string.Empty;
            if (RelayObject.Properties.TryGetValue(propertyname, out returnValue))
                return returnValue;
            return string.Empty;
        }

        public virtual string ObjectName
        {
            get { return _objectName; }
            set { _objectName = value; }
        }

        public virtual SETestObject RelayObject
        {
            set;
            get;
        }
    }
}
