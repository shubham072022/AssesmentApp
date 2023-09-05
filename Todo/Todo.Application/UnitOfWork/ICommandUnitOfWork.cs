using Todo.Application.Repositories.Commands;

namespace Todo.Application.UnitOfWork
{
    public interface ICommandUnitOfWork
    {
        ITodoCommandRepository TodoCommandRepository { get; }
    }
}
