using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Reflection;

namespace LAPResourceManager
{
    public class ResourceManagerProvider
    {
        private static Type resourceManagerType = typeof(ComponentResourceManager);
        public static ComponentResourceManager GetResourceManager(Type type)
        {
            return (ComponentResourceManager)Activator.CreateInstance(resourceManagerType, new object[] { type });
        }

        public static ComponentResourceManager GetResourceManager(string baseName, Assembly assembly)
        {
            return (ComponentResourceManager)Activator.CreateInstance(resourceManagerType, new object[] { baseName, assembly });
        }

        public static ComponentResourceManager GetResourceManager(string baseName, Assembly assembly, Type usingResourceSet)
        {
            return (ComponentResourceManager)Activator.CreateInstance(resourceManagerType, new object[] { baseName, assembly, usingResourceSet });
        }

        public static Type ResourceManagerType
        {
            get
            {
                return resourceManagerType;
            }
            set
            {
                if (value.FullName == "System.ComponentModel.ComponentResourceManager"
                    || value.IsSubclassOf(typeof(ComponentResourceManager)))
                {
                    resourceManagerType = value;
                }
                else
                {
                    throw new ApplicationException("ResourceManagerType must be a sub class of System.ComponentModel. ComponentResourceManager");
                }
            }
        }
    }
}
