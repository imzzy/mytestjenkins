using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LPReplayCore.Interfaces;
using LPReplayCore.Model;
using LPReplayCore;
using LPCommon;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System.Drawing;

namespace LPReplayCore.Web
{
    using PropertiesDictionary = System.Collections.Generic.Dictionary<string, string>;
    using SETestObjectList = List<ITestObject>;

    public class SETestObject : TestObjectBase, ITestObject, ITOFactory<SETestObject>
    {
        static ILogger _Logger = LogFactory.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private string _type = string.Empty;

        private RemoteWebElement _webElement;

        private RemoteWebDriver _webDriver;

        public RemoteWebDriver WebDriver
        {
            get
            {
                return _webDriver;
            }
            set
            {
                _webDriver = value;
            }
        }

        public string Cssselector 
        {
            set; get;
        }

        #region ITOFactory
        public SETestObject CreateTestObject(ObjectDescriptor descriptor, ModelLoadLevel loadLevel = ModelLoadLevel.ReplayOnly)
        {
            return new SETestObject(descriptor);
        }

        #endregion

        public SETestObject()
        {

        }

        public SETestObject(RemoteWebDriver webDriver)
        {
            _webDriver = webDriver;
        }


        public SETestObject(string name, PropertiesDictionary identityProperties)
        {
            this.NodeName = name;
            if (identityProperties != null)
            {
                _properties = new PropertiesDictionary(identityProperties);
            }
        }

        public SETestObject(ObjectDescriptor descriptor)
        {
            _nodeName = descriptor.Name;

            _description = descriptor.Description;


            IdentifyPropertyGroup propertyItem = descriptor.GetItem<IdentifyPropertyGroup>();

            CachedPropertyGroup cachedItem = descriptor.GetItem<CachedPropertyGroup>();

            if (cachedItem != null) SetContext<CachedPropertyGroup>(cachedItem);

            _properties = (propertyItem != null) ? propertyItem.Properties : new PropertiesDictionary();

            if (_properties.ContainsKey(WebControlKeys.Type))
            {
                _type = _properties[WebControlKeys.Type];
            }
            if (_children == null) _children = new SETestObjectList();
        }

        #region ITestObject Interface

        public override ObjectDescriptor GetDescriptor()
        {
            ObjectDescriptor descriptor = new ObjectDescriptor();
            descriptor.Type = NodeType.Selenium;
            descriptor.Name = this.NodeName;
            descriptor.Description = this.Description;

            IdentifyPropertyGroup item = new IdentifyPropertyGroup();

            item.Properties = _properties;
            item.Properties[WebControlKeys.Type] = _type;

            descriptor.SetItem<IdentifyPropertyGroup>(item);

            CachedPropertyGroup cachedGroup = GetContext<CachedPropertyGroup>();
            if (cachedGroup != null)
            {
                descriptor.SetItem<CachedPropertyGroup>(cachedGroup);
            }

            foreach (ITestObject to in Children)
            {
                ObjectDescriptor childDescriptor = to.GetDescriptor();
                descriptor.Children.Add(childDescriptor);
                childDescriptor.Parent = descriptor;
            }

            return descriptor;
        }
        #endregion

        public override string ControlName
        {
            get
            {
                string name;
                _properties.TryGetValue(WebControlKeys.Name, out name);
                return name;
            }
            set
            {
                _properties[WebControlKeys.Name] = value;
            }
        }

        public override string ControlTypeString
        {
            get
            {
                if (string.IsNullOrEmpty(_type))
                {
                    string controlType = string.Empty;
                    if (!_properties.TryGetValue(WebControlKeys.Type, out controlType))
                        return "";
                    _type = controlType;
                }
                return _type;
            }
        }

        public override PropertiesDictionary Properties
        {
            get
            {
                //TODO, consider convert it to readonly
                return _properties;
            }
        }

        public override ITestObject Find(string key, string value)
        {
            if (_children == null) return null;

            if (key == DescriptorKeys.NodeName)
            {
                return _children.Find(to => to.NodeName == value);
            }
            return _children.First(child => child.Contains(key) && child[key] == value);
        }


        static ReadOnlyCollection<ITestObject> _emptyChildren = (new List<ITestObject>()).AsReadOnly();

