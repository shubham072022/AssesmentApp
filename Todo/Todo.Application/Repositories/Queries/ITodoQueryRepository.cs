using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Application.Repositories.Queries.Base;
using Todo.Domain.Entities;

namespace Todo.Application.Repositories.Queries
{
    public interface ITodoQueryRepository : IQueryRepository<TodoM>
    {

    }
}
