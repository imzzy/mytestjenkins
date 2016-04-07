using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Windows;
using System.Windows.Automation;
using LPCommon;

namespace LPUIAObjects
{
    [Guid("D0E3C7FD-2B17-4D12-AB00-4BE7EC9497ED")]
    public interface IUIAScrollBar
    {
        [DispId(1)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IUIAWindow UIAWindow(string conditions, string conditions1 = "", string conditions2 = "", string conditions3 = "", string conditions4 = "", string conditions5 = "", string conditions6 = "", string conditions7 = "", string conditions8 = "", string conditions9 = "");

        [DispId(2)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IUIAPane UIAPane(string conditions, string conditions1 = "", string conditions2 = "", string conditions3 = "", string conditions4 = "", string conditions5 = "", string conditions6 = "", string conditions7 = "", string conditions8 = "", string conditions9 = "");

        [DispId(3)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IUIAEditor UIAEditor(string conditions, string conditions1 = "", string conditions2 = "", string conditions3 = "", string conditions4 = "", string conditions5 = "", string conditions6 = "", string conditions7 = "", string conditions8 = "", string conditions9 = "");

        [DispId(4)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IUIAButton UIAButton(string conditions, string conditions1 = "", string conditions2 = "", string conditions3 = "", string conditions4 = "", string conditions5 = "", string conditions6 = "", string conditions7 = "", string conditions8 = "", string conditions9 = "");

        [DispId(5)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IUIACheckbox UIACheckbox(string conditions, string conditions1 = "", string conditions2 = "", string conditions3 = "", string conditions4 = "", string conditions5 = "", string conditions6 = "", string conditions7 = "", string conditions8 = "", string conditions9 = "");

        [DispId(6)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IUIAList UIAList(string conditions, string conditions1 = "", string conditions2 = "", string conditions3 = "", string conditions4 = "", string conditions5 = "", string conditions6 = "", string conditions7 = "", string conditions8 = "", string conditions9 = "");

        [DispId(7)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IUIARadioButton UIARadiobutton(string conditions, string conditions1 = "", string conditions2 = "", string conditions3 = "", string conditions4 = "", string conditions5 = "", string conditions6 = "", string conditions7 = "", string conditions8 = "", string conditions9 = "");

        [DispId(8)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IUIAMenuBar UIAMenuBar(string conditions, string conditions1 = "", string conditions2 = "", string conditions3 = "", string conditions4 = "", string conditions5 = "", string conditions6 = "", string conditions7 = "", string conditions8 = "", string conditions9 = "");

        [DispId(9)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IUIATree UIATree(string conditions, string conditions1 = "", string conditions2 = "", string conditions3 = "", string conditions4 = "", string conditions5 = "", string conditions6 = "", string conditions7 = "", string conditions8 = "", string conditions9 = "");

        [DispId(10)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IUIAText UIAText(string conditions, string conditions1 = "", string conditions2 = "", string conditions3 = "", string conditions4 = "", string conditions5 = "", string conditions6 = "", string conditions7 = "", string conditions8 = "", string conditions9 = "");

        [DispId(11)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IUIATable UIATable(string conditions, string conditions1 = "", string conditions2 = "", string conditions3 = "", string conditions4 = "", string conditions5 = "", string conditions6 = "", string conditions7 = "", string conditions8 = "", string conditions9 = "");

        [DispId(12)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IUIAScrollBar UIAScrollbar(string conditions, string conditions1 = "", string conditions2 = "", string conditions3 = "", string conditions4 = "", string conditions5 = "", string conditions6 = "", string conditions7 = "", string conditions8 = "", string conditions9 = "");

        [DispId(13)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IUIAComboBox UIAComboBox(string conditions, string conditions1 = "", string conditions2 = "", string conditions3 = "", string conditions4 = "", string conditions5 = "", string conditions6 = "", string conditions7 = "", string conditions8 = "", string conditions9 = "");

        [DispId(14)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IUIASlider UIASlider(string conditions, string conditions1 = "", string conditions2 = "", string conditions3 = "", string conditions4 = "", string conditions5 = "", string conditions6 = "", string conditions7 = "", string conditions8 = "", string conditions9 = "");

        [DispId(15)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IUIATab UIATab(string conditions, string conditions1 = "", string conditions2 = "", string conditions3 = "", string conditions4 = "", string conditions5 = "", string conditions6 = "", string conditions7 = "", string conditions8 = "", string conditions9 = "");

        [DispId(16)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IUIAImage UIAImage(string conditions, string conditions1 = "", string conditions2 = "", string conditions3 = "", string conditions4 = "", string conditions5 = "", string conditions6 = "", string conditions7 = "", string conditions8 = "", string conditions9 = "");

        [DispId(17)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IUIAEdit UIAEdit(string conditions, string conditions1 = "", string conditions2 = "", string conditions3 = "", string conditions4 = "", string conditions5 = "", string conditions6 = "", string conditions7 = "", string conditions8 = "", string conditions9 = "");

        [DispId(18)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IUIAToolBar UIAToolBar(string conditions, string conditions1 = "", string conditions2 = "", string conditions3 = "", string conditions4 = "", string conditions5 = "", string conditions6 = "", string conditions7 = "", string conditions8 = "", string conditions9 = "");

        [DispId(19)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IUIACustom UIACustom(string conditions, string conditions1 = "", string conditions2 = "", string conditions3 = "", string conditions4 = "", string conditions5 = "", string conditions6 = "", string conditions7 = "", string conditions8 = "", string conditions9 = "");

        [DispId(20)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IUIAMenu UIAMenu(string conditions, string conditions1 = "", string conditions2 = "", string conditions3 = "", string conditions4 = "", string conditions5 = "", string conditions6 = "", string conditions7 = "", string conditions8 = "", string conditions9 = "");

        [DispId(21)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IUIALink UIALink(string conditions, string conditions1 = "", string conditions2 = "", string conditions3 = "", string conditions4 = "", string conditions5 = "", string conditions6 = "", string conditions7 = "", string conditions8 = "", string conditions9 = "");
 
        [Description("Click UIAScrollbar, MouseKey=1 is left button,\"2\" is right button, default is \"1\"")]
        void Click(int x = 0, int y = 0, int mousekey = 1);

        [Description("Double Click UIAScrollbar, MouseKey=1 is left button,\"2\" is right button, default is \"1\"")]
        void DBClick(int x = 0, int y = 0, int mousekey = 1);

        string Text { [Description("Get the UIAScrollbar test")] get; }

        [Description("Check whether UIAScrollbar exists, default value of times is \"0\"")]
        bool Exist(int time = 0);

        [Description("Scroll left button is minus, like \"-2\", Scroll right button is positive, like \"2\"")]
        void HScroll(int value = 1);

        [Description("Scroll up button is minus, like \"-2\", Scroll down button is positive, like \"2\"")]
        void VScroll(int value = 1);

        [Description("Support value: title, name, text, hwnd, x, y, height, width, enabled, focused, helptext, labeledtext, processid")]
        string GetRoProperty(string propertyname);

        [Description("Set the test object's search condition property")]
        void SetToProperty(string propertyname, string propertyvalue);

        [Description("Support value: title, name, text, hwnd, x, y, height, width, enabled, focused, helptext, labeledtext, processid")]
        bool WaitProperty(string propertyname, string value, int TimeOut = 0);

        [Description("Drag UIAScrollbar")]
        void Drag(int x = -1, int y = -1);

        [Description("Drop UIAScrollbar")]
        void Drop(int x = -1, int y = -1);

        string Name { [Description("Get the UI name of UIAScrollbar")]get; }

        int Hwnd { [Description("Get the handle of UIAScrollbar")] get; }

        int X { [Description("Get absolute location of X of UIAScrollbar")] get; }

        int Y { [Description("Get absolute location of Y of UIAScrollbar")] get; }

        int Height { [Description("Get Height of UIAScrollbar")] get; }

        int Width { [Description("Get Width of UIAScrollbar")] get; }

        bool Enabled { [Description("Get Enabled of UIAScrollbar")] get; }

        bool Focused { [Description("Get Focused of UIAScrollbar")] get; }

        string HelpText { [Description("Get Help Text of UIAScrollbar")] get; }

        string LabeledText { [Description("Get Labeled text of UIAScrollbar")] get; }

        string Value { [Description("Get Value of UIAScrollbar")] get; }

        int ProcessID { [Description("Get ProcessID of UIAScrollbar")] get; }

        [Description("Press one or more keystrokes, value can be \"Hi Ants Automation,{DELETE}\"")]
        void PressKeys(string keys);

        //For Scroll bar
        [Description("Scroll left button is minus, like \"-2\", Scroll right button is positive, like \"2\"")]
        void Set(int value);
    }

    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("240EA497-6490-47CC-8A11-1DCCC6F97E2F")]
    [ProgId("LeanPro.UIAScrollbar")]
    [TypeLibType((short)2)]
    [Description("Automation UIA Scrollbar")]
    public class UIAScrollBar : UIAContainerBase, IUIAScrollBar
    {
        public UIAScrollBar(UIACondition condition)
            : base(condition)
        { }

        public UIAScrollBar()
            : base()
        { }

        public void Set(int value)
        {
            this.PrepareForReplay();
            Condition button = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Button);         
            AutomationElement scrollbarobject = this._condition.AutomationElement ;
            AutomationElementCollection scrollcollection = null;
            if (scrollbarobject != null)
            {
                AutomationElement abutton = null;
                scrollcollection = scrollbarobject.FindAll(TreeScope.Children, button);

                if (value >= 0)
                {
                    abutton = scrollcollection[scrollcollection.Count - 1];
                }
                else
                {
                    abutton = scrollcollection[0];
                }

                int hwnd = abutton.Current.NativeWindowHandle;
                if (hwnd != 0)
                {
                    while (value != 0)
                    {
                        KeyInput.Click(KeyInput.MouseClickType.LClick, hwnd, 2, 2);
                        if (value < 0)
                            value++;
                        if (value > 0)
                            value--;
                    }
                }
                else
                {
                    try
                    {
                        Point p = new Point();
                        p.X = (int)abutton.Current.BoundingRectangle.Left + (int)((abutton.Current.BoundingRectangle.Right - abutton.Current.BoundingRectangle.Left) / 2);
                        p.Y = (int)abutton.Current.BoundingRectangle.Top + (int)((abutton.Current.BoundingRectangle.Bottom - abutton.Current.BoundingRectangle.Top) / 2);
                        while (value != 0)
                        {
                            KeyInput.Click(KeyInput.MouseClickType.LClick, p);
                            if (value < 0)
                                value++;
                            if (value > 0)
                                value--;
                        }
                        return;
                    }
                    catch { }

                    try
                    {
                        InvokePattern cinvoke = (InvokePattern)this._condition.AutomationElement.GetCurrentPattern(InvokePattern.Pattern);
                        while (value != 0)
                        {
                            cinvoke.Invoke();
                            if (value < 0)
                                value++;
                            if (value > 0)
                                value--;
                        }
                    }
                    catch
                    {

                    }
                }
            }
            else
                return;
        }
        
    }
}
