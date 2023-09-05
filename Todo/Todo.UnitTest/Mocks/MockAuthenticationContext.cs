using Microsoft.EntityFrameworkCore;
using MockQueryable.Moq;
using Moq;
using Todo.Application.Common.Interfaces;
using Todo.Application.Dtos;
using Todo.Application.Repositories.Commands;
using Todo.Domain.Entities;
using Todo.Idenity.Services;
using Todo.Idenity.Services.IServices;
using Todo.Shared.Models;

namespace Todo.UnitTest.Mocks
{
    public class MockAuthenticationContext : BaseMockContext
    {
        private readonly Mock<IAuthenticationCommandRepository> mockContext;
        private readonly Mock<ICurrentUserService> currentUserService;
        protected readonly Mock<ITokenService> tokenService;

        public MockApplicationUserContext()
        {
            currentUserService = new Mock<ICurrentUserService>();
            currentUserService.Setup(x => x.GetCurrentUser().Result).Returns(new Mock<LoggedInUserDTO>().Object);
            mockContext = GetApplicationUserDbContext();
            tokenService = new Mock<ITokenService>(); tokenService = new Mock<ITokenService>();
            tokenService.Setup(t => t.GetToken(It.IsAny<ApplicationUser>(),It.IsAny<CancellationToken>()))
                    .Returns(new TokenDTO
                    {
                        AccessToken = Guid.NewGuid().ToString(),
                        RefreshToken = Guid.NewGuid().ToString(),
                    });
        }
        protected Mock<IAuthenticationCommandRepository> GetApplicationUserDbContext()
        {
            var mockContext = new Mock<IAuthenticationCommandRepository>();

            return mockContext;
        }
    }
}
