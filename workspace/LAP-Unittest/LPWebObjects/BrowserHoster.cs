using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Interactions;
using System.Threading;
using LPReplayCore.Web;

namespace LPWebObjects
{
    internal class BrowserHoster
    {
        private static BrowserHoster _browserHoster = null;

        private RemoteWebDriver _webDriver = null;

        public RemoteWebDriver WebDriver
        {
            get { return _webDriver; }
        }
        public static BrowserHoster getInstance() 
        {
            if (_browserHoster == null)
            {
                _browserHoster = new BrowserHoster();
                _browserHoster._webDriver = WebUtility.startWebBrower(BrowerEnum.Chrome);
                _browserHoster._webDriver.Manage().Window.Maximize();
            }
            return _browserHoster;
        }

        private BrowserHoster() { }

        public void SwitchToURL(string URL)
        {
            string currentWindow = _webDriver.CurrentWindowHandle;
            string currTitle = _webDriver.Title;
            string currURL = _webDriver.Url;
            int indexofQuestion = currURL.IndexOf("?");
            if ( indexofQuestion > 0)
            {
                currURL = currURL.Substring(0, currURL.Length - indexofQuestion);
            }

            if (URL.StartsWith(currURL))
                return;


            if ( _webDriver.WindowHandles.Count == 1 &&
                _webDriver.Url.Equals("data:,") )
            {
                _webDriver.Navigate().GoToUrl(URL);
                return;
            }
            string currentAllWindow = string.Empty;
            string url2 = string.Empty;
            foreach (string handle in _webDriver.WindowHandles)
            {
                currentAllWindow += handle;
                currentAllWindow += ":";
                //current window doesn't need to check
                if (!handle.Equals(currentWindow))
                {
                    //switch
                    _webDriver.SwitchTo().Window(handle);
                    url2 = _webDriver.Url;
                    indexofQuestion = url2.IndexOf("?");
                    if (indexofQuestion > 0)
                    {
                        url2 = url2.Substring(0, url2.Length - indexofQuestion);
                    }

                    if (URL.StartsWith(url2))
                        return;
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
                    return;
                }
            }
            return;
        }

    }
}
