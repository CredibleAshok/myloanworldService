using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ExceptionHandling;

namespace SuperCheapCart.Exception
{
    public class ExceptionLoggerContex
    {
        public ExceptionContext ExceptionContext { get; set; }
        public bool CanBeHandled { get; set; }
    }
}