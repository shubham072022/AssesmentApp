﻿using FluentValidation;
using MediatR;

namespace Todo.Application.Common.Behaviors
{
    public class ValidationBehavior<TRequest,TResponse> : IPipelineBehavior<TRequest,TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,CancellationToken cancellationToken)
        {
            if(_validators.Any()) 
            {
                var context = new ValidationContext<TRequest>(request);

                var validationResult = await Task.WhenAll(
                    _validators.Select(v => v.ValidateAsync(context,cancellationToken)));

                var failures = validationResult
                    .Where(r => r.Errors.Any())
                    .SelectMany(r => r.Errors)
                    .ToList();

                if(failures.Any())
                {
                    failures.ForEach(r => { r.ErrorMessage = "Validation: " + r.ErrorMessage; });
                    
                }
            }

            return await next();
        }
    }
}
