using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Windows.Automation;





namespace LPUIAObjects
{
    [Guid("31EB2B98-678A-49F3-9AD7-AB8AF4455A4B")]
    public interface IUIASlider
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
  
        [Description("Click UIASlider, MouseKey=1 is left button,\"2\" is right button, default is \"1\"")]
        void Click(int x = 0, int y = 0, int mousekey = 1);

        [Description("Double Click UIASlider, MouseKey=1 is left button,\"2\" is right button, default is \"1\"")]
        void DBClick(int x = 0, int y = 0, int mousekey = 1);

        string Text { [Description("Get the UIASlider test")] get; }

        [Description("Check whether UIASlider exists, default value of times is \"0\"")]
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

        [Description("Drag UIASlider")]
        void Drag(int x = -1, int y = -1);

        [Description("Drop UIASlider")]
        void Drop(int x = -1, int y = -1);

        string Name { [Description("Get the UI name of UIASlider")]get; }

        int Hwnd { [Description("Get the handle of UIASlider")] get; }

        int X { [Description("Get absolute location of X of UIASlider")] get; }

        int Y { [Description("Get absolute location of Y of UIASlider")] get; }

        int Height { [Description("Get Height of UIASlider")] get; }

        int Width { [Description("Get Width of UIASlider")] get; }

        bool Enabled { [Description("Get Enabled of UIASlider")] get; }

        bool Focused { [Description("Get Focused of UIASlider")] get; }

        string HelpText { [Description("Get Help Text of UIASlider")] get; }

        string LabeledText { [Description("Get Labeled text of UIASlider")] get; }

        string Value { [Description("Get Value of UIASlider")] get; }

        int ProcessID { [Description("Get ProcessID of UIASlider")] get; }

        [Description("Press one or more keystrokes, value can be \"Hi Ants Automation,{DELETE}\"")]
        void PressKeys(string keys);

        //for Slider 
        [Description("Get Maximum value of UIASlider")]
        int Maximum { get; }

        [Description("Get Minimum value of UIASlider")]
        int Minimum { get; }

        [Description("Get ReadOnly value of UIASlider")]
        bool ReadOnly { get; }

        [Description("Set the value of UIASlider")]
        void Set(string value);

    }       

    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("43A46967-AEEA-4568-8C08-98335DAE23F3")]
    [ProgId("LeanPro.UIASlider")]
    [TypeLibType((short)2)]
    [Description("Automation UIA Slider")]
    public class UIASlider : UIAContainerBase, IUIASlider
    {
        public UIASlider(UIACondition condition)
            : base(condition)
        { }

        public UIASlider()
            : base()
        { }

        public int Maximum
        {
            get
            {
                this.PrepareForReplay();
                try
                {
                    RangeValuePattern v = (RangeValuePattern)this._condition.AutomationElement.GetCurrentPattern(RangeValuePattern.Pattern);
                    return Convert.ToInt16(v.Current.Maximum);
                }
                catch
                {
                    ControlSearcher.ThrowError(ErrorType.CannotPerformThisOperation);
                }

                return 0;
            }
        }

        public int Minimum
        {
            get
            {
                this.PrepareForReplay();
                try
                {
                    RangeValuePattern v = (RangeValuePattern)this._condition.AutomationElement.GetCurrentPattern(RangeValuePattern.Pattern);
                    return Convert.ToInt16(v.Current.Minimum);
                }
                catch
                {
                    ControlSearcher.ThrowError(ErrorType.CannotPerformThisOperation);
                }
                return 0;
            }
        }

        public new bool ReadOnly
        {
            get
            {
                this.PrepareForReplay();
                try
                {
                    RangeValuePattern v = (RangeValuePattern)this._condition.AutomationElement.GetCurrentPattern(RangeValuePattern.Pattern);
                    return (v.Current.IsReadOnly);
                }
                catch
                { }

                try
                {
                    ValuePattern v = (ValuePattern)this._condition.AutomationElement.GetCurrentPattern(ValuePattern.Pattern);
                    return (v.Current.IsReadOnly);
                }
                catch
                {
                    ControlSearcher.ThrowError(ErrorType.CannotPerformThisOperation);
                }

                return false;
            }
        }

        public new void Set(string value)
        {
            this.PrepareForReplay();
            try
            {
                RangeValuePattern v = (RangeValuePattern)this._condition.AutomationElement.GetCurrentPattern(RangeValuePattern.Pattern);
                v.SetValue(Convert.ToDouble(value));
            }
            catch
            {
                
            }

            try
            {
                ValuePattern v = (ValuePattern)this._condition.AutomationElement.GetCurrentPattern(ValuePattern.Pattern);
                v.SetValue(value);
            }
            catch
            {
                ControlSearcher.ThrowError(ErrorType.CannotPerformThisOperation);
            }

        }
    }
}
