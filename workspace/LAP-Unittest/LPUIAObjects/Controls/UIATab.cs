using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.ComponentModel;




using System.Windows.Automation;

namespace LPUIAObjects
{
    [Guid("C77DD802-462E-4657-8405-63CA0E00DC59")]
    public interface IUIATab
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
  
        [Description("Click UIATab, MouseKey=1 is left button,\"2\" is right button, default is \"1\"")]
        void Click(int x = 0, int y = 0, int mousekey = 1);

        [Description("Double Click UIATab, MouseKey=1 is left button,\"2\" is right button, default is \"1\"")]
        void DBClick(int x = 0, int y = 0, int mousekey = 1);

        string Text { [Description("Get the UIATab test")] get; }

        [Description("Check whether UIATab exists, default value of times is \"0\"")]
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

        [Description("Drag UIATab")]
        void Drag(int x = -1, int y = -1);

        [Description("Drop UIATab")]
        void Drop(int x = -1, int y = -1);

        string Name { [Description("Get the UI name of UIATab")]get; }

        int Hwnd { [Description("Get the handle of UIATab")] get; }

        int X { [Description("Get absolute location of X of UIATab")] get; }

        int Y { [Description("Get absolute location of Y of UIATab")] get; }

        int Height { [Description("Get Height of UIATab")] get; }

        int Width { [Description("Get Width of UIATab")] get; }

        bool Enabled { [Description("Get Enabled of UIATab")] get; }

        bool Focused { [Description("Get Focused of UIATab")] get; }

        string HelpText { [Description("Get Help Text of UIATab")] get; }

        string LabeledText { [Description("Get Labeled text of UIATab")] get; }

        string Value { [Description("Get Value of UIATab")] get; }

        int ProcessID { [Description("Get ProcessID of UIATab")] get; }

        [Description("Press one or more keystrokes, value can be \"Hi Ants Automation,{DELETE}\"")]
        void PressKeys(string keys);

        //For Tab methods and properties
        [Description("Get tab item count of UIATab")]
        int ItemCount { get; }

        [Description("Get tab item name of UIATab by tab index")]
        string ItemName(int index);

        [Description("Get selected tab item name of UIATab")]
        string SelectedItem { get; }

        [Description("Select tab item by item name or item index \"#2\", index is start from \"#0\"")]
        void Select(string item);
    }       

    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("7834423E-39E0-4317-A2E2-EF38C030F59C")]
    [ProgId("LeanPro.UIATab")]
    [TypeLibType((short)2)]
    [Description("Automation UIA Tab")]
    public class UIATab : UIAContainerBase, IUIATab
    {
        public UIATab(UIACondition condition)
            : base(condition)
        { }

        public UIATab()
            : base()
        { }

        public int ItemCount 
        {
            get 
            {
                this.PrepareForReplay();
                try
                {
                    return _childs.Count;
                }
                catch
                {
                    ControlSearcher.ThrowError(ErrorType.CannotPerformThisOperation);   
                }
                return 0;
            }
        }

        public string ItemName(int index)
        {
            this.PrepareForReplay();
            try
            {
                AutomationElementCollection ac = _childs;
                if (ac.Count - 1 < index)
                {
                    ControlSearcher.ThrowError(ErrorType.OutRange);
                }
                else
                {
                    return ac[index].Current.Name;
                }
            }
            catch { }
            return "";
        }

        public string SelectedItem
        {
            get 
            {
                this.PrepareForReplay();
                try
                {
                    SelectionPattern s = (SelectionPattern)this._condition.AutomationElement.GetCurrentPattern(SelectionPattern.Pattern);
                    return s.Current.GetSelection()[0].Current.Name;
                }
                catch
                { }

                try
                {
                    AutomationElementCollection ic = _childs;
                    foreach (AutomationElement element in _childs)
                    {
                        SelectionItemPattern pattern = (SelectionItemPattern)element.GetCurrentPattern(SelectionItemPattern.Pattern);

                        if (pattern.Current.IsSelected)
                            return element.Current.Name;                      
                    }
                }
                catch
                {
                    ControlSearcher.ThrowError(ErrorType.CannotPerformThisOperation);
                }
                return "";
            }
        }

        public void Select(string item)
        {
            this.PrepareForReplay();
            int itemindex = -1;
            AutomationElementCollection alllabitem = this._childs;
            SelectionItemPattern labitempattern = null;
            if (item.IndexOf('#') == 0)
            {
                itemindex = Convert.ToInt16(item.Substring(1));
                if (alllabitem.Count - 1 < itemindex)
                {
                    ControlSearcher.ThrowError(ErrorType.OutRange);
                }
                else
                {
                    labitempattern = (SelectionItemPattern)alllabitem[itemindex].GetCurrentPattern(SelectionItemPattern.Pattern);
                    labitempattern.Select();
                    return;
                }
            }
            else
            {
                for (int i = 0; i < alllabitem.Count; i++)
                {
                    if (alllabitem[i].Current.Name.Trim() == item)
                    {
                        labitempattern = (SelectionItemPattern)alllabitem[i].GetCurrentPattern(SelectionItemPattern.Pattern);
                        labitempattern.Select();
                        return;
                    }
                }
            }
            ControlSearcher.ThrowError(ErrorType.NotItemExistinthelist);
        }

        private  AutomationElementCollection _childs
        {
            get
            {
                Condition itemcondtion = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.TabItem);
                return this._condition.AutomationElement.FindAll(TreeScope.Children, itemcondtion);                
            }
        }

        
    }
}
