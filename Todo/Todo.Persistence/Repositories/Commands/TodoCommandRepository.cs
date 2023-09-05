using Todo.Application.Common.Wrapper.Abstract;
using Todo.Application.Common.Wrapper.Concrete;
using Todo.Application.Repositories.Commands;
using Todo.Domain.Entities;
using Todo.Persistence.DbContext;
using Todo.Persistence.Repositories.Commands.Base;

namespace Todo.Persistence.Repositories.Commands
{
    public class TodoCommandRepository : CommandRepository<TodoM>,ITodoCommandRepository
    {
        private readonly TodoDbContext _db;
        public TodoCommandRepository(TodoDbContext db):base(db)
        {
            _db = db;
        }
        public async Task<IResponse> Update(TodoM todoM)
        {
            try
            {
                var task = _db.TodoM.FirstOrDefault(t => t.Id == todoM.Id);
                if (task == null)
                {
                    return new ErrorResponse(404, "Task not found");
                }
                task.Title = todoM.Title;
                task.IsCompleted = todoM.IsCompleted;
                await _db.SaveChangesAsync();
                return new SuccessResponse(200, "Task modified");
            }
            catch (Exception ex)
            {
                return new ErrorResponse(500, "There is some issue with data, Please check that it is not being used");
            }
        }
    }
}
