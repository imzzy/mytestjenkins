using LPReplayCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LPReplayCore.Interfaces;

namespace LPReplayCore
{
    public class BaseContext: IContext
    {
        private object[] _contexts;

        public T GetContext<T>() where T: class
        {
            if (_contexts == null) return default(T);
            foreach(object obj in _contexts)
            {
                T context = obj as T;
                if (context != null) return context;
            }
            return default(T);
        }

        public void SetContext<T>(T context) where T : class
        {
            if (context == null)
            {
                //remove the context
                if (_contexts == null) return;
                foreach (object obj in _contexts)
                {
                    if ((obj as T) != null)
                    {
                        //this is the only object to be removed. set context null;
                        if (_contexts.Length == 1)
                        {
                            _contexts = null;
                            return;
                        }
                        //TODO if there are more context types, need to be handled
                        Debug.Assert(false, "Should handle more context types");
                    }
                }
            }
            else
            {
                //add or update the context
                if (_contexts == null || _contexts.Length == 0)
                {
                    _contexts = new object[] { context };
                }
                else
                {
                    Debug.Assert((_contexts[0] as T) != null);
                    _contexts[0] = context;
                }
            }
        }
    }
}
