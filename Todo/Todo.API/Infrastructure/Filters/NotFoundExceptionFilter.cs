using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Todo.Application.Common.Exceptions;
using Todo.Application.Common.Wrapper.Concrete;

namespace Todo.API.Infrastructure.Filters
{
    public class NotFoundExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is NotFoundException)
            {
                context.Result = new NotFoundObjectResult(new ErrorResponse(StatusCodes.Status404NotFound, context.Exception.Message));
                return;
            }
        }
    }
}
