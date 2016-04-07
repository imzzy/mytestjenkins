using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using OpenQA.Selenium.Support.UI;


namespace LPWebObjects.Controls
{

    [Guid("514ED369-CAC3-4EC1-8C58-D5A71929AB11")]
    [TypeLibType(4160)]
    public interface IWebList
    {
        [DispId(1)]
        void SelectByIndex(int index);

        [DispId(2)]
        void SelectByValue(string value);

        [DispId(3)]
        void SelectByName(string name);

        [DispId(4)]
        string SelectedOption
        {
            set;
            get;
        }
    }

    [ProgId("LeanPro.WebList")]
    [Guid(WebList.ClassId)]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    public class WebList : WebControlBase, IWebList, IWebControl, IWebElement
    {
        internal const string ClassId = "9FFADCE7-4E94-4909-AA57-78CA0B1403DD";

        protected SelectElement _selectElement = null;
        public WebList()
            : base()
        {
        }

        public void SelectByIndex(int index)
        {
            if (_selectElement == null)
            {
                _selectElement = new SelectElement(RelayObject.SEWebElement);
            }
            _selectElement.SelectByIndex(index);
        }

        public void SelectByValue(string value)
        {
            if (_selectElement == null)
            {
                _selectElement = new SelectElement(RelayObject.SEWebElement);
            }
            _selectElement.SelectByValue(value);
        }

        public void SelectByName(string name)
        {
            if (_selectElement == null)
            {
                _selectElement = new SelectElement(RelayObject.SEWebElement);
            }
            _selectElement.SelectByText(name);
        }


        public string SelectedOption
        {
            set
            {
                if (_selectElement == null)
                {
                    _selectElement = new SelectElement(RelayObject.SEWebElement);
                }
                _selectElement.SelectByText(value);
            }
            get
            {
                return _selectElement.SelectedOption.Text;
            }
        }
    }
}
