using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Reflection;
using Todo.Application.Common.Interfaces;
using Todo.Domain.Common;
using Todo.Domain.Entities;

namespace Todo.Persistence.DbContext
{
    public class TodoDbContext : Microsoft.EntityFrameworkCore.DbContext
    {

        private readonly IMediator Mediator;
        private readonly ICurrentUserService _currentUserService;
        private IDbContextTransaction Transaction;
        public TodoDbContext(DbContextOptions<TodoDbContext> options
            , IMediator mediator
            , ICurrentUserService currentUserService) : base(options) 
        {
            Mediator = mediator;
            _currentUserService = currentUserService;
        }

        public DbSet<TodoM> TodoM { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                foreach (var entry in this.ChangeTracker.Entries<BaseAuditableEntity>())
                {
                    if (entry.State == EntityState.Added)
                    {
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = _currentUserService.GetCurrentUser().Result != null ? (await _currentUserService.GetCurrentUser()).UserId : 0;
                    }

                    if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
                    {
                        entry.Entity.ModifiedBy = _currentUserService.GetCurrentUser().Result != null ? (await _currentUserService.GetCurrentUser()).UserId : 0;
                        entry.Entity.ModifiedDate = DateTime.Now;
                    }
                }

                return await base.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                Transaction.Rollback();
                throw ex;
            }
        }
    }
}
