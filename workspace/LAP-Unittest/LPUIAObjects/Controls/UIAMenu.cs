using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Windows;
using System.Threading;
using System.Windows.Automation;
using LPCommon;

namespace LPUIAObjects
{
    [Guid("164F7275-307D-426F-B076-6E2B6E3648CB")]
    public interface IUIAMenu
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

        [Description("Click UIAMenu, MouseKey=1 is left button,\"2\" is right button, default is \"1\"")]
        void Click(int x = 0, int y = 0, int mousekey = 1);

        [Description("Double Click UIAMenu, MouseKey=1 is left button,\"2\" is right button, default is \"1\"")]
        void DBClick(int x = 0, int y = 0, int mousekey = 1);

        string Text { [Description("Get the UIAMenu test")] get; }

        [Description("Check whether UIAMenu exists, default value of times is \"0\"")]
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

        [Description("Drag UIAMenu")]
        void Drag(int x = -1, int y = -1);

        [Description("Drop UIAMenu")]
        void Drop(int x = -1, int y = -1);

        string Name { [Description("Get the UI name of UIAMenu")]get; }

        int Hwnd { [Description("Get the handle of UIAMenu")] get; }

        int X { [Description("Get absolute location of X of UIAMenu")] get; }

        int Y { [Description("Get absolute location of Y of UIAMenu")] get; }

        int Height { [Description("Get Height of UIAMenu")] get; }

        int Width { [Description("Get Width of UIAMenu")] get; }

        bool Enabled { [Description("Get Enabled of UIAMenu")] get; }

        bool Focused { [Description("Get Focused of UIAMenu")] get; }

        string HelpText { [Description("Get Help Text of UIAMenu")] get; }

        string LabeledText { [Description("Get Labeled text of UIAMenu")] get; }

        string Value { [Description("Get Value of UIAMenu")] get; }

        int ProcessID { [Description("Get ProcessID of UIAMenu")] get; }

        [Description("Press one or more keystrokes, value can be \"Hi Ants Automation,{DELETE}\"")]
        void PressKeys(string keys);

        //For Menu    
        [Description("Get Menu item count by full menu path, it can be Menu Name or index, \"File;#3;Save as;#2\" , index is start from \"#0\"")]
        int ItemCount(string MenuPath);

        [Description("Get Menu item name by full menu path, it can be Menu Name or index, \"File;#3;Save as;#2\", index is start from \"#0\"")]
        string ItemName(string MenuPath);

