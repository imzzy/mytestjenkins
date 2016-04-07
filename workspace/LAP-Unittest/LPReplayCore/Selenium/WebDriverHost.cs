using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Interactions;
using System.Drawing;
using System.Windows.Automation;
using System.Diagnostics;
using LPReplayCore.Common;
using LPReplayCore.UIA;
using System.Windows.Automation;
using System.Threading;
using System.Collections;
using System.Collections.ObjectModel;

namespace LPReplayCore.Web
{
    using WebElementsList = List<RemoteWebElement>;

    using WebElementPropertiesList = List<WebElementProperties>;

    /// <summary>
    /// 
    /// 
    /// </summary>
    public class WebDriverHost : IDisposable
    {
       
        private RemoteWebElement _currFrameElement = null;

        private RemoteWebDriver _webDriver = null;

        private RemoteWebElement _webSelectElement = null;

        private AutomationElement _toobarAutoElement = null;

        private AutomationElement _ChromeAutoElement = null;

        private AutomationElement _HostAutoElement = null;

        private const string _ChromeClassName = "Chrome_WidgetWin_1";

        private const string _ChromeContentClassName = "Chrome_RenderWidgetHostHWND";

        private bool _isInFrame = false;
        public RemoteWebDriver WebDriver
        {
            get
            {
                return _webDriver;
            }
        }

        public RemoteWebElement WebSelectElement
        {
            get
            {
                return _webSelectElement;
            }
        }
        public void GotoUrl(string URL)
        {
            _webDriver.Navigate().GoToUrl(URL);
        }

        public bool SwithToURL(string URL)
        {
            string currentWindow = _webDriver.CurrentWindowHandle;
            string currTitle = _webDriver.Title;
            string currURL = _webDriver.Url;
            if (currURL.Equals(URL))
                return true;

            string currentAllWindow = string.Empty;
            foreach (string handle in _webDriver.WindowHandles)
            {
                currentAllWindow += handle;
                currentAllWindow += ":";
                //current window doesn't need to check
                if (!handle.Equals(currentWindow))
                {
                    //switch
                    _webDriver.SwitchTo().Window(handle);
                    if (URL.Equals(_webDriver.Url))
                        return true;
                }
            }

            //create a new Tab
            Actions newTab = new Actions(_webDriver);
            newTab.SendKeys(Keys.Control + "t").Perform();
            Thread.Sleep(1000);
            foreach (string handle in _webDriver.WindowHandles)
            {
                if (currentAllWindow.IndexOf(handle) == -1)
                {
                    _webDriver.SwitchTo().Window(handle);
                    _webDriver.Navigate().GoToUrl(URL);

                    //Utility.AsyncCall(() =>
                    //{
                    //    //look for all existing browsers
                    //    AutomationElementCollection browserElementsBefore = AutomationElement.RootElement.FindAll(TreeScope.Children,
                    //           new PropertyCondition(AutomationElement.ClassNameProperty, _ChromeClassName));
                    //    //launch the browser
                    //    _webDriver = WebUtility.startWebBrower(BrowerEnum.Chrome);
                    //    //_webDriver.Navigate().GoToUrl("http://newtours.demoaut.com");
                    //    //look for all existing browsers after launched the browser
                    //    AutomationElementCollection browserElementsAfter = AutomationElement.RootElement.FindAll(TreeScope.Children,
                    //            new PropertyCondition(AutomationElement.ClassNameProperty, _ChromeClassName));
                    //    AutomationElement browserElement = null;
                    //    switch (browserElementsAfter.Count)
                    //    {
                    //        case 0:
                    //            {
                    //                Debug.Assert(true, "Browser didn't launch successfully!!!!!");
                    //            }
                    //            break;
                    //        case 1:
                    //            {
                    //                browserElement = browserElementsAfter[0];
                    //            }
                    //            break;
                    //        default:
                    //            {
                    //                int i = 0;
                    //                AutomationElement ae = null;
                    //                bool isFind = false;
                    //                for (i = 0; i < browserElementsAfter.Count; ++i)
                    //                {
                    //                    ae = browserElementsAfter[i];
                    //                    isFind = false;
                    //                    foreach (AutomationElement aeBefore in browserElementsBefore)
                    //                    {
                    //                        if (ae == aeBefore)
                    //                        {
                    //                            isFind = true;
                    //                            break;
                    //                        }
                    //                    }
                    //                    if (!isFind)
                    //                    {
                    //                        browserElement = ae;
                    //                        break;
                    //                    }
                    //                }

                    //            }
                    //            break;
                    //    }
                    //    _ChromeAutoElement = browserElement;
                    //    _HostAutoElement = browserElement.FindFirst(TreeScope.Children,
                    //            new PropertyCondition(AutomationElement.ClassNameProperty, _ChromeContentClassName));
                    //});

                    return true;
                }
            }
            return false;
        }

