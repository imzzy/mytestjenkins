using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Drawing;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using LPReplayCore.Interfaces;
using LPReplayCore.Model;
using LPReplayCore;
using System.Windows.Forms;
using System.Collections.ObjectModel;

namespace LPReplayCore.Web
{
   

    public class WebElementProperties : IElementProperties
    {
        public static WebElementProperties createWebElementPropertiesWithWebElement(RemoteWebElement webElement, RemoteWebElement FrameElement, WebDriverHost webDriverHost)
        {
            if (webElement == null) return null;
            //get web element's type
            string webCtrlType = WebKit.generateWebElementType(webElement);
            if (string.IsNullOrEmpty(webCtrlType)) return null;

            WebElementProperties webEleProperties = new WebElementProperties();
            webEleProperties._webElement = webElement;
            webEleProperties.BuildPropertiesWithControlType(webCtrlType);
            webEleProperties._isInFrame = FrameElement != null?true:false;
            webEleProperties.FrameElement = FrameElement;
            webEleProperties.BrowserURL = webElement.WrappedDriver.Url;
            webEleProperties._webDriverHost = webDriverHost;
            return webEleProperties;
        }

        private Dictionary<string, string> _properties = new Dictionary<string,string>();

        private Dictionary<string, string> _recommendedProperties = new Dictionary<string, string>();

        private Dictionary<string, string> _otherProperties = new Dictionary<string, string>();

        private Dictionary<string, string> _selectedProperties = null;

        private RemoteWebElement _webElement = null;

        private string _name = string.Empty;

        public Rectangle BoundingRectangle;

        private bool _isInFrame = false;

        public RemoteWebElement FrameElement
        {
            get;set; 
        }
        private WebDriverHost _webDriverHost = null;

        public bool IsInFrame
        {
            set
            {
                _isInFrame = value;
            }
            get
            {
                return _isInFrame;
            }
        }

        public string BrowserURL
        {
            set;
            get;
        }

        public RemoteWebElement WebElement
        {
            get { return _webElement; }
        }

        public string Name
        {
            get { return string.IsNullOrEmpty(_name) ? _webElement.TagName : _name; }
        }

        private string _webCtrlType = string.Empty;

        #region IElementProperties
        public string ControlTypeString
        {
            get { return _webCtrlType; }
        }

        public Dictionary<string, string> Properties
        {
            get { return _properties; }
        }

        public Dictionary<string, string> RecommendedProperties
        {
            get { return _recommendedProperties; }
        }

        public Dictionary<string, string> OtherProperties
        {
            get { return _otherProperties; }
        }

        public Dictionary<string, string> SelectedProperties
        {
            get
            {
                if (_selectedProperties == null)
                {
                    _selectedProperties = _recommendedProperties;
                }
                return _selectedProperties;
            }
            set
            {
                _selectedProperties = value;
            }
        }

        public Dictionary<string, string> NoneEmptyProperties
        {
            get
            {
                Dictionary<String, String> properties = new Dictionary<string, string>();
                foreach (KeyValuePair<string, string> pair in _properties)
                {
                    if (!String.IsNullOrEmpty(pair.Value))
                    {
                        properties.Add(pair.Key, pair.Value);
                    }
                }

                return properties;
            }
        }

        #endregion 

        private WebElementProperties()
        {

        }

        public WebElementProperties(RemoteWebElement webElement)
        {
            this._webElement = webElement;
            this.BuildPropertiesWithControlType();
            _otherProperties = GetOtherProperties(_recommendedProperties, _properties);

        }

