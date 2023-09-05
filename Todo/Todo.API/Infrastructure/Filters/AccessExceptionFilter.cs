using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Todo.Application.Common.Exceptions;
using Todo.Application.Common.Wrapper.Concrete;

namespace Todo.API.Infrastructure.Filters
{
    public class AccessExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is UnauthorizedAccessException)
            {
                context.Result = new UnauthorizedObjectResult(new ErrorResponse(StatusCodes.Status403Forbidden, context.Exception.Message));
                return;
            }
            if (context.Exception is ForbiddenAccessException)
            {
                context.Result = new UnauthorizedObjectResult(new ErrorResponse(StatusCodes.Status403Forbidden, context.Exception.Message));
                return;
            }
        }
    }
}
