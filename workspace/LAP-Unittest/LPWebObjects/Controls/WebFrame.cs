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


namespace LPWebObjects.Controls
{

    [Guid("F13439AE-FA5F-48B8-80D5-37862FA796EF")]
    [TypeLibType(4160)]
    public interface IWebFrame
    {
        //TODO Frame should be able to create a sub frame object, however currently
        //the spy doesn't support, so removed it temporarily
       /* [DispId(1)]
        [return: MarshalAs(UnmanagedType.Interface)]
        WebFrame WebFrame(string nodeName);*/
    }

    [ProgId("LeanPro.WebFrame")]
    [Guid(WebFrame.ClassId)]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    public class WebFrame : WebContainerBase, IWebFrame, IWebElement, IWebContainer
    {

        internal const string ClassId = "DC0AB09E-D874-4728-BB4A-4ED91B918AB6";

        public WebFrame()
            : base()
        {
        }


    }
}
