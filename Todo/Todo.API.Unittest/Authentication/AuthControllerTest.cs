using Xunit;
using Todo.Application.Repositories.Commands;
using NSubstitute;
using Todo.Application.Features.Authentication.Commands.LoginCommand;
using Microsoft.AspNetCore.Http;
using Shouldly;
using Todo.Application.Common.Constants;
using Todo.Application.Common.Wrapper.Concrete;
using Todo.Application.Dtos;
using Todo.Application.Common.Wrapper.Abstract;

namespace Todo.API.Unittest.Authentication
{
    public class AuthControllerTest
    {
        private readonly IAuthenticationCommandRepository repository = Substitute.For<IAuthenticationCommandRepository>();

        private LoginCommandHandler _handler;

        public AuthControllerTest()
        {
            _handler = new LoginCommandHandler(repository);
        }

        private DataResponse<TokenDTO> GetLoginResponse()
        {
            return new DataResponse<TokenDTO>(new TokenDTO(), CustomStatusCodes.Accepted);
        }

        [Fact]
        public async Task LoginTest()
        {
            var request = new LoginCommandRequest
            {
                Email = "shubham@atharvasystem.com",
                Password = "05@Jan1999"
            };

            var result = await _handler.Handle(request,CancellationToken.None);
            Assert.NotNull(result);

            result.ShouldBeOfType<IResponse>();

            DataResponse<TokenDTO> response = (DataResponse<TokenDTO>)result;

            response.StatusCode.ShouldBe(CustomStatusCodes.Accepted);

            response.Success.ShouldBe(true);

            response.Message.ShouldBe(Messages.Success);
        }
    }
}
