using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace LPWebObjects.Controls
{

    [Guid("188A2D45-FA67-4112-8CC1-B13DE97C4418")]
    [TypeLibType(4160)]
    public interface IWebObject
    {
    }

    [ProgId("LeanPro.WebObject")]
    [Guid(WebObject.ClassId)]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    public class WebObject : WebControlBase, IWebObject, IWebControl, IWebElement
    {
        internal const string ClassId = "F8481DE7-50CC-4AEB-8FEB-416A3D2DAE28";

        public WebObject()
            : base()
        { 
        }
    }
}
