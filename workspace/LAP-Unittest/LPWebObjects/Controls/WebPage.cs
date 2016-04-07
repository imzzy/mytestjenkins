using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Interactions;
using LPReplayCore.Model;
using LPWebObjects;

namespace LPWebObjects.Controls
{

    [Guid("A1573EA6-AE68-4F9E-84ED-9AD67C9F6D83")]
    [TypeLibType(4160)]
    public interface IWebPage
    {
        //TODO After WebFrame can create sub frame object, this function should be moved to IWebContainer   
        [DispId(1)]
        WebFrame WebFrame(string nodeName);

        [DispId(2)]
        void Navigate(string URL);

        [DispId(3)]
        void Back();

        [DispId(4)]
        void Forward();

        [DispId(5)]
        void Refresh();
    }


    [ProgId("LeanPro.WebPage")]
    [Guid(WebPage.ClassID)]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    public class WebPage : WebContainerBase, IWebPage, IWebElement, IWebContainer
    {
        internal const string ClassID = "562C8C2C-ED57-4B34-B067-7DBACBFA582E";
        public WebPage()
        {

        }

        internal static void SwitchTo(WebPage webPage)
        {
            BrowserHoster browser = BrowserHoster.getInstance();
            RemoteWebDriver webDriver = browser.WebDriver;
            if (string.IsNullOrEmpty(webPage.WindowHandle))
            {
                browser.SwitchToURL(webPage.RelayObject.Properties[WebControlKeys.URL]);
                webPage.WindowHandle = webDriver.CurrentWindowHandle;
                return;
            }
            if (webPage.WindowHandle.Equals(webDriver.CurrentWindowHandle))
                return;

            try
            {
                webDriver.SwitchTo().Window(webPage.WindowHandle);
            }
            catch (OpenQA.Selenium.NoSuchWindowException)
            {
                browser.SwitchToURL(webPage.RelayObject.Properties[WebControlKeys.URL]);
                webPage.WindowHandle = webDriver.CurrentWindowHandle;
            }
        }
        internal string WindowHandle
        {
            set;
            get;
        }

        public WebFrame WebFrame(string nodeName)
        {
            return base.GetTo<WebFrame>(nodeName);
        }

        private void SwithToMe()
        {
            SwitchTo(this);
        }
        public void Navigate(string URL)
        {
            SwithToMe();
            BrowserHoster.getInstance().WebDriver.Navigate().GoToUrl(URL);
        }

        public void Back()
        {
            SwithToMe();
            BrowserHoster.getInstance().WebDriver.Navigate().Back();
        }

        public void Forward()
        {
            SwithToMe();
            BrowserHoster.getInstance().WebDriver.Navigate().Forward();
        }

        public void Refresh()
        {
            SwithToMe();
            BrowserHoster.getInstance().WebDriver.Navigate().Refresh();
        }
    }
}
