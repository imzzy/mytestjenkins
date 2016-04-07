using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LPReplayCore.Model
{

    public class ControlKeysManager
    {
        public static string GetDisplayString(string persistedString, string ctrltypeHeader = "")
        {
            if (ctrltypeHeader.StartsWith("Web"))
            {
                return WebControlKeys.Instance.GetDisplayString(persistedString);
            }
            return UIAControlKeys.Instance.GetDisplayString(persistedString);
        }

        public static string GetKeyString(string displayName, string ctrltypeHeader = "")
        {
            if (ctrltypeHeader.StartsWith("Web"))
            {
                return WebControlKeys.Instance.GetKeyString(displayName);
            }
            return UIAControlKeys.Instance.GetKeyString(displayName);
        }
    }

    public class ControlKeys
    {
        //below are common control keys across technologies

        public const string Name = "name";
        public const string Type = "type";
        public const string Text = "text";

        public const string Url = "url";
        public const string Title = "title";

        public const string Index = "index";

        //snapshot image path
        public const string ImagePath = "imgPath";

        private Dictionary<string, string> key_displayName_mapping;
        private Dictionary<string, string> displayName_key_mapping;

        public ControlKeys()
        {

            key_displayName_mapping = new Dictionary<string, string>();
            displayName_key_mapping = new Dictionary<string, string>();
        }

        protected void GetDisplayStringMappings(Type type)
        {
            FieldInfo[] properties = type.GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.GetField);

            foreach (FieldInfo property in properties)
            {
                string value = (type.InvokeMember(property.Name, BindingFlags.Static | BindingFlags.Public | BindingFlags.GetField, null, null, null)) as string;
                if (value != null)
                {
                    key_displayName_mapping.Add(value, property.Name);
                    displayName_key_mapping.Add(property.Name, value);
                }
                

            }
        }

        public string GetDisplayString(string persistedString)
        {
            string displayString = null;
            key_displayName_mapping.TryGetValue(persistedString, out displayString);
            return displayString;
        }

        public string GetKeyString(string displayName)
        {
            string keyString = null;
            displayName_key_mapping.TryGetValue(displayName, out keyString);
            return keyString;
        }
    }

    public class WebControlKeys: ControlKeys
    {
        public const string ID = "id";
        public const string TagName = "tagname";
        public const string Class = "class";
        public const string BoundingRectangle = "boundingRectangle";

        //WebLink
        public const string Role = "role";

        //WebImage
        public const string Alt = "alt";

        //WebImage, WebFrame
        public const string Src = "src";

        //WebButton
        public const string AttrType = "attrtype";

        //browser
        public const string URL = "URL";

        //WebTable
        public const string Width = "width";
        //WebTable
        public const string Height = "height";
        //
        public const string IndexofTags = "indexoftags";

        public const string CssSelector = "cssSelector";


        public WebControlKeys()
        {
            GetDisplayStringMappings(typeof(ControlKeys));
            GetDisplayStringMappings(typeof(WebControlKeys));
        }

        public static ControlKeys _instance;

        public static ControlKeys Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new WebControlKeys();
                }
                return _instance;
            }
        }
    }

    public class UIAControlKeys: ControlKeys
    {
        public const string HWnd = "hwnd";
        public const string AttachedText = "attachedtext";
        public const string Handle = "handle";
        public const string ProcessId = "processid";
        public const string HelpText = "helptext";
        public const string AutomationId = "automationId";
        public const string ClassName = "className";
        public const string AccessKey = "accessKey";
        public const string BoundingRectangle = "boundingRectangle";
        private static Dictionary<string, string> key_displayName_mapping;
        private static Dictionary<string, string> displayName_key_mapping;

        public UIAControlKeys()
        {
            GetDisplayStringMappings(typeof(ControlKeys));
            GetDisplayStringMappings(typeof(UIAControlKeys));
        }

        public static ControlKeys _instance;

        public static ControlKeys Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UIAControlKeys();
                }
                return _instance;
            }
        }
    }
}
