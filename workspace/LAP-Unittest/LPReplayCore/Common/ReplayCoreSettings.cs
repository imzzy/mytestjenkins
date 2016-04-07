using LPReplayCore.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPReplayCore
{
    public class ReplayCoreSettings
    {
        public enum IndentificationLevelEnum
        {
            Strict,
            Loose
        }
        public static IndentificationLevelEnum IndentificationLevel
        {
            get
            {
                string levelString = LPConfig.Global.GetSetting<string>("identificationLevel");

                if (levelString == null) return IndentificationLevelEnum.Strict; //default value

                IndentificationLevelEnum level = (IndentificationLevelEnum)Enum.Parse(typeof(IndentificationLevelEnum), levelString);

                return level;
            }
            set
            {
                //TODO set the highlight setting
                //throw new NotImplementedException();
            }
        }

        public static Color HighlightColor
        {
            get
            {
                string color = LPConfig.Global.GetSetting<String>("highlightColor");
                if (string.IsNullOrEmpty(color))
                {
                    return Color.Red; //default color;
                }
                KnownColor colorKnown = (KnownColor)Enum.Parse(typeof(KnownColor), color);
                return Color.FromKnownColor(colorKnown);
            }
            set
            {
                LPConfig.Global.SetSettings("highlightColor", value.Name);
            }
            
        }


        public static bool Highlight
        {
            get
            {
                bool? highlight = LPConfig.Global.GetSetting<bool?>("highlight");

                if (highlight == null) return true; //default value
                return (bool)highlight;
            }
            set
            {
                //TODO set the highlight setting
                //throw new NotImplementedException();
            }
        }

    }
}
