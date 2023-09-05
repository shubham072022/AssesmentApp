using MediatR;
using Todo.Application.Common.Wrapper.Abstract;
using Todo.Application.UnitOfWork;

namespace Todo.Application.Features.TodoModule.Commands.DeleteTodo
{
    public class TodoDeleteCommandHandler : IRequestHandler<TodoDeleteComandRequest,IResponse>
    {
        private readonly ICommandUnitOfWork _command;
        private readonly IQueryUnitOfWork _query;
        public TodoDeleteCommandHandler(ICommandUnitOfWork command
            ,IQueryUnitOfWork query)
        {
            _command = command;
            _query = query;
        }

        public async Task<IResponse> Handle(TodoDeleteComandRequest request, CancellationToken cancellationToken)
        {
            var todo = await _query.TodoQueryRepository.GetByIdAsync(request.Id);
            return await _command.TodoCommandRepository.Remove(todo);
        }
    }
}
