using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace LPWebObjects.Controls
{

    [Guid("237AED5F-5E3F-4EC5-B23B-31BAD10E38BF")]
    [TypeLibType(4160)]
    public interface IWebImageLink
    {
    }

    [ProgId("LeanPro.WebImageLink")]
    [Guid(WebImageLink.ClassId)]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    public class WebImageLink : WebControlBase, IWebImageLink, IWebControl, IWebElement
    {
        internal const string ClassId = "2CA572CF-74E4-4359-B33F-D218BDF14E85";

        public WebImageLink()
            : base()
        {
        }
    }
}
