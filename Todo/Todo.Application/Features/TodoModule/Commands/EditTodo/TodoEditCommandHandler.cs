using MediatR;
using Microsoft.EntityFrameworkCore;
using Todo.Application.Common.Constants;
using Todo.Application.Common.Interfaces;
using Todo.Application.Common.Wrapper.Abstract;
using Todo.Application.Common.Wrapper.Concrete;

namespace Todo.Application.Features.TodoModule.Commands.EditTodo
{
    public class TodoEditCommandHandler : IRequestHandler<TodoEditCommandRequest, IResponse>
    {
        private readonly ITodoDbContext _db;

        public TodoEditCommandHandler(ITodoDbContext db)
        {
            _db = db;
        }

        public async Task<IResponse> Handle(TodoEditCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var todo = await _db.TodoM.FirstOrDefaultAsync(t => t.Id == request.Id);
                if (todo == null)
                {
                    return new ErrorResponse(CustomStatusCodes.NotFound, Messages.NoDataFound);
                }
                todo.Title = request.Title;
                todo.IsCompleted = request.IsCompleted;
                await _db.SaveChangesAsync(cancellationToken);
                return new SuccessResponse(CustomStatusCodes.Accepted, Messages.UpdatedSuccessfully);
            }
            catch (Exception ex)
            {
                return new ErrorResponse(CustomStatusCodes.InternalServerError, ex.Message);
            }
        }
    }
}
