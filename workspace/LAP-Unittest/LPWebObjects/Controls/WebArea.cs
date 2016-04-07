using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace LPWebObjects.Controls
{

    [Guid("8E8C8679-6333-4B23-9FA3-54A69057CA7B")]
    [TypeLibType(4160)]
    public interface IWebArea
    {
    }

    [ProgId("LeanPro.IWebArea")]
    [Guid(WebArea.ClassId)]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    public class WebArea : WebControlBase, IWebArea, IWebControl, IWebElement
    {
        internal const string ClassId = "38AADC7B-137D-47B6-A586-D77528DC983F";

        public WebArea()
            : base()
        {
        }
    }
}
