using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace LPUIAObjects
{

    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("3D1457B8-22A9-4409-9F9F-0E99377425CB")]
    [ProgId("LeanPro.UIAContainerBase")]
    [TypeLibType((short)2)]
    //[ComSourceInterfaces(typeof(IUIAContainerBase))]
    [Description("Ants Container Base")]
    public class UIAContainerBase : UIAControlBase, IUIAContainerBase
    {
        public UIAContainerBase(string conditionString)
            : base(conditionString)
        { }

        public UIAContainerBase(UIACondition condition)
            : base(condition)
        { }

        internal UIAContainerBase()
            : base()
        { }

        [Description("Get an UIAWindow")]
        public IUIAWindow UIAWindow(string conditions, string conditions1 = "", string conditions2 = "", string conditions3 = "", string conditions4 = "", string conditions5 = "", string conditions6 = "", string conditions7 = "", string conditions8 = "", string conditions9 = "")
        {
            UIACondition cdition = ControlSearcher.GetCondition(this._condition, ControlType.Window, conditions, conditions1, conditions2, conditions3, conditions4, conditions5, conditions6, conditions7, conditions8, conditions9);
            return (UIAWindow)UIACommonMethods.ObjectCreator(cdition);
        }

        [Description("Get an UIAPanel")]
        public IUIAPane UIAPane(string conditions, string conditions1 = "", string conditions2 = "", string conditions3 = "", string conditions4 = "", string conditions5 = "", string conditions6 = "", string conditions7 = "", string conditions8 = "", string conditions9 = "")
        {
            UIACondition cdition = ControlSearcher.GetCondition(this._condition, ControlType.Pane, conditions, conditions1, conditions2, conditions3, conditions4, conditions5, conditions6, conditions7, conditions8, conditions9);
            return (UIAPane)UIACommonMethods.ObjectCreator(cdition);
        }

        [Description("Get an UIAEditor")]
        public IUIAEditor UIAEditor(string conditions, string conditions1 = "", string conditions2 = "", string conditions3 = "", string conditions4 = "", string conditions5 = "", string conditions6 = "", string conditions7 = "", string conditions8 = "", string conditions9 = "")
        {
            UIACondition cdition = ControlSearcher.GetCondition(this._condition, ControlType.Document, conditions, conditions1, conditions2, conditions3, conditions4, conditions5, conditions6, conditions7, conditions8, conditions9);
            return (UIAEditor)UIACommonMethods.ObjectCreator(cdition);
        }

        [Description("Get an UIAEdit")]
        public IUIAEdit UIAEdit(string conditions, string conditions1 = "", string conditions2 = "", string conditions3 = "", string conditions4 = "", string conditions5 = "", string conditions6 = "", string conditions7 = "", string conditions8 = "", string conditions9 = "")
        {
            UIACondition cdition = ControlSearcher.GetCondition(this._condition, ControlType.Edit, conditions, conditions1, conditions2, conditions3, conditions4, conditions5, conditions6, conditions7, conditions8, conditions9);
            return (UIAEdit)UIACommonMethods.ObjectCreator(cdition);
        }

        [Description("Get an UIAButton")]
        public IUIAButton UIAButton(string conditions, string conditions1 = "", string conditions2 = "", string conditions3 = "", string conditions4 = "", string conditions5 = "", string conditions6 = "", string conditions7 = "", string conditions8 = "", string conditions9 = "")
        {
            UIACondition cdition = ControlSearcher.GetCondition(this._condition, ControlType.Button, conditions, conditions1, conditions2, conditions3, conditions4, conditions5, conditions6, conditions7, conditions8, conditions9);
            return (UIAButton)UIACommonMethods.ObjectCreator(cdition);
        }

        [Description("Get an UIACheckbox")]
        public IUIACheckbox UIACheckbox(string conditions, string conditions1 = "", string conditions2 = "", string conditions3 = "", string conditions4 = "", string conditions5 = "", string conditions6 = "", string conditions7 = "", string conditions8 = "", string conditions9 = "")
        {
            UIACondition cdition = ControlSearcher.GetCondition(this._condition, ControlType.CheckBox, conditions, conditions1, conditions2, conditions3, conditions4, conditions5, conditions6, conditions7, conditions8, conditions9);
            return (UIACheckbox)UIACommonMethods.ObjectCreator(cdition);
        }

        [Description("Get an UIAList")]
        public IUIAList UIAList(string conditions, string conditions1 = "", string conditions2 = "", string conditions3 = "", string conditions4 = "", string conditions5 = "", string conditions6 = "", string conditions7 = "", string conditions8 = "", string conditions9 = "")
        {
            UIACondition cdition = ControlSearcher.GetCondition(this._condition, ControlType.List, conditions, conditions1, conditions2, conditions3, conditions4, conditions5, conditions6, conditions7, conditions8, conditions9);
            return (UIAList)UIACommonMethods.ObjectCreator(cdition);
        }

        [Description("Get an UIARadiobutton")]
        public IUIARadioButton UIARadiobutton(string conditions, string conditions1 = "", string conditions2 = "", string conditions3 = "", string conditions4 = "", string conditions5 = "", string conditions6 = "", string conditions7 = "", string conditions8 = "", string conditions9 = "")
        {
            UIACondition cdition = ControlSearcher.GetCondition(this._condition, ControlType.RadioButton, conditions, conditions1, conditions2, conditions3, conditions4, conditions5, conditions6, conditions7, conditions8, conditions9);
            return (UIARadioButton)UIACommonMethods.ObjectCreator(cdition);
        }

        [Description("Get an UIAMenuBar")]
        public IUIAMenuBar UIAMenuBar(string conditions, string conditions1 = "", string conditions2 = "", string conditions3 = "", string conditions4 = "", string conditions5 = "", string conditions6 = "", string conditions7 = "", string conditions8 = "", string conditions9 = "")
        {
            UIACondition cdition = ControlSearcher.GetCondition(this._condition, ControlType.MenuBar, conditions, conditions1, conditions2, conditions3, conditions4, conditions5, conditions6, conditions7, conditions8, conditions9);
            return (UIAMenuBar)UIACommonMethods.ObjectCreator(cdition);
        }

        [Description("Get an UIATree")]
        public IUIATree UIATree(string conditions, string conditions1 = "", string conditions2 = "", string conditions3 = "", string conditions4 = "", string conditions5 = "", string conditions6 = "", string conditions7 = "", string conditions8 = "", string conditions9 = "")
        {
            UIACondition cdition = ControlSearcher.GetCondition(this._condition, ControlType.Tree, conditions, conditions1, conditions2, conditions3, conditions4, conditions5, conditions6, conditions7, conditions8, conditions9);
            return (UIATree)UIACommonMethods.ObjectCreator(cdition);
        }

        [Description("Get an UIAText")]
        public IUIAText UIAText(string conditions, string conditions1 = "", string conditions2 = "", string conditions3 = "", string conditions4 = "", string conditions5 = "", string conditions6 = "", string conditions7 = "", string conditions8 = "", string conditions9 = "")
        {
            UIACondition cdition = ControlSearcher.GetCondition(this._condition, ControlType.Text, conditions, conditions1, conditions2, conditions3, conditions4, conditions5, conditions6, conditions7, conditions8, conditions9);
            return (UIAText)UIACommonMethods.ObjectCreator(cdition);
        }

        [Description("Get an UIATable")]
        public IUIATable UIATable(string conditions, string conditions1 = "", string conditions2 = "", string conditions3 = "", string conditions4 = "", string conditions5 = "", string conditions6 = "", string conditions7 = "", string conditions8 = "", string conditions9 = "")
        {
            UIACondition cdition = ControlSearcher.GetCondition(this._condition, ControlType.Table, conditions, conditions1, conditions2, conditions3, conditions4, conditions5, conditions6, conditions7, conditions8, conditions9);
            return (UIATable)UIACommonMethods.ObjectCreator(cdition);
        }

        [Description("Get an UIAScrollbar")]
        public IUIAScrollBar UIAScrollbar(string conditions, string conditions1 = "", string conditions2 = "", string conditions3 = "", string conditions4 = "", string conditions5 = "", string conditions6 = "", string conditions7 = "", string conditions8 = "", string conditions9 = "")
        {
            UIACondition cdition = ControlSearcher.GetCondition(this._condition, ControlType.ScrollBar, conditions, conditions1, conditions2, conditions3, conditions4, conditions5, conditions6, conditions7, conditions8, conditions9);
            return (UIAScrollBar)UIACommonMethods.ObjectCreator(cdition);
        }

        [Description("Get an UIAComboBox")]
        public IUIAComboBox UIAComboBox(string conditions, string conditions1 = "", string conditions2 = "", string conditions3 = "", string conditions4 = "", string conditions5 = "", string conditions6 = "", string conditions7 = "", string conditions8 = "", string conditions9 = "")
        {
            UIACondition cdition = ControlSearcher.GetCondition(this._condition, ControlType.ComboBox, conditions, conditions1, conditions2, conditions3, conditions4, conditions5, conditions6, conditions7, conditions8, conditions9);
            return (UIAComboBox)UIACommonMethods.ObjectCreator(cdition);
        }

        [Description("Get an UIASlider")]
        public IUIASlider UIASlider(string conditions, string conditions1 = "", string conditions2 = "", string conditions3 = "", string conditions4 = "", string conditions5 = "", string conditions6 = "", string conditions7 = "", string conditions8 = "", string conditions9 = "")
        {
            UIACondition cdition = ControlSearcher.GetCondition(this._condition, ControlType.Slider, conditions, conditions1, conditions2, conditions3, conditions4, conditions5, conditions6, conditions7, conditions8, conditions9);
            return (UIASlider)UIACommonMethods.ObjectCreator(cdition);
        }

        [Description("Get an UIATab")]
        public IUIATab UIATab(string conditions, string conditions1 = "", string conditions2 = "", string conditions3 = "", string conditions4 = "", string conditions5 = "", string conditions6 = "", string conditions7 = "", string conditions8 = "", string conditions9 = "")
        {
            UIACondition cdition = ControlSearcher.GetCondition(this._condition, ControlType.Tab, conditions, conditions1, conditions2, conditions3, conditions4, conditions5, conditions6, conditions7, conditions8, conditions9);
            return (UIATab)UIACommonMethods.ObjectCreator(cdition);
        }

        [Description("Get an UIAImage")]
        public IUIAImage UIAImage(string conditions, string conditions1 = "", string conditions2 = "", string conditions3 = "", string conditions4 = "", string conditions5 = "", string conditions6 = "", string conditions7 = "", string conditions8 = "", string conditions9 = "")
        {
            UIACondition cdition = ControlSearcher.GetCondition(this._condition, ControlType.Image, conditions, conditions1, conditions2, conditions3, conditions4, conditions5, conditions6, conditions7, conditions8, conditions9);
            return (UIAImage)UIACommonMethods.ObjectCreator(cdition);
        }

        [Description("Get an UIAToolBar")]
        public IUIAToolBar UIAToolBar(string conditions, string conditions1 = "", string conditions2 = "", string conditions3 = "", string conditions4 = "", string conditions5 = "", string conditions6 = "", string conditions7 = "", string conditions8 = "", string conditions9 = "")
        {
            UIACondition cdition = ControlSearcher.GetCondition(this._condition, ControlType.ToolBar, conditions, conditions1, conditions2, conditions3, conditions4, conditions5, conditions6, conditions7, conditions8, conditions9);
            return (UIAToolBar)UIACommonMethods.ObjectCreator(cdition);
        }

        [Description("Get an UIAObject")]
        public IUIACustom UIACustom(string conditions, string conditions1 = "", string conditions2 = "", string conditions3 = "", string conditions4 = "", string conditions5 = "", string conditions6 = "", string conditions7 = "", string conditions8 = "", string conditions9 = "")
        {
            UIACondition cdition = ControlSearcher.GetCondition(this._condition, ControlType.Custom, conditions, conditions1, conditions2, conditions3, conditions4, conditions5, conditions6, conditions7, conditions8, conditions9);
            return (UIACustom)UIACommonMethods.ObjectCreator(cdition);
        }

        [Description("Get an UIAMenu")]
        public IUIAMenu UIAMenu(string conditions, string conditions1 = "", string conditions2 = "", string conditions3 = "", string conditions4 = "", string conditions5 = "", string conditions6 = "", string conditions7 = "", string conditions8 = "", string conditions9 = "")
        {
            UIACondition cdition = ControlSearcher.GetCondition(this._condition, ControlType.Menu, conditions, conditions1, conditions2, conditions3, conditions4, conditions5, conditions6, conditions7, conditions8, conditions9);
            return (UIAMenu)UIACommonMethods.ObjectCreator(cdition);
        }

        [Description("Get an UIALink")]
        public IUIALink UIALink(string conditions, string conditions1 = "", string conditions2 = "", string conditions3 = "", string conditions4 = "", string conditions5 = "", string conditions6 = "", string conditions7 = "", string conditions8 = "", string conditions9 = "")
        {
            UIACondition cdition = ControlSearcher.GetCondition(this._condition, ControlType.Hyperlink, conditions, conditions1, conditions2, conditions3, conditions4, conditions5, conditions6, conditions7, conditions8, conditions9);
            return (UIALink)UIACommonMethods.ObjectCreator(cdition);
        }
    }
}
