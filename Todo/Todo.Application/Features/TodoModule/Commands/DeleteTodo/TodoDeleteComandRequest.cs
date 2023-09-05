using MediatR;
using Todo.Application.Common.Wrapper.Abstract;

namespace Todo.Application.Features.TodoModule.Commands.DeleteTodo
{
    public record TodoDeleteComandRequest(int Id) : IRequest<IResponse>;
}
