using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using LPReplayCore.Interfaces;

namespace LPReplayCore.Model
{
    public class VisualRelationPropertyItem : IPropertyGroup
    {

        public const string Key = "relation";

        public string GetKey() { return VisualRelationPropertyItem.Key; }

        public string Left;

        public string Right;

        public VisualRelationPropertyItem()
        {
        }
        

        public VisualRelationPropertyItem(SerializationInfo info, StreamingContext context)
        {
            foreach (SerializationEntry se in info)
            {
                switch (se.Name)
                {
                    case "left":
                        Left = se.Value.ToString();
                        continue;
                    case "right":
                        Right = se.Value.ToString();
                        continue;
                    default:
                        //TODO: can log warning
                        break;
                }

            }
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (Left != null)
                info.AddValue("left", Left);

            if (Right != null)
            info.AddValue("right", Right);
        }
    }
}
