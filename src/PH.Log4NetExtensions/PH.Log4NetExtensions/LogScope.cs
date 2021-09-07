using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

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
        public static LogScope Init([CanBeNull] string scopeName = "", [CallerMemberName] string callMemberName = "")
        {
            if (string.IsNullOrEmpty(scopeName))
            {
                scopeName = callMemberName;
            }
            return new LogScope(message: scopeName);
        }


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
}