        public WebDriverHost()
        {
            Utility.AsyncCall(() =>
            {
                //look for all existing browsers
                AutomationElementCollection browserElementsBefore = AutomationElement.RootElement.FindAll(TreeScope.Children,
                       new PropertyCondition(AutomationElement.ClassNameProperty, _ChromeClassName));
                //launch the browser
                _webDriver = WebUtility.startWebBrower(BrowerEnum.Chrome);
                //_webDriver.Navigate().GoToUrl("http://newtours.demoaut.com");
                //look for all existing browsers after launched the browser
                AutomationElementCollection browserElementsAfter = AutomationElement.RootElement.FindAll(TreeScope.Children,
                        new PropertyCondition(AutomationElement.ClassNameProperty, _ChromeClassName));
                AutomationElement browserElement = null;
                switch (browserElementsAfter.Count)
                {
                    case 0:
                        {
                            Debug.Assert(true, "Browser didn't launch successfully!!!!!");
                        }
                        break;
                    case 1:
                        {
                            browserElement = browserElementsAfter[0];
                        }
                        break;
                    default:
                        {
                            int i = 0;
                            AutomationElement ae = null;
                            bool isFind = false;
                            for (i = 0; i < browserElementsAfter.Count; ++i)
                            {
                                ae = browserElementsAfter[i];
                                isFind = false;
                                foreach (AutomationElement aeBefore in browserElementsBefore)
                                {
                                    if (ae == aeBefore)
                                    {
                                        isFind = true;
                                        break;
                                    }
                                }
                                if (!isFind)
                                {
                                    browserElement = ae;
                                    break;
                                }
                            }

                        }
                        break;
                }
                _ChromeAutoElement = browserElement;
                _HostAutoElement = browserElement.FindFirst(TreeScope.Children,
                       new PropertyCondition(AutomationElement.ClassNameProperty, _ChromeContentClassName));

                _toobarAutoElement = browserElement.FindFirst(TreeScope.Subtree,
                       new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.ToolBar));

                
            });
        }

        private AutomationElement HostAutoElement
        {
            get
            {
                if (_HostAutoElement == null || _HostAutoElement.Current.BoundingRectangle.IsEmpty)
                {
                    _HostAutoElement = _ChromeAutoElement.FindFirst(TreeScope.Children,
                        new PropertyCondition(AutomationElement.ClassNameProperty, _ChromeContentClassName));
                }
                return _HostAutoElement;
            }
        }

        public void HighlightWebElement(RemoteWebElement webElement)
        {
            if (webElement == null) return;
            int X = webElement.Location.X + (int)_toobarAutoElement.Current.BoundingRectangle.TopLeft.X;
            int Y = webElement.Location.Y + (int)_toobarAutoElement.Current.BoundingRectangle.TopLeft.Y + (int)_toobarAutoElement.Current.BoundingRectangle.Height;
            Rectangle rc = new Rectangle(X, Y, webElement.Size.Width, webElement.Size.Height);
            UIAHighlight.HighlightRect(rc);
        }


