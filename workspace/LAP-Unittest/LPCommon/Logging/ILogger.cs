using System;
using System.Collections;
using log4net.Appender;
using log4net.Core;

namespace LPCommon
{
  /// <summary>
  /// Defines methods used by application to log messages.
  /// </summary>
  public interface ILogger
  {
    /// <summary>
    /// Writes to Debug stream the first hierarchy of the object properties
    /// </summary>
    /// <param name="o">The object to write</param>
    //void DebugObjectDump(object o);

    /// <summary>
    /// Writes to Debug stream the given depth hierarchy of the object properties
    /// </summary>
    /// <param name="o">The object to write</param>
    /// <param name="depth">the depth to navigate in the object</param>
    //void DebugObjectDump(object o, int depth);

    /// <summary>
    /// Writes to Debug stream the method name and its args
    /// </summary>
    /// <param name="args">the args values to be written to log, they will be written in the same order
    /// they appear in the Method signature
    /// </param>
    /// <example>
    /// The following method calls DebugMethodEntrance
    /// <code>
    ///  void SomeMethod(int i, string s)
    ///  {
    ///    DebugMethodEntrance(i, s);
    ///  }
    ///  static void Main(string[] args)
    ///  {
    ///     Program p = new Program();
    ///     p.SomeMethod(1, "hello");
    ///  }
    /// </code>
    /// Output to Log:
    /// Entering to SomeMethod (i = 1, s = hello)
    /// </example>
    void DebugMethodEntrance(params object[] args);

    ///<summary>
    /// Writes to Debug stream that the calling method is exiting
    ///</summary>
    void DebugMethodExit();

    ///<summary>
    /// Writes to Debug stream the method name
    ///</summary>
    ///<param name="methodName">The method name</param>
    void Entry(string methodName);


    ///<summary>
    /// Writes to Debug stream the method name
    ///</summary>
    ///<param name="methodName">The method name</param> 
    ///<param name="args">Paramters names and values</param>
    void Entry(string methodName, LogArgs args);

    ///<summary>
    /// Writes to Debug stream the method name
    ///</summary>
    ///<param name="methodName">The method name</param> 
    ///<param name="getArgs">Late invoke method to get paramters names and values</param>
    void Entry(string methodName, Func<LogArgs> getArgs);

    ///<summary>
    /// Writes to Trace stream the method name
    ///</summary>
    ///<param name="methodName">The method name</param>
    void TraceEntry(string methodName);

    ///<summary>
    /// Writes to Trace stream the method name
    ///</summary>
    ///<param name="methodName">The method name</param> 
    ///<param name="args">Paramters names and values</param>
    void TraceEntry(string methodName, LogArgs args);

    ///<summary>
    /// Writes to Trace stream the method name
    ///</summary>
    ///<param name="methodName">The method name</param> 
    ///<param name="getArgs">Late invoke method to get paramters names and values</param>
    void TraceEntry(string methodName, Func<LogArgs> getArgs);

    ///<summary>
    /// Writes to Debug stream the method exit
    ///</summary>
    ///<param name="methodName">The method name</param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", MessageId = "Exit")]
    void Exit(string methodName);

    ///<summary>
    /// Writes to Debug stream the method exit
    ///</summary>
    ///<param name="methodName">The method name</param>
    ///<param name="retVal">The return value</param>
    /// [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", MessageId = "Exit")]
    void Exit(string methodName, object retVal);

    ///<summary>
    /// Writes to Debug stream the method exit
    ///</summary>
    ///<param name="methodName">The method name</param>
    ///<param name="message"></param>
    ///<param name="retVal">The return value</param> 
    ///[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", MessageId = "Exit")]
    void Exit(string methodName, string message, object retVal);

    ///<summary>
    /// Writes to Trace stream the method exit
    ///</summary>
    ///<param name="methodName">The method name</param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", MessageId = "Exit")]
    void TraceExit(string methodName);

    ///<summary>
    /// Writes to Trace stream the method exit
    ///</summary>
    ///<param name="methodName">The method name</param>
    ///<param name="retVal">The return value</param>
    /// [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", MessageId = "Exit")]
    void TraceExit(string methodName, object retVal);

    ///<summary>
    /// Writes to trace stream the method exit
    ///</summary>
    ///<param name="methodName">The method name</param>
    ///<param name="message"></param>
    ///<param name="retVal">The return value</param> 
    ///[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", MessageId = "Exit")]
    void TraceExit(string methodName, string message, object retVal);

    ///<summary>
    /// Writes to the Trace stream if it is enabled.
    ///</summary>
    ///<param name="message"></param>
    void Trace(object message);

