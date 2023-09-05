using Todo.Application.Repositories.Queries;

namespace Todo.Application.UnitOfWork
{
    public interface IQueryUnitOfWork
    {
        ITodoQueryRepository TodoQueryRepository { get; }
    }
}