        public WebElementPropertiesList GenerateElementPropertiesLineByPoint(Point point)
        {
            _isInFrame = false;
            _webDriver.SwitchTo().DefaultContent();
            point.X -= (int)_toobarAutoElement.Current.BoundingRectangle.TopLeft.X;
            point.Y -= ((int)_toobarAutoElement.Current.BoundingRectangle.TopLeft.Y + (int)_toobarAutoElement.Current.BoundingRectangle.Height);
            _webSelectElement = WebUtility.FindElementByPoint(_webDriver, point);
            WebElementsList webElementsLine = null;
            WebElementPropertiesList webElementPropertiesList = null;

            //testing
#if false
            RemoteWebElement frame = _webSelectElement;

            ReadOnlyCollection<IWebElement> res = _webDriver.FindElementsByTagName("frame");
            ReadOnlyCollection<IWebElement> inputs = null;
            _webDriver.SwitchTo().Frame(res[1]);

            inputs = _webDriver.FindElementsByTagName("input");

            _webDriver.SwitchTo().DefaultContent();
            _webDriver.SwitchTo().Frame(res[1]);
#endif


#if false
            RemoteWebElement inputElement = _webDriver.FindElementByTagName("input") as RemoteWebElement;

            string currWindow = _webDriver.CurrentWindowHandle;

            RemoteWebDriver currWebDriver2 = null;
            foreach(string window in _webDriver.WindowHandles)
            {
                if ( window.Equals(currWindow))
                    continue;
                currWebDriver2 = _webDriver.SwitchTo().Window(window) as RemoteWebDriver;
                break;
            }
            RemoteWebElement inputElement2 = _webDriver.FindElementByTagName("button") as RemoteWebElement;

            _webDriver.SwitchTo().Window(currWindow);

            Thread.Sleep(0);

#endif
            //testing end
            if (_webSelectElement.TagName.ToUpper().IndexOf("FRAME") >= 0)
            {

                //Currently, window handle is pointing to main page
                webElementsLine = GenerateWebElementsLine(_webSelectElement);

                //Generate the WebElementProperties list - since the window handle will be switched to iFrame
                //the Selenium elements will be not available
                //Currently, the generated elements are in the main page, can't get the elements in the iFrame page
                webElementPropertiesList = webElementsLine
                     .Select(element =>
                     {
                         return WebElementProperties.createWebElementPropertiesWithWebElement(element, null, this);
                     })
                     .Where(resElementProperties => resElementProperties != null).ToList();

                point.X -= _webSelectElement.Location.X;
                point.Y -= _webSelectElement.Location.Y;
                //Currently, window handle is pointing to iFrame page, can get the elements in the iFrame page
                _webDriver.SwitchTo().Frame(_webSelectElement);
                RemoteWebElement FrameElement = _webSelectElement;
                _webSelectElement = WebUtility.FindElementByPoint(_webDriver, point);
                webElementsLine = GenerateWebElementsLine(_webSelectElement);
                //don't need the WebPage since the WebFrame object has been already inserted into the list, it is the "WebPage" for the iFrame page
                webElementPropertiesList.AddRange(webElementsLine
                    .Select(element =>
                    {
                        return WebElementProperties.createWebElementPropertiesWithWebElement(element, FrameElement, this);
                    })
                    .Where(resElementProperties => resElementProperties != null && !resElementProperties.ControlTypeString.Equals("WebPage")).ToList());

            }
            else
            {
                webElementPropertiesList = GenerateWebElementsLine(_webSelectElement)
                 .Select(element =>
                 {
                     return WebElementProperties.createWebElementPropertiesWithWebElement(element, null, this);
                 })
                 .Where(resElementProperties => resElementProperties != null).ToList();

            }
            return webElementPropertiesList;
        }

        public RemoteWebElement FindElementByPoint(Point point)
        {
            _isInFrame = false;
            _webDriver.SwitchTo().DefaultContent();
            point.X -= (int)_toobarAutoElement.Current.BoundingRectangle.TopLeft.X;
            point.Y -= ((int)_toobarAutoElement.Current.BoundingRectangle.TopLeft.Y + (int)_toobarAutoElement.Current.BoundingRectangle.Height);
            _webSelectElement = WebUtility.FindElementByPoint(_webDriver, point);

            if (_webSelectElement.TagName.ToUpper().IndexOf("FRAME") >=0 )
            {
                _currFrameElement = _webSelectElement;
                point.X -= _webSelectElement.Location.X;
                point.Y -= _webSelectElement.Location.Y;
                _webDriver.SwitchTo().Frame(_webSelectElement);
                _webSelectElement = WebUtility.FindElementByPoint(_webDriver, point);
                _isInFrame = true;
            }
            return _webSelectElement;
        }


        public WebElementsList GenerateWebElementsLine(RemoteWebElement webElement)
        {
            WebElementsList webElementsLine = WebUtility.GenerateWebElementsLine(webElement);
            
            //if the element is in a frame, need to switch to the top
            /*if (_isInFrame)
            {
                _webDriver.SwitchTo().DefaultContent();
              //  _currFrameElement.
                
            }*/

            return webElementsLine;

        }

