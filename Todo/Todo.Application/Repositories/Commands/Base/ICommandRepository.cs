using System.Threading.Tasks;
using Todo.Application.Common.Wrapper.Abstract;

namespace Todo.Application.Repositories.Commands.Base
{
    public interface ICommandRepository<T> where T : class
    {
        Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
        Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
        Task<IResponse> Remove(T entity, CancellationToken cancellationToken = default);
        Task<IResponse> RemoveRange(IEnumerable<T> entities, CancellationToken cancellationToken = default);
    }
}
