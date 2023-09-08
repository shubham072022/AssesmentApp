using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Application.Common.Wrapper.Abstract;
using Todo.Application.Repositories.Commands;

namespace Todo.Application.Features.Authentication.Commands.LoginCommand
{
    public class LoginCommandHandler : IRequestHandler<LoginCommandRequest,IResponse>
    {
        private readonly IAuthenticationCommandRepository _command;
        public LoginCommandHandler(IAuthenticationCommandRepository command) 
        {
            _command = command;
        }

        public async Task<IResponse> Handle(LoginCommandRequest request,CancellationToken cancellationToken)
        {
            return await _command.Login(request,cancellationToken);
        }
    }
}
