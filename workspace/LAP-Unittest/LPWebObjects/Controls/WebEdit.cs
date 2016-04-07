using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Interactions;

namespace LPWebObjects.Controls
{
    [Guid("6DEE4CD6-7683-4D47-A675-846915E51E97")]
    [TypeLibType(4160)]
    public interface IWebEdit
    {
        [DispId(1)]
        void MarkText(string markText);

        [DispId(2)]
        void MarkText(int start, int end);

        [DispId(3)]
        void ClearValue();

        [DispId(4)]
        void TypeText(string Text);
    }

    [ProgId("LeanPro.WebLink")]
    [Guid(WebEdit.ClassId)]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    public class WebEdit : WebControlBase, IWebEdit, IWebControl, IWebElement
    {
        internal const string ClassId = "01500ADD-D5A6-4BBC-A88D-AC802F863B5D";

        public WebEdit()
            : base()
        {
        }

        public virtual void MarkText(string markText)
        {
            ActionsHelper actionsHelper = ActionsHelper.getInstance();
            actionsHelper.MarkText(RelayObject.SEWebElement, markText);
        }

        public virtual void MarkText(int start, int end)
        {
            ActionsHelper actionsHelper = ActionsHelper.getInstance();
            actionsHelper.MarkText(RelayObject.SEWebElement, start, end);
        }

        public virtual void ClearValue()
        {
            ActionsHelper actionsHelper = ActionsHelper.getInstance();
            actionsHelper.ClearValue(RelayObject.SEWebElement);
        }

        public virtual void TypeText(string Text)
        {
            ActionsHelper actionsHelper = ActionsHelper.getInstance();
            actionsHelper.TypeText(RelayObject.SEWebElement, Text);
        }
    }
}
