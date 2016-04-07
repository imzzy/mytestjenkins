using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using log4net;
using log4net.Appender;

namespace LPCommon
{
    using log4net.Core;

    /// <summary>
    /// Base implementation of the <seealso cref="ILogger"/> interface.
    /// </summary>
    public class BaseLogger : ILogger
    {
        /// <summary>
        /// Represents the character used for indent.
        /// </summary>
        public const char IndentChar = '\t';
        static string _indentPrefix = "";
        const string NullStr = "null";
        /// <summary>
        /// the logger
        /// </summary>
        ILog _logTarget;

        /// <summary>
        /// Constructs a new <seealso cref="BaseLogger"/> instance.
        /// </summary>
        /// <param name="logTarget"></param>
        public BaseLogger(ILog logTarget)
        {
            _logTarget = logTarget;
        }

        #region Indentation

        static object _syncRoot = new object();

        static byte _indentLevel;

        static string GetIndentedMessage(object message)
        {
            return _indentLevel == 0 ? message.ToString() : _indentPrefix + message;
        }

        #endregion

        #region Implementation of ILoggingService

        public void Trace(object message)
        {
            if (_logTarget.Logger.IsEnabledFor(Level.Trace))
            {
                _logTarget.Logger.Log(typeof(LogImpl), Level.Trace, message, null);
            }
        }

        public void TraceFormatted(string format, params object[] args)
        {
            string message = format;

            if (_indentLevel != 0)
            {
                message = GetIndentedMessage(format);
            }

            if (args != null)
            {
                message = string.Format(message, args);
            }

            if (_logTarget.Logger.IsEnabledFor(Level.Trace))
            {
                _logTarget.Logger.Log(typeof(LogImpl), Level.Trace, message, null);
            }
        }

        /// <summary>
        /// Logs a debug message.
        /// </summary>
        /// <param name="message">An object representing the debug message to log.</param>
        public void Debug(object message)
        {

            if (_indentLevel == 0)
            {
                _logTarget.Debug(message);
            }
            else
            {
                if (_logTarget.IsDebugEnabled)
                {
                    _logTarget.Debug(GetIndentedMessage(message));
                }
            }
        }

        /// <summary>
        /// Logs a formatted debug message.
        /// </summary>
        /// <param name="format">A string containing zero or more format items.</param>
        /// <param name="args">An object array containing zero or more objects to format.</param>
        public void DebugFormatted(string format, params object[] args)
        {
            string message = format;

            if (_indentLevel != 0)
            {
                message = GetIndentedMessage(format);
            }

            if (args != null)
            {
                message = string.Format(message, args);
            }

            if (_logTarget.IsDebugEnabled)
            {
                _logTarget.Debug(message);
            }

        }

        /// <summary>
        /// Logs a information message.
        /// </summary>
        /// <param name="message">An object representing the message to log.</param>
        public void Info(object message)
        {
            if (_indentLevel == 0)
            {
                _logTarget.Info(message);
            }
            else
            {
                if (_logTarget.IsInfoEnabled)
                {
                    _logTarget.Info(GetIndentedMessage(message));
                }
            }
        }

        /// <summary>
        /// Logs a formatted information message.
        /// </summary>
        /// <param name="format">A string containing zero or more format items.</param>
        /// <param name="args">An object array containing or more objects to format.</param>
        public void InfoFormatted(string format, params object[] args)
        {
            string message = format;

            if (_indentLevel != 0)
            {
                message = GetIndentedMessage(format);
            }

            if (args != null)
            {
                message = string.Format(message, args);
            }

            if (_logTarget.IsInfoEnabled)
            {
                _logTarget.Info(message);
            }

        }

        /// <summary>
        /// Logs a warning message.
        /// </summary>
        /// <param name="message">An object representing the message to log.</param>
        public void Warn(object message)
        {
            if (_indentLevel == 0)
            {
                _logTarget.Warn(message);
            }
            else
            {
                if (_logTarget.IsWarnEnabled)
                {
                    _logTarget.Warn(GetIndentedMessage(message));
                }
            }
        }

