using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using LPReplayCore.Web;

namespace LPWebObjects.Controls
{

    [Guid("5E44CA09-7911-4D08-9CDC-3619DF16DA14")]
    [TypeLibType(4160)]
    public interface IWebElement
    {
        [DispId(1)]

        string ObjectName
        {
            set;
            get;
        }

        [DispId(2)]

        string GetRoProperty(string propertyname);

        [DispId(3)]
        string GetToProperty(string propertyname);

        [DispId(4)]
        SETestObject RelayObject
        {
            set;
            get;
        }

        [DispId(5)]
        bool Enabled
        {
            get;
        }

        [DispId(6)]
        bool Displayed
        {
            get;
        }

       
    }


    [Guid("30858D45-0E3A-473B-A730-D4512FC49B4E")]
    [TypeLibType(4160)]
    public interface IWebControl
    {
        [DispId(1)]
        void Click(int x = -1, int y = -1);

        [DispId(2)]
        void RClick(int x = -1, int y = -1);

        [DispId(3)]
        void DBClick(int x = -1, int y = -1);

        [DispId(4)]
        void Drag(int x = -1, int y = -1);

        [DispId(5)]
        void Drop(int x = -1, int y = -1);

        [DispId(6)]
        void DragAndDrop(IWebElement target);
    }
}
