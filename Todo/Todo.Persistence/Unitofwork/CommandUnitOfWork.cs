using Todo.Application.Repositories.Commands;
using Todo.Application.UnitOfWork;
using Todo.Persistence.DbContext;
using Todo.Persistence.Repositories.Commands;

namespace Todo.Persistence.Unitofwork
{
    public class CommandUnitOfWork : ICommandUnitOfWork
    {
        private readonly TodoDbContext _db;
        public CommandUnitOfWork(TodoDbContext db)
        {
            _db = db;
        }

        public TodoCommandRepository todoCommandRepository;
        public ITodoCommandRepository TodoCommandRepository => todoCommandRepository ?? (todoCommandRepository = new TodoCommandRepository(_db));

    }
}
