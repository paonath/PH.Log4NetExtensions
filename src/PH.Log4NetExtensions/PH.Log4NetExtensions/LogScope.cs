using System;
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
        public static LogScope Init([NotNull] string scopeName) => new LogScope(message: scopeName);


        private readonly IDisposable _ndc;

        private LogScope([NotNull] string message)
        {
            _ndc = log4net.NDC.Push(message);
        }

        

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose()
        {
            _ndc.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}