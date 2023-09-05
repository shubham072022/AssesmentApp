using Todo.Application.Common.Wrapper.Abstract;
using Todo.Application.Features.Authentication.Commands.LoginCommand;
using Todo.Application.Features.Authentication.Commands.RegisterCommand;

namespace Todo.Application.Repositories.Commands
{
    public interface IAuthenticationCommandRepository
    {
        Task<IResponse> Register(RegisterCommandRequest model, CancellationToken cancellationToken);
        Task<IResponse> Login(LoginCommandRequest model, CancellationToken cancellationToken);
    }
}
