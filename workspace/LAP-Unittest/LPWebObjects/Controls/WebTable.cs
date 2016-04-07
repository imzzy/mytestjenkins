using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace LPWebObjects.Controls
{

    [Guid("A6F20ECC-20E0-472B-8495-50EEC6FC88D3")]
    [TypeLibType(4160)]
    public interface IWebTable
    {
    }
    
    [ProgId("LeanPro.WebTable")]
    [Guid(WebTable.ClassId)]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    public class WebTable : WebControlBase, IWebTable, IWebControl, IWebElement
    {
        internal const string ClassId = "E612E276-0942-470D-B2E8-55D407D96A71";

        public WebTable()
            : base()
        {
        }
    }
}