        [Description("Select Menu item by full menu path, it can be Menu Name or index, \"File;#3;Save as;#2\", index is start from \"#0\"")]
        void Select(string MenuPath);
    }       

    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("4EFD964A-438F-47ED-B62D-E8259B6A3A00")]
    [ProgId("LeanPro.UIAMenu")]
    [TypeLibType((short)2)]
    [Description("Automation UIA Menu")]
    public class UIAMenu : UIAContainerBase, IUIAMenu
    {
        public UIAMenu(UIACondition condition)
            : base(condition)
        { }

        public UIAMenu()
            : base()
        { }

        public int ItemCount(string MenuPath="")
        {            
            if (MenuPath == "")
                return this._getchilds(this._condition.AutomationElement).Count;
            else
                return _getchilds(_getmenuitembypath(this._condition.AutomationElement, MenuPath, true)).Count;

        }

        public string ItemName(string MenuPath)
        {            
            return _getmenuitembypath(this._condition.AutomationElement, MenuPath).Current.Name;

        }

        public void Select(string MenuPath)
        {
            AutomationElement curentmenuitem = _getmenuitembypath(this._condition.AutomationElement, MenuPath);
            if (curentmenuitem == null)
                ControlSearcher.ThrowError(ErrorType.NotItemExistinthelist);
            else
            {
                try
                {
                    ExpandCollapsePattern mexpand = (ExpandCollapsePattern)curentmenuitem.GetCurrentPattern(ExpandCollapsePattern.Pattern);
                    mexpand.Expand();
                }
                catch
                {                    
                    try
                    {
                        Point p = new Point(curentmenuitem.Current.BoundingRectangle.Left, curentmenuitem.Current.BoundingRectangle.Top);
                        KeyInput.Click(KeyInput.MouseClickType.LClick, p);
                    }
                    catch
                    {
                        ControlSearcher.ThrowError(ErrorType.CannotPerformThisOperation);
                    }
                }
            }
        }

        private AutomationElementCollection _getchilds(AutomationElement a)
        {
            Condition menuitemcondtion = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.MenuItem);            
            AutomationElementCollection allitems=a.FindAll(TreeScope.Children, menuitemcondtion);            
            if (allitems==null || allitems.Count == 0)
            {
                Condition menuname = new PropertyCondition(AutomationElement.NameProperty, a.Current.Name);
                Condition menuprocessid = new PropertyCondition(AutomationElement.ProcessIdProperty, a.Current.ProcessId);
                Condition menutypecondtion = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.MenuItem);
                Condition andcondition = new AndCondition(new Condition[] { menutypecondtion, menuname, menuprocessid });
                try
                {
                    AutomationElement menuobject = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, andcondition);
                    if (menuobject != null)
                    {
                        allitems = menuobject.FindAll(TreeScope.Children, menuitemcondtion);
                    }
                }
                catch { }
            }
            return allitems;                
        }

        private AutomationElement _getmenuitembypath(AutomationElement parentitem, string menupath, bool openlastone = false)
        {
            string[] path = menupath.Split(';');
            if (parentitem == null)
            {
                ControlSearcher.ThrowError(ErrorType.ObjectIsOutOfScreen, menupath);
                return null;
            }
            AutomationElementCollection allItems = this._getchilds(parentitem);
            AutomationElement curentMenuItem = null;
            if (path.Length != 0)
            {                 
                if (path[0].IndexOf('#') == 0)
                {
                    int menuindex=-1;
                    menuindex = Convert.ToInt16(path[0].Substring(1));
                    if (allItems.Count - 1 < menuindex)
                    {
                        ControlSearcher.ThrowError(ErrorType.OutRange, "Value: " + menuindex.ToString());
                    }
                    else
                    {
                        curentMenuItem = allItems[menuindex];
                    }
                }
                else
                {                    
                    for (int i = 0; i < allItems.Count;i++ )                        
                    {
                        if (allItems[i].Current.Name.Trim() == path[0].Trim())
                            curentMenuItem = allItems[i];
                    }
                }
                if (curentMenuItem == null)
                    ControlSearcher.ThrowError(ErrorType.NotItemExistinthelist, "Value: " + path[0].ToString());
                else
                {
                    if ((openlastone && path.Length == 1) || (path.Length > 1))
                    {
                        try
                        {                            
                            ExpandCollapsePattern mexpand = (ExpandCollapsePattern)curentMenuItem.GetCurrentPattern(ExpandCollapsePattern.Pattern);
                            mexpand.Expand();
                            Thread.Sleep(300);
                            mexpand.Expand();
                            Thread.Sleep(300);                            
                            
                            if (mexpand.Current.ExpandCollapseState == ExpandCollapseState.Collapsed)
                            {
                                try
                                {
                                    Point p = new Point((int)curentMenuItem.Current.BoundingRectangle.Left, (int)curentMenuItem.Current.BoundingRectangle.Top);
                                    KeyInput.Click(KeyInput.MouseClickType.LClick, p);
                                }
                                catch
                                {
                                    ControlSearcher.ThrowError(ErrorType.CannotPerformThisOperation, "Value: " + path[0].ToString());
                                }
                            }
                        }
                        catch
                        {
                            try
                            {
                                Point p = new Point((int)curentMenuItem.Current.BoundingRectangle.Left, (int)curentMenuItem.Current.BoundingRectangle.Top);
                                KeyInput.Click(KeyInput.MouseClickType.LClick, p);
                            }
                            catch
                            {
                                ControlSearcher.ThrowError(ErrorType.CannotPerformThisOperation, "Value: " + path[0].ToString());
                            }
                        }

                        if (path.Length > 1)
                        {
                            menupath = menupath.Substring(path[0].Length + 1);
                            return _getmenuitembypath(curentMenuItem, menupath, openlastone);
                        }
                        else
                            return curentMenuItem;
                    }
                    else
                        return curentMenuItem;                    

                }
            }
            return null;
            
        }

    }
}
