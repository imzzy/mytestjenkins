using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;

using LPReplayCore;
using LPReplayCore.Interfaces;
using LPReplayCore.Model;
using LPReplayCore.Common;
using LPReplayCore.UIA;


namespace LPUIAObjects
{
    /// <summary>
    /// process the element properties 
    /// </summary>
    public class ElementProperties : IContext, IElementProperties
    {
        Dictionary<string, string> _properties;
        Dictionary<string, string> _recommendedProperties;
        Dictionary<string, string> _otherProperties;
        Dictionary<string, string> _selectedProperties;

        AutomationElement _element;

        string _name;

        public ElementProperties(AutomationElement element)
        {
            _element = element;
            _name = element.Current.Name;
            _properties = GetProperties(element);
            _recommendedProperties = FindRecommendedProperties(_properties);
            _otherProperties = GetOtherProperties(_recommendedProperties, _properties);
        }

#if TEST
        public ElementProperties(Dictionary<string, string> properties)
        {
            _properties = properties;
            _recommendedProperties = FindRecommendedProperties(_properties);
            _otherProperties = GetOtherProperties(_recommendedProperties, _properties);
        }
#endif

        private static Dictionary<string, string> FindRecommendedProperties(Dictionary<string, string> properties)
        {
            Dictionary<string, string> recommendedProperties = new Dictionary<string, string>();
            foreach (KeyValuePair<string, string> pair in properties)
            {
                switch (pair.Key)
                {
                    case UIAControlKeys.AutomationId:
                        if (!string.IsNullOrEmpty(pair.Value))
                        {
                            recommendedProperties.Add(pair.Key, pair.Value);
                        }
                        break;
                    case UIAControlKeys.Type:
                        if (!string.IsNullOrEmpty(pair.Value))
                        {
                            recommendedProperties.Add(pair.Key, pair.Value);
                        }
                        break;
                    case UIAControlKeys.ClassName:
                        if (!string.IsNullOrEmpty(pair.Value))
                        {
                            recommendedProperties.Add(pair.Key, pair.Value);
                        }
                        break;
                    case UIAControlKeys.Name:
                        if (!string.IsNullOrEmpty(pair.Value))
                        {
                            recommendedProperties.Add(pair.Key, pair.Value);
                        }
                        break;
                }
            }
            return recommendedProperties;
        }


        private static Dictionary<string, string> GetProperties(AutomationElement element)
        {
            Dictionary<string, string> pairs = new Dictionary<string, string>();

            pairs.Add(UIAControlKeys.AutomationId, element.Current.AutomationId);
            pairs.Add(UIAControlKeys.Type, element.Current.ControlType.ControlTypeToString());
            pairs.Add(UIAControlKeys.ClassName, element.Current.ClassName);
            pairs.Add(UIAControlKeys.Name, element.Current.Name);
            pairs.Add(UIAControlKeys.AccessKey, element.Current.AccessKey);
            pairs.Add(UIAControlKeys.HelpText, element.Current.HelpText);

            pairs.Add(UIAControlKeys.BoundingRectangle, element.Current.BoundingRectangle.ToString());

            //pairs.Add(ControlKeys.AttachedText, element.Current.LabeledBy);

            return pairs;
        }

        public static Dictionary<string, string> GetOtherProperties(Dictionary<string, string> recommendedProperties, Dictionary<string, string> properties)
        {
            Dictionary<string, string> otherProperties = new Dictionary<string, string>();

            foreach (KeyValuePair<string, string> pair in properties)
            {
                if (recommendedProperties.ContainsKey(pair.Key)) continue;

                otherProperties.Add(pair.Key, pair.Value);
            }

            return otherProperties;
        }

        public Dictionary<string, string> RecommendedProperties
        {
            get
            {
                return _recommendedProperties;
            }
        }

        public Dictionary<string, string> NoneEmptyProperties
        {
            get
            {
                Dictionary<String, String> properties = new Dictionary<string, string>();
                foreach (KeyValuePair<string, string> pair in _properties)
                {
                    if (!String.IsNullOrEmpty(pair.Value))
                    {
                        properties.Add(pair.Key, pair.Value);
                    }
                }

                return properties;
            }
        }

        public Dictionary<string, string> OtherProperties
        {
            get
            {
                return _otherProperties;
            }
        }

        public Dictionary<string, string> SelectedProperties
        {
            get
            {
                if (_selectedProperties == null)
                {
                    _selectedProperties = _recommendedProperties;
                }
                return _selectedProperties;
            }
            set
            {
                _selectedProperties = value;
            }
        }

        public ITestObject ToTestObject()
        {
            return this.ToNurseObject().TestObject;
        }

        public TestObjectNurse ToNurseObject()
        {
            UIATestObject testObject = new UIATestObject();

            foreach (KeyValuePair<string, string> pair in SelectedProperties)
            {
                testObject.Properties.Add(pair.Key, pair.Value);
            }
            
            testObject.AutomationElement = _element;

            testObject.ControlType = ControlType;
            testObject.NodeName = DerivedName;

            TestObjectNurse testNurse = new TestObjectNurse(testObject);

            foreach (KeyValuePair<string, string> pair in NoneEmptyProperties)
            {
                testNurse.CachedProperties.Add(pair.Key, pair.Value);
            }
            return testNurse;
        }

        private static int idSeed;
        private string _derivedName;
        public string DerivedName
        {
            get
            {
                if (!string.IsNullOrEmpty(_derivedName)) return _derivedName;
                string controlName;

                _properties.TryGetValue(ControlKeys.Name, out controlName);

                if (!string.IsNullOrEmpty(controlName))
                {
                    _derivedName = controlName;
                    return controlName;
                }

                string controlType;
                _properties.TryGetValue(ControlKeys.Type, out controlType);

                idSeed++;
                _derivedName = controlType + idSeed;
                return _derivedName;
            }
        }

#if TEST
        internal static void ResetSeed()
        {
            idSeed = 0;
        }
#endif
        public string Name
        {
            get
            {
                return _name;
            }
        }

        private BaseContext _context;

        private BaseContext Context
        {
            get
            {
                if (_context == null) _context = new BaseContext();
                return _context;
            }
        }

        public T GetContext<T>() where T : class
        {
            return Context.GetContext<T>();
        }

        public void SetContext<T>(T context) where T : class
        {
            Context.SetContext<T>(context);
        }

        public ControlType ControlType
        {
            get
            {
                string controlTypeString = null;
                _properties.TryGetValue(ControlKeys.Type, out controlTypeString);
                if (controlTypeString == null) return null;
                return controlTypeString.ToControlType();
            }
        }

        public string ControlTypeString
        {
            get
            {
                string controlTypeString = null;
                _properties.TryGetValue(ControlKeys.Type, out controlTypeString);
                return controlTypeString;
            }
        }

        public AutomationElement AutomationElement
        {
            get
            {
                return this._element;
            }
        }
    }
}
