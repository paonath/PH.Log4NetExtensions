using System;
using JetBrains.Annotations;
using log4net;
using log4net.Core;

namespace PH.Log4NetExtensions
{
    /// <summary>
    /// Log4Net Exstensions
    /// </summary>
    public static class ILogExtensions
    {
        /// <summary>Traces the specified message.</summary>
        /// <param name="log">The log.</param>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public static void Trace([NotNull] this ILog log, string message, [CanBeNull] Exception exception) =>
            Trace(log.Logger, message, exception);

        /// <summary>Traces the specified message.</summary>
        /// <param name="logger">The logger.</param>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public static void Trace([NotNull] this ILogger logger, string message, [CanBeNull] Exception exception)
        {
            logger.Log(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, Level.Trace, message,
                       exception);
        }

        /// <summary>Traces the specified message.</summary>
        /// <param name="logger">The logger.</param>
        /// <param name="message">The message.</param>
        public static void Trace([NotNull] this ILogger logger, string message) => Trace(logger, message, null);

        /// <summary>Traces the specified message.</summary>
        /// <param name="log">The log.</param>
        /// <param name="message">The message.</param>
        public static void Trace([NotNull] this ILog log, string message) => Trace(log, message, null);


        /// <summary>Gets a NDC scope.</summary>
        /// <param name="log">The log.</param>
        /// <param name="scopeName">Name of the scope.</param>
        /// <returns><see cref="IDisposable"/> scope</returns>
        public static IDisposable GetNdcScope([NotNull] this ILog log, [NotNull] string scopeName) =>
            InitTraceLogScope(log, scopeName);
           

        /// <summary>Initializes the <see cref="TraceLogScope">trace log scope</see> .</summary>
        /// <param name="log">The log.</param>
        /// <param name="scopeName">Name of the scope.</param>
        /// <returns><see cref="IDisposable"/> scope</returns>
        public static TraceLogScope InitTraceLogScope([NotNull] this ILog log, [NotNull] string scopeName) =>
            TraceLogScope.Init(log, scopeName);

        /// <summary>Initializes the <see cref="DebugLogScope">debug log scope</see>.</summary>
        /// <param name="log">The log.</param>
        /// <param name="scopeName">Name of the scope.</param>
        /// <returns></returns>
        public static DebugLogScope InitDebugLogScope([NotNull] this ILog log, [NotNull] string scopeName) =>
            DebugLogScope.Init(log, scopeName);

        ///// <summary>Initializes the <see cref="InfoLogScope">info log scope</see>.</summary>
        ///// <param name="log">The log.</param>
        ///// <param name="scopeName">Name of the scope.</param>
        ///// <returns></returns>
        //public static InfoLogScope InitInfoLogScope([NotNull] this ILog log, [NotNull] string scopeName) =>
        //    InfoLogScope.Init(log, scopeName);

        ///// <summary>Initializes the <see cref="WarnLogScope">warn log scope</see>.</summary>
        ///// <param name="log">The log.</param>
        ///// <param name="scopeName">Name of the scope.</param>
        ///// <returns></returns>
        //public static WarnLogScope InitWarnLogScope([NotNull] this ILog log, [NotNull] string scopeName) =>
        //    WarnLogScope.Init(log, scopeName);

        ///// <summary>Initializes the <see cref="ErrorLogScope">error log scope</see>.</summary>
        ///// <param name="log">The log.</param>
        ///// <param name="scopeName">Name of the scope.</param>
        ///// <returns></returns>
        //public static ErrorLogScope InitErrorLogScope([NotNull] this ILog log, [NotNull] string scopeName) =>
        //    ErrorLogScope.Init(log, scopeName);

        ///// <summary>Initializes the <see cref="FatalLogScope">fatal log scope</see>.</summary>
        ///// <param name="log">The log.</param>
        ///// <param name="scopeName">Name of the scope.</param>
        ///// <returns></returns>
        //public static FatalLogScope InitFatalLogScope([NotNull] this ILog log, [NotNull] string scopeName) =>
        //    FatalLogScope.Init(log, scopeName);



    }
}
