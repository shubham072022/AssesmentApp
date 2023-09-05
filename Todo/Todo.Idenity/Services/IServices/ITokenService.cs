using System.Security.Claims;
using Todo.Application.Dtos;
using Todo.Shared.Models;

namespace Todo.Idenity.Services.IServices
{
    public interface ITokenService
    {
        Task<TokenDTO> GetToken(ApplicationUser user, CancellationToken cancellationToken);
        Task<IEnumerable<Claim>> GetClaims(ApplicationUser user, List<string> audiences);
        string CreateRefreshToken();
    }
}
