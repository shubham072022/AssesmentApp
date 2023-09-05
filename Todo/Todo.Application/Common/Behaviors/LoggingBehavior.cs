using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace Todo.Application.Common.Behaviors
{
    public class LoggingBehavior<TRequest> : IRequestPreProcessor<TRequest> 
    {
        private readonly ILogger _logger;
        public LoggingBehavior(ILogger logger) 
        { 
            _logger = logger;
        }

        public async Task Process(TRequest request,CancellationToken cancellationToken)
        {
            _logger.LogInformation("Todo Request: {@Request}", request);
        }
    }
}
