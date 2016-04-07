using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

using OpenQA.Selenium.Remote;

namespace LPWebObjects.Controls
{

    [Guid("B8FA906F-852B-46C4-9C0D-EAE4DE6858FF")]
    [TypeLibType(4160)]
    public interface IWebCheckBox
    {
        [DispId(1)]
        bool Selected { get; set; }
    }
    

    [ProgId("LeanPro.WebCheckBox")]
    [Guid(WebCheckBox.ClassId)]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    public class WebCheckBox : WebControlBase, IWebCheckBox, IWebControl, IWebElement
    {
        internal const string ClassId = "F3F4B1C4-4A33-4B92-96A6-438D5C7C1AAC";

        public WebCheckBox()
            : base()
        {
        }

        public bool Selected
        {
            get
            {
                 RemoteWebElement webElement = RelayObject.SEWebElement;
                 return webElement.Selected;
            }
            set
            {
                RemoteWebElement webElement = RelayObject.SEWebElement;
                if (webElement.Selected != value)
                    base.Click();
            }
        }
    }
}
