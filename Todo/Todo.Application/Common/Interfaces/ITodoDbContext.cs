using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;

namespace Todo.Application.Common.Interfaces
{
    public interface ITodoDbContext
    {
        DbSet<TodoM> TodoM { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
