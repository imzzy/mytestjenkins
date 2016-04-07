using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Windows.Forms;
using LPReplayCore;
using LPReplayCore.Interfaces;
using LPReplayCore.Model;
using LPReplayCore.UIA;
using LPReplayCore.Common;
using System.Collections.ObjectModel;

namespace LPUIAObjects
{
    public class UIACondition: IContext
    {
        private string _attachedText = "";

        private string _left = "", _right = "";

        private ITestObject _testObject;

        private int _hwnd = -1, _processId = -1;

        private int _conditionCount = 0;

        private List<String> _setToPropertyList = new List<string>();

        private Condition _condition = null;


        private bool _isIndexOnly = true, iswindow = false;

        public object UIAObject = null;

        CachedPropertyGroup _cachedProperties;

        public Dictionary<string, string> CachedProperties
        {
            get 
            {
                if (_cachedProperties == null)
                {
                    _cachedProperties = new CachedPropertyGroup();
                    TestObject.SetContext<CachedPropertyGroup>(_cachedProperties);
                }
                return _cachedProperties.Properties; 
            }
            set 
            {
                _cachedProperties = new CachedPropertyGroup();
                TestObject.SetContext<CachedPropertyGroup>(_cachedProperties);
                _cachedProperties.Properties = value; 
            }
        }

        private void Init(ITestObject testObject)
        {
            _testObject = (UIATestObject) testObject;

            _cachedProperties = testObject.GetContext<CachedPropertyGroup>();
        }

        public UIACondition(string conditionString)
        {
            ITestObject testObject = ParseToTestObject(conditionString);

            testObject.SetContext(this);

            Init(testObject);
        }

        public static UIACondition GetCondition(string conditionString)
        {
            return GetCondition(AppModel.Current, conditionString);
        }

        public static UIACondition GetCondition(AppModel model, string conditionString)
        {
            string nodeName = conditionString;

            ITestObject testObject = model.GetTestObject(nodeName);

            return GetCondition(testObject);
        }

        public static UIACondition GetCondition(ITestObject testObject)
        {
            if (testObject == null) return null;

            UIACondition condition = testObject.GetContext<UIACondition>();
            if (condition == null)
            {
                condition = new UIACondition(testObject);
            }
            return condition;
        }

        private static ITestObject ParseToTestObject(string conditionString)
        {
            //TODO: parse the string
            string nodeName = conditionString;

            ITestObject testObject = AppModel.Current.GetTestObject(nodeName);
            return testObject;
        }

        //use this to create the condition by description language.
        public UIACondition(ITestObject testObject)
        {
            testObject.SetContext(this);
            Init(testObject);
        }

        //use this to create the condition by Repository
        public UIACondition(ITestObject testObject, UIACondition parentCondition)
        {
            //testObject.Parent = parentCondition.TestObject;
//            _parentCondition = parentCondition;

            if (parentCondition != null)
            {
                testObject.Parent = parentCondition.TestObject;
            }
            testObject.SetContext(this);
            Init(testObject);
        }
        /*
        // use this to create condition in Repository, if the AutomationElement exists.
        public UIACondition(TreeNode treeNode, string nodeName, string leftName = "", string rightName = "")
        {
            AutomationElement element = ((UIACondition)treeNode.Tag).AutomationElement;

            if (leftName != "")
            {
                _left = leftName;
            }

            if (rightName != "")
            {
                _right = rightName;
            }

            UIAUtility.InitProperties(nodeName, element, TestObject);

            InitNode(treeNode, element);
        }*/

        // use this to create condition in Add object window
        public UIACondition(AutomationElement element)
        {
            TestObject = UIAUtility.CreateTestObject(element);

            /* try to avoid using NativeWindowHandle
            if (_conditionCount == 0)
            {
                try
                {
                    if (element.Current.NativeWindowHandle != 0)
                    {
                        _hwnd = (int)element.Current.NativeWindowHandle;
                        return;
                    }
                }
                catch { }
            }*/
        }

        public UIACondition(AutomationElement element, ElementProperties properties)
        {
            foreach (KeyValuePair<string, string> pair in properties.SelectedProperties)
            {
                TestObject.Properties.Add(pair.Key, pair.Value);
            }
            
            foreach (KeyValuePair<string, string> pair in properties.NoneEmptyProperties)
            {
                this.CachedProperties.Add(pair.Key, pair.Value);
            }
            TestObject.AutomationElement = element;

            TestObject.ControlType = properties.ControlType;
            TestObject.NodeName = properties.DerivedName;

            //UIAUtility.InitProperties(string.Empty, element, TestObject);
            /* try to avoid using NativeWindowHandle
            if (_conditionCount == 0)
            {
                try
                {
                    if (element.Current.NativeWindowHandle != 0)
                    {
                        _hwnd = (int)element.Current.NativeWindowHandle;
                        return;
                    }
                }
                catch { }
            }*/
        }

