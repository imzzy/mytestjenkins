using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace LPWebObjects.Controls
{

    [Guid("D707AA6A-6EDA-40DF-BC62-A3438550A05E")]
    [TypeLibType(4160)]
    public interface IWebPlugin
    {
    }

    [ProgId("LeanPro.WebPlugin")]
    [Guid(WebPlugin.ClassId)]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    public class WebPlugin : WebControlBase, IWebPlugin, IWebControl, IWebElement
    {
        internal const string ClassId = "4C747460-3043-44EC-83F0-ED9F37A47F27";

        public WebPlugin()
            : base()
        {
        }
    }
}
