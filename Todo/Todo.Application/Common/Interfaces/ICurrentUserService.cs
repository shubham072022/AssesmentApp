using Todo.Application.Dtos;

namespace Todo.Application.Common.Interfaces
{
    public interface ICurrentUserService
    {
        Task SetCurrentUser(LoggedInUserDTO user);
        Task<LoggedInUserDTO> GetCurrentUser();
    }
}
