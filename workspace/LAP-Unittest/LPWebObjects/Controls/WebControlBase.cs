using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Interactions;
using LPReplayCore.Web;
using LPReplayCore;
using System.Drawing;
using LPWebObjects;

namespace LPWebObjects.Controls
{
    public abstract class WebControlBase
    {
        private const string _jsDnD = "var dragstartArg = new Event('dragstart', {bubbles: true});" +
            "dragstartArg.dataTransfer = { data: {},	setData: function(type, val){this.data[type] = val;},getData: function(type){return this.data[type];}};" +
            "arguments[0].dispatchEvent(dragstartArg);" +
            "var dropArg = new Event('drop', {bubbles: true});" +
            "dropArg.dataTransfer = dragstartArg.dataTransfer;" +
            "arguments[1].dispatchEvent(dropArg);" +
            "var dragendArg = new Event('dragend', {bubbles: true});" +
            "arguments[0].dispatchEvent(dragendArg);";


        private const string _jsDrag = "window.dragstartArg = new Event('dragstart', {bubbles: true});" +
            "window.dragstartArg.dataTransfer = { data: {},	setData: function(type, val){this.data[type] = val;},getData: function(type){return this.data[type];}};" +
            "arguments[0].dispatchEvent(window.dragstartArg);";

        private const string _jsDrop =
            "if (window.dragstartArg != null) {var dropArg = new Event('drop', {bubbles: true});" +
            "dropArg.dataTransfer = window.dragstartArg.dataTransfer;" +
            "arguments[0].dispatchEvent(dropArg);" +
            "var dragendArg = new Event('dragend', {bubbles: true});" +
            "window.dragstartArg.srcElement.dispatchEvent(dragendArg);" +
            "window.dragstartArg = null; return true;} else { return false;}";

        protected string _nodeName = string.Empty;

        protected Actions _action = null;

        protected static Actions _dragdropaction = null;

        public virtual string GetRoProperty(string propertyname)
        {
            RemoteWebElement webElement = RelayObject.SEWebElement;
            propertyname = propertyname.ToLower();
            string returnValue = string.Empty;
            switch (propertyname)
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

        public virtual string GetToProperty(string propertyname)
        {
            string returnValue = string.Empty;
            if (RelayObject.Properties.TryGetValue(propertyname, out returnValue))
                return returnValue;
            return string.Empty;
        }

        public virtual string ObjectName
        {
            set; 
            get;
            
        }

        public virtual SETestObject RelayObject
        {
            set;
            get;
        }

        protected WebControlBase()
        {
           
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

        public virtual void Click(int x = -1, int y = -1)
        {
            ActionsHelper actionsHelper = ActionsHelper.getInstance();
            actionsHelper.Click(RelayObject.SEWebElement, x, y);
        }

        public virtual void RClick(int x = -1, int y = -1)
        {
            ActionsHelper actionsHelper = ActionsHelper.getInstance();
            actionsHelper.RClick(RelayObject.SEWebElement, x, y);
        }

        public virtual void DBClick(int x = -1, int y = -1)
        {
            ActionsHelper actionsHelper = ActionsHelper.getInstance();
            actionsHelper.DBClick(RelayObject.SEWebElement, x, y);
        }

        public virtual void Drag(int x = -1, int y = -1)
        {
            ActionsHelper actionsHelper = ActionsHelper.getInstance();
            RemoteWebElement webElement = RelayObject.SEWebElement;
            string draggable = webElement.GetAttribute("draggable");
            if (!string.IsNullOrEmpty(draggable) && draggable.ToLower().Equals("true"))
            {
                BrowserHoster.getInstance().WebDriver.ExecuteScript(_jsDrag, RelayObject.SEWebElement);
            }
            else
            {
                actionsHelper.Drag(RelayObject.SEWebElement, x, y);
            }

            
        }
        public virtual void Drop(int x = -1, int y = -1)
        {
            ActionsHelper actionsHelper = ActionsHelper.getInstance();
            actionsHelper.Drop(RelayObject.SEWebElement, x, y);
            bool droppable =  Convert.ToBoolean(BrowserHoster.getInstance().WebDriver.ExecuteScript(_jsDrop, RelayObject.SEWebElement));
            if (!droppable)
            {
                actionsHelper.Drop(RelayObject.SEWebElement, x, y);
            }
        }

        public virtual void DragAndDrop(IWebElement target)
        {
            ActionsHelper actionsHelper = ActionsHelper.getInstance();
            RemoteWebElement webElement = RelayObject.SEWebElement;
            string draggable = webElement.GetAttribute("draggable");
            if (!string.IsNullOrEmpty(draggable) && draggable.ToLower().Equals("true"))
            {
                BrowserHoster.getInstance().WebDriver.ExecuteScript(_jsDnD, RelayObject.SEWebElement, target.RelayObject.SEWebElement);
            }
            else
            {
                actionsHelper.DragAndDrop(RelayObject.SEWebElement, target.RelayObject.SEWebElement);
            }
        }


    }
}
