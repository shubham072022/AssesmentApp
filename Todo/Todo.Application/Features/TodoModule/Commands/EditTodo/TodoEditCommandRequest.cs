using MediatR;
using Todo.Application.Common.Wrapper.Abstract;

namespace Todo.Application.Features.TodoModule.Commands.EditTodo
{
    public class TodoEditCommandRequest : IRequest<IResponse>
    {
        public int Id { get; init; }
        public string Title { get; init; }
        public bool IsCompleted { get; init; }
    }
}
