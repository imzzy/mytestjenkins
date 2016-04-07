using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

using System.ComponentModel;



using System.Windows.Automation;

namespace LPUIAObjects
{
    [Guid("22A1BDE2-36B1-46A2-B2EC-9A978012DAA6")]
    public interface IUIAList
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

        [Description("Click UIAList, MouseKey=1 is left button,\"2\" is right button, default is \"1\"")]
        void Click(int x = 0, int y = 0, int mousekey = 1);

        [Description("Double Click UIAList, MouseKey=1 is left button,\"2\" is right button, default is \"1\"")]
        void DBClick(int x = 0, int y = 0, int mousekey = 1);

        string Text { [Description("Get the UIAList test")] get; }

        [Description("Check whether UIAList exists, default value of times is \"0\"")]
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

        [Description("Drag UIAList")]
        void Drag(int x = -1, int y = -1);

        [Description("Drop UIAList")]
        void Drop(int x = -1, int y = -1);

        string Name { [Description("Get the UI name of UIAList")]get; }

        int Hwnd { [Description("Get the handle of UIAList")] get; }

        int X { [Description("Get absolute location of X of UIAList")] get; }

        int Y { [Description("Get absolute location of Y of UIAList")] get; }

        int Height { [Description("Get Height of UIAList")] get; }

        int Width { [Description("Get Width of UIAList")] get; }

        bool Enabled { [Description("Get Enabled of UIAList")] get; }

        bool Focused { [Description("Get Focused of UIAList")] get; }

        string HelpText { [Description("Get Help Text of UIAList")] get; }

        string LabeledText { [Description("Get Labeled text of UIAList")] get; }

        string Value { [Description("Get Value of UIAList")] get; }

        int ProcessID { [Description("Get ProcessID of UIAList")] get; }

        [Description("Press one or more keystrokes, value can be \"Hi Ants Automation,{DELETE}\"")]
        void PressKeys(string keys);

        // For List
        [Description("Get item name in UIAList")]
        string GetItem(int itemindex);

        [Description("Get item count in UIAList")]
        int ItemCount { get; }

        [Description("Get selected item name in UIAList")]
        string SelectedItem { get; }

        [Description("Select item, item name can be item index like \"#3\", start from \"#0\", or item name")]
        void Select(string ItemName);

        [Description("Get the column count in list")]
        int ColumnCount { get; }

        [Description("Get the column name by index in list")]
        string GetColumnName(int columnindex);

        [Description("Get the item value in list, item can be item name or item index \"#3\", column can be column name or column index \"#3\", start from \"#0\"")]
        string GetColumnItemValue(string item, string column);

    }       

    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("929D4985-0A31-4046-BBB9-79D6C5D1CE4B")]
    [ProgId("LeanPro.UIAList")]
    [TypeLibType((short)2)]
    [Description("Automation UIA Checkbox")]
    public class UIAList : UIAContainerBase, IUIAList
    {
        public UIAList(UIACondition condition)
            : base(condition)
        { }

        public UIAList()
            : base()
        { }

        public string GetItem(int itemindex)
        {
            AutomationElementCollection child = _lists;
            if (child.Count<=itemindex)
                ControlSearcher.ThrowError(ErrorType.OutRange, "List Item index is out of range");
            return child[itemindex].Current.Name;
        }

        public int ItemCount
        {
            get
            {
                return _lists.Count;
            }
        }

        public string SelectedItem
        {
            get
            {
                UIAComboBox abox = new UIAComboBox(this._condition);
                return abox.SelectedItem;
            }
        }

        public void Select(string ItemName)
        {
            UIAComboBox abox = new UIAComboBox(this._condition);
            abox.Select(ItemName);            
        }

        public int ColumnCount
        {
            get
            {
                return _columns.Count;
            }
        }

        public string GetColumnName(int columnindex)
        { 
            AutomationElementCollection ca= _columns;
            if (ca.Count <= columnindex)
                ControlSearcher.ThrowError(ErrorType.OutRange);
            return ca[columnindex].Current.Name;
        }

        public string GetColumnItemValue(string item, string column)
        {
            AutomationElementCollection ca = _columns;
            AutomationElementCollection ia = _lists;

            int itemindex = -1, columnindex = -1;
            if (item.IndexOf('#') == 0)
            {
                itemindex = Convert.ToInt16(item.Substring(1));
                if (ia.Count<=itemindex)
                    ControlSearcher.ThrowError(ErrorType.OutRange, "List Item index is out of range");
            }
            else
            {
                for (int i = 0; i < ia.Count; i++)
                {
                    if (ia[i].Current.Name.Trim() == item.Trim())
                        itemindex = i;
                }
            }
            if (column.IndexOf('#') == 0)
            {
                columnindex = Convert.ToInt16(column.Substring(1));
                if (ca.Count<= columnindex)
                    ControlSearcher.ThrowError(ErrorType.OutRange, "Column Item index is not in the list");
            }
            else
            {
                for (int j = 0; j < ca.Count; j++)
                {
                    if (ca[j].Current.Name.Trim() == column.Trim())
                        columnindex = j;
                }
            }

            if (itemindex == -1)
                ControlSearcher.ThrowError(ErrorType.OutRange, "List Item is not in the list");
            if (columnindex ==-1)
                ControlSearcher.ThrowError(ErrorType.OutRange, "Column Item is not in the header");
            
            AutomationElement lelement = ia[itemindex];
            AutomationElementCollection childitem=lelement.FindAll(TreeScope.Children, TreeWalker.ControlViewWalker.Condition);
            if (childitem.Count<=columnindex)
                ControlSearcher.ThrowError(ErrorType.OutRange, "Column Item index is not in the list");
            try
            {
                return ((ValuePattern)childitem[columnindex].GetCurrentPattern(ValuePattern.Pattern)).Current.Value;
            }
            catch
            { }

            try
            {
                return ((TextPattern)childitem[columnindex].GetCurrentPattern(TextPattern.Pattern)).DocumentRange.GetText(-1);
            }
            catch
            { }

            return childitem[columnindex].Current.Name;
        }

        private AutomationElementCollection _columns
        {
            get
            {
                Condition rowheader = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Header);
                Condition rowheaderitem = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Header);
                // if there are more than one header, return these headers, if only one, check if this header contains other header items or controls.
                if (this._condition.AutomationElement.FindAll(TreeScope.Descendants, rowheader).Count == 1)
                {
                    AutomationElement header = this._condition.AutomationElement.FindFirst(TreeScope.Descendants, rowheader);
                    if (header.FindAll(TreeScope.Descendants, rowheaderitem).Count > 0)
                    {
                        return header.FindAll(TreeScope.Descendants, rowheaderitem);
                    }
                    else
                    {
                        //0x21 is the role of list
                        if ((int)header.GetCurrentPropertyValue(LegacyIAccessiblePattern.RoleProperty) == 0x21)
                        {
                            return header.FindAll(TreeScope.Children, TreeWalker.ControlViewWalker.Condition);
                        }                        
                    }
                }
                else
                {
                    return this._condition.AutomationElement.FindAll(TreeScope.Descendants, rowheader);
                }
                return null;
            }

        }

        private AutomationElementCollection _lists
        {
            get
            {
                Condition listCondtion = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.ListItem);
                return this._condition.AutomationElement.FindAll(TreeScope.Descendants, listCondtion);
            }
        }
    }
}
