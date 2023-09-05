using Todo.Application.Common.Wrapper.Abstract;
using Todo.Application.Repositories.Commands.Base;
using Todo.Domain.Entities;

namespace Todo.Application.Repositories.Commands
{
    public interface ITodoCommandRepository : ICommandRepository<TodoM>
    {
        Task<IResponse> Update(TodoM todoM);
    }
}
