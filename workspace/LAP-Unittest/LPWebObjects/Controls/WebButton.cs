using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace LPWebObjects.Controls
{

    [Guid("6434F842-668A-4889-AF46-CE7B9EDC819B")]
    [TypeLibType(4160)]
    public interface IWebButton
    {
    }

    [ProgId("LeanPro.WebButton")]
    [Guid(WebButton.ClassId)]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    public class WebButton : WebControlBase, IWebButton, IWebControl, IWebElement
    {
        internal const string ClassId = "23614E75-AF70-4BFA-8953-C505F51526CF";

        public WebButton()
            : base()
        { 
        }
    }
}
