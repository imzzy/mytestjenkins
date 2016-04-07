using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using OpenQA.Selenium;

namespace LPWebObjects.Controls
{

    [Guid("D925F9E2-87C3-44A9-B8B9-09A61D652CF4")]
    [TypeLibType(4160)]
    public interface IWebForm
    {
        [DispId(1)]
        void Submit();

    }

    [ProgId("LeanPro.WebForm")]
    [Guid(WebForm.ClassId)]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    public class WebForm : WebControlBase, IWebForm, IWebControl, IWebElement
    {
        internal const string ClassId = "1DB84875-C7D6-4A12-BB0D-BDE2FC80227A";

        public WebForm()
            : base()
        {
        }

        public void Submit()
        {
            try
            {
                RelayObject.SEWebElement.Submit();
            }
            catch(Exception)
            {

            }
            
        }
    }
}