        /// <summary>
        /// Logs a formatted warning message.
        /// </summary>
        /// <param name="format">A string containing zero or more format items.</param>
        /// <param name="args">An object array containing zero or more items to format.</param>
        public void WarnFormatted(string format, params object[] args)
        {
            string message = format;

            if (_indentLevel != 0)
            {
                message = GetIndentedMessage(format);
            }

            if (args != null)
            {
                message = string.Format(message, args);
            }

            if (_logTarget.IsWarnEnabled)
            {
                _logTarget.Warn(message);
            }

        }

        /// <summary>
        /// Logs a warning message including the <see cref="Exception"/>.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="exception">The <see cref="Exception"/> to log.</param>
        public void Warn(object message, Exception exception)
        {
            if (_indentLevel == 0)
            {
                _logTarget.Warn(message, exception);
            }
            else
            {
                if (_logTarget.IsWarnEnabled)
                {
                    _logTarget.Warn(GetIndentedMessage(message), exception);
                }
            }
        }

        /// <summary>
        /// Logs a error message.
        /// </summary>
        /// <param name="message">An object representing the error message to log.</param>
        public void Error(object message)
        {
            if (message is Exception)
            {
                var exception = message as Exception;
                Error(exception.Message, exception);
                return;
            }

            if (_indentLevel == 0)
                _logTarget.Error(message);
            else
            {
                if (_logTarget.IsErrorEnabled)
                    _logTarget.Error(GetIndentedMessage(message));
            }
        }

        /// <summary>
        /// Logs a formatted error message.
        /// </summary>
        /// <param name="format">A string containing zero or more formatted items.</param>
        /// <param name="args">An object array containing zero or more items to format.</param>
        public void ErrorFormatted(string format, params object[] args)
        {
            string message = format;

            if (_indentLevel != 0)
            {
                message = GetIndentedMessage(format);
            }

            if (args != null)
            {
                message = string.Format(message, args);
            }

            if (_logTarget.IsErrorEnabled)
            {
                _logTarget.Error(message);
            }
        }

        /// <summary>
        /// Logs a error message, including the <see cref="Exception"/>.
        /// </summary>
        /// <param name="message">An object representing the message to log.</param>
        /// <param name="exception">The <see cref="Exception"/> to log.</param>
        public void Error(object message, Exception exception)
        {
            bool isErrorEnbled = _logTarget.IsErrorEnabled;

            if (_indentLevel == 0)
                _logTarget.Error(message, exception);
            else
            {
                if (isErrorEnbled) 
                    _logTarget.Error(GetIndentedMessage(message), exception);
            }

            //if (isErrorEnbled)
            //    LoggerUtils.MarkExceptionAsLogged(exception);
        }

        /// <summary>
        /// Logs a fatal message.
        /// </summary>
        /// <param name="message">An object representing the message to log.</param>
        public void Fatal(object message)
        {
            if (_indentLevel == 0)
            {
                _logTarget.Fatal(message);
            }
            else
            {
                if (_logTarget.IsFatalEnabled)
                {
                    _logTarget.Fatal(GetIndentedMessage(message));
                }
            }
        }

        /// <summary>
        /// Logs a formatted fatal message.
        /// </summary>
        /// <param name="format">A string containing zero or more formatted items.</param>
        /// <param name="args">An object array containing zero or more items to format.</param>
        public void FatalFormatted(string format, params object[] args)
        {
            string message = format;

            if (_indentLevel != 0)
            {
                message = GetIndentedMessage(format);
            }

            if (args != null)
            {
                message = string.Format(message, args);
            }

            if (_logTarget.IsFatalEnabled)
            {
                _logTarget.Fatal(message);
            }
        }

        /// <summary>
        /// Logs a fatal message, including the <see cref="Exception"/>.
        /// </summary>
        /// <param name="message">An object representing the message to log.</param>
        /// <param name="exception">The <see cref="Exception"/> to log.</param>
        public void Fatal(object message, Exception exception)
        {
            if (_indentLevel == 0)
            {
                _logTarget.Fatal(message, exception);
            }
            else
            {
                if (_logTarget.IsFatalEnabled)
                {
                    _logTarget.FatalFormat(GetIndentedMessage(message), exception);
                }
            }
        }

        /// <summary>
        /// Gets a Boolean value indicating whether the Fatal level log is enabled.
        /// </summary>
        public bool IsTraceEnabled
        {
            get
            {
                return _logTarget.Logger.IsEnabledFor(Level.Trace);
            }
        }

