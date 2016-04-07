using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LPSpy
{
    public partial class PropertyBag
    {
        #region PropertySpecDescriptor class definition
        private class PropertySpecDescriptor : PropertyDescriptor
        {
            private PropertyBag bag;
            private PropertySpec item;

            public PropertySpecDescriptor(PropertySpec item, PropertyBag bag, string name, Attribute[] attrs) :
                base(name, attrs)
            {
                this.bag = bag;
                this.item = item;
            }

            public override Type ComponentType
            {
                get { return item.GetType(); }
            }

            public override bool IsReadOnly
            {
                get { return (Attributes.Matches(ReadOnlyAttribute.Yes)); }
            }

            public override Type PropertyType
            {
                get { return Type.GetType(item.TypeName); }
            }

            public override bool CanResetValue(object component)
            {
                if (item.DefaultValue == null)
                    return false;
                else
                    return !this.GetValue(component).Equals(item.DefaultValue);
            }

            public override object GetValue(object component)
            {
                // Have the property bag raise an event to get the current value
                // of the property.

                PropertySpecEventArgs e = new PropertySpecEventArgs(item, null);
                bag.OnGetValue(e);
                return e.Value;
            }

            public override void ResetValue(object component)
            {
                SetValue(component, item.DefaultValue);
            }

            public override void SetValue(object component, object value)
            {
                // Have the property bag raise an event to set the current value
                // of the property.

                PropertySpecEventArgs e = new PropertySpecEventArgs(item, value);
                bag.OnSetValue(e);
            }

            public override bool ShouldSerializeValue(object component)
            {
                object val = this.GetValue(component);

                if (item.DefaultValue == null && val == null)
                    return false;
                else
                    return !val.Equals(item.DefaultValue);
            }
        }
        #endregion
    }
}
