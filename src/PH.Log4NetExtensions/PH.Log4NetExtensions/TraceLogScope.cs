using System;
using JetBrains.Annotations;
using log4net;
using log4net.Core;

namespace PH.Log4NetExtensions
{
    /// <summary>
    /// A NDC Log Scope thath writes Begin and end on Trace appender
    /// </summary>
    /// <seealso cref="PH.Log4NetExtensions.LogScope" />
    /// <seealso cref="System.IDisposable" />
    public class TraceLogScope : LoggableLogScope, IDisposable
    {

        public TraceLogScope([NotNull] ILog log,[NotNull] string message):base(log, Level.Trace, message)
        {
        }

        /// <summary>Initializes the specified scope with name and Trace begin and End on logger.</summary>
        /// <param name="log">The loger.</param>
        /// <param name="scopeName">Name of the scope.</param>
        /// <returns><see cref="IDisposable"/> scope</returns>
        [NotNull]
        public static TraceLogScope Init([NotNull] ILog log,[NotNull] string scopeName) => new TraceLogScope(log,message: scopeName);

        
    }
}