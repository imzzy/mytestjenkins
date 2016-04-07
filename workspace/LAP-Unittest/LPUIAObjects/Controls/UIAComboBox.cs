using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows;
using System.ComponentModel;
using System.Threading;
using System.Windows.Automation;
using LPCommon;

namespace LPUIAObjects
{
    [Guid("48F32AD8-CEBF-41C7-B5CF-3B9B016C2D9D")]
    public interface IUIAComboBox
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

        [Description("Click UIAComboBox, MouseKey=1 is left button,\"2\" is right button, default is \"1\"")]
        void Click(int x = 0, int y = 0, int mousekey = 1);

        [Description("Double Click UIAComboBox, MouseKey=1 is left button,\"2\" is right button, default is \"1\"")]
        void DBClick(int x = 0, int y = 0, int mousekey = 1);

        string Text { [Description("Get the UIAComboBox test")] get; }

        [Description("Check whether UIAComboBox exists, default value of times is \"0\"")]
        bool Exist(int time = 0);

        [Description("Scroll left button is minus, like \"-2\", Scroll right button is positive, like \"2\"")]
        void HScroll(int value = 1);

        [Description("Scroll up button is minus, like \"-2\", Scroll down button is positive, like \"2\"")]
        void VScroll(int value = 1);

        [Description("Support value: title, name, text, hwnd, x, y, height, width, enabled, focused, helptext, labeledtext, processid")]
        string GetRoProperty(string propertyname);

        [Description("Support value: title, name, text, hwnd, x, y, height, width, enabled, focused, helptext, labeledtext, processid")]
        bool WaitProperty(string propertyname, string value, int TimeOut = 0);

        [Description("Drag UIAComboBox")]
        void Drag(int x = -1, int y = -1);

        [Description("Drop UIAComboBox")]
        void Drop(int x = -1, int y = -1);

        string Name { [Description("Get the UI name of UIAComboBox")]get; }

        int Hwnd { [Description("Get the handle of UIAComboBox")] get; }

        int X { [Description("Get absolute location of X of UIAComboBox")] get; }

        int Y { [Description("Get absolute location of Y of UIAComboBox")] get; }

        int Height { [Description("Get Height of UIAComboBox")] get; }

        int Width { [Description("Get Width of UIAComboBox")] get; }

        bool Enabled { [Description("Get Enabled of UIAComboBox")] get; }

        bool Focused { [Description("Get Focused of UIAComboBox")] get; }

        string HelpText { [Description("Get Help Text of UIAComboBox")] get; }

        string LabeledText { [Description("Get Labeled text of UIAComboBox")] get; }

        string Value { [Description("Get Value of UIAComboBox")] get; }

        int ProcessID { [Description("Get ProcessID of UIAComboBox")] get; }

        [Description("Press one or more keystrokes, value can be \"Hi Ants Automation,{DELETE}\"")]
        void PressKeys(string keys);

        [Description("Set the test object's search condition property")]
        void SetToProperty(string propertyname, string propertyvalue);

        // For ComboBox
        [Description("Get the item name by item index, start from \"0\" .")]
        string GetItem(int itemindex);

        [Description("Get the item count")]
        int ItemCount{get;}

        [Description("Get the selected item name")]
        string SelectedItem{get;}

        [Description("Select item, item name can be item index like \"#3\" start from \"#0\", or item name")]
        void Select(string ItemName);

