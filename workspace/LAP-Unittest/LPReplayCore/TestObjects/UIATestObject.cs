using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using LPCommon;
using LPReplayCore.Interfaces;
using LPReplayCore.Model;
using LPReplayCore.Common;
using System.Windows;
using System.Drawing;

namespace LPReplayCore.UIA
{

    using PropertiesDictionary = System.Collections.Generic.Dictionary<string, string>;
    using TestObjectList = List<ITestObject>;
    

    //convert the descriptor to Automation elements
    public class UIATestObject : TestObjectBase, ITestObject, ITOFactory<UIATestObject>
    {
        static ILogger _Logger = LogFactory.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);//"LPReplayCore.UIA.UIAFinder");

        AutomationElement _element;

        VisualRelationPropertyItem _relation;

        private ControlType _type;

        public UIATestObject()
        {
        }

        public UIATestObject(string name, ControlType type, PropertiesDictionary identityProperties)
        {
            this.NodeName = name;
            this.ControlType = type;

            if (identityProperties != null)
            {
                _properties = new PropertiesDictionary(identityProperties);
            }
        }

        public UIATestObject(ObjectDescriptor descriptor)
        {
            _nodeName = descriptor.Name;

            _description = descriptor.Description;

            _relation = descriptor.GetItem<VisualRelationPropertyItem>();

            IdentifyPropertyGroup propertyItem = descriptor.GetItem<IdentifyPropertyGroup>();

            CachedPropertyGroup cachedItem = descriptor.GetItem<CachedPropertyGroup>();

            if (cachedItem != null) SetContext<CachedPropertyGroup>(cachedItem);

            _properties = (propertyItem != null) ? propertyItem.Properties : new PropertiesDictionary();

            if (_properties.ContainsKey(UIAControlKeys.Type))
            {
                _type = _properties[UIAControlKeys.Type].ToControlType();
            }
            if (_children == null) _children = new TestObjectList();
            /*
            if (descriptor.Children != null)
            {
                foreach (ObjectDescriptor child in descriptor.Children)
                {
                    new UIATestObject(child, this);
                }
            }*/
        }

        public UIATestObject(ObjectDescriptor descriptor, ITestObject parent):this(descriptor)
        {
            _parent = parent;

            if (parent != null) parent.AddChild(this);
        }

        #region Static methods

        public static UIATestObject ToTestObject(ObjectDescriptor descriptor)
        {
            if (descriptor == null) throw new ArgumentException("Argument cannot be null");
            return new UIATestObject(descriptor);
        }

        public static AutomationElement ToAutomationObject(ITestObject testObject)
        {
            return (AutomationElement)testObject.GetAutomationObject();
        }

        #endregion

        #region ITestObject Interface

        public override ObjectDescriptor GetDescriptor()
        {
            ObjectDescriptor descriptor = new ObjectDescriptor();
            descriptor.Type = NodeType.UIAControl;
            descriptor.Name = this.NodeName;
            descriptor.Description = this.Description;

            if (_relation != null)
            {
                descriptor.SetItem<VisualRelationPropertyItem>(_relation);
            }

            IdentifyPropertyGroup item = new IdentifyPropertyGroup();

            item.Properties = _properties;
            item.Properties[ControlKeys.Type] = _type.ControlTypeToString();

            descriptor.SetItem<IdentifyPropertyGroup>(item);

            CachedPropertyGroup cachedGroup = GetContext<CachedPropertyGroup>();
            if (cachedGroup != null)
            {
                descriptor.SetItem<CachedPropertyGroup>(cachedGroup);
            }

            foreach (ITestObject to in Children)
            {
                ObjectDescriptor childDescriptor = to.GetDescriptor();
                descriptor.Children.Add(childDescriptor);
                childDescriptor.Parent = descriptor;
            }

            return descriptor;
        }

        

        #endregion


        public bool TryInvoke()
        {
            InvokePattern pattern = _element.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
            if (pattern == null) return false;
            pattern.Invoke();
            return true;
        }


        public UIATestObject CreateTestObject(ObjectDescriptor descriptor, ModelLoadLevel loadLevel = ModelLoadLevel.ReplayOnly)
        {
            return UIAUtility.CreateTestObject(descriptor, loadLevel);
        }

        public override object GetAutomationObject()
        {
            return AutomationElement;
        }


        //the name given by the application
        public override string ControlName
        {
            get
            {
                string name;
                _properties.TryGetValue(ControlKeys.Name, out name);
                return name;
            }
            set
            {
                _properties[ControlKeys.Name] = value;
            }
        }

