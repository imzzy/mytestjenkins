using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Design.Serialization;
using System.Reflection;

namespace LAPResourceManager
{
    [DesignerSerializer(typeof(MLUResManagerSerializer), typeof(CodeDomSerializer))]
    public partial class ResourceControl : Component
    {
        public string UIComponentName
        {
            set;
            get;
        }

        public string ResAssemblyName
        {
            set;
            get;
        }

        public bool reInitResManger(ref ComponentResourceManager ComResMgr)
        {
            if (null == this.UIComponentName || 0 == this.UIComponentName.Length
                || null == this.ResAssemblyName || 0 == this.ResAssemblyName.Length)
                return false;

            ResourceManagerProvider.ResourceManagerType = typeof(MLUComponentResourceManager);

            string RealResourceName = this.ResAssemblyName + "." + this.UIComponentName;
            Assembly ab = Assembly.Load(this.ResAssemblyName);
            ComResMgr = ResourceManagerProvider.GetResourceManager(RealResourceName, Assembly.Load(this.ResAssemblyName));

            return true;
        }

    }
}
