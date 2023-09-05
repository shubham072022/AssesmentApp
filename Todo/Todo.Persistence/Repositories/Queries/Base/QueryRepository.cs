using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Application.Repositories.Queries.Base;
using Todo.Persistence.DbContext;

namespace Todo.Persistence.Repositories.Queries.Base
{
    public class QueryRepository<T> : IQueryRepository<T> where T : class
    {
        protected readonly TodoDbContext _db;
        public QueryRepository(TodoDbContext db)
        {
            _db = db;
        }
        public async Task<IQueryable<T>> GetAllAsyn()
        {
            return _db.Set<T>().Select(e => e);
        }

        public async Task<T> GetByIdAsync(int Id)
        {
            return await _db.Set<T>().FindAsync(Id);
        }
    }
}
