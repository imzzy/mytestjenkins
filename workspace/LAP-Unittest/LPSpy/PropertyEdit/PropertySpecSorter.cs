using LPReplayCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPSpy
{
    public class PropertySpecSorter : IComparer<PropertySpec>
    {
        #region IComparer<PropertyDescriptor> Members

        public int Compare(PropertySpec x, PropertySpec y)
        {
            // compare category
            int ret = String.Compare(x.Category, y.Category, true);
            if (ret != 0) return ret;

            if (x.Name == ControlKeys.Type) return -1;
            if (y.Name == ControlKeys.Type) return 1;

            return String.Compare(x.Name, y.Name, true);
            
        }

        #endregion

       
    }

}
