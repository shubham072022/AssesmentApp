using MediatR;
using Todo.Application.Common.Wrapper.Abstract;

namespace Todo.Application.Features.Authentication.Commands.RegisterCommand
{
    public class RegisterCommandRequest : IRequest<IResponse>
    {
        public string Email { get; init; }
        public string Password { get; init; }
        public string ConfirmPassword { get; init; }
    }
}
