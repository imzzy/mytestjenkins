using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Interactions.Internal;
using OpenQA.Selenium.Internal;
using System.Drawing;

namespace LPReplayCore.Web
{
    public class WebKit
    {
        public static readonly string s_jsGetBoundingClientRect = "return arguments[0].getBoundingClientRect();";

        private readonly static string[] _tagsAllowedInPath = {"FONT", "B", "I", "STRONG", "DIV", "NOBR", "EM", "DD", "CENTER", "SPAN"};

        public static Point getScreenCoordinates(RemoteWebElement webElement)
        {
            RemoteWebElement remoteWebElement = webElement as RemoteWebElement;
            if (remoteWebElement != null)
            {
                ICoordinates coordinates = remoteWebElement.Coordinates;
                return new Point(coordinates.LocationOnScreen.X, coordinates.LocationOnScreen.Y);
            }
            return new Point(0, 0);
        }

        public static Rectangle getScreenRectangle(RemoteWebElement webElement)
        {
            IJavaScriptExecutor jsExecutor = webElement.WrappedDriver as IJavaScriptExecutor;
            if (jsExecutor == null) return new Rectangle(0, 0, 0, 0);
            var result =  jsExecutor.ExecuteScript(s_jsGetBoundingClientRect,webElement) as Dictionary<string, object>;
            
            if ((webElement as RemoteWebElement) == null) return new Rectangle(0, 0, 0, 0);
           // Point coordinates = getScreenCoordinates(webElement);
            return Rectangle.FromLTRB(Convert.ToInt32(result["left"]), Convert.ToInt32(result["top"]), Convert.ToInt32(result["right"]),
                Convert.ToInt32(result["bottom"]));
            //return new Rectangle(coordinates, webElement.Size);
        }

        private static RemoteWebElement getImageParentAnchor(RemoteWebElement webElement)
        {
            webElement = WebUtility.GetParentElement(webElement);
            while(webElement != null)
            {
                string tagName = webElement.TagName.ToUpper();
                if (tagName.ToUpper().Equals("A")) return webElement;
                if (_tagsAllowedInPath.Where((a) => (a.Equals(tagName))).Count() == 0)
                    return null;
                webElement = WebUtility.GetParentElement(webElement); 
            }
            return null;
        }
         
        private static bool isElementContentEditable(RemoteWebElement webElement)
        {
            while(null != webElement)
            {
                string Editable = webElement.GetAttribute("contentEditable");
                if ( webElement.GetAttribute("nodeType") != "1" || Editable.Equals("inherit") || Editable.Equals("false") )
                {
                    webElement = WebUtility.GetParentElement(webElement);
                    continue;
                }
                return !Editable.Equals("false");
            }
            return false;
        }

        private static bool isRealLink(RemoteWebElement webElement)
        {
            if (webElement == null) return false;
            string href = webElement.GetAttribute("href");
            if (string.IsNullOrEmpty(href))
                return false;
            return true;
        }

        public static string generateWebElementType(RemoteWebElement webElement)
        {
            string webCtrlType = string.Empty;
            if (webElement == null) return webCtrlType;
            string tagName = webElement.TagName.ToUpper();
            switch(tagName)
            {
                case "IFRAME":  //This will answer queryies from our child Frames.
                case "FRAME":
                    webCtrlType = "WebFrame";
                    break;
                case "HTML":
                    webCtrlType = "WebPage";
                    break;
                case "A":
                    if (isRealLink(webElement))
                        webCtrlType = "WebLink";
                    break;
                case "IMG":
                    if (getImageParentAnchor(webElement) != null)
                        webCtrlType = "WebImageLink";
                    else
                        webCtrlType = "WebImage";
                    break;
                case "BUTTON":
                    webCtrlType = "WebButton";
                    break;
                case "INPUT":
                    string type = webElement.GetAttribute("type");
                    switch (type.ToLower())
                    {
                        case "button":
                        case "submit":
                        case "reset":
                            webCtrlType = "WebButton";
                            break;
                        case "text":
                            webCtrlType = "WebEdit";
                            break;
                        case "image":
                            webCtrlType = "WebImage";
                            break;
                        case "checkbox":
                            webCtrlType = "WebCheckBox";
                            break;
                        case "radio":
                            // Save the element which caused the radio-group to be created (_elem is the active radio-button)
                            webCtrlType = "WebRadioGroup";
                            break;
                        case "file":
                            webCtrlType = "WebFile";
                            break;
                        case "hidden":
                            break;
                        case "range":
                            webCtrlType = "WebEdit";
                            //RangeBehavior & RangeBaseBehavior
                            break;
                        case "number":
                            webCtrlType = "WebEdit";
                            //RangeBaseBehavior & numberBehavior
                            break;
                        default:
                            webCtrlType = "WebEdit";
                            break;
                    }
                    break;
                case "TEXTAREA":
                    webCtrlType = "WebEdit";
                    break;
                case "SELECT":
                    webCtrlType = "WebList";
                    break;
                case "AREA":
                    webCtrlType = "WebArea";
                    break;
                case "TABLE":
                    webCtrlType = "WebTable";
                    break;
                case "VIDEO":
                    webCtrlType = "WebVideo";
                    break;
                case "AUDIO":
                    webCtrlType = "WebAudio";
                    break;
                case "FORM":
                    webCtrlType = "WebForm";
                    break;
                case "OBJECT":
                    webCtrlType = "WebPlugin";
                    break;
                case "SPAN":
                case "DIV":
                    if (isElementContentEditable(webElement))
                        webCtrlType = "WebEdit";
                    else
                        webCtrlType = "WebObject";
                    break;
                default:
                    webCtrlType = "WebObject";
                    break;
            }
            return webCtrlType;

        }
    }
}
