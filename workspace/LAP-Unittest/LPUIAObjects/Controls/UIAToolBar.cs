using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Windows.Automation;

namespace LPUIAObjects
{
    [Guid("B3D4D86D-5639-4B9E-8C6F-640745EFC61D")]
    public interface IUIAToolBar
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

        [Description("Click UIAToolBar, MouseKey=1 is left button,\"2\" is right button, default is \"1\"")]
        void Click(int x = 0, int y = 0, int mousekey = 1);

        [Description("Double Click UIAToolBar, MouseKey=1 is left button,\"2\" is right button, default is \"1\"")]
        void DBClick(int x = 0, int y = 0, int mousekey = 1);

        string Text { [Description("Get the UIAToolBar test")] get; }

        [Description("Check whether UIAToolBar exists, default value of times is \"0\"")]
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

        [Description("Drag UIAToolBar")]
        void Drag(int x = -1, int y = -1);

        [Description("Drop UIAToolBar")]
        void Drop(int x = -1, int y = -1);

        string Name { [Description("Get the UI name of UIAToolBar")]get; }

        int Hwnd { [Description("Get the handle of UIAToolBar")] get; }

        int X { [Description("Get absolute location of X of UIAToolBar")] get; }

        int Y { [Description("Get absolute location of Y of UIAToolBar")] get; }

        int Height { [Description("Get Height of UIAToolBar")] get; }

        int Width { [Description("Get Width of UIAToolBar")] get; }

        bool Enabled { [Description("Get Enabled of UIAToolBar")] get; }

        bool Focused { [Description("Get Focused of UIAToolBar")] get; }

        string HelpText { [Description("Get Help Text of UIAToolBar")] get; }

        string LabeledText { [Description("Get Labeled text of UIAToolBar")] get; }

        string Value { [Description("Get Value of UIAToolBar")] get; }

        int ProcessID { [Description("Get ProcessID of UIAToolBar")] get; }

        [Description("Press one or more keystrokes, value can be \"Hi Ants Automation,{DELETE}\"")]
        void PressKeys(string keys);

        //For Tool Bar Methos and Properties
        [Description("Get item count of UIAToolBar")]
        int ItemCount { get; }

        [Description("Get item name by index of UIAToolBar")]
        string ItemName(int index);

        [Description("Press item by name or index \"#2\", index is start from \"#0\"")]
        void Press(string itemname);
                
    }       

    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("4D30C7CF-509C-4763-8874-6535F50CCC00")]
    [ProgId("LeanPro.UIAToolBar")]
    [TypeLibType((short)2)]
    [Description("Automation UIA ToolBar")]
    public class UIAToolBar : UIAContainerBase, IUIAToolBar
    {
        public UIAToolBar(UIACondition condition)
            : base(condition)
        { }

        public UIAToolBar()
            : base()
        { }

        public int ItemCount
        {
            get
            {
                this.PrepareForReplay();
                return this._allitems.Count;
            }
        }

        public string ItemName(int index)
        {
            this.PrepareForReplay();
            AutomationElementCollection ac = this._allitems;
            if (ac.Count - 1 < index)
                ControlSearcher.ThrowError(ErrorType.OutRange);
            else
                return ac[index].Current.Name;
            return "";
        }

        public void Press(string itemname)
        {
            AutomationElement toolitem = _getitem(itemname);
            try
            {
                UIAControlBase c = new UIAControlBase(new UIACondition(toolitem));                
                c.Click(3, 3);
                return;
            }
            catch
            {
                ControlSearcher.ThrowError(ErrorType.CannotPerformThisOperation);
            }
        }

        private AutomationElementCollection _allitems
        {
            get
            {
                return this._condition.AutomationElement.FindAll(TreeScope.Descendants, TreeWalker.ControlViewWalker.Condition);
            }
        }

        private AutomationElement _getitem(string itemname)
        {
            this.PrepareForReplay();
            int itemindex = -1;
            if (itemname.IndexOf('#') == 0)
            {
                itemindex = Convert.ToInt16(itemname.Substring(1));
            }

            AutomationElementCollection itemcollection = this._allitems;
            AutomationElement menuitem = null;
            if (itemindex != -1)
            {
                if (itemcollection.Count - 1 < itemindex)
                {
                    ControlSearcher.ThrowError(ErrorType.OutRange);
                }
                else
                {
                    menuitem = itemcollection[itemindex];
                }
            }
            else
            {
                for (int i = 0; i < itemcollection.Count; i++)
                {
                    if (itemcollection[i].Current.Name.Trim() == itemname.Trim())
                    {
                        menuitem = itemcollection[i];
                    }
                }

            }

            if (menuitem != null)
            {
                return menuitem;
            }
            else
            {
                ControlSearcher.ThrowError(ErrorType.NotItemExistinthelist);
            }
            return null;
        }

    }
}
