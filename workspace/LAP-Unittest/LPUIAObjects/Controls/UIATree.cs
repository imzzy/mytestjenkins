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
    [Guid("B822188B-C8D1-4B68-ABE0-67ECD9F4184F")]
    public interface IUIATree
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

        [Description("Click UIATree, MouseKey=1 is left button,\"2\" is right button, default is \"1\"")]
        void Click(int x = 0, int y = 0, int mousekey = 1);

        [Description("Double Click UIATree, MouseKey=1 is left button,\"2\" is right button, default is \"1\"")]
        void DBClick(int x = 0, int y = 0, int mousekey = 1);

        string Text { [Description("Get the UIATree test")] get; }

        [Description("Check whether UIATree exists, default value of times is \"0\"")]
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

        [Description("Drag UIATree")]
        void Drag(int x = -1, int y = -1);

        [Description("Drop UIATree")]
        void Drop(int x = -1, int y = -1);

        string Name { [Description("Get the UI name of UIATree")]get; }

        int Hwnd { [Description("Get the handle of UIATree")] get; }

        int X { [Description("Get absolute location of X of UIATree")] get; }

        int Y { [Description("Get absolute location of Y of UIATree")] get; }

        int Height { [Description("Get Height of UIATree")] get; }

        int Width { [Description("Get Width of UIATree")] get; }

        bool Enabled { [Description("Get Enabled of UIATree")] get; }

        bool Focused { [Description("Get Focused of UIATree")] get; }

        string HelpText { [Description("Get Help Text of UIATree")] get; }

        string LabeledText { [Description("Get Labeled text of UIATree")] get; }

        string Value { [Description("Get Value of UIATree")] get; }

        int ProcessID { [Description("Get ProcessID of UIATree")] get; }

        [Description("Press one or more keystrokes, value can be \"Hi Ants Automation,{DELETE}\"")]
        void PressKeys(string keys);

        //For Tree Object
        [Description("Get the tree node count by full tree path, path name can be index or name, \"Root;#3;File\", default value is \"\", root of tree")]
        int GetTreeNodeCount(string treepath="");

        [Description("Get the tree node text by full tree path, path name can be index or name, \"Root;#3;File\"")]
        string GetTreeNodeText(string treepath);

        [Description("Select the tree node by full tree path, path name can be index or name, \"Root;#3;File\"")]
        void SelectTreeNode(string treepath);

        [Description("Double click the tree node by full tree path, path name can be index or name, \"Root;#3;File\"")]
        void DBClickTreeNode(string treepath);

        [Description("Expand the tree node by full tree path, path name can be index or name, \"Root;#3;File\"")]
        void ExpandTreeNode(string treepath);

        [Description("Collapse the tree node by full tree path, path name can be index or name, \"Root;#3;File\"")]
        void CollapseTreeNode(string treepath);

        [Description("Get the tree node status by full tree path, path name can be index or name, \"Root;#3;File\", the return value is boolen, checked or unchecked")]
        bool GetItemCheckedStatus(string treepath);

        [Description("Set the tree node status by full tree path, path name can be index or name, \"Root;#3;File\"")]
        void SetItemCheckedStatus(string treepath, bool Checked);
    }       

    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("44DE59D5-FE83-475B-8342-C541006DB504")]
    [ProgId("LeanPro.UIATree")]
    [TypeLibType((short)2)]
    [Description("Automation UIA Tree")]
    public class UIATree : UIAContainerBase, IUIATree
    {
        public UIATree(UIACondition condition)
            : base(condition)
        { }

        public UIATree()
            : base()
        { }

        public int GetTreeNodeCount(string treepath = "")
        {
            if (treepath == "")
                return _items(this._condition.AutomationElement).Count;
            else
                return _items(_openitem(this._condition.AutomationElement, treepath, false)).Count;

        }

        public string GetTreeNodeText(string treepath)
        {
            return _openitem(this._condition.AutomationElement, treepath, false).Current.Name;
        }

        public void SelectTreeNode(string treepath)
        {
            _openitem(this._condition.AutomationElement, treepath, true);
        }

        public void DBClickTreeNode(string treepath)
        {          
            KeyInput.Click(KeyInput.MouseClickType.LDClick, _openitem(this._condition.AutomationElement, treepath, false));            
        }

        public void ExpandTreeNode(string treepath)
        {
            AutomationElement e = _openitem(this._condition.AutomationElement, treepath, false);
            try
            {
                ExpandCollapsePattern mexpand = (ExpandCollapsePattern)e.GetCurrentPattern(ExpandCollapsePattern.Pattern);
                mexpand.Expand();                
            }
            catch
            {
                ControlSearcher.ThrowError(ErrorType.CannotPerformThisOperation);
            }
        }

        public void CollapseTreeNode(string treepath)
        {
            AutomationElement e = _openitem(this._condition.AutomationElement, treepath, false);
            try
            {
                ExpandCollapsePattern mexpand = (ExpandCollapsePattern)e.GetCurrentPattern(ExpandCollapsePattern.Pattern);
                mexpand.Collapse();
            }
            catch
            {
                ControlSearcher.ThrowError(ErrorType.CannotPerformThisOperation);
            }
        }

        public bool GetItemCheckedStatus(string treepath)
        {
            AutomationElement e = _openitem(this._condition.AutomationElement, treepath, false);
            try
            {
                TogglePattern mexpand = (TogglePattern)e.GetCurrentPattern(TogglePattern.Pattern);
                if (mexpand.Current.ToggleState == ToggleState.On)
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

        public void SetItemCheckedStatus(string treepath, bool Checked)
        {
            AutomationElement e = _openitem(this._condition.AutomationElement, treepath, false);
            try
            {
                TogglePattern mexpand = (TogglePattern)e.GetCurrentPattern(TogglePattern.Pattern);
                if (Checked && mexpand.Current.ToggleState == ToggleState.Off)
                    mexpand.Toggle();
                else if (! Checked && mexpand.Current.ToggleState == ToggleState.On)
                    mexpand.Toggle();
            }
            catch
            {
                ControlSearcher.ThrowError(ErrorType.CannotPerformThisOperation);
            }
        }

        private AutomationElementCollection _items(AutomationElement e)
        {
            Condition treeitemcondition = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.TreeItem);            
            return e.FindAll(TreeScope.Children, treeitemcondition);
        }

        private AutomationElement _openitem(AutomationElement parentitem, string treepath, bool openlastone = false)
        { 
            string[] path = treepath.Split(';');
            if (parentitem == null)
            {
                ControlSearcher.ThrowError(ErrorType.ObjectIsOutOfScreen, treepath);
                return null;
            }
            AutomationElementCollection allitems = this._items(parentitem);
            AutomationElement treeNodeItemObject = null;
            if (path.Length != 0)
            {                 
                if (path[0].IndexOf('#') == 0)
                {
                    int treenodeindex=-1;
                    treenodeindex = Convert.ToInt16(path[0].Substring(1));
                    if (allitems.Count - 1 < treenodeindex)
                    {
                        ControlSearcher.ThrowError(ErrorType.OutRange, "Value: " + treenodeindex.ToString());
                    }
                    else
                    {
                        treeNodeItemObject = allitems[treenodeindex];
                    }
                }
                else
                {
                    for (int i = 0; i < allitems.Count; i++)
                    {
                        if (allitems[i].Current.Name.Trim() == path[0].Trim())
                            treeNodeItemObject = allitems[i]; 
                    }
                }
                if (treeNodeItemObject == null)
                    ControlSearcher.ThrowError(ErrorType.NotItemExistinthelist, "Value: " + path[0].ToString());
                else
                {
                    if ((openlastone && path.Length == 1) || (path.Length > 1))
                    {
                        try
                        {
                            ExpandCollapsePattern mexpand = (ExpandCollapsePattern)treeNodeItemObject.GetCurrentPattern(ExpandCollapsePattern.Pattern);
                            mexpand.Expand();
                        }
                        catch
                        {
                            try
                            {
                                Point p = new Point((int)treeNodeItemObject.Current.BoundingRectangle.Left, (int)treeNodeItemObject.Current.BoundingRectangle.Top);
                                KeyInput.Click(KeyInput.MouseClickType.LClick, p);
                            }
                            catch
                            {
                                ControlSearcher.ThrowError(ErrorType.CannotPerformThisOperation, "Value: " + path[0].ToString());
                            }
                        }

                        if (path.Length > 1)
                        {
                            treepath = treepath.Substring(path[0].Length + 1);
                            return _openitem(treeNodeItemObject, treepath, openlastone);
                        }
                        else
                            return treeNodeItemObject;
                    }
                    else
                        return treeNodeItemObject;                    

                }
            }
            return null;                    
        }
    }
}
