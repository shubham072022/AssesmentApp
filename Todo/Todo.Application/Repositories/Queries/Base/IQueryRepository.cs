namespace Todo.Application.Repositories.Queries.Base
{
    public interface IQueryRepository<T> where T : class
    {
        Task<IQueryable<T>> GetAllAsyn();

        Task<T> GetByIdAsync(int Id);
    }
}