        //use this to show the properties in the adding properties window
        public UIACondition(AutomationElement element, string nodeName, string leftName = "", string rightName = "")
        {

            if (leftName != "")
            {
                _left = leftName;
            }

            if (rightName != "")
            {
                _right = rightName;
            }

            UIAUtility.InitProperties(nodeName, element, TestObject);

            try
            {
                if (element.Current.NativeWindowHandle != 0)
                {
                    _hwnd = (int)element.Current.NativeWindowHandle;
                }
            }
            catch { }

            try
            {
                if (element.Current.ProcessId > 0)
                {
                    _processId = element.Current.ProcessId;
                }
            }
            catch
            { }
        }

        private void InitNode(TreeNode treeNode, AutomationElement element)
        {

            //use index
            if (_conditionCount == 0)
            {
                try
                {
                    if (element.Current.NativeWindowHandle != 0)
                    {
                        _hwnd = (int)element.Current.NativeWindowHandle;
                        _conditionCount++;
                        return;
                    }
                }
                catch { }

            }
        }

        public ControlType ControlType
        {
            get
            {
                return TestObject.ControlType;
            }
            set
            {
                TestObject.ControlType = value;
            }
        }

        public string ControlName
        {
            get
            {
                return TestObject.ControlName;
            }
            set
            {
                TestObject.ControlName = value;
            }
        }

        public string Title
        {
            get
            {
                string title = null;
                TestObject.Properties.TryGetValue(ControlKeys.Title, out title);
                return title;
            }
            set
            {
                TestObject.Properties[ControlKeys.Title] = value;
            }
        }

        public int Index
        {
            get
            {
                return TestObject.Index;
            }
            set
            {
                TestObject.Index = value;
            }
        }

        public string AttachedText
        {
            get
            {
                return _attachedText;
            }
        }

        public string Text
        {
            get
            {
                return GetNullableProperty(ControlKeys.Text);
            }
            set
            {
                TestObject.Properties[ControlKeys.Text] = value;
            }
        }

        private string GetNullableProperty(string key)
        {
            string text = null;
            TestObject.Properties.TryGetValue(key, out text);
            return text;
        }

        public string Left
        {
            get
            {
                return _left;
            }
        }

        public string Right
        {
            get
            {
                return _right;
            }
        }

        public int Hwnd
        {
            get
            {
                return _hwnd;
            }
        }

        public int ProcessID
        {
            get
            {
                return _processId;
            }
        }

        public string HelpText
        {
            get
            {
                return GetNullableProperty(UIAControlKeys.HelpText);
            }
            set
            {
                TestObject.Properties[UIAControlKeys.HelpText] = value;
            }
        }

        public string URL
        {
            get
            {
                return GetNullableProperty(ControlKeys.Url);
            }
            set
            {
                TestObject.Properties[ControlKeys.Url] = value;
            }
        }

        public string NodeName
        {
            get
            {
                return _testObject.NodeName ;
            }

            set
            {
                _testObject.NodeName = value;
            }
        }

        public bool IsIndexOnly
        {
            get
            {
                return _isIndexOnly;
            }
        }

        public bool IsWindow
        {
            get
            {
                return iswindow;
            }
        }

        public UIATestObject TestObject
        {
            get
            {
                if (_testObject == null)
                {
                    _testObject = new UIATestObject();
                    _testObject.SetContext(this);
                }
                return (UIATestObject)_testObject;
            }

            set
            {
                _testObject = (UIATestObject) value;
                _testObject.SetContext(this);
            }

        }

        public UIACondition ParentCondition
        {
            get
            {
                if (TestObject.Parent == null) return null;

                return TestObject.Parent.GetContext<UIACondition>();
            }
        }

        public List<string> SetToPropertyList
        {
            get
            {
                return _setToPropertyList;
            }

            set
            {
                _setToPropertyList = value;
            }
        }

        public AutomationElement AutomationElement
        {
            get
            {
                return TestObject.AutomationElement;
            }

            set
            {
                TestObject.AutomationElement = value;
            }
        }

        public IEnumerable<UIACondition> Children
        {
            get
            {
                List<UIACondition> conditions = new List<UIACondition>();
                foreach (UIATestObject testObject in _testObject.Children)
                {
                    conditions.Add(testObject.GetContext<UIACondition>());
                }
                return conditions;
            }
        }

        public Condition Condition
        {
            get
            {
                return _condition;
            }

            set
            {
                _condition = value;
            }
        }

        public bool Match(AutomationElement element)
        {
            UIAConditionMatcher matcher = new UIAConditionMatcher();

            //positive match
            bool matched = matcher.Match(this.TestObject, element);

            return matched;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        // check the object and type already exists in our container(Window,Pane, AntsAutomation) list.
        public UIACondition CheckUIAConditionExists(UIATestObject testObject, ControlType controlType)
        {
            foreach (UIACondition uiaCondition in Children)
            {
                //TODO need to create the match logic
                if (uiaCondition._testObject.Equals(testObject)
                    && uiaCondition.ParentCondition == this 
                    && uiaCondition.ControlType == controlType)
                {
                    return uiaCondition;
                }
            }
            return null;
        }


        public void AddChild(UIACondition childCondition)
        {
            //_childConditions.Add(childCondition);
            this.TestObject.AddChild(childCondition.TestObject);
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
    }
}
