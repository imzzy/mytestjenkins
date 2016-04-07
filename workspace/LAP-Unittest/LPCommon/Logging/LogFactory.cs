using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using log4net;
using log4net.Appender;
using log4net.Config;
using System.Reflection;
using log4net.Core;

namespace LPCommon
{
    /// <summary>
    /// Provides a set of methods to get <seealso cref="ILogger"/> etc.
    /// </summary>
    public static class LogFactory
    {
        #region properties

        private static Dictionary<string, ILogger> _dict = new Dictionary<string, ILogger>();
        private static object _lockVar = new object();  // variable for locking
        private static string _configFile = string.Empty;
        private static bool _isConfigured;
        private const string DefaultFallbackPattern = @"%date %-8logger [%3thread] %-5level %message%newline%exception";
        private const String DefaultFallbackLogFilePattern = "HP.Default_{0}.log";
         
        ///// <summary>
        ///// Compare default logger
        ///// </summary>
        //public static ILogger CompareLog
        //{
        //    get
        //    {
        //        return LogFactory.GetLogger(LogConstants.DefaultComparisonCategory);
        //    }
        //}

        #endregion

        /// <summary>
        /// Creates/finds logger for specified Category name. Logger objects are cached.
        /// </summary>
        /// <param name="category">Category name.</param>
        /// <returns>Logger object.</returns>
        public static ILogger GetLogger(string category)
        {
            lock(_lockVar)
            {
                ILogger res;
                //TODO: Should we convert Category to lower case?

                if(_dict.ContainsKey(category))
                {
                    res = _dict[category];
                }
                else
                {
                    var logTarget = LogManager.GetLogger(category);
                    res = new BaseLogger(logTarget);
                    _dict.Add(category, res);
                }

                return res;
            }
        }

        /// <summary>
        /// Creates/finds logger for specified Type (in this case type full name == category). Logger objects are cached.
        /// </summary>
        /// <param name="type">Type that hosts the log.</param>
        /// <returns>Logger object.</returns>
        public static ILogger GetLogger(Type type)
        {
            return GetLogger(type.FullName);
        }

        /// <summary>
        /// Get which is created from the caller type
        /// </summary>
        /// <returns></returns>
        public static ILogger GetLogger()
        {
            if (!_isConfigured) 
                BasicFallbackConfiguration();

            var sTrace = new StackTrace();
            var callerFrame = sTrace.GetFrame(1);
            return GetLogger(callerFrame.GetMethod().DeclaringType);
        }
        /// <summary>
        /// This method appends log messages that recorded by LogRecorder appender to the passed parameter
        /// for specified logger
        /// </summary>
        /// <param name="sb">Text that contains recorded messages, input\output parameter</param>
        /// <param name="logger">Specific logger</param>
        public static void AppendRecentLogMessages(StringBuilder sb, ILogger logger)
        {
            //LogRecorder.AppendRecentLogMessages(sb, logger);
        }

        /// <summary>
        /// Clears all loggers which were created before.
        /// </summary>
        public static void ClearLoggers()
        {
            _dict.Clear();
        }

        /// <summary>
        /// Gets the configuration file name.
        /// </summary>
        public static string ConfigFileName
        {
            get { return _configFile; }
            private set { _configFile = value; }
        }

        /// <summary>
        /// Initialize log file configuration.
        /// </summary>
        /// <param name="configFile">The configuration file.</param>
        public static void LoadLogConfigFile(string configFile)
        {
            if (_isConfigured && (string.IsNullOrEmpty(ConfigFileName)))
                LogManager.ResetConfiguration();

            XmlConfigurator.ConfigureAndWatch(new FileInfo(configFile));
            ConfigFileName = configFile;
            _isConfigured = true;
        }

        private static void BasicFallbackConfiguration()
        {

            //Try to configure to a file
            try
            {
                if (_isConfigured)
                    return;

                FileAppender fileAppender = new FileAppender();
                fileAppender.AppendToFile = true;

                Process currentProcess = Process.GetCurrentProcess();

                fileAppender.File = Path.Combine(Path.GetTempPath(), string.Format(DefaultFallbackLogFilePattern,currentProcess.ProcessName));
                fileAppender.Threshold = Level.Info;
                fileAppender.ImmediateFlush = true;
                fileAppender.Layout = new log4net.Layout.PatternLayout(DefaultFallbackPattern);
                fileAppender.ActivateOptions();
                fileAppender.LockingModel = new FileAppender.MinimalLock();
                BasicConfigurator.Configure(fileAppender);
                _isConfigured = true;
            }
            catch(Exception e)
            {
                Trace.TraceError("Error trying to create a default log " + e);
            }
        }
        /// <summary>
        /// Returns instance of logger with default Category name for UTT
        /// </summary>
        public static ILogger LogUtt
        {
            get { return null;/* return GetLogger(LogConstants.DefaultUttLoggerCategory);*/ }
        }

        /// <summary>
        /// Returns instance of logger with default Category name for UTT Debugger API
        /// </summary>
        public static ILogger LogDbg
        {
            get { return null; /*return GetLogger(LogConstants.DefaultDbgLoggerCategory);*/ }
        }

        /*  This method was moved to Vugen Common assembly
        /// <summary>
        /// Returns  instance of logger with default Category name for LR VuGen
        /// </summary>
        public static ILogger LogVuGen
        {
          get { return GetLogger(LogConstants.DefaultVugenCategory); }
        } */

        /// <summary>
        /// Enumerate an array into HTML string format.
        /// </summary>
        public static string ArrayToString(string[] arr)
        {
            if(arr == null)
            {
                return "(Empty Array)";
            }

            string output = "1-Dim array:<BR><TABLE border=\"1\">\n";
            foreach(object obj in arr)
            {
                var stringArray = obj as string[];
                if(stringArray != null)
                {
                    output += "<TR><TD>" + ArrayToString(stringArray) + "</TD></TR>\n";
                }
                else
                {
                    output += "<TR><TD>" + obj.ToString() + "</TD></TR>\n";
                }
            }
            return output + "</TABLE><BR>\n";
        }

        /// <summary>
        /// Enumerate an object's public properties and fields.
        /// </summary>
        /// <param name="obj">The object to enumerate.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes"),
        System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "obj")]
        public static string EnumerateObject(object obj)
        {
            if(obj == null)
            {
                return "";
            }

            string output = "Enumerating object:<BR><TABLE border=\"1\">";
            output += "<TR><TD>&nbsp;&nbsp;&nbsp;Type.Name</TD><TD>&nbsp;&nbsp;&nbsp;Value</TD></TR>";
            int len = obj.GetType().GetProperties().Length;
            for(int i = 0; i < len; i++)
            {
                try
                {
                    PropertyInfo pi = (PropertyInfo)obj.GetType().GetProperties().GetValue(i);
                    output += "<TR><TD>" + pi.PropertyType + "." + pi.Name + "</TD>";
                    if(pi.CanRead)
                    {
                        object val = pi.GetValue(obj, null);

                        var array = val as string[];
                        if(array != null)
                        {
                            val = ArrayToString(array);
                        }

                        output += "<TD>" + val + "</TD></TR>\n";
                    }
                    else
                    {
                        output += "<TD>&lt;no getter&gt;</TD></TR>\n";
                    }
                }
                catch(Exception) { }
            }
            return output + "</TABLE><BR>\n";
        }

        /// <summary>
        /// Wraps the Log4net LogManager.Shutdown()
        /// </summary>
        public static void Shutdown()
        {
            LogManager.Shutdown();
        }
    }

    public enum ConfigurationState
    {
        Configured = 0,
        NotConfigured = 1
    }
}
