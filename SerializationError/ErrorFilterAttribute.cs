using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace SerializationError
{
    public class ErrorFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            context.Result = HandlException(context.HttpContext, context.Exception);
        }

        private static IActionResult HandlException(HttpContext context, Exception ex)
        {
            context.Response.StatusCode = 500;

            return new JsonResult(new { error = new { code = context.Response.StatusCode, message = ex.Message } });
        }
    }
}
