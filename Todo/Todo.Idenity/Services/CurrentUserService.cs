using Todo.Application.Common.Interfaces;
using Todo.Application.Dtos;

namespace Todo.Idenity.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private LoggedInUserDTO loggedInUser { get; set; }
        public CurrentUserService() { }

        public async Task SetCurrentUser(LoggedInUserDTO user)
        {
            this.loggedInUser = user;
        }

        public async Task<LoggedInUserDTO> GetCurrentUser()
        {
            return this.loggedInUser;
        }
    }
}
