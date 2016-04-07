using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using OpenQA.Selenium.Remote;
using System.Collections.ObjectModel;

namespace LPWebObjects.Controls
{

    [Guid("419628FB-D872-4CAF-8BB9-DC7B97130532")]
    [TypeLibType(4160)]
    public interface IWebRadioGroup
    {
        [DispId(1)]
        void Select(string value);

        [DispId(2)]
        void Select(int index);
        
    }

    [ProgId("LeanPro.WebRadioGroup")]
    [Guid(WebRadioGroup.ClassId)]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    public class WebRadioGroup : WebControlBase, IWebRadioGroup, IWebControl, IWebElement
    {
        internal const string ClassId = "0C61B1B9-EFF0-4FAE-A516-1A6A09973C7B";

        private Dictionary<string, RemoteWebElement> _Radios = new Dictionary<string, RemoteWebElement>();
        public WebRadioGroup()
            : base()
        {

        }

        private void PrepareRadios()
        {
            if (0 < _Radios.Count)
                return;

            RemoteWebElement webElement = RelayObject.SEWebElement;
            RemoteWebDriver webDriver = webElement.WrappedDriver as RemoteWebDriver;
            string name = base.GetRoProperty("name");
            ReadOnlyCollection<OpenQA.Selenium.IWebElement> RCollection = webDriver.FindElementsByCssSelector("input[type=radio][name=" + name + "]");

            foreach(var element in RCollection)
            {
                string key = element.GetAttribute("value");
                if (string.IsNullOrEmpty(key))
                    key = element.Text;
                _Radios[key] = element as RemoteWebElement;
            }

        }

        public void Select(string value)
        {
            PrepareRadios();
            RemoteWebElement webElement = null;
            if (_Radios.TryGetValue(value, out webElement))
            {
                webElement.Click();
            }
        }

        [DispId(2)]
        public void Select(int index)
        {
            PrepareRadios();
            if (index >= _Radios.Count)
                return;
            _Radios.ElementAt(index).Value.Click();
        }
    }
}
