using MediatR;
using Todo.Application.Common.Wrapper.Abstract;

namespace Todo.Application.Features.TodoModule.Queries.GetAllTodos
{
    public class TodoGetAllQueryRequest : IRequest<IResponse>
    {
    }
}
