using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http.ExceptionHandling;

namespace MyLoanWorldService.Exception
{
    public class TraceExceptionLogger: ExceptionLogger
    {
        public override void LogCore(ExceptionLoggerContext context)
        {
            //base.Log(context);
            if(context.ExceptionContext != null)
            {
                Trace.TraceError(context.ExceptionContext.Exception.ToString());
            }
            else
            {
                if(context.Exception != null)
                {
                    Trace.TraceError(context.Exception.ToString());
                }
            }
        }
        public override bool ShouldLog(ExceptionLoggerContext context)
        {
            //return base.ShouldLog(context);
            return true;
        }
    }
}