using System.Collections.Generic;

namespace LPCommon
{

    public static class Args
    {
        public static LogArgs P(string name, object val)
        {
            return new LogArgs(name, val);
        }

        public static LogArgs P(string name)
        {
            return new LogArgs(name, null);
        }

        public static LogArgs V(object val)
        {
            return new LogArgs("P0", val);
        }
    }

    public class LogArgs
    {
        private readonly List<string> _paramNames = new List<string>();

        private readonly List<object> _paramValus = new List<object>();

        public LogArgs P(string name, object val)
        {
            _paramNames.Add(name);
            _paramValus.Add(val);
            return this;
        }

        public LogArgs P(string name)
        {
            _paramNames.Add(name);
            _paramValus.Add(null);
            return this;
        }

        public LogArgs V(object val)
        {
            _paramNames.Add("P" + _paramNames.Count);
            _paramValus.Add(val);
            return this;
        }

        internal LogArgs()
        {
        }

        internal LogArgs(string name, object val)
        {
            P(name, val);
        }



        internal List<string> ParamNames
        {
            get { return _paramNames; }
        }

        internal List<object> ParamValus
        {
            get { return _paramValus; }
        }

    }

}
