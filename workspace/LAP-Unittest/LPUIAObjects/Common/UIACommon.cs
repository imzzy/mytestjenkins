using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPUIAObjects
{

    public enum ErrorType
    {
        ObjectNotExist = 1,
        ObjectIsOutOfScreen = 2,
        CannotPerformThisOperation = 3,
        ObjectIsReadOnly = 4,
        NotItemExistinthelist = 5,
        OutRange = 6,
        Others = 7
    }

    public enum UIAType
    {
        Window = 1,
        Pane = 2,
        Document = 3,
        Button = 4,
        CheckBox = 5,
        List = 6,
        RadioButton = 7,
        MenuBar = 8,
        Tree = 9,
        Text = 10,
        Table = 11,
        ScrollBar = 12,
        ComboBox = 13,
        Slider = 14,
        Tab = 15,
        Image = 16,
        Edit = 17,
        ToolBar = 18,
        Object = 19,
        Menu = 20,
        HyperLink = 21
    }

    public class DescriptionString
    {
        public static string PropertySplitString = "||||";

        public static string ObjectSplitysString = "|||*|||";

        public static string AssignOperator = ":=";

        public static string LeftRightPropertySplitString = ";;";

        public static string LeftRightQtpString = "==";
    }


}
