using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MockQueryable.Moq;
using Moq;
using Todo.Application.Common.Interfaces;
using Todo.Application.Common.Wrapper.Abstract;
using Todo.Application.Dtos;
using Todo.Application.Features.Authentication.Commands.LoginCommand;
using Todo.Application.Repositories.Commands;
using Todo.Domain.Entities;
using Todo.Idenity.DbContext;
using Todo.Idenity.Services;
using Todo.Idenity.Services.IServices;
using Todo.Shared.Models;

namespace Todo.UnitTest.Mocks
{
    public class MockAuthenticationContext : BaseMockContext
    {
        protected readonly Mock<TodoIdentityDbContext> mockContext;
        protected readonly Mock<UserManager<ApplicationUser>> userManager;
        protected readonly Mock<ICurrentUserService> currentUserService;
        protected readonly Mock<ITokenService> tokenService;

        public MockAuthenticationContext()
        {
            var store = new Mock<IUserStore<ApplicationUser>>();
            userManager = new Mock<UserManager<ApplicationUser>>(store.Object, null, null, null, null, null, null, null, null);
            userManager.Setup(x => x.FindByEmailAsync(It.IsAny<string>()).Result).Returns(new Mock<ApplicationUser>().Object);
            currentUserService = new Mock<ICurrentUserService>();
            currentUserService.Setup(x => x.GetCurrentUser().Result).Returns(new Mock<LoggedInUserDTO>().Object);
            mockContext = GetApplicationUserDbContext();
            tokenService = new Mock<ITokenService>(); tokenService = new Mock<ITokenService>();
            tokenService.Setup(t => t.GetToken(It.IsAny<ApplicationUser>(),It.IsAny<CancellationToken>()).Result)
                    .Returns(new TokenDTO
                    {
                        AccessToken = Guid.NewGuid().ToString(),
                        RefreshToken = Guid.NewGuid().ToString()
                    });
            
        }
        protected Mock<TodoIdentityDbContext> GetApplicationUserDbContext()
        {
            var mockContext = new Mock<TodoIdentityDbContext>();

            var userList = GetUsers();
            mockContext.Setup(r => r.Users).Returns(userList.AsQueryable().BuildMockDbSet().Object);
            mockContext.Setup(m => m.Users.AddAsync(It.IsAny<ApplicationUser>(), default))
                .Callback<ApplicationUser, CancellationToken>((s, token) =>
                {
                    userList.Add(s);
                });

            return mockContext;
        }

        protected List<ApplicationUser> GetUsers()
        {
            return new List<ApplicationUser>
            {
                new ApplicationUser
                {
                    Id = 1,
                    Email="shubham@atharvasystem.com",
                    PasswordHash = "AQAAAAIAAYagAAAAEAXrJdVIsgDKOogutTwXypeWDTAGpPwpj+oRwn8di0dZFQl5Ve1EnK41Y6qkkdKWgg==",
                    UserName = "shubham@atharvasystem.com"
                }
            };
        }
    }
}
