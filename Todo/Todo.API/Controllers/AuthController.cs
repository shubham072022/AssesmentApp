using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Todo.Application.Common.Wrapper.Abstract;
using Todo.Application.Features.Authentication.Commands.LoginCommand;
using Todo.Application.Features.Authentication.Commands.RegisterCommand;

namespace Todo.API.Controllers
{
    public class AuthController : ApiController
    {
        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public async Task<IResponse> Register(RegisterCommandRequest request)
        {
            return await Mediator.Send(request);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<IResponse> Login(LoginCommandRequest request)
        {
            return await Mediator.Send(request);
        }
    }
}
