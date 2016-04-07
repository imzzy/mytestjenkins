using LPReplayCore;
using LPReplayCore.Model;
using LPUIAObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LPSpy
{

    /// <summary>
    /// An extension of PropertyBag that manages a table of property values, in
    /// addition to firing events when property values are requested or set.
    /// </summary>
    public class TestObjectPropertyBag : PropertyBag, IDisposable
    {
        private TestObjectNurse _testNurse;

        public delegate void PropertyChangedDelegate();

        public event PropertyChangedDelegate PropertyChanged;

        /// <summary>
        /// Initializes a new instance of the PropertyTable class.
        /// </summary>
        public TestObjectPropertyBag(TestObjectNurse testNurse)
        {
            _testNurse = testNurse;

            PropertySpec[] specs = AddProperties();

            Properties.AddRange(specs);
        }

        private PropertySpec[] AddProperties()
        {
            List<PropertySpec> properties = new List<PropertySpec>();

            foreach (KeyValuePair<string, string> pair in _testNurse.TestObject.Properties)
            {
                AddProperty(properties, pair.Key, "Identifying Properties");
            }

            foreach (KeyValuePair<string, string> pair in _testNurse.CachedProperties)
            {
                if (!_testNurse.TestObject.Properties.ContainsKey(pair.Key))
                {
                    AddProperty(properties, pair.Key, "Others Properties");
                }
            }

            //PropertySpecSorter sorter = new PropertySpecSorter();
            //properties.Sort(sorter);
            return properties.ToArray();
        }

        private void AddProperty(List<PropertySpec> properties, string key, string category)
        {
            PropertySpec spec = new PropertySpec(key, ControlKeysManager.GetDisplayString(key), typeof(string), category,
                ControlKeysManager.GetDisplayString(key) /*description*/
                , null);
            
            if (key == ControlKeys.Type || key == ControlKeys.ImagePath)
            {
                spec.Attributes = new Attribute[] {ReadOnlyAttribute.Yes};
            }
            properties.Add(spec);
        }

        /// <summary>
        /// Gets or sets the value of the property with the specified name.
        /// <p>In C#, this property is the indexer of the PropertyTable class.</p>
        /// </summary>
        public object this[string key]
        {
            get 
            {
                if (_testNurse.TestObject.Contains(key))
                {
                    return _testNurse.TestObject[key];
                }
                else
                {
                    return _testNurse.CachedProperties[key];
                }
            }
            set {
                if (_testNurse.TestObject.Contains(key))
                {
                    _testNurse.TestObject.Properties[key] = value.ToString();
                }
                else
                {
                    _testNurse.CachedProperties[key] = value.ToString();
                }
            }
        }
        /*
        public override PropertyDescriptorCollection GetProperties()
        {
            if (m_pdl.Count == 0)
            {
                PropertyDescriptorCollection pdc = base.GetProperties();
                foreach (PropertyDescriptor pd in pdc)
                {
                    if (!(pd is CustomPropertyDescriptor))
                    {
                        CustomPropertyDescriptor cpd = new CustomPropertyDescriptor(base.GetPropertyOwner(pd), pd);
                        m_pdl.Add(cpd);
                    }
                }
            }

            List<CustomPropertyDescriptor> pdl = m_pdl.FindAll(pd => pd != null);

            PropertyDescriptorCollection pdcReturn = SortProperties(m_pdl);

            return pdcReturn;
        }*/

        /// <summary>
        /// This member overrides PropertyBag.OnGetValue.
        /// </summary>
        protected override void OnGetValue(PropertySpecEventArgs e)
        {
            e.Value = this[e.Property.Name];
            base.OnGetValue(e);
        }

        /// <summary>
        /// This member overrides PropertyBag.OnSetValue.
        /// </summary>
        protected override void OnSetValue(PropertySpecEventArgs e)
        {
            string oldValue = this[e.Property.Name] as string;

            this[e.Property.Name] = e.Value;
            base.OnSetValue(e);

            string newValue = e.Value as string;
            if (oldValue != newValue)
            {
                PropertyChanged();
            }
        }

        public void Dispose()
        {
            
        }
    }
}
