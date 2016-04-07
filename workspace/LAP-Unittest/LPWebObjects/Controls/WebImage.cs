using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace LPWebObjects.Controls
{

    [Guid("0974A120-A7B0-4E22-A060-77585EFA7A98")]
    [TypeLibType(4160)]
    public interface IWebImage
    {
    }

    [ProgId("LeanPro.WebImage")]
    [Guid(WebImage.ClassId)]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    public class WebImage : WebControlBase, IWebImage, IWebControl, IWebElement
    {
        internal const string ClassId = "4513FBD0-A3A1-4849-89A7-4A79B9D5F11A";

        public WebImage()
            : base()
        {
        }
    }
}
