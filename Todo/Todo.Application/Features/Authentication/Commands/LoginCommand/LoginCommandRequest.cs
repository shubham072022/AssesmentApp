using MediatR;
using Todo.Application.Common.Wrapper.Abstract;

namespace Todo.Application.Features.Authentication.Commands.LoginCommand
{
    public class LoginCommandRequest : IRequest<IResponse>
    {
        public string Email { get; init; }
        public string Password { get; init; }
    }
}
