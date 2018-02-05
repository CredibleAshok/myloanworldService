using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http.ExceptionHandling;

namespace SuperCheapCart.Exception
{
    public class GlobalExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            var showDetails = CustomErrorConfigHandler.ShouldSupplyFullException;
            System.Exception ex = null; //todo, this should be Exception
            string content = string.Empty;
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            if((context.ExceptionContext!= null)&&(context.ExceptionContext.Exception!= null))
            {
                ex = context.ExceptionContext.Exception;
            }
            else
            {
                if (context.Exception!= null)
                {
                    ex = context.Exception;
                }
            }
            if (ex != null)
            {
                if (showDetails) content = ex.ToString();
                else content = ex.Message;
                //TypeSwitch.Do(ex,
                //    TypeSwitch.Case<ArgumentException>(() => { statusCode = HttpStatusCode.BadRequest; }),
                //    TypeSwitch.Case<ArgumentNullException>(() => { statusCode = HttpStatusCode.BadRequest; }),
                //    TypeSwitch.Case<ArgumentOutOfRangeException>(() => { statusCode = HttpStatusCode.BadRequest; }),
                //    TypeSwitch.Case<ValidationException>(() => { statusCode = HttpStatusCode.BadRequest; })
                //    ); //todo content=((ValidationException))
            }
            context.Result = new TextPlainErrorResult()
            {
                StatusCode = statusCode,
                Content = content,
                Request = context.ExceptionContext.Request
            };

        }
        public override bool ShouldHandle(ExceptionHandlerContext context)
        {
            //return base.ShouldHandle(context);
            return true;
        }
    }
}