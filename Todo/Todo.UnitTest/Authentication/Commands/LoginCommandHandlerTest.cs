using Shouldly;
using Todo.Application.Common.Wrapper.Concrete;
using Todo.Application.Dtos;
using Todo.Application.Features.Authentication.Commands.LoginCommand;
using Todo.Idenity.Repository.Commands;
using Todo.UnitTest.Mocks;

namespace Todo.UnitTest.Authentication.Commands
{
    public class LoginCommandHandlerTest : MockAuthenticationContext
    {
        private readonly AuthenticationCommandRepository _handler;

        public LoginCommandHandlerTest() 
        {
            _handler = new AuthenticationCommandRepository(userManager.Object, mockContext.Object, tokenService.Object, currentUserService.Object);
        }

        [Fact]
        public async Task User_LoggedIn_Success()
        {
            var result = await _handler.Login(new LoginCommandRequest { Email = "shubham@atharvasystem.com", Password = "05@Jan1999" }, default);
            result.ShouldBeOfType<DataResponse<TokenDTO>>();
        }
    }
}
