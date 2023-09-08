using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Todo.Application.Common.Interfaces;
using Todo.Domain.Entities;
using Todo.Shared.Models;

namespace Todo.Idenity.DbContext
{
    public class TodoIdentityDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>, ITodoIdentityDbContext
    {
        private readonly IMediator mediator;
        public TodoIdentityDbContext(DbContextOptions<TodoIdentityDbContext> options,
            IMediator mediator):base(options)
        {
            this.mediator = mediator;
        }

        public DbSet<RefreshTokenM> RefreshTokenM { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public async Task<int> SaveChangesWithoutLogAsync(CancellationToken cancellationToken)
        {
            return await base.SaveChangesAsync();
        }

        public string GetConnectionString { get => this.Database.GetDbConnection().ConnectionString; }
    }
}
