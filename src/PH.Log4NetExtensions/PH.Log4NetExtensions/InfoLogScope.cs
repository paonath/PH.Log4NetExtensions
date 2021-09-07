using System;
using JetBrains.Annotations;
using log4net;
using log4net.Core;

namespace PH.Log4NetExtensions
{
    ///// <summary>
    ///// A NDC Log Scope thath writes Begin and end on Info appender
    ///// </summary>
    ///// <seealso cref="PH.Log4NetExtensions.LoggableLogScope" />
    //public class InfoLogScope : LoggableLogScope
    //{
    //    public InfoLogScope([NotNull] ILog log, [NotNull] string message) : base(log, Level.Info, message)
    //    {
    //    }

    //    /// <summary>Initializes the specified scope with name and Info begin and End on logger.</summary>
    //    /// <param name="log">The loger.</param>
    //    /// <param name="scopeName">Name of the scope.</param>
    //    /// <returns><see cref="IDisposable"/> scope</returns>
    //    [NotNull]
    //    public static InfoLogScope Init([NotNull] ILog log,[NotNull] string scopeName) => new InfoLogScope(log,message: scopeName);

    //}
}