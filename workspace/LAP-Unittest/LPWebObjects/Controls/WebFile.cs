using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace LPWebObjects.Controls
{

    [Guid("4EFFDE6C-1CD7-471D-98F5-8E0D9B7A7D8A")]
    [TypeLibType(4160)]
    public interface IWebFile
    {
    }

    [ProgId("LeanPro.WebFile")]
    [Guid(WebFile.ClassId)]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    public class WebFile : WebControlBase, IWebFile, IWebControl, IWebElement
    {
        internal const string ClassId = "D06AB8D3-0C31-482E-8678-80307AEC0DE6";

        public WebFile()
            : base()
        {
        }
    }
}
