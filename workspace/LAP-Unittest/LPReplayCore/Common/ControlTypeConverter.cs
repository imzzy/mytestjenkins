using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace LPReplayCore.Common
{

    public static class ControlTypeConverter
    {

        public static Dictionary<String, ControlType> _controlTypeMapper;
        public static Dictionary<ControlType, String> _controlTypeReverseMapper;


        internal static Dictionary<string, ControlType> GetControlTypeMappings()
        {
            Dictionary<string, ControlType> mapping = new Dictionary<string, ControlType>();

            FieldInfo[] properties = typeof(ControlType).GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.GetField);
            foreach (FieldInfo property in properties)
            {
                ControlType type = (typeof(ControlType).InvokeMember(property.Name, BindingFlags.Static | BindingFlags.Public | BindingFlags.GetField, null, null, null)) as ControlType;
                if (type == null) continue;
                AutomationIdentifier id = type;

                string typeString = id.ProgrammaticName;
                string shortTypeString = typeString.Substring(typeString.IndexOf('.') + 1);

                mapping.Add(shortTypeString, type);
            }
            return mapping;
        }

        static ControlTypeConverter()
        {
            _controlTypeMapper = GetControlTypeMappings ();
            /*= new Dictionary<string, ControlType>()
            {
                {"Window", ControlType.Window},
                {"Pane", ControlType.Pane},
                {"Document", ControlType.Document},
                {"Edit", ControlType.Edit},
                {"Button", ControlType.Button},
                {"CheckBox", ControlType.CheckBox},
                {"List", ControlType.List},
                {"RadioButton", ControlType.RadioButton},
                {"MenuBar", ControlType.MenuBar},
                {"ToolBar", ControlType.ToolBar},
                {"Tree", ControlType.Tree},
                {"Text", ControlType.Text},
                {"Table", ControlType.Table},
                {"ScrollBar", ControlType.ScrollBar},
                {"ComboBox", ControlType.ComboBox},
                {"Slider", ControlType.Slider},
                {"Tab", ControlType.Tab},
                {"Menu", ControlType.Menu},
                {"Hyperlink", ControlType.Hyperlink},
                {"Custom", ControlType.Custom},

                //Not supported yet
                {"TitleBar", ControlType.TitleBar},
                {"ListItem", ControlType.ListItem}
            };*/

            _controlTypeReverseMapper = new Dictionary<ControlType, string>();
            foreach (KeyValuePair<string, ControlType> entry in _controlTypeMapper)
            {
                _controlTypeReverseMapper.Add(entry.Value, entry.Key);
            }
        }

        public static ControlType ToControlType(this string name)
        {
            ControlType type;

            if (string.IsNullOrEmpty(name)) return null;

            _controlTypeMapper.TryGetValue(name, out type);
            if (type == null) throw new ArgumentException(string.Format("Invalid ControlType name \"{0}\"", name));

            return type;
        }

        public static string ControlTypeToString(this ControlType controlType)
        {
            string stringType = null;
            if (controlType != null)
            {
                if (!_controlTypeReverseMapper.TryGetValue(controlType, out stringType))
                {
                    throw new ArgumentException(string.Format("Invalid ControlType \"{0}\""));
                }
            }
            return stringType??string.Empty;
        }
    } 
}