        private void BuildPropertiesWithControlType(string webCtrlType = "")
        {
            if (this._webElement == null) return;
            if (string.IsNullOrEmpty(webCtrlType))
                webCtrlType = WebKit.generateWebElementType(_webElement);   //get web element's type

            this._webCtrlType = webCtrlType;
            _properties.Add(WebControlKeys.Type, webCtrlType);
            //id 
            string webCtrlID = _webElement.GetAttribute("id");
            _properties.Add(WebControlKeys.ID, webCtrlID);
            if (string.IsNullOrEmpty(webCtrlID))
                _recommendedProperties.Add(WebControlKeys.ID, webCtrlID);

            //tag name
            _properties.Add(WebControlKeys.TagName, _webElement.TagName.ToUpper());
            if (string.IsNullOrEmpty(webCtrlID))
                _recommendedProperties.Add(WebControlKeys.TagName, _webElement.TagName.ToUpper());
            
            //CSS style
            //getComputedStyle

            //CSS class
            string webCtrlClass = _webElement.GetAttribute("class");
            _properties.Add(WebControlKeys.Class, webCtrlClass);
            if (string.IsNullOrEmpty(webCtrlClass))
                _recommendedProperties.Add(WebControlKeys.Class, webCtrlClass);

            //name
            string name = _webElement.GetAttribute("name");
            _properties.Add(WebControlKeys.Name, name);
            if (!string.IsNullOrEmpty(name))
                _recommendedProperties.Add(WebControlKeys.Name, name);

            //BoundingRectangle = WebKit.getScreenRectangle(_webElement);
            Point point = WebUtility.GetElementScreenPos(_webElement);
            BoundingRectangle = new Rectangle(point, _webElement.Size);
            _properties.Add(WebControlKeys.BoundingRectangle, BoundingRectangle.ToString());
            
            //type
            if ( _properties[WebControlKeys.TagName].Equals("INPUT"))
            {
                string attrType = _webElement.GetAttribute("type");
                if (!string.IsNullOrEmpty(attrType))
                {
                    _properties.Add(WebControlKeys.AttrType, attrType);
                    _recommendedProperties.Add(WebControlKeys.AttrType, attrType);
                }
            }

            string ctrlName = string.Empty;

            switch(webCtrlType)
            {
                case "WebPage":
                    {
                        this._name = /*webCtrlType + " : " +*/ _webElement.WrappedDriver.Title;
                        _properties.Add(WebControlKeys.URL, _webElement.WrappedDriver.Url);
                        _properties.Add(WebControlKeys.Title, _webElement.WrappedDriver.Title);
                    }
                    break;
                case "WebFrame":
                    {
                        string src = WebUtility.GetAttributeWithJavascript(_webElement, "src");
                        _properties.Add(WebControlKeys.Src, src);
                        if (string.IsNullOrEmpty(name))
                        {
                            this._name = /*webCtrlType + " : " +*/ name;
                        }
                        else
                        {
                            this._name = /*webCtrlType + " : " +*/ src;
                        }
                        
                    }
                    break;
                case "WebForm":
                    {
                        this._name = /*webCtrlType + " : " +*/ name;
                    }
                    break;
                case "WebTable":
                    {
                        this._name = /*webCtrlType + " : " +*/ name;
                //        _properties.Add(WebControlKeys.Width, _webElement.Size.Width.ToString());
                      //  _properties.Add(WebControlKeys.Height, _webElement.Size.Height.ToString());
                    }
                    break;
                case "WebLink":
                    {
                        string Text = _webElement.GetAttribute("textContent");
                        _properties.Add(WebControlKeys.Role,  _webElement.GetAttribute("role"));
                        _properties.Add(WebControlKeys.Text, Text);
                        _recommendedProperties.Add(WebControlKeys.Text, Text);
                        this._name = /*webCtrlType + " : " +*/ Text;
                    }
                    break;
                case "WebImage":
                case "WebImageLink":
                    {
                        string alt = _webElement.GetAttribute("alt");
                        string src = WebUtility.GetAttributeWithJavascript(_webElement, "src");// _webElement.GetAttribute("src");
                        _properties.Add(WebControlKeys.Alt, alt);
                        _properties.Add(WebControlKeys.Src, src);
                        /*if ( src.LastIndexOf('/') >= 0 )
                        {
                            src = src.Substring(src.LastIndexOf('/') + 1);
                        }*/
                        _recommendedProperties.Add(WebControlKeys.Alt, alt);
                        this._name = /*_webCtrlType + " : " + */(string.IsNullOrEmpty(alt) ? src : alt);
                    }
                    break;
                case "WebButton":
                    {
                        string name2 = string.Empty;
                        string attrType = _webElement.GetAttribute("type"); 
                        switch (_properties[WebControlKeys.TagName])
                        {
                            case "BUTTON":
                                {
                                    name2 = _webElement.GetAttribute("textContent");
                                    if ( string.IsNullOrEmpty(name2))
                                    {
                                        _properties[WebControlKeys.Name] = name2;
                                        _recommendedProperties[WebControlKeys.Name] = name2;
                                        name = name2;
                                    }
                                }
                                break;
                            case "INPUT":
                                {
                                    name = _webElement.GetAttribute("value");
                                }
                                break;
                            default:
                                break;
                        }
                        this._name = /*_webCtrlType + " : " +*/ name;
                    }
                    break;
                case "WebEdit":
                    { 
                        this._name = /*_webCtrlType + " : " +*/ name;
                    }
                    break;
                case "WebList":
                    {
                        if (string.IsNullOrEmpty(name))
                        {
                            RemoteWebElement option = _webElement.FindElementByTagName("option") as RemoteWebElement;
                            name = option.Text;
                        }
                        this._name = name;
                    }
                    break;
                case "WebRadioGroup":
                    {
                        RemoteWebElement parentElement = WebUtility.GetParentElement(_webElement);

                         
                        _webElement = (_webElement.WrappedDriver as RemoteWebDriver).FindElementByCssSelector("input[type=radio][name=" + name + "]") as RemoteWebElement;
                     
                        if (string.IsNullOrEmpty(name))
                        {
                            name = _webElement.GetAttribute("value");
                        }

                        if (string.IsNullOrEmpty(name))
                        {
                            name = _webElement.Text;
                        }

                        this._name = /*_webCtrlType + " : " +*/ name;

                    }
                    break;
                case "WebCheckBox":
                    {
                        ctrlName = _webElement.GetAttribute("aria-label");
                        if (!string.IsNullOrEmpty(ctrlName))
                        {
                            goto findControlName;
                        }

                        ctrlName = _webElement.GetAttribute("innerText");
                        if (!string.IsNullOrEmpty(ctrlName))
                        {
                            goto findControlName;
                        }

                        RemoteWebElement nextSilbingElement = WebUtility.GetNextSiblingElement(_webElement);

                        if (nextSilbingElement != null)
                        {
                            if ( nextSilbingElement.GetAttribute("nodeType").ToString().Equals("3") )
                            {
                                ctrlName = nextSilbingElement.GetAttribute("textContent");
                                if (!string.IsNullOrEmpty(ctrlName))
                                {
                                    goto findControlName;
                                }
                            }
                        }
                       

                    findControlName:
                        this._name = /*_webCtrlType + " : " +*/ ctrlName;
                    }
                    break;
                case "WebElement":
                    {
                        this._name = string.IsNullOrEmpty(webCtrlID) ? (string.IsNullOrEmpty(name) ? _webElement.TagName.ToUpper() : name) : webCtrlID;
                    }
                    break;
                default:
                    break;
                    

            }
        }

      
        public static Dictionary<string, string> GetOtherProperties(Dictionary<string, string> recommendedProperties, Dictionary<string, string> properties)
        {
            Dictionary<string, string> otherProperties = new Dictionary<string, string>();

            foreach (KeyValuePair<string, string> pair in properties)
            {
                if (recommendedProperties.ContainsKey(pair.Key)) continue;

                otherProperties.Add(pair.Key, pair.Value);
            }

            return otherProperties;
        }