        public ControlType ControlType
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
                if (_type != null)
                {
                    _properties[ControlKeys.Type] = _type.ControlTypeToString();
                }
                else
                {
                    _properties.Remove(ControlKeys.Type);
                }
            }
        }

        public override string ControlTypeString
        {
            get
            {
                if (_type != null)
                {
                    return _type.ControlTypeToString();
                }
                return null;
            }
        }


        public override PropertiesDictionary Properties
        {
            get
            {
                //TODO, consider convert it to readonly
                return _properties;
            }
        }
        

        static ReadOnlyCollection<ITestObject> _emptyChildren = (new List<ITestObject>()).AsReadOnly();
        
        //add duplicate property will overwrite existing one
        public override void AddProperty(string key, string value)
        {
            _properties[key] = value;
            if (key == ControlKeys.Type)
            {
                _type = value.ToControlType();
            }
        }

        //remove the property from the test object
        public override void RemoveProperty(string key)
        {
            _properties.Remove(key);
            if (key == ControlKeys.Type)
            {
                _type = null;
            }
        }


        public AutomationElement AutomationElement 
        {
            get
            {
                if (_element == null)
                {
                    _element = UIAFinder.Find(this);
                }
                return _element;
            }
            set
            {
                _element = value;
            }
        }


        public override bool RemoveChild(ITestObject testObject)
        {
            int index;
            if ((index = _children.FindIndex(to => to == testObject)) >= 0)
            {
                _children.RemoveAt(index);//.Remove(testObject.NodeName);
                return true;
            }
            else
            {
                return false;
            }
        }


        public override IRelation Relation
        {
            get
            {
                //TODO, convert relation name to instance
                return null;
                //throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override bool HasProperty(string key)
        {
            return this.Properties.ContainsKey(key);
        }

        public Condition GetCondition()
        {

            Dictionary<AutomationProperty, object> properties = new Dictionary<AutomationProperty, object>();

            foreach (KeyValuePair<string, string> property in Properties)
            {
                string name = (string)property.Key;
                string value = (string)property.Value;
                switch (name)
                {
                    case UIAControlKeys.ClassName:
                        properties.Add(AutomationElement.ClassNameProperty, value);
                        break;
                    case UIAControlKeys.AutomationId:
                        properties.Add(AutomationElement.AutomationIdProperty, value);
                        break;
                    case UIAControlKeys.Type:
                        if (ControlType != null)
                        {
                            properties.Add(AutomationElement.ControlTypeProperty, ControlType);
                        }
                        break;
                    case UIAControlKeys.Name:
                        properties.Add(AutomationElement.NameProperty, value);
                        break;
                    case UIAControlKeys.Title:
                        properties.Add(AutomationElement.NameProperty, value);
                        break;
                    case UIAControlKeys.Handle:
                    case UIAControlKeys.HWnd:
                        int hwnd = Convert.ToInt32(value);
                        properties.Add(AutomationElement.NativeWindowHandleProperty, hwnd);
                        break;
                    case UIAControlKeys.ProcessId:
                        int processId = Convert.ToInt32(value);
                        properties.Add(AutomationElement.ProcessIdProperty, processId);
                        break;
                    case UIAControlKeys.HelpText:
                        string helpText = value;
                        properties.Add(AutomationElement.HelpTextProperty, helpText);
                        break;
                    case UIAControlKeys.Url:
                        string url = value;
                        properties.Add(ValuePattern.ValueProperty, url);
                        break;
                }
            }

            _Logger.WriteLog(LogTypeEnum.Debug, () =>
                {
                    StringBuilder builder = new StringBuilder();
                    builder.AppendLine("Conditions: {");
                    foreach (KeyValuePair<AutomationProperty, object> p in properties)
                    {
                        string key = p.Key.ProgrammaticName;
                        string value;
                        if (p.Value is ControlType)
                        {
                            value = ((ControlType)p.Value).ControlTypeToString();
                        }
                        else
                            value = p.Value.ToString();

                        builder.AppendLine(key + ": " + value);
                    }
                    builder.AppendLine("}");
                    return builder.ToString();
                });

            Condition condition = null;

            foreach (KeyValuePair<AutomationProperty, object> p in properties)
            {
                if (condition == null)
                {
                    condition = new PropertyCondition(p.Key, p.Value);
                }
                else
                {
                    condition = new AndCondition(condition, new PropertyCondition(p.Key, p.Value));
                }
            }

            return condition;
        }

        #region Properties
        public override int Index
        {
            get
            {
                int value = -1;
                if (Properties.ContainsKey(UIAControlKeys.Index))
                {
                    int.TryParse(Properties[UIAControlKeys.Index], out value);
                }
                return value;
            }
            set
            {
                Properties[UIAControlKeys.Index] = value.ToString();
            }
        }

        public string Text
        {
            get
            {
                string value = null;
                Properties.TryGetValue(ControlKeys.Text, out value);
                return value;
            }
            set
            {
                Properties[ControlKeys.Text] = value;
            }
        }

        public override string AutomationId
        {
            get
            {
                return Properties[UIAControlKeys.AutomationId];
            }
            set
            {
                Properties[UIAControlKeys.AutomationId] = value;
            }
        }

        #endregion

    }
}
