using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace LPWebObjects.Controls
{

    [Guid("E8DD2B36-6552-4F4E-BB26-3F698F65EEF8")]
    [TypeLibType(4160)]
    public interface IWebVideo
    {
    }

    [ProgId("LeanPro.WebVideo")]
    [Guid(WebVideo.ClassId)]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    public class WebVideo : WebControlBase, IWebVideo, IWebControl, IWebElement
    {
        internal const string ClassId = "80C60507-3C99-40BD-8D5A-D0B3267B7E1E";

        public WebVideo()
            : base()
        {
        }
    }
}
