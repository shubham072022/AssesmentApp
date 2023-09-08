using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;

namespace Todo.Application.Common.Interfaces
{
    public interface ITodoIdentityDbContext
    {
        string GetConnectionString { get; }
        DbSet<RefreshTokenM> RefreshTokenM { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        Task<int> SaveChangesWithoutLogAsync(CancellationToken cancellationToken);
    }
}
