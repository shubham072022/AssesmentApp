using MediatR;
using Todo.Application.Common.Wrapper.Abstract;
using Todo.Application.UnitOfWork;

namespace Todo.Application.Features.TodoModule.Commands.EditTodo
{
    public class TodoEditCommandHandler : IRequestHandler<TodoEditCommandRequest, IResponse>
    {
        private readonly ICommandUnitOfWork _command;
        private readonly IQueryUnitOfWork _query;

        public TodoEditCommandHandler(ICommandUnitOfWork command
            , IQueryUnitOfWork query)
        {
            _command = command;
            _query = query;
        }

        public async Task<IResponse> Handle(TodoEditCommandRequest request, CancellationToken cancellationToken)
        {
            var todo = await _query.TodoQueryRepository.GetByIdAsync(request.Id);
            todo.Title = request.Title;
            todo.IsCompleted = request.IsCompleted;
            return await _command.TodoCommandRepository.Update(todo);
        }
    }
}
