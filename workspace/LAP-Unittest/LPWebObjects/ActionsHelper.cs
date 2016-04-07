using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;

namespace LPWebObjects
{
    internal class ActionsHelper
    {
        private Actions _actions = null;

        private Actions _dragdropactions = null;

        public static ActionsHelper _internalObj = null;
        public static ActionsHelper getInstance()
        {
            if (_internalObj == null)
            {
                _internalObj = new ActionsHelper();
                _internalObj.init();
            }

            return _internalObj;
        }

        private void init()
        {
            _actions = new Actions(BrowserHoster.getInstance().WebDriver);
            _dragdropactions = new Actions(BrowserHoster.getInstance().WebDriver);
        }

        private void ClickOperation(RemoteWebElement webElement, int mousekey = 1, int x = 0, int y = 0)
        {
            _actions.MoveToElement(webElement);

            if (x != -1 && y != -1)
                _actions.MoveByOffset(x, y);

            switch (mousekey)
            {
                case 3:
                    {
                        _actions.DoubleClick(webElement);
                    }
                    break;
                case 2:
                    {
                        _actions.ContextClick(webElement);
                    }
                    break;
                default:
                    {
                        _actions.Click(webElement);
                    }
                    break;
            }
            _actions.Build().Perform();
        }

        public void Click(RemoteWebElement webElement, int x = -1, int y = -1)
        {
            ClickOperation(webElement, 1, x, y);
        }

        public void RClick(RemoteWebElement webElement, int x = -1, int y = -1)
        {
            ClickOperation(webElement, 2, x, y);
        }

        public void DBClick(RemoteWebElement webElement, int x = -1, int y = -1)
        {
            ClickOperation(webElement, 3, x, y);
        }

        public void Drag(RemoteWebElement webElement, int x = -1, int y = -1)
        {
            _dragdropactions.ClickAndHold(webElement);
            if (x != -1 && y != -1)
                _dragdropactions.MoveByOffset(x, y);
            _dragdropactions.Build().Perform();


        }
        public void Drop(RemoteWebElement webElement, int x = -1, int y = -1)
        {
            _dragdropactions.MoveToElement(webElement);
            if (x != -1 && y != -1)
                _dragdropactions.MoveByOffset(x, y);
            _dragdropactions.Release(webElement);
            _dragdropactions.Build().Perform();
        }

        public void DragAndDrop(RemoteWebElement srcElement, RemoteWebElement tagElement)
        {
            _dragdropactions.DragAndDrop(srcElement, tagElement).Perform();
        }


        public void MarkText(RemoteWebElement webElement, string markText)
        {
            // make sure it has focus
           // Click(webElement);
            _actions.MoveToElement(webElement);

            _actions.SendKeys(webElement, Keys.Home);
            int start = webElement.Text.IndexOf(markText);
            int length = markText.Length;


            for (int i = 0; i < start; i++)
            {
                _actions.SendKeys(webElement, Keys.ArrowRight);
            }
            _actions.Build().Perform();
            _actions.KeyDown(webElement, Keys.LeftShift);
            for (int i = 0; i < length; i++)
            {
                _actions.SendKeys(webElement, Keys.ArrowRight);
            }
            _actions.KeyUp(webElement, Keys.LeftShift);
            _actions.Build().Perform();
        }

        public void MarkText(RemoteWebElement webElement, int start, int end)
        {
             //  Actions actions = new Actions(webElement.WrappedDriver);
            // make sure it has focus
           // Click(webElement);
               _actions.MoveToElement(webElement);

               _actions.SendKeys(webElement, Keys.Home);
               _actions.Build().Perform();
               System.Threading.Thread.Sleep(1000);
               _actions.SendKeys(webElement, Keys.Right);
              
               _actions.Build().Perform();
               //System.Threading.Thread.Sleep(1000);
               //_actions.MoveToElement(webElement);
               //_actions.SendKeys(webElement, Keys.ArrowLeft);
               //_actions.Build().Perform();
             
             //  _actions.SendKeys(webElement, Keys.Home);
             //_actions.Build().Perform();
              // _actions.KeyUp(webElement, Keys.Home);
             //  _actions.Build().Perform();
             /*  actions.KeyDown(webElement, Keys.ArrowLeft);
               actions.SendKeys(webElement, Keys.ArrowLeft);
               actions.SendKeys(webElement, Keys.ArrowLeft);
               actions.SendKeys(webElement, Keys.ArrowLeft);
               actions.SendKeys(webElement, Keys.ArrowLeft);
               actions.SendKeys(webElement, Keys.ArrowLeft);
               actions.Build().Perform();
          */
        
          /* for (int i = 0; i < 1; i++)
            {
                _actions.SendKeys(webElement, Keys.Right);
               // _actions.Build().Perform();
            }
             _actions.Build().Perform();*/
            //_actions.Build().Perform();
         /*   _actions.KeyDown(webElement, Keys.LeftShift);
            for (int i = start; i < end; i++)
            {
                _actions.SendKeys(webElement, Keys.ArrowRight);
            }
            _actions.Build().Perform();
            _actions.KeyUp(webElement, Keys.LeftShift);
            _actions.Build().Perform();*/
        }

        public void ClearValue(RemoteWebElement webElement)
        {
            DBClick(webElement);
            _actions.SendKeys(Keys.Delete);
            _actions.Build().Perform();
        }

        public void TypeText(RemoteWebElement webElement, string Text)
        {
            _actions.MoveToElement(webElement);
            //_actions.KeyDown(webElement, Keys.LeftShift);
            _actions.SendKeys(webElement, Text);
           // _actions.KeyUp(webElement, Keys.LeftShift);
            _actions.Build().Perform();
        }
        
    }
}