        public TestObjectNurse ToNurseObject()
        {
            string cssSelector = string.Empty;//"css=";
            int indexofelement = -1;
            //WebPage - Browser
            
            //check whether the element is unique or not.
            ReadOnlyCollection<IWebElement> elements = null; //_webElement.WrappedDriver.FindElements(By.Id(_webElement.TagName));
            string tagName; this._properties.TryGetValue(WebControlKeys.TagName,out tagName);
            Debug.Assert(!string.IsNullOrEmpty(tagName), "DOM element doesn't have tag!!!!!! Unbelievable!!!!!!");
            cssSelector += tagName;
            string className; this._properties.TryGetValue(WebControlKeys.Class, out className);
            //By class
            if (string.IsNullOrEmpty(className))
            {
                cssSelector += className.Replace(' ', '.');
            }
          
            //By mandatory attributes
            foreach(KeyValuePair<string, string> pair in this.SelectedProperties)
            {
                if (string.IsNullOrEmpty(pair.Value)) continue;
                if (pair.Key.Equals(WebControlKeys.TagName) ||
                    pair.Key.Equals(WebControlKeys.BoundingRectangle) ||
                    pair.Key.Equals(WebControlKeys.Type)) continue;
                cssSelector += string.Format("[{0}='{1}']", pair.Key.Equals(WebControlKeys.AttrType) ? "type" : pair.Key, pair.Value);
            }
           
            //By ID
            string webelementID = _properties[WebControlKeys.ID];
            if (!string.IsNullOrEmpty(webelementID))
                cssSelector = "#" + webelementID;
            //locate element
            elements = _webElement.WrappedDriver.FindElements(By.CssSelector(cssSelector));
            int countofElements = elements.Count;
            int i = 0;
            
            if (1 < countofElements)
            {
                //By assistant attributes
                foreach (KeyValuePair<string, string> pair in this.OtherProperties)
                {
                    if (string.IsNullOrEmpty(pair.Value)) continue;
                    if (pair.Key.Equals(WebControlKeys.TagName) ||
                        pair.Key.Equals(WebControlKeys.BoundingRectangle) ||
                        pair.Key.Equals(WebControlKeys.Type)) continue;
                    cssSelector += string.Format("[{0}='{1}']", pair.Key.Equals(WebControlKeys.AttrType) ? "type" : pair.Key, pair.Value);
                }
            }
            else if (1 == countofElements)
            {
                goto Found;
            }
            //locate element again
            elements = _webElement.WrappedDriver.FindElements(By.CssSelector(cssSelector));
            countofElements = elements.Count;
            if (1 < elements.Count)
            {
                for (i = 0; i < countofElements; ++i)
                {
                    RemoteWebElement element = elements[i] as RemoteWebElement;
                    /*if (element.Location.X == _webElement.Location.X && element.Location.Y == _webElement.Location.Y)
                    {
                        indexofelement = i;
                       // cssSelector += string.Format("[{0}]", i);
                        goto Found;
                    }*/

                    if (element.Equals(_webElement))
                    {
                        indexofelement = i;
                        goto Found;
                    }

                }
            }
            else if (1 == countofElements)
            {
                goto Found;
            }
            //By XPath
            return null;
      
      
Found:

            SETestObject testObject = new SETestObject();

            foreach (KeyValuePair<string, string> pair in this.Properties)
            {
                testObject.Properties.Add(pair.Key, pair.Value);
            }

            testObject.SEWebElement = _webElement;
           
            testObject.Cssselector = cssSelector;
            testObject.Properties.Add(WebControlKeys.CssSelector, cssSelector);
            testObject.NodeName = this.Name;
            if (indexofelement != -1)
            {
                testObject.IndexofTags = indexofelement;
                testObject.Properties.Add(WebControlKeys.IndexofTags, indexofelement.ToString());
            }
           
            TestObjectNurse testNurse = new TestObjectNurse(testObject);

            foreach (KeyValuePair<string, string> pair in NoneEmptyProperties)
            {
                testNurse.CachedProperties.Add(pair.Key, pair.Value);
            }
            return testNurse;
        }
    }
}
