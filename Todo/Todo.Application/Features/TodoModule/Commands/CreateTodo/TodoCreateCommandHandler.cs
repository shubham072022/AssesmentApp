using MediatR;
using Todo.Application.Common.Constants;
using Todo.Application.Common.Interfaces;
using Todo.Application.Common.Wrapper.Abstract;
using Todo.Application.Common.Wrapper.Concrete;
using Todo.Domain.Entities;

namespace Todo.Application.Features.TodoModule.Commands.CreateTodo
{
    public class TodoCreateCommandHandler : IRequestHandler<TodoCreateCommandRequest,IResponse>
    {
        private readonly ITodoDbContext _db;
        private readonly ICurrentUserService _currentUser;
        public TodoCreateCommandHandler(ITodoDbContext db
            ,ICurrentUserService currentUser) 
        {
            _currentUser = currentUser;
            _db = db;
        }

        public async Task<IResponse> Handle(TodoCreateCommandRequest request,CancellationToken cancellationToken)
        {
            try
            {
                var user = await _currentUser.GetCurrentUser();

                TodoM todo = new TodoM()
                {
                    Id = 0,
                    Title = request.Title,
                    IsCompleted = request.IsCompleted,
                    UserId = user.UserId,
                };

                await _db.TodoM.AddAsync(todo);
                await _db.SaveChangesAsync(cancellationToken);
                if (todo == null)
                {
                    return new ErrorResponse(CustomStatusCodes.InternalServerError, "Please check your data");
                }
                return new SuccessResponse(CustomStatusCodes.Accepted, "Task created successfully.");
            }
            catch (Exception ex)
            {
                return new ErrorResponse(CustomStatusCodes.InternalServerError, ex.Message);
            }
        }
    }
}