        [Description("Dropdown the UIAComboBox")]
        void Open();
        
    }       

    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("9CB936C5-0314-4D45-AF50-C84DC454B2B0")]
    [ProgId("LeanPro.UIAComboBox")]
    [TypeLibType((short)2)]
    [Description("Automation UIA ComboBox")]
    public class UIAComboBox : UIAContainerBase, IUIAComboBox
    {
        public UIAComboBox(UIACondition condition)
            : base(condition)
        { }

        public UIAComboBox()
            : base()
        { }

        public string GetItem(int itemindex)
        {
            //this.PrepareForReplay();
            Open();
            try
            {
                Condition listCondtion = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.ListItem);
                AutomationElementCollection ac = this._condition.AutomationElement.FindAll(TreeScope.Descendants, listCondtion);                
                if (ac.Count - 1 < itemindex)
                {
                    ControlSearcher.ThrowError(ErrorType.OutRange);
                }
                else
                {
                    //check the name property is suit for selection value
                    if (ac.Count > 2)
                    {
                        // if all the value is the same to others, try to use the value and text pattern.
                        if (ac[0].Current.Name == ac[1].Current.Name)
                        {
                            try
                            {
                                TextPattern t = (TextPattern)ac[itemindex].GetCurrentPattern(TextPattern.Pattern);
                                if (t.DocumentRange.GetText(-1) != "")
                                    return t.DocumentRange.GetText(-1);
                            }
                            catch
                            { }

                            try
                            {
                                ValuePattern v = (ValuePattern)ac[itemindex].GetCurrentPattern(ValuePattern.Pattern);
                                if (v.Current.Value != "")
                                    return v.Current.Value;
                            }
                            catch
                            { }                            
                        }
                        return ac[itemindex].Current.Name;
                    }
                    else
                    {
                        return ac[itemindex].Current.Name;
                    }
                }
            }
            catch { }
            return "";
        }

        public int ItemCount
        {
            get
            {
                Open();
                try
                {
                    Condition listCondtion = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.ListItem);
                    AutomationElementCollection ac = this._condition.AutomationElement.FindAll(TreeScope.Descendants, listCondtion);   
                    return ac.Count;
                }
                catch { }
                return 0;
            }

        }

        public string SelectedItem
        {
            get
            {                
                Open();
                try
                {
                    List<AutomationElement> l = new List<AutomationElement>();
                    string allitems="";
                    SelectionPattern s = (SelectionPattern)this._condition.AutomationElement.GetCurrentPattern(SelectionPattern.Pattern);
                    if (s.Current.GetSelection().Length > 0)
                    {
                        if (s.Current.CanSelectMultiple)
                        {
                            for (int i = 0; i < s.Current.GetSelection().Length; i++)
                                l.Add(s.Current.GetSelection()[i]);
                        }
                        else
                        {
                            l.Add(s.Current.GetSelection()[0]);
                        }
                        if (l.Count==0)
                            return "";
                        // check if the name property is work for selection, or we can use value or text patter to check
                        Condition listCondtion = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.ListItem);
                        AutomationElementCollection ac = this._condition.AutomationElement.FindAll(TreeScope.Descendants, listCondtion);
                        if (ac.Count > 2)
                        {
                            if (ac[0].Current.Name == ac[1].Current.Name)
                            {
                                try
                                {                                    
                                    foreach(AutomationElement iuia in l)
                                    {
                                        TextPattern t = (TextPattern)iuia.GetCurrentPattern(TextPattern.Pattern);
                                        allitems = t.DocumentRange.GetText(-1) +";"+ allitems;
                                    }
                                    return allitems;
                                }
                                catch
                                { }

                                try
                                {
                                    foreach (AutomationElement iuia in l)
                                    {
                                        ValuePattern t = (ValuePattern)iuia.GetCurrentPattern(ValuePattern.Pattern);
                                        allitems = t.Current.Value + ";" + allitems;
                                    }
                                    return allitems;
                                }
                                catch
                                { }    
                            }
                            else
                            {
                                foreach (AutomationElement iuia in l)
                                {
                                    allitems = iuia .Current.Name+ ";" + allitems;
                                }
                                return allitems;
                            }
                        }
                        else
                        {
                            foreach (AutomationElement iuia in l)
                            {
                                allitems = iuia.Current.Name + ";" + allitems;
                            }
                            return allitems; 
                        }                        
                    }
                    else
                        return "";
                }
                catch
                {
                    Console.WriteLine("Not support Selection");
                }
                return "";
            }
        }

        public void Select(string ItemName)
        {            
            this.Open();
            int itemindex=-1;
            if (ItemName.IndexOf('#') == 0)
            {
                itemindex = Convert.ToInt16(ItemName.Substring(1));
            }
            Condition listCondtion = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.ListItem);
            AutomationElementCollection ac = this._condition.AutomationElement.FindAll(TreeScope.Descendants, listCondtion);   
            AutomationElement listitem = null;
            if (itemindex != -1)
            {
                if (ac.Count - 1 < itemindex)
                {
                    ControlSearcher.ThrowError(ErrorType.OutRange);
                }
                else
                {
                    listitem = ac[itemindex];
                }
            }
            else
            {
                for (int i = 0; i < ac.Count; i++)
                {
                    if (ac[i].Current.Name.Trim() == ItemName.Trim())
                    {
                        listitem = ac[i];
                    }
                }
                if (listitem == null)
                {
                    for (int i = 0; i < ac.Count; i++)
                    {
                        TextPattern t = (TextPattern)ac[i].GetCurrentPattern(TextPattern.Pattern);
                        if (t.DocumentRange.GetText(-1).Trim() == ItemName.Trim())
                        {
                            listitem = ac[i];
                        }
                    }
                }

                if (listitem == null)
                {
                    for (int i = 0; i < ac.Count; i++)
                    {
                        ValuePattern v = (ValuePattern)ac[i].GetCurrentPattern(ValuePattern.Pattern);
                        if (v.Current.Value.Trim() == ItemName.Trim())
                        {
                            listitem = ac[i];
                        }
                    }
                }
            }

            if (listitem != null)
            {                
                try
                {                    
                    SelectionItemPattern itempattern = (SelectionItemPattern)listitem.GetCurrentPattern(SelectionItemPattern.Pattern);
                    itempattern.Select();                    
                    if (_checkvalue(listitem.Current.Name))
                        return;
                }
                catch
                {
                }
                
                try
                {                    
                    if (listitem.Current.NativeWindowHandle != 0)
                    {
                        KeyInput.Click(KeyInput.MouseClickType.LClick, listitem.Current.NativeWindowHandle);
                        if (_checkvalue(listitem.Current.Name))
                            return;                        
                    }
                }
                catch
                { }

                try
                {
                    Point p = new Point((int)listitem.Current.BoundingRectangle.Left, (int)listitem.Current.BoundingRectangle.Top);
                    KeyInput.Click(KeyInput.MouseClickType.LClick, p);
                    if (_checkvalue(listitem.Current.Name))
                        return;                    
                }
                catch
                { }
                //ControlSearcher.ThrowError(ErrorType.CannotperforthisOperation);
            }
            else
            {
                ControlSearcher.ThrowError(ErrorType.NotItemExistinthelist);
            }           
        }

        public void Open()
        {
            this.PrepareForReplay();            

            try
            {
                ExpandCollapsePattern ep = (ExpandCollapsePattern)this._condition.AutomationElement.GetCurrentPattern(ExpandCollapsePattern.Pattern);
                if (ep.Current.ExpandCollapseState == ExpandCollapseState.Collapsed)
                {                    
                    ep.Expand();
                    Thread.Sleep(100);
                    ep.Expand();
                    Thread.Sleep(100);
                    ep.Expand();
                    Thread.Sleep(100);
                    ep.Expand();                    
                }                
                Thread.Sleep(700);
                return;
            }
            catch
            { }

            Condition listCondtion = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.ListItem);
            AutomationElementCollection ac = this._condition.AutomationElement.FindAll(TreeScope.Descendants, listCondtion);
            if (ac.Count > 0)
                return;

            try
            {
                Condition childbutton = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Button);
                ExpandCollapsePattern ep = (ExpandCollapsePattern)this._condition.AutomationElement.GetCurrentPattern(ExpandCollapsePattern.Pattern);
                if (ep.Current.ExpandCollapseState == ExpandCollapseState.Collapsed)
                    ((InvokePattern)this._condition.AutomationElement.FindFirst(TreeScope.Children, childbutton).GetCurrentPattern(InvokePattern.Pattern)).Invoke();
                Thread.Sleep(1000);
                return;
            }
            catch
            { }

            try
            {
                this.Click(2, 2);
            }
            catch
            { }
            
        }

        private bool _checkvalue(string value)
        {
            try
            {
                SelectionPattern s = (SelectionPattern)this._condition.AutomationElement.GetCurrentPattern(SelectionPattern.Pattern);
                if (s.Current.GetSelection()[0].Current.Name == value)
                    return true;
            }
            catch { }
            if (this.Text == value)
                return true;
            if (this.Value == value)
                return true;
            return false;
        }
               
    }
}
