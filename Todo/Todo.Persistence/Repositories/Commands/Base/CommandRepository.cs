using Microsoft.EntityFrameworkCore;
using Todo.Application.Common.Wrapper.Abstract;
using Todo.Application.Common.Wrapper.Concrete;
using Todo.Application.Repositories.Commands.Base;
using Todo.Persistence.DbContext;

namespace Todo.Persistence.Repositories.Commands.Base
{
    public class CommandRepository<T> : ICommandRepository<T> where T : class
    {
        protected readonly TodoDbContext _db;
        public CommandRepository(TodoDbContext db) {
            _db = db;
        }

        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _db.Set<T>().AddAsync(entity, cancellationToken);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            await _db.Set<T>().AddRangeAsync(entities, cancellationToken);
            await _db.SaveChangesAsync();
        }

        public async Task<IResponse> Remove(T entity, CancellationToken cancellationToken = default)
        {
            try
            {
                _db.Set<T>().Remove(entity);
                await _db.SaveChangesAsync();
                return new SuccessResponse(200, "Deleted successfully");
            }
            catch(Exception ex)
            {
                return new ErrorResponse(500, "There is some issue with data, Please check that it is not being used");
            }
        }

        public async Task<IResponse> RemoveRange(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            try
            {
                _db.Set<T>().RemoveRange(entities);
                await _db.SaveChangesAsync();
                return new SuccessResponse(200, "Deleted successfully");
            }
            catch (Exception ex)
            {
                return new ErrorResponse(500, "There is some issue with data, Please check that it is not being used");
            }
        }
    }
}
