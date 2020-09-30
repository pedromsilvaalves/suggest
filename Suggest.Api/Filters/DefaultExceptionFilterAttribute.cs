using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;
using Suggest.Services.Models;
using System.Net;

namespace Suggest.Api.Filters
{
    public class DefaultExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private const string DEFAULT_EXCEPTION = "An unexpected error ocurred.";
        public override void OnException(ExceptionContext context)
        {
            Log.Error(context.Exception, context.Exception.Message);
            context.Result = new ObjectResult(new ErrorModel(DEFAULT_EXCEPTION))
            {
                StatusCode = HttpStatusCode.InternalServerError.GetHashCode()
            };
        }
    }
}