        /// <summary>
        /// Gets a Boolean value indicating whether the Debug level log is enabled.
        /// </summary>
        public bool IsDebugEnabled
        {
            get { return _logTarget.IsDebugEnabled; }
        }

        /// <summary>
        /// Gets a Boolean value indicating whether the Info level log is enabled.
        /// </summary>
        public bool IsInfoEnabled
        {
            get { return _logTarget.IsInfoEnabled; }
        }

        /// <summary>
        /// Gets a Boolean value indicating whether the Warn level log is enabled.
        /// </summary>
        public bool IsWarnEnabled
        {
            get { return _logTarget.IsWarnEnabled; }
        }

        /// <summary>
        /// Gets a Boolean value indicating whether the Error level log is enabled.
        /// </summary>
        public bool IsErrorEnabled
        {
            get { return _logTarget.IsErrorEnabled; }
        }

        /// <summary>
        /// Gets a Boolean value indicating whether the Fatal level log is enabled.
        /// </summary>
        public bool IsFatalEnabled
        {
            get { return _logTarget.IsFatalEnabled; }
        }

        #endregion

        #region Implementation of ILogger

        public void TraceDelegated(LogMessageProvider provider)
        {
            if (!(_logTarget.Logger.IsEnabledFor(Level.Trace) || provider == null))
                return;

            _logTarget.Logger.Log(typeof(LogImpl),Level.Trace,_indentLevel == 0 ? provider.Invoke() : GetIndentedMessage(provider.Invoke()),null);
        }

        /// <summary>
        /// Writes to the debug stream if it is enabled.
        /// The provider method is invoked only in case the level is enabled.
        /// </summary>
        /// <param name="provider">An application level method which creates the log message when invoked.</param>
        public void DebugDelegated(LogMessageProvider provider)
        {
            if (!_logTarget.IsDebugEnabled || provider == null)
                return;

            _logTarget.Debug(_indentLevel == 0 ? provider.Invoke() : GetIndentedMessage(provider.Invoke()));
        }

        /// <summary>
        /// Writes to the info stream if it is enabled.
        /// The provider method is invoked only in case the level is enabled.
        /// </summary>
        /// <param name="provider">An application level method which creates the log message when invoked.</param>
        public void InfoDelegated(LogMessageProvider provider)
        {
            if (!_logTarget.IsInfoEnabled || provider == null)
                return;

            _logTarget.Info(_indentLevel == 0 ? provider.Invoke() : GetIndentedMessage(provider.Invoke()));
        }

        /// <summary>
        /// Writes to the warning stream if it is enabled.
        /// The provider method is invoked only in case the level is enabled.
        /// </summary>
        /// <param name="provider">An application level method which creates the log message when invoked.</param>
        public void WarnDelegated(LogMessageProvider provider)
        {
            if (!_logTarget.IsWarnEnabled || provider == null)
                return;

            _logTarget.Warn(_indentLevel == 0 ? provider.Invoke() : GetIndentedMessage(provider.Invoke()));
        }

        /// <summary>
        /// Writes to the error stream if it is enabled.
        /// The provider method is invoked only in case the level is enabled.
        /// </summary>
        /// <param name="provider">An application level method which creates the log message when invoked.</param>
        public void ErrorDelegated(LogMessageProvider provider)
        {
            if (!_logTarget.IsErrorEnabled || provider == null)
                return;

            _logTarget.Error(_indentLevel == 0 ? provider.Invoke() : GetIndentedMessage(provider.Invoke()));
        }

        /// <summary>
        /// Writes to the fatal stream if it is enabled.
        /// The provider method is invoked only in case the level is enabled.
        /// </summary>
        /// <param name="provider">An application level method which creates the log message when invoked.</param>
        public void FatalDelegated(LogMessageProvider provider)
        {
            if (!_logTarget.IsFatalEnabled || provider == null)
                return;

            _logTarget.Fatal(_indentLevel == 0 ? provider.Invoke() : GetIndentedMessage(provider.Invoke()));
        }

        /// <summary>
        /// Increments the indentation of all loggers by one level.
        /// The maximum limit is <see cref="byte.MaxValue"/>.
        /// When this limit is reached, the indentation level is no longer raised and stays constant.
        /// </summary>
        /// <returns>The indentation level of the log, after incrementing it.</returns>
        public byte Indent()
        {
            lock (_syncRoot)
            {
                // guard against going over the limit
                if (_indentLevel < Byte.MaxValue)
                {
                    _indentPrefix = new string(IndentChar, ++_indentLevel);
                }
                return _indentLevel;
            }
        }

