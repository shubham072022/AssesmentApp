using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Todo.Application.Common.Wrapper.Concrete;
using FluentValidation;

namespace Todo.API.Infrastructure.Filters
{
    public class ApiValidationExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is ValidationException)
            {
                var exception = (ValidationException)context.Exception;
                context.Result = new BadRequestObjectResult(new ErrorResponse(StatusCodes.Status400BadRequest, exception.Errors.Select(err => err.ErrorMessage).ToList()));
                return;
            }

        }
    }
}
