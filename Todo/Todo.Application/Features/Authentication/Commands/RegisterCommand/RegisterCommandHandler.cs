using MediatR;
using Todo.Application.Common.Wrapper.Abstract;
using Todo.Application.Repositories.Commands;
using Todo.Application.UnitOfWork;

namespace Todo.Application.Features.Authentication.Commands.RegisterCommand
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommandRequest,IResponse>
    {
        private readonly IAuthenticationCommandRepository _command;
        public RegisterCommandHandler(IAuthenticationCommandRepository command)
        {
            _command = command;
        }

        public async Task<IResponse> Handle(RegisterCommandRequest request,CancellationToken cancellationToken)
        {
            return await _command.Register(request,cancellationToken);
        }
    }
}
