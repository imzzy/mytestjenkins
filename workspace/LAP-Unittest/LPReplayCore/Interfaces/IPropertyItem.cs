using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LPReplayCore.Interfaces
{
    public interface IPropertyGroup : ISerializable
    {
        //used in generic methods to get the key of the property group
        string GetKey();
    }
}
