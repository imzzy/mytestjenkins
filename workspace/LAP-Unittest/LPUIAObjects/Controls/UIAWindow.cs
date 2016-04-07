using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.ComponentModel;
using LPReplayCore;
using LPCommon;

namespace LPUIAObjects
{

    [Guid("04191845-1D29-4BD3-B3DE-4507AF273451"),InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IUIAWindow
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

        /// <summary>
        /// Ants Control Methods interface
        /// </summary>

        [Description("Click UIAWindow, MouseKey=1 is left button,\"2\" is right button, default is \"1\"")]
        void Click(int x = 0, int y = 0, int mousekey = 1);

        [Description("Double Click UIAWindow, MouseKey=1 is left button,\"2\" is right button, default is \"1\"")]
        void DBClick(int x = 0, int y = 0, int mousekey = 1);

        string Text { [Description("Get the UIAWindow test")] get; }

        [Description("Check whether UIAWindow exists, default value of times is \"0\"")]
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

        [Description("Drag UIAWindow")]
        void Drag(int x = -1, int y = -1);

        [Description("Drop UIAWindow")]
        void Drop(int x = -1, int y = -1);

        string Name { [Description("Get the UI name of UIAWindow")]get; }

        int Hwnd { [Description("Get the handle of UIAWindow")] get; }

        int X { [Description("Get absolute location of X of UIAWindow")] get; }

        int Y { [Description("Get absolute location of Y of UIAWindow")] get; }

        int Height { [Description("Get Height of UIAWindow")] get; }

        int Width { [Description("Get Width of UIAWindow")] get; }

        bool Enabled { [Description("Get Enabled of UIAWindow")] get; }

        bool Focused { [Description("Get Focused of UIAWindow")] get; }

        string HelpText { [Description("Get Help Text of UIAWindow")] get; }

        string LabeledText { [Description("Get Labeled text of UIAWindow")] get; }

        string Value { [Description("Get Value of UIAWindow")] get; }

        int ProcessID { [Description("Get ProcessID of UIAWindow")] get; }

        [Description("Press one or more keystrokes, value can be \"Hi Ants Automation,{DELETE}\"")]
        void PressKeys(string keys);

        // Ants Window Methods interface
        [Description("Activates the window.")]
        void Active();

        [Description("Maximizes the window to fill the entire screen.")]
        void Maximize();

        [Description("Minimizes the window to an icon.")]
        void Minimize();

        [Description("Restores the window to its previous size.")]
        void Restore();
        
    }       

    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("53C2A3E5-436D-4492-93E3-23BA5E1FCC16")]
    [ProgId("LeanPro.UIAWindow")]
    [TypeLibType((short)2)]
    [Description("Automation UIA Window")]
    public class UIAWindow : UIAContainerBase, IUIAWindow
    {
        public UIAWindow(string conditionString)
            : base(conditionString)
        {
        }

        public UIAWindow(UIACondition condition)
            : base(condition)
        { }

        public UIAWindow()
            : base()
        { }

        public void Active()
        {            
            this.PrepareForReplay();            
            try
            {                
                int hwnd = this._condition.AutomationElement.Current.NativeWindowHandle;
                SafeNativeMethods.ShowWindow((IntPtr)hwnd, NativeMethods.SW_RESTORE);
            }
            catch
            {
                ControlSearcher.ThrowError(ErrorType.ObjectNotExist);
            }
        }

        public void Maximize()
        {
            this.PrepareForReplay();            
            try
            {
                int hwnd = this._condition.AutomationElement.Current.NativeWindowHandle;
               SafeNativeMethods.ShowWindow((IntPtr)hwnd,NativeMethods.SW_SHOWMAXIMIZED);
            }
            catch
            {
                ControlSearcher.ThrowError(ErrorType.ObjectNotExist);
            }
        }

        public void Minimize()
        {
            this.PrepareForReplay();            
            try
            {
                int hwnd = this._condition.AutomationElement.Current.NativeWindowHandle;
               SafeNativeMethods.ShowWindow((IntPtr)hwnd,NativeMethods.SW_SHOWMINIMIZED);
            }
            catch
            {
                ControlSearcher.ThrowError(ErrorType.ObjectNotExist);
            }
        }

        public void Restore()
        {
            this.PrepareForReplay();            
            try
            {
                int hwnd = this._condition.AutomationElement.Current.NativeWindowHandle;
               SafeNativeMethods.ShowWindow((IntPtr)hwnd, NativeMethods.SW_RESTORE);
            }
            catch
            {
                ControlSearcher.ThrowError(ErrorType.ObjectNotExist);
            }
        }
    }
}
