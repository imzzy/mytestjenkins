using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace LPWebObjects.Controls
{
    [Guid("66E9F563-917E-46F2-8BC9-40DEA52C4159")]
    [TypeLibType(4160)]
    public interface IWebLink 
    {
    }

    [ProgId("LeanPro.WebLink")]
    [Guid(WebLink.ClassId)]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    public class WebLink : WebControlBase, IWebLink, IWebControl, IWebElement
    {
        internal const string ClassId = "9E4779DC-D74E-487A-AC4F-02408DDD0917";

        public WebLink()
            : base()
        { 
        }
    }
}
