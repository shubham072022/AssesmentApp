using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;
using Todo.Shared.Models;

namespace Todo.Idenity.DbContext
{
    public class TodoIdentityDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
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

        public string GetConnectionString { get => this.Database.GetDbConnection().ConnectionString; }
    }
}
