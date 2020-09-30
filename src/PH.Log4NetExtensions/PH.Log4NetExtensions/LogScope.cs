using System;
using JetBrains.Annotations;
using log4net;

namespace PH.Log4NetExtensions
{
    /// <summary>
    /// A NDC Log Scope
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class LogScope : IDisposable
    {
        /// <summary>Initializes the specified scope with name.</summary>
        /// <param name="scopeName">Name of the scope.</param>
        /// <returns><see cref="IDisposable"/> scope</returns>
        [NotNull]
        public static LogScope Init([NotNull] string scopeName) => new LogScope(message: scopeName);


        private readonly IDisposable _ndc;

        internal LogScope([NotNull] string message)
        {
            _ndc = log4net.NDC.Push(message);
        }


        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _ndc?.Dispose();
            }
        }

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

    /// <summary>
    /// A NDC Log Scope thath writes Begin and end on Trace appender
    /// </summary>
    /// <seealso cref="PH.Log4NetExtensions.LogScope" />
    /// <seealso cref="System.IDisposable" />
    public class TraceLogScope : LogScope, IDisposable
    {
        private readonly string _m;
        private readonly ILog _log;
        public TraceLogScope([NotNull] ILog log,[NotNull] string message):base(message)
        {
            _m   = message;
            _log = log;
            _log?.Trace($"----> {_m}");
        }

        /// <summary>Initializes the specified scope with name and Trace begin and End on logger.</summary>
        /// <param name="log">The loger.</param>
        /// <param name="scopeName">Name of the scope.</param>
        /// <returns><see cref="IDisposable"/> scope</returns>
        [NotNull]
        public static TraceLogScope Init([NotNull] ILog log,[NotNull] string scopeName) => new TraceLogScope(log,message: scopeName);

        protected override void Dispose(bool disposing)
        {
            _log?.Trace($"<---- {_m}");
            base.Dispose(disposing);
        }
    }
}