        /// <summary>
        /// Decrements the indentation of all loggers by one level.
        /// The limit is 0. When this limit is reached, the indentation level 
        /// is no longer changed and stays constant.
        /// </summary>
        /// <returns>The indentation level of the log, after changing it.</returns>
        public byte Unindent()
        {
            lock (_syncRoot)
            {
                if (_indentLevel > 0)
                {
                    _indentPrefix = new string(IndentChar, --_indentLevel);
                }
                return _indentLevel;
            }
        }

        /// <summary>
        /// Resets the indentation of all loggers to 0.
        /// </summary>
        public void ResetIndent()
        {
            lock (_syncRoot)
            {
                _indentLevel = 0;
                _indentPrefix = "";
            }
        }

        /// <summary>
        /// Gets the current indentation level for all loggers.
        /// </summary>
        public byte IndentLevel
        {
            get { return _indentLevel; }
        }

        /// <summary>
        /// Logs a debug message containing the dump of the object.
        /// </summary>
        /// <param name="o">The object to dump and log.</param>
        public void DebugObjectDump(object o)
        {
            //DebugObjectDump(o, 0);
        }

        ///// <summary>
        ///// Logs a debug message containing the dump of the object with specified depth.
        ///// </summary>
        ///// <param name="o">The object to dump.</param>
        ///// <param name="depth">An integer value indicating the dump depth.</param>
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        //public void DebugObjectDump(object o, int depth)
        //{
        //    if (!_logTarget.IsDebugEnabled)
        //        return;

        //    try
        //    {
        //        using (var sw = new StringWriter())
        //        {
        //            ObjectDumper.Write(o, depth, sw);

        //            string format = "Object Dump->{0} = \n\t{1}";
        //            if (_indentLevel == 0)
        //            {
        //                _logTarget.DebugFormat(format, o, sw.ToString());
        //            }
        //            else
        //            {
        //                _logTarget.DebugFormat(GetIndentedMessage(format), o, sw.ToString());
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Debug.Fail("Error in logger", ex.Message);
        //    }
        //}

