using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Todo.Application.Common.Interfaces;
using Todo.Application.Dtos;
using Todo.Domain.Entities;
using Todo.Idenity.DbContext;
using Todo.Idenity.Services.IServices;
using Todo.Idenity.Settings;
using Todo.Shared.Models;

namespace Todo.Idenity.Services
{
    public class TokenService : ITokenService
    {
        private readonly JWTSettings _jwtSettings;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly TodoIdentityDbContext _db;
        private readonly ICurrentUserService _currentUserService;

        public TokenService(UserManager<ApplicationUser> userManager,
            IOptions<JWTSettings> jwtSettings
            ,TodoIdentityDbContext db
            , ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
            _jwtSettings = jwtSettings.Value;
            _db = db;
            _userManager = userManager;
        }

        public async Task<TokenDTO> GetToken(ApplicationUser user, CancellationToken cancellationToken)
        {
            var accessTokenExpiration = DateTime.Now.AddMinutes(_jwtSettings.AccessTokenExpiration);
            var refreshTokenExpiration = DateTime.Now.AddMinutes(_jwtSettings.RefreshTokenExpiration);
            var securityKey = Encoding.ASCII.GetBytes(_jwtSettings.SecurityKey);
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(securityKey),
                SecurityAlgorithms.HmacSha256Signature);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                    issuer: _jwtSettings.Issuer,
                    audience: _jwtSettings.Audience[0],
                    expires: accessTokenExpiration,
                     notBefore: DateTime.Now,
                     claims: await GetClaims(user, _jwtSettings.Audience),
                     signingCredentials: signingCredentials);

            var handler = new JwtSecurityTokenHandler();

            var token = handler.WriteToken(jwtSecurityToken);

            var tokenDto = new TokenDTO
            {
                AccessToken = token,
                RefreshToken = CreateRefreshToken()
            };

            var refreshToken = new RefreshTokenM()
            {
                UserId = user.Id,
                RefreshToken = tokenDto.RefreshToken,
                RefreshTokenExpiration = refreshTokenExpiration,
            };

            await _db.RefreshTokenM.AddAsync(refreshToken, cancellationToken);

            await _db.SaveChangesAsync(cancellationToken);
            LoggedInUserDTO loggedInUser = new LoggedInUserDTO()
            {
                UserId = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Token = token,
            };
            await _currentUserService.SetCurrentUser(loggedInUser);

            return tokenDto;
        }

        public async Task<IEnumerable<Claim>> GetClaims(ApplicationUser user, List<string> audiences)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, $"{user.Email}"),
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim("Id",user.Id.ToString()),
                new Claim("expiration",DateTime.Now.AddMinutes(_jwtSettings.RefreshTokenExpiration).ToString()),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            var roles = await _userManager.GetRolesAsync(user);
            claims.AddRange(roles.Select(x => new Claim(ClaimTypes.Role, x)));
            claims.AddRange(audiences.Select(x => new Claim(JwtRegisteredClaimNames.Aud, x)));
            return claims;
        }

        public string CreateRefreshToken()
        {
            var numberByte = new byte[32];
            using var rnd = RandomNumberGenerator.Create();
            rnd.GetBytes(numberByte);
            return Convert.ToBase64String(numberByte);
        }
    }
}
