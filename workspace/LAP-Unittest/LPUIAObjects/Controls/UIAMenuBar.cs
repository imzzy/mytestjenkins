using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

using System.ComponentModel;



using System.Windows.Automation;

namespace LPUIAObjects
{
    [Guid("D667DE57-197E-4B78-9DC3-01C4FC3571DE")]
    public interface IUIAMenuBar
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

        [Description("Click UIAMenuBar, MouseKey=1 is left button,\"2\" is right button, default is \"1\"")]
        void Click(int x = 0, int y = 0, int mousekey = 1);

        [Description("Double Click UIAMenuBar, MouseKey=1 is left button,\"2\" is right button, default is \"1\"")]
        void DBClick(int x = 0, int y = 0, int mousekey = 1);

        string Text { [Description("Get the UIAMenuBar test")] get; }

        [Description("Check whether UIAMenuBar exists, default value of times is \"0\"")]
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

        [Description("Drag UIAMenuBar")]
        void Drag(int x = -1, int y = -1);

        [Description("Drop UIAMenuBar")]
        void Drop(int x = -1, int y = -1);

        string Name { [Description("Get the UI name of UIAMenuBar")]get; }

        int Hwnd { [Description("Get the handle of UIAMenuBar")] get; }

        int X { [Description("Get absolute location of X of UIAMenuBar")] get; }

        int Y { [Description("Get absolute location of Y of UIAMenuBar")] get; }

        int Height { [Description("Get Height of UIAMenuBar")] get; }

        int Width { [Description("Get Width of UIAMenuBar")] get; }

        bool Enabled { [Description("Get Enabled of UIAMenuBar")] get; }

        bool Focused { [Description("Get Focused of UIAMenuBar")] get; }

        string HelpText { [Description("Get Help Text of UIAMenuBar")] get; }

        string LabeledText { [Description("Get Labeled text of UIAMenuBar")] get; }

        string Value { [Description("Get Value of UIAMenuBar")] get; }

        int ProcessID { [Description("Get ProcessID of UIAMenuBar")] get; }

        [Description("Press one or more keystrokes, value can be \"Hi Ants Automation,{DELETE}\"")]
        void PressKeys(string keys);

        //For MenuBar
        [Description("Get the menu item count")]
        int ItemCount { get; }

        [Description("Get the menu item name by index")]
        string ItemName(int index);

        [Description("Press the menu item by item name or item index \"#2\", index is start from \"#0\"")]
        void Press(string itemname);
    }       

    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("686B706C-8BC5-4608-A36A-075466EB0118")]
    [ProgId("LeanPro.UIAMenuBar")]
    [TypeLibType((short)2)]
    [Description("Automation UIA MenuBar")]
    public class UIAMenuBar : UIAContainerBase, IUIAMenuBar
    {
        public UIAMenuBar(UIACondition condition)
            : base(condition)
        { }

        public UIAMenuBar()
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
            AutomationElement menuitem = _getitem(itemname);
            try
            {
                UIAControlBase c = new UIAControlBase(new UIACondition(menuitem));                
                c.Click(3,3);
                return;
            }
            catch
            {
                ControlSearcher.ThrowError(ErrorType.CannotPerformThisOperation);
            }                        
        }

        public void OpenMenu(string itemname)
        {
            AutomationElement menuitem = _getitem(itemname);
            try
            {
                ExpandCollapsePattern mexpand = (ExpandCollapsePattern)menuitem.GetCurrentPattern(ExpandCollapsePattern.Pattern);
                mexpand.Expand();
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
                Condition allitems = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.MenuItem);
                return this._condition.AutomationElement.FindAll(TreeScope.Children, allitems);
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
                for (int i = 0; i < itemcollection.Count;i++ )
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
