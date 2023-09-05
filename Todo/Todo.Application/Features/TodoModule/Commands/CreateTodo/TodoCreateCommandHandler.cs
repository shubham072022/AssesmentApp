using MediatR;
using Todo.Application.Common.Constants;
using Todo.Application.Common.Interfaces;
using Todo.Application.Common.Wrapper.Abstract;
using Todo.Application.Common.Wrapper.Concrete;
using Todo.Application.UnitOfWork;
using Todo.Domain.Entities;

namespace Todo.Application.Features.TodoModule.Commands.CreateTodo
{
    public class TodoCreateCommandHandler : IRequestHandler<TodoCreateCommandRequest,IResponse>
    {
        private readonly ICommandUnitOfWork _command;
        private readonly ICurrentUserService _currentUser;
        public TodoCreateCommandHandler(ICommandUnitOfWork command
            ,ICurrentUserService currentUser) 
        {
            _currentUser = currentUser;
            _command = command;
        }

        public async Task<IResponse> Handle(TodoCreateCommandRequest request,CancellationToken cancellationToken)
        {
            var todo = new TodoM()
            {
                Id = 0,
                Title = request.Title,
                IsCompleted = request.IsCompleted,
                UserId = _currentUser.GetCurrentUser().Id,
            };

            todo = await _command.TodoCommandRepository.AddAsync(todo);
            if(todo == null)
            {
                return new ErrorResponse(CustomStatusCodes.InternalServerError, "Please check your data");
            }
            return new SuccessResponse(CustomStatusCodes.Accepted, "Task created successfully.");
        }
    }
}
