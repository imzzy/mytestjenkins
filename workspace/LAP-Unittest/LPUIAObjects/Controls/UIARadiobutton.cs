using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Windows.Automation;




namespace LPUIAObjects
{
    [Guid("54BC0AAB-F884-43CF-BA5B-1245D7E2A9FC")]
    public interface IUIARadioButton
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
  
        [Description("Click UIARadiobutton, MouseKey=1 is left button,\"2\" is right button, default is \"1\"")]
        void Click(int x = 0, int y = 0, int mousekey = 1);

        [Description("Double Click UIARadiobutton, MouseKey=1 is left button,\"2\" is right button, default is \"1\"")]
        void DBClick(int x = 0, int y = 0, int mousekey = 1);

        string Text { [Description("Get the UIARadiobutton test")] get; }

        [Description("Check whether UIARadiobutton exists, default value of times is \"0\"")]
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

        [Description("Drag UIARadiobutton")]
        void Drag(int x = -1, int y = -1);

        [Description("Drop UIARadiobutton")]
        void Drop(int x = -1, int y = -1);

        string Name { [Description("Get the UI name of UIARadiobutton")]get; }

        int Hwnd { [Description("Get the handle of UIARadiobutton")] get; }

        int X { [Description("Get absolute location of X of UIARadiobutton")] get; }

        int Y { [Description("Get absolute location of Y of UIARadiobutton")] get; }

        int Height { [Description("Get Height of UIARadiobutton")] get; }

        int Width { [Description("Get Width of UIARadiobutton")] get; }

        bool Enabled { [Description("Get Enabled of UIARadiobutton")] get; }

        bool Focused { [Description("Get Focused of UIARadiobutton")] get; }

        string HelpText { [Description("Get Help Text of UIARadiobutton")] get; }

        string LabeledText { [Description("Get Labeled text of UIARadiobutton")] get; }

        string Value { [Description("Get Value of UIARadiobutton")] get; }

        int ProcessID { [Description("Get ProcessID of UIARadiobutton")] get; }

        [Description("Press one or more keystrokes, value can be \"Hi Ants Automation,{DELETE}\"")]
        void PressKeys(string keys);

        // For Radiobutton methods
        [Description("Get the checked value: \"true\" is Checked, \"false\"is Unchecked")]
        bool Checked{get;}

        [Description("Set the checked value: \"true\" is Checked, \"false\" is Unchecked")]
        void Check(bool value);
    }       

    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("E4D11D7C-41BD-4E0B-848A-031C67B0A822")]
    [ProgId("LeanPro.UIARadiobutton")]
    [TypeLibType((short)2)]
    [Description("Automation UIA Radiobutton")]
    public class UIARadioButton : UIAContainerBase, IUIARadioButton
    {
        public UIARadioButton(UIACondition condition)
            : base(condition)
        { }

        public UIARadioButton()
            : base()
        { }

        public bool Checked
        {
            get
            {
                this.PrepareForReplay();
                try
                {
                    SelectionItemPattern itempattern = (SelectionItemPattern)this._condition.AutomationElement.GetCurrentPattern(SelectionItemPattern.Pattern);
                    if (itempattern.Current.IsSelected)
                        return true;
                    else
                        return false;
                }
                catch
                {
                    ControlSearcher.ThrowError(ErrorType.CannotPerformThisOperation);
                }
                return false;
            }
        }

        public void Check(bool value)
        {
            this.PrepareForReplay();
            try
            {
                SelectionItemPattern itempattern = (SelectionItemPattern)this._condition.AutomationElement.GetCurrentPattern(SelectionItemPattern.Pattern);
                bool v = false;
                if (value)
                    v = true;
                else
                    v = false;
                if (itempattern.Current.IsSelected != v)
                {
                    itempattern.Select();
                }
            }
            catch
            {
                ControlSearcher.ThrowError(ErrorType.CannotPerformThisOperation);
            }            
        }
    }
}
