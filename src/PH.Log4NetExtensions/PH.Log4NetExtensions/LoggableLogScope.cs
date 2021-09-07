using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using log4net;
using log4net.Core;

namespace PH.Log4NetExtensions
{
    public abstract class LoggableLogScope : LogScope 
    {
        protected readonly string _msg;
        protected readonly ILog Log;
        private readonly Type _declaringType;
        private readonly Level _level;

        internal LoggableLogScope([NotNull] ILog log,[NotNull] log4net.Core.Level level,[CanBeNull] string message, [CallerMemberName] string memberName = "") 
            : base(string.IsNullOrEmpty(message) ? memberName : message)
        {
            _msg = message;
            Log  = log;

            StackFrame frame  = new StackFrame(1);
            var        method = frame.GetMethod();
            var        type   = method.DeclaringType;
            var        name   = method.Name;
            _declaringType = type;

            //_declaringType = System.Reflection.MethodBase.GetCurrentMethod().get.DeclaringType;
            _level = level;

            Log.Logger.Log(_declaringType, _level, GetBegin(), null);
        }

        [NotNull]
        private string GetBegin() => $"----> {_msg}\t Begin Disposable Scope";
        [NotNull]
        private string GetEnd() => $"<---- {_msg}\t End Disposable Scope";

        protected override void Dispose(bool disposing)
        {
            Log.Logger.Log(_declaringType, _level, GetEnd(), null);
            base.Dispose(disposing);
        }

        
    }
}