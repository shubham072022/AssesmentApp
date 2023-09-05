using MediatR;
using Todo.Application.Common.Wrapper.Abstract;

namespace Todo.Application.Features.TodoModule.Commands.CreateTodo
{
    public class TodoCreateCommandRequest : IRequest<IResponse>
    {
        public string Title { get; init; }
        public bool IsCompleted { get; init; } = false;
    }
}
