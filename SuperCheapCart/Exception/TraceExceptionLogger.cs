using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http.ExceptionHandling;

namespace SuperCheapCart.Exception
{
    public class TraceExceptionLogger : ExceptionLogger
    {
        public override void LogCore(ExceptionLoggerContext context)
        {
            Trace.TraceError(context.ExceptionContext.Exception.ToString());
        }
    }
}