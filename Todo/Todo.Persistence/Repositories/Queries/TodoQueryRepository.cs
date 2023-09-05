using Todo.Application.Repositories.Queries;
using Todo.Domain.Entities;
using Todo.Persistence.DbContext;
using Todo.Persistence.Repositories.Queries.Base;

namespace Todo.Persistence.Repositories.Queries
{
    public class TodoQueryRepository : QueryRepository<TodoM>,ITodoQueryRepository
    {
        public TodoQueryRepository(TodoDbContext context): base(context) { }    
    }
}
