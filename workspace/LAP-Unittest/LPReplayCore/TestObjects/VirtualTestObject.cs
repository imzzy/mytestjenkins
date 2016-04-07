using LPReplayCore.Interfaces;
using LPReplayCore.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LPReplayCore.UIA
{
    //TODO implement VirtualTestObject
    public class VirtualTestObject : TestObjectBase, IEquatable<VirtualTestObject>
    {
        public VirtualTestObject()
        {
        }
        
        public Rect _rect;

        public VirtualTestObject(string name, Rectangle rect)
        {
            this.NodeName = name;
            this.BoundingRect = new Rect(rect.Left, rect.Top, rect.Width, rect.Height);
        }

        public VirtualTestObject(string name, System.Windows.Rect rect)
        {
            this.NodeName = name;
            this.BoundingRect = rect;
        }

        public override ObjectDescriptor GetDescriptor()
        {
            ObjectDescriptor descriptor = base.GetDescriptor();
            
            descriptor.Type = NodeType.VirtualControl;
            
            IdentifyPropertyGroup item = new IdentifyPropertyGroup();

            item.Properties = new Dictionary<string, string>();
            item.Properties[UIAControlKeys.BoundingRectangle] = RectToString(_rect);
            descriptor.SetItem(item);

            return descriptor;
        }

        private string RectToString(Rect rect)
        {
            return string.Format("{0},{1},{2},{3}", rect.Left, rect.Top, rect.Width, rect.Height);
        }

        internal static VirtualTestObject CreateTestObject(ObjectDescriptor descriptor, ModelLoadLevel loadLevel)
        {
            IdentifyPropertyGroup propertyItem = descriptor.GetItem<IdentifyPropertyGroup>();
            string boundingRect = propertyItem.Properties[UIAControlKeys.BoundingRectangle];

            Rect rect = StringRectToRect(boundingRect);

            VirtualTestObject testObject = new VirtualTestObject(descriptor.Name, rect);

            return testObject;
        }

        internal static Rect StringRectToRect(string boundingRect)
        {
            if (boundingRect == null) return Rect.Empty;

            string[] parts = boundingRect.Split(',');

            Debug.Assert(parts.Length == 4);

            int left = int.Parse(parts[0]), top = int.Parse(parts[1]);
            int width = int.Parse(parts[2]), height = int.Parse(parts[3]);

            return new Rect(left, top, width, height);
        }

        public Rect BoundingRect 
        {
            get
            {
                return _rect;
            }
            set
            {
                _rect = value;
                Properties[UIAControlKeys.BoundingRectangle] = RectToString(_rect);
            }
        }

        public Rectangle BoundingRectangle
        {
            get
            {
                return new Rectangle((int)_rect.Left, (int)_rect.Top, (int)_rect.Width, (int)_rect.Height);
            }
            set
            {
                _rect = new Rect(value.Left, value.Top, value.Width, value.Height);
                Properties[UIAControlKeys.BoundingRectangle] = RectToString(_rect);
            }
        }

        public override string ControlTypeString
        {
            get { return NodeType.VirtualControl; }
        }

        public override bool Equals(object obj)
        {
            VirtualTestObject testObject = obj as VirtualTestObject;
            return this.Equals(testObject);
        }

        public override int GetHashCode()
        {
            return (this.NodeName + RectToString(_rect)).GetHashCode();
        }

        public static bool operator ==(VirtualTestObject obj1, VirtualTestObject obj2)
        {
            return (Object.ReferenceEquals(null, obj1) && Object.ReferenceEquals(null, obj2))
                || (Object.ReferenceEquals(null, obj1) && obj2.Equals(obj1))
                || (obj1.Equals(obj2));
        }

        public static bool operator !=(VirtualTestObject obj1, VirtualTestObject obj2)
        {
            return !(obj1 == obj2);
        }

        public bool Equals(VirtualTestObject testObject)
        {
            if (testObject == null) return false;

            if (this.NodeName != testObject.NodeName) return false;

            if (this._rect != testObject.BoundingRect) return false;

            return true;
        }

        public void Click()
        {
            Assert.IsTrue(this.Parent != null);
            UIATestObject parentObject = (UIATestObject)this.Parent;
            
            Rect? tempRect = UIAHighlight.HighlightVirtualControl(parentObject.AutomationElement, this.BoundingRect);
            if (tempRect == null) return;

            Rect rect = (Rect)tempRect;
            ClickOnPointTool.ClickOnPoint((IntPtr)null, new System.Windows.Point(rect.Left + 10, rect.Top + 10));
            //InvokePattern invokePattern = (InvokePattern)parentObject.AutomationElement.GetCurrentPattern(InvokePattern.Pattern);
        }

        private System.Drawing.Point GetPointToClick(UIATestObject parentObject, Rect rect)
        {
            throw new NotImplementedException();
        }

        public static void ClickPosition(IntPtr hWnd, System.Windows.Point point)
        {
            ClickOnPointTool.ClickOnPoint(hWnd, point);
        }

        public void HighlightControl()
        {
            UIATestObject parentObject = (UIATestObject)this.Parent;
            UIAHighlight.HighlightVirtualControl(parentObject.AutomationElement, this.BoundingRect);
        }
    }
}
