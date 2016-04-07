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
using System.Xml;
using System.Windows.Automation;
using System.Windows;
using LPReplayCore.Common;
using LPReplayCore.UIA;
using LPReplayCore;
using LPCommon;


namespace LPUIAObjects
{
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("3926AEB1-E6E7-45C1-B94B-E427780686CD")]
    [ProgId("LeanPro.UIAControlBase")]
    [TypeLibType((short)2)]
    [Description("Automation UIA Worker")]
    public class UIAControlBase : IUIAControlBase
    {
        internal UIACondition _condition;
        static ILogger _Logger = LogFactory.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);//"LPReplayCore.UIA.UIAFinder");


        public UIAControlBase(string conditionString)
        {
            _condition = new UIACondition(conditionString);
        }

        public UIAControlBase(UIACondition condition)
        {
            _condition = condition;
        }

        internal UIAControlBase()
        {
        }

        public void Click(int x = 0, int y = 0, int mousekey = 1)
        {
            PrepareForReplay();
            int handle = 0;
            try
            {
                handle = (int)_condition.AutomationElement.Current.NativeWindowHandle;
            }
            catch { }

            if (x == 0 && y == 0)
            {
                try
                {
                    Rect tr_point = _condition.AutomationElement.Current.BoundingRectangle;
                    x = (int)(tr_point.Right - tr_point.Left) / 2;
                    y = (int)(tr_point.Bottom - tr_point.Top) / 2;
                }
                catch { }
            }

            if (handle != 0)
            {
                if (mousekey == 2)
                {
                    KeyInput.Click(KeyInput.MouseClickType.RClick, handle, x, y);
                }
                else
                {
                    KeyInput.Click(KeyInput.MouseClickType.LClick, handle, x, y);
                }
            }
            else
            {
                //using Point to click
                try
                {
                    Point p = new Point();
                    Rect tr = _condition.AutomationElement.Current.BoundingRectangle;
                    p.X = (int)tr.Left + x;
                    p.Y = (int)tr.Top + y;
                    if (mousekey == 2)
                    {
                        KeyInput.Click(KeyInput.MouseClickType.RClick, p);
                    }
                    else
                    {
                        KeyInput.Click(KeyInput.MouseClickType.LClick, p);
                    }
                    return;
                }
                catch { }

                try
                {

                    ((InvokePattern)_condition.AutomationElement.GetCurrentPattern(InvokePattern.Pattern)).Invoke();
                }
                catch
                {
                    ControlSearcher.ThrowError(ErrorType.CannotPerformThisOperation);
                }
            }
        }

        public void DBClick(int x = 0, int y = 0, int mousekey = 1)
        {
            PrepareForReplay();
            int handle = 0;
            try
            {
                handle = (int)_condition.AutomationElement.Current.NativeWindowHandle;
            }
            catch { }

            if (x == 0 && y == 0)
            {
                try
                {
                    Rect tr_point = _condition.AutomationElement.Current.BoundingRectangle;
                    x = (int)(tr_point.Right - tr_point.Left) / 2;
                    y = (int)(tr_point.Bottom - tr_point.Top) / 2;
                }
                catch { }
            }

            if (handle != 0)
            {
                if (mousekey == 2)
                {
                    KeyInput.Click(KeyInput.MouseClickType.RDClcik, handle, x, y);
                }
                else
                {
                    KeyInput.Click(KeyInput.MouseClickType.LDClick, handle, x, y);
                }
            }
            else
            {
                try
                {
                    Point p = new Point();
                    Rect tr = _condition.AutomationElement.Current.BoundingRectangle;
                    p.X = (int)tr.Left + x;
                    p.Y = (int)tr.Top + y;
                    if (mousekey == 2)
                    {
                        KeyInput.Click(KeyInput.MouseClickType.RDClcik, p);
                    }
                    else
                    {
                        KeyInput.Click(KeyInput.MouseClickType.LDClick, p);
                    }
                    return;
                }
                catch
                {
                    ControlSearcher.ThrowError(ErrorType.CannotPerformThisOperation);
                }
            }
        }

        public bool Exist(int time = 0)
        {
            _Logger.WriteLog("Check if the objest is exist in the Object list.");
            bool found = false;
            for (int i = 0; i <= time; i++)
            {
                if (found == true)
                    return found;
                else
                {
                    try
                    {
                        if (_condition.AutomationElement == null)
                        {
                            found = false;
                        }
                        Rect value = _condition.AutomationElement.Current.BoundingRectangle;
                        if (value.Right == 0 && value.Left == 0 && value.Top == 0 && value.Bottom == 0)
                            found = false;
                        else
                            found = true;
                    }
                    catch
                    {
                        found = false;
                    }
                }
                if (!found)
                {
                    Console.WriteLine("This object is not exist and find it again: " + _condition.TestObject);
                    //search it again
                    UIACondition c = ControlSearcher.GetCondition(_condition.ParentCondition, _condition.TestObject, _condition.ControlType);
                    if (c.AutomationElement != null)
                    {
                        _condition = c;
                        found = true;
                    }
                }
            }
            return found;
        }

        public void HScroll(int value = 1)
        {
            PrepareForReplay();
            ScrollBar(2, value);
        }

        public void VScroll(int value = 1)
        {
            PrepareForReplay();
            ScrollBar(1, value);
        }

        public string GetRoProperty(string propertyname)
        {
            PrepareForReplay();
            try
            {
                switch (propertyname.ToLower().Trim())
                {
                    case "title":
                        return (string)_condition.AutomationElement.Current.Name;
                    case "name":
                        return (string)_condition.AutomationElement.Current.Name;
                    case "text":
                        return this.Text;
                    case "hwnd":
                        return _condition.AutomationElement.Current.NativeWindowHandle.ToString();
                    case "handle":
                        return _condition.AutomationElement.Current.NativeWindowHandle.ToString();
                    case "x":
                        return _condition.AutomationElement.Current.BoundingRectangle.Left.ToString();
                    case "y":
                        return _condition.AutomationElement.Current.BoundingRectangle.Top.ToString();
                    case "height":
                        return (_condition.AutomationElement.Current.BoundingRectangle.Bottom - _condition.AutomationElement.Current.BoundingRectangle.Top).ToString();
                    case "width":
                        return (_condition.AutomationElement.Current.BoundingRectangle.Right - _condition.AutomationElement.Current.BoundingRectangle.Left).ToString();
                    case "enabled":
                        if (_condition.AutomationElement.Current.IsEnabled)
                            return "true";
                        else
                            return "false";
                    case "focused":
                        if (_condition.AutomationElement.Current.HasKeyboardFocus)
                            return "true";
                        else
                            return "false";
                    case "helptext":
                        return _condition.AutomationElement.Current.HelpText;
                    case "value":
                        return this.Value;
                    case "labeledtext":
                        if (_condition.AutomationElement.Current.LabeledBy != null)
                        {
                            return _condition.AutomationElement.Current.LabeledBy.Current.Name;
                        }
                        else
                            return "";
                    case "processid":
                        return _condition.AutomationElement.Current.ProcessId.ToString();
                }
            }
            catch
            {
                ControlSearcher.ThrowError(ErrorType.CannotPerformThisOperation, "Object doese not support this property");
            }
            return "";
        }

        public void SetToProperty(string propertyname, string propertyvalue)
        {
            //TODO fix this part
            /*
             * 
            List<String> toPropertyList = _condition.SetToPropertyList;
            if (!string.IsNullOrEmpty(_condition.XmlXpath))
            {
                foreach (string newProperty in toPropertyList)
                {
                    if (newProperty.IndexOf(_condition.XmlXpath) >= 0)
                    {
                        string newpropertycondition = newProperty.Substring(newProperty.IndexOf(DescriptionString.PropertySplitString) + DescriptionString.PropertySplitString.Length);
                        string newpropertyname = newpropertycondition.Split(new string[] { DescriptionString.AssignOperator }, StringSplitOptions.RemoveEmptyEntries)[0];
                        if (newpropertyname.Trim().ToLower() == propertyname.ToLower().Trim())
                        {
                            toPropertyList[toPropertyList.IndexOf(newProperty)] = _condition.NodeName + DescriptionString.PropertySplitString + propertyname + DescriptionString.AssignOperator + propertyvalue;
                            _condition.TestObject = null;
                            _condition.AutomationElement = null;
                            return;
                        }
                    }
                }
                toPropertyList.Add(_condition.NodeName + DescriptionString.PropertySplitString + propertyname + DescriptionString.AssignOperator + propertyvalue);
                _condition.SetToPropertyList = toPropertyList;
                _condition.TestObject = null;
                _condition.AutomationElement = null;
            }
             */
        }

        public int ProcessID
        {
            get
            {
                return Convert.ToInt32(this.GetRoProperty("processid"));
            }
        }

        public string Text
        {
            get
            {
                PrepareForReplay();
                string text = null;
                try
                {
                    text = ((TextPattern)_condition.AutomationElement.GetCurrentPattern(TextPattern.Pattern)).DocumentRange.GetText(-1);
                    return text;
                }
                catch
                {

                }
                try
                {
                    
                    return (string)_condition.AutomationElement.GetCurrentPropertyValue( LegacyIAccessiblePattern.RoleProperty);
                }
                catch
                {
                    return "";
                }
            }
        }

        public string Name
        {
            get
            {
                return this.GetRoProperty("name");
            }
        }

        public string Value
        {
            get
            {
                PrepareForReplay();
                try
                {
                    ValuePattern v = (ValuePattern)_condition.AutomationElement.GetCurrentPattern(TextPattern.Pattern);
                    return v.Current.Value;
                }
                catch
                {
                }

                try
                {
                    RangeValuePattern v = (RangeValuePattern)_condition.AutomationElement.GetCurrentPattern(RangeValuePattern.Pattern);
                    return v.Current.Value.ToString();
                }
                catch
                {
                }

                try
                {
                    return (string)_condition.AutomationElement.GetCurrentPropertyValue(LegacyIAccessiblePattern.RoleProperty);
                }
                catch
                {
                    return "";
                }

            }
        }

        public int Hwnd
        {
            get
            {
                return Convert.ToInt32(this.GetRoProperty("hwnd"));
            }
        }

        public int X
        {
            get
            {
                return Convert.ToInt32(this.GetRoProperty("x"));
            }
        }

        public int Y
        {
            get
            {
                return Convert.ToInt32(this.GetRoProperty("y"));
            }
        }

        public int Height
        {
            get
            {
                return Convert.ToInt32(this.GetRoProperty("height"));
            }
        }

        public int Width
        {
            get
            {
                return Convert.ToInt32(this.GetRoProperty("width"));
            }
        }

        public bool Enabled
        {
            get
            {
                return Convert.ToBoolean(this.GetRoProperty("enabled"));
            }
        }

        public bool Focused
        {
            get
            {
                return Convert.ToBoolean(this.GetRoProperty("focused"));
            }
        }

        public string HelpText
        {
            get
            {
                return this.GetRoProperty("helptext");
            }
        }

        public string LabeledText
        {
            get
            {
                return this.GetRoProperty("labeledtext");
            }
        }

        public bool WaitProperty(string propertyname, string value, int TimeOut = 0)
        {
            PrepareForReplay();
            for (int i = 0; i < TimeOut; i++)
            {
                if (GetRoProperty(propertyname) == value)
                    return true;
            }
            return false;
        }

        public void Drag(int x = -1, int y = -1)
        {
            PrepareForReplay();
            int handle = 0;
            try
            {
                handle = (int)_condition.AutomationElement.Current.NativeWindowHandle;
            }
            catch { }

            if (handle != 0)
            {
                KeyInput.Drag(handle, x, y);
            }
            else
            {
                //using Point to drag
                try
                {
                    Point p = new Point();
                    p.X = (int)_condition.AutomationElement.Current.BoundingRectangle.Left + x;
                    p.Y = (int)_condition.AutomationElement.Current.BoundingRectangle.Top + y;
                    KeyInput.Drag(p);
                    return;
                }
                catch
                {

                }
            }
        }

        public void Drop(int x = -1, int y = -1)
        {
            PrepareForReplay();
            int handle = 0;
            try
            {
                handle = (int)_condition.AutomationElement.Current.NativeWindowHandle;
            }
            catch { }

            if (handle != 0)
            {
                KeyInput.Drag(handle, x, y);
                KeyInput.Drop(handle, x, y);
            }
            else
            {
                //using Point to drop
                try
                {
                    Point p = new Point();
                    p.X = (int)_condition.AutomationElement.Current.BoundingRectangle.Left + x;
                    p.Y = (int)_condition.AutomationElement.Current.BoundingRectangle.Top + y;
                    KeyInput.Drag(p);
                    KeyInput.Drop(p);
                    return;
                }
                catch
                {

                }
            }
        }

        public void PressKeys(string keys)
        {
            this.PrepareForReplay();
            KeyInput.Sendkeys(keys);
        }

        protected void PrepareForReplay()
        {
            if (!this.Exist(2))
            {
                ControlSearcher.ThrowError(ErrorType.ObjectNotExist);
            }
            if (_condition.AutomationElement.Current.HasKeyboardFocus)
            {
                return;
            }

            AutomationElement rootwindow = UIAUtility.GetRootWindow(_condition.AutomationElement);
            if (rootwindow == null)
            {
                rootwindow = _condition.AutomationElement;
            }
            int rootWindowHandle = (int)rootwindow.Current.NativeWindowHandle;

            try
            {
                Point p;
                p = rootwindow.GetClickablePoint();
                SafeNativeMethods.SetForegroundWindow((IntPtr)rootWindowHandle);
                return;
            }
            catch
            {
            }

            //if Object can not get the clickble point, will try to get the parent.                            
            //try to make the root window to visible
            try
            {
                SafeNativeMethods.SetForegroundWindow((IntPtr)rootWindowHandle);
                Point p;
                p = rootwindow.GetClickablePoint();
                // if the window is visible now, start to check the object is out of screen.
                if (!_condition.AutomationElement.Current.IsOffscreen)
                {
                    ControlSearcher.ThrowError(ErrorType.ObjectIsOutOfScreen);
                }
                else
                {
                    return;
                }
            }
            catch
            {
            }
            // Window is not visible, start to make it visible
            SafeNativeMethods.ShowWindow((IntPtr)rootWindowHandle, 4);
            SafeNativeMethods.SetForegroundWindow((IntPtr)rootWindowHandle);

            //Check again
            try
            {
                string value = _condition.AutomationElement.Current.ClassName;
            }
            catch
            {
                ControlSearcher.ThrowError(ErrorType.CannotPerformThisOperation);
            }

            if (_condition.AutomationElement.Current.IsOffscreen)
            {
                return;
            }
            else
            {
                ControlSearcher.ThrowError(ErrorType.ObjectIsOutOfScreen);
            }

        }

        // Vertically=1, Horizontally=2
        private void ScrollBar(int type = 1, int value = 1)
        {
            Condition c = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.ScrollBar);
            Condition button = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Button);
            AutomationElementCollection iarray = _condition.AutomationElement.FindAll(TreeScope.Descendants, c);
            AutomationElement scrollbarobject = null;
            for (int i = 0; i < iarray.Count; i++)
            {

                if ((type == 1 && (iarray[i].Current.BoundingRectangle.Bottom - iarray[i].Current.BoundingRectangle.Top) >= (iarray[i].Current.BoundingRectangle.Right - iarray[i].Current.BoundingRectangle.Left))
                    || (type == 2 && (iarray[i].Current.BoundingRectangle.Bottom - iarray[i].Current.BoundingRectangle.Top) < iarray[i].Current.BoundingRectangle.Right - iarray[i].Current.BoundingRectangle.Left))
                {
                    scrollbarobject = iarray[i];
                    break;
                }
            }

            if (scrollbarobject != null)
            {
                AutomationElement abutton = null;
                iarray = scrollbarobject.FindAll(TreeScope.Children, button);

                if (value >= 0)
                {
                    abutton = iarray[iarray.Count - 1];
                }
                else
                {
                    abutton = iarray[0];
                }
                int hwnd = (int)abutton.Current.NativeWindowHandle;
                if (hwnd != 0)
                {
                    while (value != 0)
                    {
                        KeyInput.Click(KeyInput.MouseClickType.LClick, hwnd, 2, 2);
                        if (value < 0)
                            value++;
                        if (value > 0)
                            value--;
                    }
                }
                else
                {
                    try
                    {
                        Point p = new Point();
                        p.X = (int)abutton.Current.BoundingRectangle.Left + (int)((abutton.Current.BoundingRectangle.Right - abutton.Current.BoundingRectangle.Left) / 2);
                        p.Y = (int)abutton.Current.BoundingRectangle.Top + (int)((abutton.Current.BoundingRectangle.Bottom - abutton.Current.BoundingRectangle.Top) / 2);
                        while (value != 0)
                        {
                            KeyInput.Click(KeyInput.MouseClickType.LClick, p);
                            if (value < 0)
                                value++;
                            if (value > 0)
                                value--;
                        }
                        return;
                    }
                    catch { }

                    try
                    {
                        InvokePattern cinvoke = (InvokePattern)abutton.GetCurrentPattern(InvokePattern.Pattern);
                        while (value != 0)
                        {
                            cinvoke.Invoke();
                            if (value < 0)
                                value++;
                            if (value > 0)
                                value--;
                        }
                    }
                    catch
                    {
                    }
                }
            }
            else
                return;
        }

        // For Edit and Editor Class
        #region Editor and Editr class and methods
        public string Set(string value)
        {
            ClearAll();

            try
            {
                ValuePattern v = (ValuePattern)_condition.AutomationElement.GetCurrentPattern(ValuePattern.Pattern);
                v.SetValue(value);
                if (valuechecker(value))
                    return value;
            }
            catch
            { }

            try
            {
                ClearAll();
                KeyInput.Sendkeys(value);
                if (valuechecker(value))
                    return value;
            }
            catch
            { }

            try
            {
                ClearAll();
                KeyInput.SendKeys_A(_condition.AutomationElement.Current.NativeWindowHandle, value);
                if (valuechecker(value))
                    return value;
            }
            catch
            { }

            return "";
        }

        public void ClearAll()
        {
            this.PrepareForReplay();
            this.Click(2, 2);
            try
            {
                ValuePattern v = (ValuePattern)_condition.AutomationElement.GetCurrentPattern(ValuePattern.Pattern);
                v.SetValue("");
                return;
            }
            catch { }

            try
            {
                TextPattern t = (TextPattern)_condition.AutomationElement.GetCurrentPattern(TextPattern.Pattern);
                t.DocumentRange.Select();
                KeyInput.Sendkeys("{DELETE}");
                return;
            }
            catch { }

            try
            {
                this.Click();
                KeyInput.Sendkeys("^A");
                KeyInput.Sendkeys("{DELETE}");
                return;
            }
            catch
            { }
        }

        public bool ReadOnly
        {
            get
            {
                this.PrepareForReplay();
                try
                {
                    ValuePattern v = (ValuePattern)_condition.AutomationElement.GetCurrentPattern(ValuePattern.Pattern);
                    if (!v.Current.IsReadOnly)
                        return false;
                    else
                        return true;
                }
                catch { }

                try
                {
                    TextPattern t = (TextPattern)_condition.AutomationElement.GetCurrentPattern(TextPattern.Pattern);
                    return Convert.ToBoolean(t.DocumentRange.GetAttributeValue(TextPattern.IsReadOnlyAttribute));
                }
                catch
                {
                    ControlSearcher.ThrowError(ErrorType.CannotPerformThisOperation);
                }
                return false;
            }
        }

        public void SetCaretPos(int column)
        {
            this.PrepareForReplay();
            try
            {
                UnsafeNativeMethods.SendMessage((IntPtr)_condition.AutomationElement.Current.NativeWindowHandle, NativeMethods.EM_SETSEL, (IntPtr)column, (IntPtr)column);
            }
            catch { }
        }

        public void SetCaretPos(int line, int column)
        {
            return;
        }

        public void SetSelection(int startcolumn, int endcolumn)
        {
            this.PrepareForReplay();
            try
            {
                UnsafeNativeMethods.SendMessage((IntPtr)_condition.AutomationElement.Current.NativeWindowHandle, NativeMethods.EM_SETSEL, (IntPtr)startcolumn, (IntPtr)endcolumn);
            }
            catch { }
        }

        #endregion

        protected bool valuechecker(string value)
        {
            if (this.Text == value)
                return true;
            if (this.Value == value)
                return true;
            if (this.Name == value)
                return true;
            return false;
        }

        [ComVisible(false)]
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        [ComVisible(false)]
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        [ComVisible(false)]
        public override string ToString()
        {
            return base.ToString();
        }

        internal void SetCondition(UIACondition condition)
        {
            _condition = condition;
        }

    }


}
