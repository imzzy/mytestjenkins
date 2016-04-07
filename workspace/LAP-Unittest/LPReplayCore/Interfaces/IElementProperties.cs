using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPReplayCore.Interfaces
{
    public interface IElementProperties
    {
        /*Dictionary<string, string> Properties
        {
            get;
        }*/
        string ControlTypeString
        {
            get;
        }
        Dictionary<string, string> RecommendedProperties
        {
            get;
        }

        Dictionary<string, string> OtherProperties
        {
            get;
        }

        Dictionary<string, string> SelectedProperties
        {
            set;
            get;
        }

        Dictionary<string, string> NoneEmptyProperties
        {
            get;
        }

        TestObjectNurse ToNurseObject(); 
    }
}