        public void SwitchRelevantWindow(RemoteWebElement frameElement)
        {
            if (frameElement != null)
            {
                _webDriver.SwitchTo().DefaultContent();
                _webDriver.SwitchTo().Frame(frameElement);
            }
        }

        public void SwitchRelevantWindow(string URL)
        {
            if (URL.Equals(_webDriver.Url))
                return;

            string currWindowHandle = _webDriver.CurrentWindowHandle;
            
            foreach(string windowHandle in _webDriver.WindowHandles)
            {
                if (windowHandle.Equals(currWindowHandle)) continue;

                _webDriver.SwitchTo().Window(windowHandle);
                if (URL.Equals(_webDriver.Url))
                    return;
            }
            // for scenario - if can't find the relevant window handle, maybe in the iFrame window handle 
            _webDriver.SwitchTo().DefaultContent();
        }


        public void CheckWindowHandle(AutomationElement hostae)
        {
            _HostAutoElement = hostae;
            if (_webDriver.WindowHandles.Count == 1) return;
            AutomationElement browserWindow = UIAUtility.GetParentElement(hostae);
            string currentWindow = _webDriver.CurrentWindowHandle;
            string currTitle = _webDriver.Title;
            do
            {
                //search the chrome window
                if (browserWindow.Current.ClassName.Equals(_ChromeClassName) )
                {
                    //get Title
                    string title = browserWindow.Current.Name;
                    if (title.EndsWith(" - Google Chrome"))
                    {
                        title = title.Remove(title.LastIndexOf(" - Google Chrome"));
                    }
                    //compare the title of browser with the current window handle
                    //if equal, it is the correct current window then return
                    if (title.Equals(_webDriver.Title))
                        break;

                    //loop to find out the correct current window
                    foreach (string handle in _webDriver.WindowHandles)
                    {
                        //current window doesn't need to check
                        if (!handle.Equals(currentWindow))
                        {
                            //switch
                            _webDriver.SwitchTo().Window(handle);
                            if (_webDriver.Title.IndexOf(title) >= 0)
                                return;
                        }
                    }
                    //not found switch back
                    _webDriver.SwitchTo().Window(currentWindow);
                    break;
                }
            } 
            while( AutomationElement.RootElement != (browserWindow = UIAUtility.GetParentElement(browserWindow)));
           
           
        }
        public Rectangle GetElementRectangle(SETestObject seTestObject)
        {
            Rectangle rect = seTestObject.absolutePageRect;
            rect.X += (int)_toobarAutoElement.Current.BoundingRectangle.X;

            rect.Y += ((int)_toobarAutoElement.Current.BoundingRectangle.TopLeft.Y + (int)_toobarAutoElement.Current.BoundingRectangle.Height);

            return rect;

        }

        public Rectangle GetElementRectangle(WebElementProperties webElementProperties)
        {
            Point pos = new Point();
            pos.X = 0;  pos.Y = 0;
            Size size = new Size();
            try
            {
                pos = webElementProperties.WebElement.Location;
                size = webElementProperties.WebElement.Size;
                if ( webElementProperties.IsInFrame)
                {
                    _webDriver.SwitchTo().DefaultContent();
                    pos.Offset(webElementProperties.FrameElement.Location);
                    //_webDriver.SwitchTo().Frame(webElementProperties.FrameElement);

                }
            }
            catch (OpenQA.Selenium.StaleElementReferenceException exception)
            {
                //the element is not available
                if (!_webDriver.Url.Equals(webElementProperties.BrowserURL))
                {
                    this.SwithToURL(webElementProperties.BrowserURL);
                }
                if (webElementProperties.IsInFrame)
                {
                    //switch to frame
                    _webDriver.SwitchTo().DefaultContent();
                    pos = webElementProperties.FrameElement.Location;
                    _webDriver.SwitchTo().Frame(webElementProperties.FrameElement);
                }
                pos.Offset(webElementProperties.WebElement.Location);
                size = webElementProperties.WebElement.Size;
            }

            pos.X += (int)_toobarAutoElement.Current.BoundingRectangle.X;

            pos.Y += ((int)_toobarAutoElement.Current.BoundingRectangle.Y + (int)_toobarAutoElement.Current.BoundingRectangle.Height);


            return new Rectangle(pos, size);


        }


        public void Dispose()
        {
            if (_webDriver != null)
                WebUtility.stopWebBrower(_webDriver);
        }
        
    }
}
