using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace LPUIAObjects
{
    [Guid("FCCDE7F3-8FF1-406D-AEAE-673B950526DD")]
    public interface IUIAControlBase
    {
        void Click(int x = 0, int y = 0, int mousekey = 1);
        void DBClick(int x = 0, int y = 0, int mousekey = 1);
        string Text { get; }
        bool Exist(int time = 0);
        void HScroll(int value = 1);
        void VScroll(int value = 1);
        string GetRoProperty(string propertyname);
        bool WaitProperty(string propertyname, string value, int TimeOut = 0);
        void Drag(int x = -1, int y = -1);
        void Drop(int x = -1, int y = -1);
        string Name { get; }
        string Value { get; }
        int Hwnd { get; }
        int X { get; }
        int Y { get; }
        int Height { get; }
        int Width { get; }
        bool Enabled { get; }
        bool Focused { get; }
        string HelpText { get; }
        string LabeledText { get; }
        int ProcessID { get; }
        void PressKeys(string keys);
        void SetToProperty(string propertyname, string propertyvalue);
    }
    
}