    /// <summary>
    /// Writes the formatted message to the Trace stream if it is enabled.
    /// </summary>
    /// <param name="format">Standard <see cref="String.Format(string,object[])">String.Format</see>
    ///   string.</param>
    /// <param name="args">Arguments for the format string.</param>
    /// <remarks>
    /// Formatting of the message is performed only in case Trace level is enabled.
    /// </remarks>
    /// <seealso cref="string.Format(string,object[])">String.Format(string,object[])</seealso>
    void TraceFormatted(string format, params object[] args);

    /// <summary>
    /// Writes to the Debug stream if it is enabled.
    /// </summary>
    /// <param name="message">The message to write</param>
    void Debug(object message);

    /// <summary>
    /// Writes the formatted message to the Debug stream if it is enabled.
    /// </summary>
    /// <param name="format">Standard <see cref="String.Format(string,object[])">String.Format</see>
    ///   string.</param>
    /// <param name="args">Arguments for the format string.</param>
    /// <remarks>
    /// Formatting of the message is performed only in case Debug level is enabled.
    /// </remarks>
    /// <seealso cref="string.Format(string,object[])">String.Format(string,object[])</seealso>
    void DebugFormatted(string format, params object[] args);

    /// <summary>
    /// Writes to the Info stream if it is enabled.
    /// </summary>
    /// <param name="message">The message to write</param>
    void Info(object message);

    /// <summary>
    /// Writes the formatted message to the Info stream if it is enabled.
    /// </summary>
    /// <param name="format">Standard <see cref="String.Format(string,object[])">String.Format</see>
    ///   string.</param>
    /// <param name="args">Arguments for the format string.</param>
    /// <remarks>
    /// Formatting of the message is performed only in case Info level is enabled.
    /// </remarks>
    /// <seealso cref="string.Format(string,object[])">String.Format(string,object[])</seealso>
    void InfoFormatted(string format, params object[] args);

    /// <summary>
    /// Writes to the Warn stream if it is enabled.
    /// </summary>
    /// <param name="message">The message to write</param>
    void Warn(object message);

    /// <summary>
    /// Writes the formatted message to the Warn stream if it is enabled.
    /// </summary>
    /// <param name="format">Standard <see cref="String.Format(string,object[])">String.Format</see>
    ///   string.</param>
    /// <param name="args">Arguments for the format string.</param>
    /// <remarks>
    /// Formatting of the message is performed only in case Warn level is enabled.
    /// </remarks>
    /// <seealso cref="string.Format(string,object[])">String.Format(string,object[])</seealso>
    void WarnFormatted(string format, params object[] args);

    /// <summary>
    /// Writes to the Error stream if it is enabled.
    /// </summary>
    /// <param name="message">The message to write</param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", MessageId = "Error")]
    void Error(object message);

    /// <summary>
    /// Writes the formatted message to the Error stream if it is enabled.
    /// </summary>
    /// <param name="format">Standard <see cref="String.Format(string,object[])">String.Format</see>
    ///   string.</param>
    /// <param name="args">Arguments for the format string.</param>
    /// <remarks>
    /// Formatting of the message is performed only in case Error level is enabled.
    /// </remarks>
    /// <seealso cref="string.Format(string,object[])">String.Format(string,object[])</seealso>
    void ErrorFormatted(string format, params object[] args);

    /// <summary>
    /// Writes to the Fatal stream if it is enabled.
    /// </summary>
    /// <param name="message">The message to write</param>
    void Fatal(object message);

    /// <summary>
    /// Writes the formatted message to the Fatal stream if it is enabled.
    /// </summary>
    /// <param name="format">Standard <see cref="String.Format(string,object[])">String.Format</see>
    ///   string.</param>
    /// <param name="args">Arguments for the format string.</param>
    /// <remarks>
    /// Formatting of the message is performed only in case Fatal level is enabled.
    /// </remarks>
    /// <seealso cref="string.Format(string,object[])">String.Format(string,object[])</seealso>
    void FatalFormatted(string format, params object[] args);

    /// <summary>
    /// Writes the message and the exception to the Warn stream if it is enabled.
    /// </summary>
    /// <param name="message">The message to write</param>
    /// <param name="exception">The exception to log</param>
    void Warn(object message, Exception exception);

    /// <summary>
    /// Writes the message and the exception to the Error stream if it is enabled.
    /// </summary>
    /// <param name="message">The message to write</param>
    /// <param name="exception">The exception to log</param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", MessageId = "Error")]
    void Error(object message, Exception exception);

