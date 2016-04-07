using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using LPReplayCore.Common;


namespace LPUIAObjects
{
    public class UIACommonMethods
    {
        public static UIAControlBase ObjectCreator(UIACondition condition)
        {
            if (condition.UIAObject == null)
            {
                string typeString = "LPUIAObjects.UIA" + condition.ControlType.ControlTypeToString();
                Type type = Type.GetType(typeString);
                if (type == null)
                {
                    throw new InvalidOperationException(string.Format("type {0} cannot be created", typeString));
                }
                condition.UIAObject = (UIAControlBase)Activator.CreateInstance(type, condition);                
            }
            return (UIAControlBase)condition.UIAObject;
        }
    }
}
