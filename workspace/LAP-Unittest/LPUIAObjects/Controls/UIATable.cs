using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.ComponentModel;
using LPCommon;




using System.Windows.Automation;

namespace LPUIAObjects
{

    [Guid("79957753-9E0C-4B3F-8902-0EF3C7B323A7")]
    public interface IUIATable
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

        [Description("Click UIATable, MouseKey=1 is left button,\"2\" is right button, default is \"1\"")]
        void Click(int x = 0, int y = 0, int mousekey = 1);

        [Description("Double Click UIATable, MouseKey=1 is left button,\"2\" is right button, default is \"1\"")]
        void DBClick(int x = 0, int y = 0, int mousekey = 1);

        string Text { [Description("Get the UIATable test")] get; }

        [Description("Check whether UIATable exists, default value of times is \"0\"")]
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

        [Description("Drag UIATable")]
        void Drag(int x = -1, int y = -1);

        [Description("Drop UIATable")]
        void Drop(int x = -1, int y = -1);

        string Name { [Description("Get the UI name of UIATable")]get; }

        int Hwnd { [Description("Get the handle of UIATable")] get; }

        int X { [Description("Get absolute location of X of UIATable")] get; }

        int Y { [Description("Get absolute location of Y of UIATable")] get; }

        int Height { [Description("Get Height of UIATable")] get; }

        int Width { [Description("Get Width of UIATable")] get; }

        bool Enabled { [Description("Get Enabled of UIATable")] get; }

        bool Focused { [Description("Get Focused of UIATable")] get; }

        string HelpText { [Description("Get Help Text of UIATable")] get; }

        string LabeledText { [Description("Get Labeled text of UIATable")] get; }

        string Value { [Description("Get Value of UIATable")] get; }

        int ProcessID { [Description("Get ProcessID of UIATable")] get; }

        [Description("Press one or more keystrokes, value can be \"Hi Ants Automation,{DELETE}\"")]
        void PressKeys(string keys);

        //For Table Object
        [Description("Get column count of UIATable")]
        int ColumnCount { get; }

        [Description("Get row count of UIATable")]
        int RowCount { get; }

        [Description("Click cell by row index and column nane, column name can by name or index \"#2\", index is start from \"#0\"")]
        void ClickCell(int rowindex,string columnname );

        [Description("Click cell by row index and column nane, column name can by name or index \"#2\", index is start from \"#0\"")]
        string GetCellValue(int rowindex, string columnname);

        [Description("Set cell value by row index and column nane, column name can by name or index \"#2\", index is start from \"#0\"")]
        string SetCellValue(int rowindex, string columnname, string value);

        [Description("Get column name by column index")]
        string GetColumnName(int columnindex);

    }

    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("DB7932C2-726D-4277-95D9-29DF19E0849B")]
    [ProgId("LeanPro.UIATable")]
    [TypeLibType((short)2)]
    [Description("Automation UIA Table")]
    public class UIATable : UIAContainerBase, IUIATable
    {
        public UIATable(UIACondition condition)
            : base(condition)
        { }

        public UIATable()
            : base()
        { }

        public int ColumnCount 
        {
            get
            {
                this.PrepareForReplay();
                try
                {
                    return _getcolumns.Count;
                }
                catch
                { 
                    
                }                
                return 0;
            }
        }

        public string GetColumnName(int columnindex)
        {
            this.PrepareForReplay();
            try
            {
                AutomationElementCollection allcolumns = _getcolumns;
                if (columnindex >= allcolumns.Count)
                    ControlSearcher.ThrowError(ErrorType.OutRange);
                return allcolumns[columnindex].Current.Name;
            }
            catch{}

            return "";
        }

        public int RowCount
        {
            get
            {
                this.PrepareForReplay();
                try
                {  
                    return _getrows.Count;
                }
                catch
                {

                }
                return 0;
            }
        }

        public void ClickCell(int rowindex, string columnname)
        {
            this.PrepareForReplay();
            KeyInput.Click(KeyInput.MouseClickType.LClick,_getcell(rowindex, columnname),2,2);            
        }

        public string GetCellValue(int rowindex, string columnname)
        {            
            AutomationElement iae = _getcell(rowindex, columnname);
            UIAControlBase ab = new UIAControlBase(new UIACondition(iae));            
            if (ab.Value != "")
                return ab.Value;
            if (ab.Text != "")
                return ab.Text;
            return "";
        }

        public string SetCellValue(int rowindex, string columnname, string value)
        {
            AutomationElement iae = _getcell(rowindex, columnname);
            UIAControlBase ab = new UIAControlBase(new UIACondition(iae));            
            ab.Click(2, 2);
            ab.Set(value);
            if (ab.Value != "")
                return ab.Value;
            if (ab.Text != "")
                return ab.Text;
            return "";
        }

        private AutomationElement _getcell(int rowindex, string columnname)
        {
            this.PrepareForReplay();
            int columnindex = -1;
            try
            {                
                try
                {
                    if (columnname.IndexOf('#') == 0)
                    {
                        columnindex = Convert.ToInt16(columnname.Substring(1));                         
                    }                    
                }
                catch
                {
                    AutomationElementCollection iColumns = _getcolumns;
                    for (int i = 0; i < iColumns.Count;i++ )
                    {
                        if (iColumns[i].Current.Name == columnname)
                            columnindex = i;
                    }
                }
                if (columnindex != -1)
                {
                    try
                    {
                        return _getcell(_getrows[rowindex], columnindex);
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        ControlSearcher.ThrowError(ErrorType.OutRange);    
                    }
                    //catch
                }
                else
                    ControlSearcher.ThrowError(ErrorType.NotItemExistinthelist);
            }
            catch
            {

            }
            return null; 
        }

        private AutomationElementCollection _getrows
        {
            get
            {
                int row = 0x1C;
                Condition columncondition = new PropertyCondition(LegacyIAccessiblePattern.RoleProperty, row);
                AutomationElementCollection allelement = this._condition.AutomationElement.FindAll(TreeScope.Descendants, columncondition);
                return allelement;
            }
        }

        private AutomationElementCollection _getcolumns
        {
            get
            {               
                
                int columns = 0x19;
                int rowheader = 0x1A;
                Condition rowcondition = new PropertyCondition(LegacyIAccessiblePattern.RoleProperty, columns);
                Condition rowcondition_1 = new PropertyCondition(LegacyIAccessiblePattern.RoleProperty, rowheader);
                Condition allcondtion = new OrCondition(new Condition[] { rowcondition, rowcondition_1});
                AutomationElementCollection allelement = this._condition.AutomationElement.FindAll(TreeScope.Descendants, allcondtion);                
                return allelement;
            }
        }
               
        private AutomationElement _getcell(AutomationElement row, int columnindex)
        {
            int cell = 0x1D;
            Condition cellcondition = new PropertyCondition(LegacyIAccessiblePattern.RoleProperty, cell);
            AutomationElementCollection allelement = row.FindAll(TreeScope.Descendants, cellcondition);
            if (columnindex >= allelement.Count)
                ControlSearcher.ThrowError(ErrorType.OutRange);
            else
                return allelement[columnindex];
            return null;
            
        }
    }
}