    /// <summary>
    /// Writes the message and the exception to the Fatal stream if it is enabled.
    /// </summary>
    /// <param name="message">The message to write</param>
    /// <param name="exception">The exception to log</param>
    void Fatal(object message, Exception exception);

    /// <summary>
    /// Returns true if the Trace level is enabled.
    /// </summary>
    bool IsTraceEnabled { get; }

    /// <summary>
    /// Returns true if the Debug level is enabled.
    /// </summary>
    bool IsDebugEnabled { get; }

    /// <summary>
    /// Returns true if the Info level is enabled.
    /// </summary>
    bool IsInfoEnabled { get; }

    /// <summary>
    /// Returns true if the Warn level is enabled.
    /// </summary>
    bool IsWarnEnabled { get; }

    /// <summary>
    /// Returns true if the Error level is enabled.
    /// </summary>
    bool IsErrorEnabled { get; }

    /// <summary>
    /// Returns true if the Fatal level is enabled.
    /// </summary>
    bool IsFatalEnabled { get; }

    /// <summary>
    /// Writes to the trace stream if it is enabled.
    /// The provider method is invoked only in case the level is enabled.
    /// </summary>
    /// <param name="provider">An application level method which creates the log message when invoked.</param>
    void TraceDelegated(LogMessageProvider provider);

    /// <summary>
    /// Writes to the debug stream if it is enabled.
    /// The provider method is invoked only in case the level is enabled.
    /// </summary>
    /// <param name="provider">An application level method which creates the log message when invoked.</param>
    void DebugDelegated(LogMessageProvider provider);

    /// <summary>
    /// Writes to the info stream if it is enabled.
    /// The provider method is invoked only in case the level is enabled.
    /// </summary>
    /// <param name="provider">An application level method which creates the log message when invoked.</param>
    void InfoDelegated(LogMessageProvider provider);

    /// <summary>
    /// Writes to the warning stream if it is enabled.
    /// The provider method is invoked only in case the level is enabled.
    /// </summary>
    /// <param name="provider">An application level method which creates the log message when invoked.</param>
    void WarnDelegated(LogMessageProvider provider);

    /// <summary>
    /// Writes to the error stream if it is enabled.
    /// The provider method is invoked only in case the level is enabled.
    /// </summary>
    /// <param name="provider">An application level method which creates the log message when invoked.</param>
    void ErrorDelegated(LogMessageProvider provider);

    /// <summary>
    /// Writes to the fatal stream if it is enabled.
    /// The provider method is invoked only in case the level is enabled.
    /// </summary>
    /// <param name="provider">An application level method which creates the log message when invoked.</param>
    void FatalDelegated(LogMessageProvider provider);

    /// <summary>
    /// Increments the indentation of all loggers by one level.
    /// The maximum limit is <see cref="byte.MaxValue"/>.
    /// When this limit is reached, the indentation level is no longer raised and stays constant.
    /// </summary>
    /// <returns>The indentation level of the log, after incrementing it.</returns>
    byte Indent();

    /// <summary>
    /// Decrements the indentation of all loggers by one level.
    /// The limit is 0. When this limit is reached, the indentation level 
    /// is no longer changed and stays constant.
    /// </summary>
    /// <returns>The indentation level of the log, after changing it.</returns>
    byte Unindent();

    /// <summary>
    /// Resets the indentation of all loggers to 0.
    /// </summary>
    void ResetIndent();

    /// <summary>
    /// Returns the current indentation level for all loggers.
    /// </summary>
    byte IndentLevel { get; }

    /// <summary>
    /// Returns the list of <seealso cref="IAppender"/>s of logger.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays")]
    IAppender[] Appenders { get; }



    void WriteLog(string message);

    void WriteLog(LogTypeEnum logType, string message);

    void WriteLog(LogTypeEnum logType, Func<string> getMessage);
   
    void WriteError(string message);

    void WriteWarning(string message);

    void WriteInfo(string message);

    void WriteDebug(string message);

  }

  /// <summary>
  /// Delegate used for logging purposes.
  /// </summary>
  /// <returns>The string to log.</returns>
  /// <seealso cref="ILogger.DebugDelegated"/>
  /// <seealso cref="ILogger.InfoDelegated"/>
  /// <seealso cref="ILogger.WarnDelegated"/>
  /// <seealso cref="ILogger.ErrorDelegated"/>
  /// <seealso cref="ILogger.FatalDelegated"/>
  public delegate string LogMessageProvider();

  public enum LogTypeEnum
  {
      Fatal,
      Error,
      Warning,
      Info,
      Debug
  }
}
