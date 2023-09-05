using Microsoft.AspNetCore.Identity;
using Todo.Application.Common.Interfaces;
using Todo.Application.Common.Wrapper.Abstract;
using Todo.Application.Common.Wrapper.Concrete;
using Todo.Application.Dtos;
using Todo.Application.Features.Authentication.Commands.LoginCommand;
using Todo.Application.Features.Authentication.Commands.RegisterCommand;
using Todo.Application.Repositories.Commands;
using Todo.Idenity.DbContext;
using Todo.Idenity.Services.IServices;
using Todo.Shared.Models;

namespace Todo.Idenity.Repository.Commands
{
    public class AuthenticationCommandRepository : IAuthenticationCommandRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly TodoIdentityDbContext _db;
        private readonly ITokenService _tokenService;
        private readonly ICurrentUserService _currentUserService;

        public AuthenticationCommandRepository(UserManager<ApplicationUser> userManager,
            TodoIdentityDbContext db
            ,ITokenService tokenService
            ,ICurrentUserService currentUserService)
        {
            _userManager = userManager;
            _db = db;
            _tokenService = tokenService;
            _currentUserService = currentUserService;
        }

        public async Task<IResponse> Register(RegisterCommandRequest model,CancellationToken cancellationToken)
        {
            var existingUser = await _userManager.FindByEmailAsync(model.Email);
            if(existingUser != null)
            {
                return new ErrorResponse(400, "User with same email already exists.");
            }
            ApplicationUser user = new ApplicationUser
            {
                Email = model.Email,
                UserName = model.Email,
                NormalizedEmail = model.Email.ToUpper()
            };

            var result = await _userManager.CreateAsync(user);
            if(result.Succeeded)
            {
                await _userManager.AddPasswordAsync(user, model.Password);
            }
            else
            {
                return new ErrorResponse(400, result.Errors.Select(e => e.Description).ToList());
            }
            await _db.SaveChangesAsync(cancellationToken);
            var token = await _tokenService.GetToken(user,cancellationToken);

            var currentUser = new LoggedInUserDTO()
            {
                UserId = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Token = token.AccessToken
            };
            await _currentUserService.SetCurrentUser(currentUser);

            return new DataResponse<TokenDTO>(token, 200);
        }

        public async Task<IResponse> Login(LoginCommandRequest model,CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return new ErrorResponse(400, "Email or password is incorrect, pleae check your credentials.");
            }
            else
            {
                if(!(await _userManager.CheckPasswordAsync(user, model.Password)))
                {
                    return new ErrorResponse(400, "Email or password is incorrect, pleae check your credentials.");
                }
            }
            var token = await _tokenService.GetToken(user, cancellationToken);
            var currentUser = new LoggedInUserDTO()
            {
                UserId = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Token = token.AccessToken
            };
            await _currentUserService.SetCurrentUser(currentUser);
            return new DataResponse<TokenDTO>(token, 200);
        }
    }
}
