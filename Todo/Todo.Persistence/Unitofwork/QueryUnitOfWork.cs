using Todo.Application.Repositories.Queries;
using Todo.Application.UnitOfWork;
using Todo.Persistence.DbContext;
using Todo.Persistence.Repositories.Queries;

namespace Todo.Persistence.Unitofwork
{
    public class QueryUnitOfWork : IQueryUnitOfWork
    {
        private readonly TodoDbContext _db;
        public QueryUnitOfWork(TodoDbContext db) 
        {
            _db = db;
        }

        public TodoQueryRepository todoQueryRepository;
        public ITodoQueryRepository TodoQueryRepository => todoQueryRepository ?? (todoQueryRepository = new TodoQueryRepository(_db));
    }
}
