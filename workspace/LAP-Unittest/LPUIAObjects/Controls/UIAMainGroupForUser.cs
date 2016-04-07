using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.ComponentModel;
using System.Reflection;
using Microsoft.Win32;
using System.Threading;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Windows.Automation;




namespace LPUIAObjects
{
    [EditorBrowsable(EditorBrowsableState.Always)]
    [Guid("010C7EF7-8063-4985-9A90-71B35816BC82")]
    public interface IUIAAutomation
    {
        [DispId(1)]
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
    }

    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("4F1A1B47-4AD0-4BFB-ACC4-80B1D85F708B")]
    [ProgId("LeanPro.UIAAutomation")]
    [TypeLibType((short)2)]
    [Description("Ants Automation")]
    [ComSourceInterfaces(typeof(IUIAAutomation))]
    public class UIAAutomation : IUIAAutomation
    {
        private UIACondition _condition = null;        
        public UIAAutomation()
        {
            //AntsEnvironment.AntsEnter.init();      
            //_condition = UIACondition.RootUIACondition;            
        }

        [Description("Get an UIAWindow")]
        public IUIAWindow UIAWindow(string conditions, string conditions1 = "", string conditions2 = "", string conditions3 = "", string conditions4 = "", string conditions5 = "", string conditions6 = "", string conditions7 = "", string conditions8 = "", string conditions9 = "")
        {
            UIACondition cdition = ControlSearcher.GetCondition(_condition, ControlType.Window, conditions, conditions1, conditions2, conditions3, conditions4, conditions5, conditions6, conditions7, conditions8, conditions9);
            return (UIAWindow)UIACommonMethods.ObjectCreator(cdition);
        }

        [Description("Get an UIAPanel")]
        public IUIAPane UIAPane(string conditions, string conditions1 = "", string conditions2 = "", string conditions3 = "", string conditions4 = "", string conditions5 = "", string conditions6 = "", string conditions7 = "", string conditions8 = "", string conditions9 = "")
        {
            UIACondition cdition = ControlSearcher.GetCondition(_condition, ControlType.Pane, conditions, conditions1, conditions2, conditions3, conditions4, conditions5, conditions6, conditions7, conditions8, conditions9);
            return (UIAPane)UIACommonMethods.ObjectCreator(cdition);
        }

        [Description("Get an UIAEditor")]
        public IUIAEditor UIAEditor(string conditions, string conditions1 = "", string conditions2 = "", string conditions3 = "", string conditions4 = "", string conditions5 = "", string conditions6 = "", string conditions7 = "", string conditions8 = "", string conditions9 = "")
        {
            UIACondition cdition = ControlSearcher.GetCondition(_condition, ControlType.Document, conditions, conditions1, conditions2, conditions3, conditions4, conditions5, conditions6, conditions7, conditions8, conditions9);
            return (UIAEditor)UIACommonMethods.ObjectCreator(cdition);
        }

        [Description("Get an UIAEdit")]
        public IUIAEdit UIAEdit(string conditions, string conditions1 = "", string conditions2 = "", string conditions3 = "", string conditions4 = "", string conditions5 = "", string conditions6 = "", string conditions7 = "", string conditions8 = "", string conditions9 = "")
        {
            UIACondition cdition = ControlSearcher.GetCondition(_condition, ControlType.Edit, conditions, conditions1, conditions2, conditions3, conditions4, conditions5, conditions6, conditions7, conditions8, conditions9);
            return (UIAEdit)UIACommonMethods.ObjectCreator(cdition);
        }

        [Description("Get an UIAButton")]
        public IUIAButton UIAButton(string conditions, string conditions1 = "", string conditions2 = "", string conditions3 = "", string conditions4 = "", string conditions5 = "", string conditions6 = "", string conditions7 = "", string conditions8 = "", string conditions9 = "")
        {
            UIACondition cdition = ControlSearcher.GetCondition(_condition, ControlType.Button, conditions, conditions1, conditions2, conditions3, conditions4, conditions5, conditions6, conditions7, conditions8, conditions9);
            return (UIAButton)UIACommonMethods.ObjectCreator(cdition);
        }

        [Description("Get an UIACheckbox")]
        public IUIACheckbox UIACheckbox(string conditions, string conditions1 = "", string conditions2 = "", string conditions3 = "", string conditions4 = "", string conditions5 = "", string conditions6 = "", string conditions7 = "", string conditions8 = "", string conditions9 = "")
        {
            UIACondition cdition = ControlSearcher.GetCondition(_condition, ControlType.CheckBox, conditions, conditions1, conditions2, conditions3, conditions4, conditions5, conditions6, conditions7, conditions8, conditions9);
            return (UIACheckbox)UIACommonMethods.ObjectCreator(cdition);
        }

        [Description("Get an UIAList")]
        public IUIAList UIAList(string conditions, string conditions1 = "", string conditions2 = "", string conditions3 = "", string conditions4 = "", string conditions5 = "", string conditions6 = "", string conditions7 = "", string conditions8 = "", string conditions9 = "")
        {
            UIACondition cdition = ControlSearcher.GetCondition(_condition, ControlType.List, conditions, conditions1, conditions2, conditions3, conditions4, conditions5, conditions6, conditions7, conditions8, conditions9);
            return (UIAList)UIACommonMethods.ObjectCreator(cdition);
        }

        [Description("Get an UIARadiobutton")]
        public IUIARadioButton UIARadiobutton(string conditions, string conditions1 = "", string conditions2 = "", string conditions3 = "", string conditions4 = "", string conditions5 = "", string conditions6 = "", string conditions7 = "", string conditions8 = "", string conditions9 = "")
        {
            UIACondition cdition = ControlSearcher.GetCondition(_condition, ControlType.RadioButton, conditions, conditions1, conditions2, conditions3, conditions4, conditions5, conditions6, conditions7, conditions8, conditions9);
            return (UIARadioButton)UIACommonMethods.ObjectCreator(cdition);
        }

        [Description("Get an UIAMenuBar")]
        public IUIAMenuBar UIAMenuBar(string conditions, string conditions1 = "", string conditions2 = "", string conditions3 = "", string conditions4 = "", string conditions5 = "", string conditions6 = "", string conditions7 = "", string conditions8 = "", string conditions9 = "")
        {
            UIACondition cdition = ControlSearcher.GetCondition(_condition, ControlType.MenuBar, conditions, conditions1, conditions2, conditions3, conditions4, conditions5, conditions6, conditions7, conditions8, conditions9);
            return (UIAMenuBar)UIACommonMethods.ObjectCreator(cdition);
        }

        [Description("Get an UIATree")]
        public IUIATree UIATree(string conditions, string conditions1 = "", string conditions2 = "", string conditions3 = "", string conditions4 = "", string conditions5 = "", string conditions6 = "", string conditions7 = "", string conditions8 = "", string conditions9 = "")
        {
            UIACondition cdition = ControlSearcher.GetCondition(_condition, ControlType.Tree, conditions, conditions1, conditions2, conditions3, conditions4, conditions5, conditions6, conditions7, conditions8, conditions9);
            return (UIATree)UIACommonMethods.ObjectCreator(cdition);
        }

        [Description("Get an UIAText")]
        public IUIAText UIAText(string conditions, string conditions1 = "", string conditions2 = "", string conditions3 = "", string conditions4 = "", string conditions5 = "", string conditions6 = "", string conditions7 = "", string conditions8 = "", string conditions9 = "")
        {
            UIACondition cdition = ControlSearcher.GetCondition(_condition, ControlType.Text, conditions, conditions1, conditions2, conditions3, conditions4, conditions5, conditions6, conditions7, conditions8, conditions9);
            return (UIAText)UIACommonMethods.ObjectCreator(cdition);
        }

        [Description("Get an UIATable")]
        public IUIATable UIATable(string conditions, string conditions1 = "", string conditions2 = "", string conditions3 = "", string conditions4 = "", string conditions5 = "", string conditions6 = "", string conditions7 = "", string conditions8 = "", string conditions9 = "")
        {
            UIACondition cdition = ControlSearcher.GetCondition(_condition, ControlType.Table, conditions, conditions1, conditions2, conditions3, conditions4, conditions5, conditions6, conditions7, conditions8, conditions9);
            return (UIATable)UIACommonMethods.ObjectCreator(cdition);
        }

        [Description("Get an UIAScrollbar")]
        public IUIAScrollBar UIAScrollbar(string conditions, string conditions1 = "", string conditions2 = "", string conditions3 = "", string conditions4 = "", string conditions5 = "", string conditions6 = "", string conditions7 = "", string conditions8 = "", string conditions9 = "")
        {
            UIACondition cdition = ControlSearcher.GetCondition(_condition, ControlType.ScrollBar, conditions, conditions1, conditions2, conditions3, conditions4, conditions5, conditions6, conditions7, conditions8, conditions9);
            return (UIAScrollBar)UIACommonMethods.ObjectCreator(cdition);
        }

        [Description("Get an UIAComboBox")]
        public IUIAComboBox UIAComboBox(string conditions, string conditions1 = "", string conditions2 = "", string conditions3 = "", string conditions4 = "", string conditions5 = "", string conditions6 = "", string conditions7 = "", string conditions8 = "", string conditions9 = "")
        {
            UIACondition cdition = ControlSearcher.GetCondition(_condition, ControlType.ComboBox, conditions, conditions1, conditions2, conditions3, conditions4, conditions5, conditions6, conditions7, conditions8, conditions9);
            return (UIAComboBox)UIACommonMethods.ObjectCreator(cdition);
        }

        [Description("Get an UIASlider")]
        public IUIASlider UIASlider(string conditions, string conditions1 = "", string conditions2 = "", string conditions3 = "", string conditions4 = "", string conditions5 = "", string conditions6 = "", string conditions7 = "", string conditions8 = "", string conditions9 = "")
        {
            UIACondition cdition = ControlSearcher.GetCondition(_condition, ControlType.Slider, conditions, conditions1, conditions2, conditions3, conditions4, conditions5, conditions6, conditions7, conditions8, conditions9);
            return (UIASlider)UIACommonMethods.ObjectCreator(cdition);
        }

        [Description("Get an UIATab")]
        public IUIATab UIATab(string conditions, string conditions1 = "", string conditions2 = "", string conditions3 = "", string conditions4 = "", string conditions5 = "", string conditions6 = "", string conditions7 = "", string conditions8 = "", string conditions9 = "")
        {
            UIACondition cdition = ControlSearcher.GetCondition(_condition, ControlType.Tab, conditions, conditions1, conditions2, conditions3, conditions4, conditions5, conditions6, conditions7, conditions8, conditions9);
            return (UIATab)UIACommonMethods.ObjectCreator(cdition);
        }

        [Description("Get an UIAImage")]
        public IUIAImage UIAImage(string conditions, string conditions1 = "", string conditions2 = "", string conditions3 = "", string conditions4 = "", string conditions5 = "", string conditions6 = "", string conditions7 = "", string conditions8 = "", string conditions9 = "")
        {
            UIACondition cdition = ControlSearcher.GetCondition(_condition, ControlType.Image, conditions, conditions1, conditions2, conditions3, conditions4, conditions5, conditions6, conditions7, conditions8, conditions9);
            return (UIAImage)UIACommonMethods.ObjectCreator(cdition);
        }

        [Description("Get an UIAToolBar")]
        public IUIAToolBar UIAToolBar(string conditions, string conditions1 = "", string conditions2 = "", string conditions3 = "", string conditions4 = "", string conditions5 = "", string conditions6 = "", string conditions7 = "", string conditions8 = "", string conditions9 = "")
        {
            UIACondition cdition = ControlSearcher.GetCondition(_condition, ControlType.ToolBar, conditions, conditions1, conditions2, conditions3, conditions4, conditions5, conditions6, conditions7, conditions8, conditions9);
            return (UIAToolBar)UIACommonMethods.ObjectCreator(cdition);
        }

        [Description("Get an UIAObject")]
        public IUIACustom UIACustom(string conditions, string conditions1 = "", string conditions2 = "", string conditions3 = "", string conditions4 = "", string conditions5 = "", string conditions6 = "", string conditions7 = "", string conditions8 = "", string conditions9 = "")
        {
            UIACondition cdition = ControlSearcher.GetCondition(_condition, ControlType.Custom, conditions, conditions1, conditions2, conditions3, conditions4, conditions5, conditions6, conditions7, conditions8, conditions9);
            return (UIACustom)UIACommonMethods.ObjectCreator(cdition);
        }

        [Description("Get an UIAMenu")]
        public IUIAMenu UIAMenu(string conditions, string conditions1 = "", string conditions2 = "", string conditions3 = "", string conditions4 = "", string conditions5 = "", string conditions6 = "", string conditions7 = "", string conditions8 = "", string conditions9 = "")
        {
            UIACondition cdition = ControlSearcher.GetCondition(_condition, ControlType.Menu, conditions, conditions1, conditions2, conditions3, conditions4, conditions5, conditions6, conditions7, conditions8, conditions9);
            return (UIAMenu)UIACommonMethods.ObjectCreator(cdition);
        }

        [Description("Get an UIALink")]
        public IUIALink UIALink(string conditions, string conditions1 = "", string conditions2 = "", string conditions3 = "", string conditions4 = "", string conditions5 = "", string conditions6 = "", string conditions7 = "", string conditions8 = "", string conditions9 = "")
        {
            UIACondition cdition = ControlSearcher.GetCondition(_condition, ControlType.Hyperlink, conditions, conditions1, conditions2, conditions3, conditions4, conditions5, conditions6, conditions7, conditions8, conditions9);
            return (UIALink)UIACommonMethods.ObjectCreator(cdition);
        }
    }

}