        //add duplicate property will overwrite existing one
        public override void AddProperty(string key, string value)
        {
            _properties[key] = value;
            if (key == WebControlKeys.Type)
            {
                _type = value;
            }
        }

        //remove the property from the test object
        public override void RemoveProperty(string key)
        {
            _properties.Remove(key);
            if (key == WebControlKeys.Type)
            {
                _type = null;
            }
        }

        public Rectangle absolutePageRect
        {
            get
            {
                RemoteWebElement webElement = this.SEWebElement;
                Point pos = new Point();
                Size size = new Size();
                try
                {
                    pos = webElement.Location;
                    size = webElement.Size;
                    //go to the top element
                    if (!this.Properties[WebControlKeys.Type].Equals("WebPage") &&
                        !this.Properties[WebControlKeys.Type].Equals("WebFrame"))
                    {
                        SETestObject rootObject = this.rootObject as SETestObject;
                        ITestObject FrameObject = this;
                        while (FrameObject.Parent != rootObject)
                        {
                            FrameObject = FrameObject.Parent;
                        }
                        SETestObject seFrameObject = FrameObject as SETestObject;
                        if (seFrameObject.Properties[WebControlKeys.Type].Equals("WebFrame"))
                        {
                            _webDriver.SwitchTo().DefaultContent();
                            pos.Offset(seFrameObject.SEWebElement.Location);
                        }
                    }
                }
                catch (OpenQA.Selenium.StaleElementReferenceException exception)
                {

                    //to check whether the webElement is still available or not
                    _webDriver = webElement.WrappedDriver as RemoteWebDriver;
                    //go to the top element
                    SETestObject rootObject = this.rootObject as SETestObject;
                    _webDriver.SwitchTo().Window(rootObject.Properties[WebControlKeys.URL]);
                    if (!this.Properties[WebControlKeys.Type].Equals("WebPage") &&
                        !this.Properties[WebControlKeys.Type].Equals("WebFrame"))
                    {
                        // check frame
                        ITestObject FrameObject = this;
                        while (FrameObject.Parent != rootObject)
                        {
                            FrameObject = FrameObject.Parent;
                        }
                        SETestObject seFrameObject = FrameObject as SETestObject;
                        if (seFrameObject.Properties[WebControlKeys.Type].Equals("WebFrame"))
                        {
                            //get frame position
                            pos = seFrameObject.SEWebElement.Location;
                            _webDriver.SwitchTo().Frame(seFrameObject.SEWebElement);
                            pos.Offset(webElement.Location);
                            size = webElement.Size;
                        }
                    } 
                    else 
                    {
                        pos = webElement.Location;
                        size = webElement.Size;
                    }
                }

                return new Rectangle(pos, size);
            }
        }
        public RemoteWebElement SEWebElement
        {
            get
            {
                if (_webElement == null)
                {
                    if ( null != _webDriver)
                    {
                        //go to the top element
                        if (!this.Properties[WebControlKeys.Type].Equals("WebPage") &&
                            !this.Properties[WebControlKeys.Type].Equals("WebFrame"))
                        {
                            SETestObject rootObject = this.rootObject as SETestObject;
                            ITestObject FrameObject = this;
                            while (FrameObject.Parent != rootObject)
                            {
                                FrameObject = FrameObject.Parent;
                            }
                            SETestObject seFrameObject = FrameObject as SETestObject;
                            if (seFrameObject.Properties[WebControlKeys.Type].Equals("WebFrame"))
                            {
                                _webDriver.SwitchTo().Frame(seFrameObject.SEWebElement);
                            }
                        }

                        if (string.IsNullOrEmpty(Cssselector))
                        {
                            Cssselector = _properties[WebControlKeys.CssSelector];
                        }
                        ReadOnlyCollection<IWebElement> webelements = _webDriver.FindElementsByCssSelector(Cssselector);
                        if (webelements.Count == 1) _webElement = webelements[0] as RemoteWebElement;
                        string indexofTags = string.Empty;
                        if (_properties.TryGetValue(WebControlKeys.IndexofTags, out indexofTags))
                        {
                            this.IndexofTags = Convert.ToInt32(indexofTags);
                            _webElement = webelements[this.IndexofTags] as RemoteWebElement;
                        }
                        else
                        {
                            _webElement = webelements[this.IndexofTags] as RemoteWebElement;
                        }
                    }
                }
                else
                {
                    try
                    {
                        System.Drawing.Point pos = _webElement.Location;
                    }
                    catch (OpenQA.Selenium.StaleElementReferenceException exception)
                    {

                        //to check whether the webElement is still available or not
                        _webDriver = _webElement.WrappedDriver as RemoteWebDriver;
                        //go to the top element
                        SETestObject rootObject = this.rootObject as SETestObject;
                        if (!_webDriver.Url.Equals(rootObject.Properties[WebControlKeys.URL]))
                        {
                            _webDriver.SwitchTo().DefaultContent();
                            string currentWindow = _webDriver.CurrentWindowHandle;
                            //loop to find out the correct current window
                            foreach (string handle in _webDriver.WindowHandles)
                            {
                                //current window doesn't need to check
                                if (!handle.Equals(currentWindow))
                                {
                                    //switch
                                    _webDriver.SwitchTo().Window(handle);
                                    if (_webDriver.Url.IndexOf(rootObject.Properties[WebControlKeys.URL]) >= 0)
                                        break;
                                }
                            }

                            //_webDriver.SwitchTo().Window(rootObject.Properties[WebControlKeys.URL]);
                        }
                        else
                        {
                            //go to the top element
                            if (!this.Properties[WebControlKeys.Type].Equals("WebPage") &&
                                !this.Properties[WebControlKeys.Type].Equals("WebFrame"))
                            {
                                rootObject = this.rootObject as SETestObject;
                                ITestObject FrameObject = this;
                                while (FrameObject.Parent != rootObject)
                                {
                                    FrameObject = FrameObject.Parent;
                                }
                                SETestObject seFrameObject = FrameObject as SETestObject;
                                if (seFrameObject.Properties[WebControlKeys.Type].Equals("WebFrame"))
                                {
                                    _webDriver.SwitchTo().Frame(seFrameObject.SEWebElement);
                                }
                            }

                            if (string.IsNullOrEmpty(Cssselector))
                            {
                                Cssselector = _properties[WebControlKeys.CssSelector];
                            }
                            ReadOnlyCollection<IWebElement> webelements = _webDriver.FindElementsByCssSelector(Cssselector);
                            if (webelements.Count == 1) _webElement = webelements[0] as RemoteWebElement;
                            string indexofTags = string.Empty;
                            if (_properties.TryGetValue(WebControlKeys.IndexofTags, out indexofTags))
                            {
                                this.IndexofTags = Convert.ToInt32(indexofTags);
                                _webElement = webelements[this.IndexofTags] as RemoteWebElement;
                            }
                            else
                            {
                                _webElement = webelements[this.IndexofTags] as RemoteWebElement;
                            }
                        }
                        if (!this.Properties[WebControlKeys.Type].Equals("WebPage") &&
                            !this.Properties[WebControlKeys.Type].Equals("WebFrame"))
                        {
                            // check frame
                            ITestObject FrameObject = this;
                            while (FrameObject.Parent != rootObject)
                            {
                                FrameObject = FrameObject.Parent;
                            }
                            SETestObject seFrameObject = FrameObject as SETestObject;
                            if (seFrameObject.Properties[WebControlKeys.Type].Equals("WebFrame"))
                            {
                                _webDriver.SwitchTo().Frame(seFrameObject.SEWebElement);
                            }
                        }
                    }
                }
                return _webElement;
            }
            set
            {
                _webElement = value;
                _webDriver = _webElement.WrappedDriver as RemoteWebDriver;
            }
        }


        public override bool RemoveChild(ITestObject testObject)
        {
            int index;
            if ((index = _children.FindIndex(to => to == testObject)) >= 0)
            {
                _children.RemoveAt(index);//.Remove(testObject.NodeName);
                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool HasProperty(string key)
        {
            return this.Properties.ContainsKey(key);
        }


        #region Properties
        public string TagName
        {
            get
            {
                string value = null;
                Properties.TryGetValue(WebControlKeys.TagName, out value);
                return value;
            }
            set
            {
                Properties[WebControlKeys.TagName] = value;
            }
        }

        public string ID
        {
            get
            {
                return Properties[WebControlKeys.ID];
            }
            set
            {
                Properties[WebControlKeys.ID] = value;
            }
        }

        public int IndexofTags
        {
            set;
            get;
        }

        #endregion

    }
}