        /// <summary>
        /// Logs a debug message containing the active method and its arguments.
        /// </summary>
        /// <param name="args">An object array containing the method's arguments.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        public void DebugMethodEntrance(params object[] args)
        {
            if (!_logTarget.IsDebugEnabled)
                return;

            try
            {
                StackFrame sf = new StackFrame(1, false);

                // get the method name
                string methodName = sf.GetMethod().Name;
                string type = sf.GetMethod().ReflectedType.Name;
                List<ParameterInfo> parameters = new List<ParameterInfo>(sf.GetMethod().GetParameters());

                int i = 0;

                //Get parameters in the following format {"param1 = value1", "param2 = value2",... }
                var parametersDescription = parameters.ConvertAll(
                    parameterInfo =>
                    {
                        string paramValue;

                        if (args != null && (i < args.Length && args[i] != null))
                        {
                            var currentObject = args[i++];
                            //check if the object overrides ToString, if so the print to string otherwise print {}
                            var methodInfo = currentObject.GetType().GetMethod("ToString", new Type[] { });
                            if (methodInfo.DeclaringType == currentObject.GetType())
                                paramValue = currentObject.ToString();
                            else
                                paramValue = "{...}";
                        }
                        else
                            paramValue = "<Unknown>";

                        return String.Format("{0} = {1}", parameterInfo.Name, paramValue);
                    });

                string format = "-> {0}::{1}({2})";

                if (_indentLevel == 0)
                {
                    _logTarget.DebugFormat(format, type, methodName, String.Join(",", parametersDescription.ToArray()));
                }
                else
                {
                    _logTarget.DebugFormat(GetIndentedMessage(format), type, methodName, String.Join(",", parametersDescription.ToArray()));
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Fail("Error in logger", ex.Message);
            }
        }

        /// <summary>
        /// Logs a debug message telling the method is exited.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        public void DebugMethodExit()
        {
            if (!_logTarget.IsDebugEnabled)
                return;

            try
            {
                const string EXIT_FORMAT = "<- {0}::{1}";

                StackFrame sf = new StackFrame(1, false);

                // get the method name
                string methodName = sf.GetMethod().Name;
                string type = sf.GetMethod().ReflectedType.Name;

                if (_indentLevel == 0)
                {
                    _logTarget.DebugFormat(EXIT_FORMAT, type, methodName);
                }
                else
                {
                    _logTarget.DebugFormat(GetIndentedMessage(EXIT_FORMAT), type, methodName);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Fail("Error in logger", ex.Message);
            }
        }

        /// <summary>
        /// Logs a debug message telling the method is exited.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        public void Exit(string methodName)
        {
            if (!_logTarget.IsDebugEnabled)
                return;

            const string EXIT_FORMAT = "<- {0}";

            try
            {
                if (_indentLevel == 0)
                {
                    _logTarget.DebugFormat(EXIT_FORMAT, methodName);
                }
                else
                {
                    _logTarget.DebugFormat(GetIndentedMessage(EXIT_FORMAT), methodName);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Fail("Error in logger", ex.Message);
            }
        }

        public void Exit(string methodName, object retVal)
        {
            Exit(methodName, string.Empty, retVal);
        }

        public void Exit(string methodName, string message, object retVal)
        {
            if (_logTarget.IsDebugEnabled)
            {
                if (retVal == null)
                    retVal = NullStr;

                if (!string.IsNullOrEmpty(message))
                    message = string.Format(" message: {0}", message);
                else
                    message = string.Empty;

                Exit(string.Format("{0} returned value: {1}{2}", methodName, retVal, message));
            }
        }

        /// <summary>
        /// Logs a trace message telling the method is exited.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        public void TraceExit(string methodName)
        {
            if (!IsTraceEnabled)
                return;

            const string EXIT_FORMAT = "<- {0}";

            try
            {
                if (_indentLevel == 0)
                {
                    TraceFormatted(EXIT_FORMAT, methodName);
                }
                else
                {
                    TraceFormatted(GetIndentedMessage(EXIT_FORMAT), methodName);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.Fail("Error in logger", ex.Message);
            }
        }

        /// <summary>
        /// Logs a trace message telling the method is exited.
        /// </summary>
        public void TraceExit(string methodName, object retVal)
        {
            TraceExit(methodName, string.Empty, retVal);
        }

        /// <summary>
        /// Logs a trace message telling the method is exited.
        /// </summary>
        public void TraceExit(string methodName, string message, object retVal)
        {
            if (IsTraceEnabled)
            {
                if (retVal == null)
                    retVal = NullStr;

                if (!string.IsNullOrEmpty(message))
                    message = string.Format(" message: {0}", message);
                else
                    message = string.Empty;

                TraceExit(string.Format("{0} returned value: {1}{2}", methodName, retVal, message));
            }
        }

        /// <summary>
        /// Logs a debug message telling the method is entered.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        public void Entry(string methodName)
        {
            if (!_logTarget.IsDebugEnabled)
                return;

            const string ENTRY_FORMAT = "-> {0}";

            try
            {
                if (_indentLevel == 0)
                {
                    _logTarget.DebugFormat(ENTRY_FORMAT, methodName);
                }
                else
                {
                    _logTarget.DebugFormat(GetIndentedMessage(ENTRY_FORMAT), methodName);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Fail("Error in logger", ex.Message);
            }
        }

        /// <summary>
        /// Logs a debug message telling the method is entered.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        public void Entry(string methodName, LogArgs args)
        {
            if (!_logTarget.IsDebugEnabled)
                return;

            const string ENTRY_FORMAT = "-> {0}({1})";

            try
            {
                if (_indentLevel == 0)
                {
                    _logTarget.DebugFormat(ENTRY_FORMAT, methodName, GetParamtersString(args));
                }
                else
                {
                    _logTarget.DebugFormat(GetIndentedMessage(ENTRY_FORMAT), methodName,GetParamtersString(args));
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Fail("Error in logger", ex.Message);
            }
        }

        public void Entry(string methodName, Func<LogArgs> getArgs)
        {
            if (!_logTarget.IsDebugEnabled)
                return;

            Entry(methodName, getArgs.Invoke());
        }

        /// <summary>
        /// Logs a trace message telling the method is entered.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        public void TraceEntry(string methodName)
        {
            if (!IsTraceEnabled)
                return;

            const string ENTRY_FORMAT = "-> {0}";

            try
            {
                if (_indentLevel == 0)
                {
                    TraceFormatted(ENTRY_FORMAT, methodName);
                }
                else
                {
                    TraceFormatted(GetIndentedMessage(ENTRY_FORMAT), methodName);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.Fail("Error in logger", ex.Message);
            }
        }

        /// <summary>
        /// Logs a trace message telling the method is entered.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        public void TraceEntry(string methodName, LogArgs args)
        {
            if (!IsTraceEnabled)
                return;

            const string ENTRY_FORMAT = "-> {0}({1})";

            try
            {
                if (_indentLevel == 0)
                {
                    TraceFormatted(ENTRY_FORMAT, methodName, GetParamtersString(args));
                }
                else
                {
                    TraceFormatted(GetIndentedMessage(ENTRY_FORMAT), methodName, GetParamtersString(args));
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.Fail("Error in logger", ex.Message);
            }
        }

        /// <summary>
        /// Logs a trace message telling the method is entered.
        /// </summary>
        public void TraceEntry(string methodName, Func<LogArgs> getArgs)
        {
            if (!IsTraceEnabled)
                return;

            TraceEntry(methodName, getArgs.Invoke());
        }

        private string GetParamtersString(LogArgs arg)
        {
            if ((arg == null) || (arg.ParamNames.Count == 0))
                return string.Empty;

            string argstring = string.Empty;

            for (int i = 0; i < arg.ParamNames.Count; i++)
            {
                if (arg.ParamNames[i] != null)
                {
                    object currentObject = arg.ParamValus[i];
                    string paramValue;

                    if (currentObject == null)
                        paramValue = NullStr;
                    else
                    {
                        var methodInfo = currentObject.GetType().GetMethod("ToString", new Type[] { });
                        if (methodInfo.DeclaringType == currentObject.GetType())
                            paramValue = currentObject.ToString();
                        else
                            paramValue = "{...}";
                    }

                    if (string.IsNullOrEmpty(argstring))
                        argstring = string.Format("{0} = {1}", arg.ParamNames[i], paramValue);
                    else
                        argstring = string.Format("{0}, {1} = {2}", argstring, arg.ParamNames[i], paramValue);
                }
            }

            return argstring;
        }


        /// <summary>
        /// Gets the collection of <seealso cref="IAppender"/>s.
        /// </summary>
        public IAppender[] Appenders
        {
            get
            {
                return _logTarget.Logger.Repository.GetAppenders();
            }
        }

     
        #endregion

        #region My own APIs

        public void WriteLog(string message)
        {
            //always write the log, therefore consider it to be error.
            _logTarget.Error(message);
        }

        public void WriteLog(LogTypeEnum logType, string message)
        {
            switch (logType)
            {
                case LogTypeEnum.Fatal:
                    _logTarget.Fatal(message);
                    break;
                case LogTypeEnum.Error:
                    _logTarget.Error(message);
                    break;
                case LogTypeEnum.Warning:
                    _logTarget.Warn(message);
                    break;
                case LogTypeEnum.Info:
                    _logTarget.Info(message);
                    break;
                case LogTypeEnum.Debug:
                    _logTarget.Debug(message);
                    break;
            }
        }

        public void WriteLog(LogTypeEnum logType, Func<string> getMessage)
        {
            switch (logType)
            {
                case LogTypeEnum.Fatal:
                    _logTarget.Fatal(getMessage());
                    break;
                case LogTypeEnum.Error:
                    _logTarget.Error(getMessage());
                    break;
                case LogTypeEnum.Warning:
                    _logTarget.Warn(getMessage());
                    break;
                case LogTypeEnum.Info:
                    _logTarget.Info(getMessage());
                    break;
                case LogTypeEnum.Debug:
                    _logTarget.Debug(getMessage());
                    break;
            }
        }

        public void WriteError(string message)
        {
            _logTarget.Error(message);
        }

        public void WriteWarning(string message)
        {
            _logTarget.Warn(message);
        }

        public void WriteInfo(string message)
        {
            _logTarget.Info(message);
        }

        public void WriteDebug(string message)
        {
            _logTarget.Info(message);
        }
        #endregion
    }
}

