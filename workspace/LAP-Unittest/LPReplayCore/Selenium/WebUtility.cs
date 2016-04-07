using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Interactions.Internal;
using OpenQA.Selenium.Internal;
using LPReplayCore.Interfaces;
using LPReplayCore.Model;

namespace LPReplayCore.Web
{
    public enum BrowerEnum : short
    {
        Chrome,
        Edge,
        Firefox,
        IE
    };

    public class WebUtility
    {
       // public static readonly string _jsFindEleByPos = "var x = arguments[0] - (window.screenLeft + (window.outerWidth - window.innerWidth)); " +
       //     "var y = arguments[1] - (window.screenTop + (window.outerHeight - window.innerHeight)); return document.elementFromPoint(x,y);";

        public static readonly string _jsFindEleByPos = "var x = arguments[0]; var y = arguments[1]; " +
            "return document.elementFromPoint(x,y);";

        public static readonly string _jsCalcScreenPos = "var border = (window.outerWidth - window.innerWidth) / 2;" +
            "var x = arguments[0] + window.screenLeft + border;" +
            "var y  = arguments[1] + (window.screenTop + (window.outerHeight - window.innerHeight - border)); return {x : x, y : y};";

        public static void switchWindow(IWebDriver webDriver, string Title = "")
        {
            foreach( var handle in webDriver.WindowHandles)
            {
                Console.WriteLine(handle);
            }
        }



        public static RemoteWebDriver startWebBrower(BrowerEnum brower)
        {
            switch (brower)
            {
                case BrowerEnum.Chrome:
                    return new ChromeDriver(LPReplayCore.Common.Utility.GetBinDirectory());
                default:
                    return null;
            }
        }

        public static void stopWebBrower(IWebDriver webDriver)
        {
            if ( webDriver != null)
            {
                webDriver.Close();
                webDriver.Dispose();
            }
        }

        public static RemoteWebElement FindElementByPoint(IWebDriver webDriver, Point point)
        {
            try
            {
                IJavaScriptExecutor jsExecutor = webDriver as IJavaScriptExecutor;
                if (null == jsExecutor) return null;
                return jsExecutor.ExecuteScript(_jsFindEleByPos, new object[] { point.X, point.Y }) as RemoteWebElement;
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        public static List<RemoteWebElement> GenerateWebElementsLine(RemoteWebElement webElement)
        {
            List<RemoteWebElement> webElementsLine = new List<RemoteWebElement>();
            webElementsLine.Add(webElement);

            while(!webElement.TagName.ToUpper().Equals("HTML"))
            {
                webElement = webElement.FindElement(By.XPath("..")) as RemoteWebElement;
                webElementsLine.Add(webElement);
            }
            webElementsLine.Reverse();
            return webElementsLine;
        }

        public static RemoteWebElement GetParentElement(RemoteWebElement webElement)
        {
            if (webElement == null || webElement.TagName.ToUpper().Equals("HTML")) return null;
            return webElement.FindElement(By.XPath("..")) as RemoteWebElement;
        }

        public static RemoteWebElement GetNextSiblingElement(RemoteWebElement webElement)
        {
            IJavaScriptExecutor jsExecutor = webElement.WrappedDriver as IJavaScriptExecutor;
            return jsExecutor.ExecuteScript("return arguments[0].nextSibling;", webElement) as RemoteWebElement;
        }

        public static Point GetElementScreenPos(RemoteWebElement webElement)
        {
            if (webElement == null) return new Point(0, 0);
            IWrapsDriver wrapsDriver = webElement as IWrapsDriver;
            IJavaScriptExecutor jsExecutor = wrapsDriver.WrappedDriver as IJavaScriptExecutor;

            Dictionary<string, object> pos = 
                jsExecutor.ExecuteScript(_jsCalcScreenPos, webElement.Location.X, webElement.Location.Y) as Dictionary<string, object>;

            return new Point(Convert.ToInt32(pos["x"]), Convert.ToInt32(pos["y"]));

        }

        public static Rectangle GetElementScreenRect(RemoteWebElement webElement)
        {
            if (webElement == null) return new Rectangle();
            IWrapsDriver wrapsDriver = webElement as IWrapsDriver;
            IJavaScriptExecutor jsExecutor = wrapsDriver.WrappedDriver as IJavaScriptExecutor;

            Dictionary<string, object> pos =
                jsExecutor.ExecuteScript(_jsCalcScreenPos, webElement.Location.X, webElement.Location.Y) as Dictionary<string, object>;

            return new Rectangle(new Point(Convert.ToInt32(pos["x"]), Convert.ToInt32(pos["y"])), webElement.Size);
        }



        public static bool AreEqual(ITestObject a, ITestObject b)
        {
            string cta = a.ControlTypeString;
            string ctb = b.ControlTypeString;

            if (!cta.Equals(ctb)) return false;

            if (cta.Equals("WebPage"))
            {
                return a.Properties[WebControlKeys.URL].ToString().Equals(b.Properties[WebControlKeys.URL].ToString())
                    && a.Properties[WebControlKeys.Title].ToString().Equals(b.Properties[WebControlKeys.Title].ToString());
            }

            string va = string.Empty;
            string vb = string.Empty;
            bool resa = a.Properties.TryGetValue(WebControlKeys.ID, out va);
            bool resb = b.Properties.TryGetValue(WebControlKeys.ID, out vb);
            if (resa != resb || (resa && !va.Equals(vb))) return false;

            resa = a.Properties.TryGetValue(WebControlKeys.TagName, out va);
            resb = b.Properties.TryGetValue(WebControlKeys.TagName, out vb);

            if (resa != resb || (resa && !va.Equals(vb))) return false;

            resa = a.Properties.TryGetValue(WebControlKeys.CssSelector, out va);
            resb = b.Properties.TryGetValue(WebControlKeys.CssSelector, out vb);

            if (resa != resb || (resa && !va.Equals(vb))) return false;

            resa = a.Properties.TryGetValue(WebControlKeys.IndexofTags, out va);
            resb = b.Properties.TryGetValue(WebControlKeys.IndexofTags, out vb);

            if (resa != resb || ( resa && !va.Equals(vb))) return false;

            return true;

        }


        public static string GetAttributeWithJavascript(RemoteWebElement webElement, string attrName)
        {
            if (null == webElement) return string.Empty;
            return ((IJavaScriptExecutor)webElement.WrappedDriver).ExecuteScript("return arguments[0].attributes['src'].value;", webElement).ToString();
        }
    }
}
