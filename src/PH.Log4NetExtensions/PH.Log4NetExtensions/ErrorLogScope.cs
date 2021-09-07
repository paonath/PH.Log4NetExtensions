using System;
using JetBrains.Annotations;
using log4net;
using log4net.Core;

namespace PH.Log4NetExtensions
{
    ///// <summary>
    ///// A NDC Log Scope thath writes Begin and end on Error appender
    ///// </summary>
    ///// <seealso cref="PH.Log4NetExtensions.LoggableLogScope" />
    //public class ErrorLogScope : LoggableLogScope
    //{
    //    public ErrorLogScope([NotNull] ILog log, [NotNull] string message) : base(log, Level.Error, message)
    //    {
    //    }

    //    /// <summary>Initializes the specified scope with name and Error begin and End on logger.</summary>
    //    /// <param name="log">The loger.</param>
    //    /// <param name="scopeName">Name of the scope.</param>
    //    /// <returns><see cref="IDisposable"/> scope</returns>
    //    [NotNull]
    //    public static ErrorLogScope Init([NotNull] ILog log,[NotNull] string scopeName) => new ErrorLogScope(log,message: scopeName);

    //}
}