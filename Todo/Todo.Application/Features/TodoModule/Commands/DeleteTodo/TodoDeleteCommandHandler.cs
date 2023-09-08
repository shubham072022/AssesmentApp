using MediatR;
using Microsoft.EntityFrameworkCore;
using Todo.Application.Common.Constants;
using Todo.Application.Common.Interfaces;
using Todo.Application.Common.Wrapper.Abstract;
using Todo.Application.Common.Wrapper.Concrete;

namespace Todo.Application.Features.TodoModule.Commands.DeleteTodo
{
    public class TodoDeleteCommandHandler : IRequestHandler<TodoDeleteComandRequest,IResponse>
    {
        private readonly ITodoDbContext _db;
        public TodoDeleteCommandHandler(ITodoDbContext db)
        {
            _db = db;
        }

        public async Task<IResponse> Handle(TodoDeleteComandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var todo = await _db.TodoM.FirstOrDefaultAsync(t => t.Id == request.Id);
                if(todo == null)
                {
                    return new ErrorResponse(CustomStatusCodes.NotFound, Messages.NoDataFound);
                }
                _db.TodoM.Remove(todo);
                await _db.SaveChangesAsync(cancellationToken);
                return new SuccessResponse(CustomStatusCodes.Accepted, Messages.DeletedSuccessfully);
            }
            catch(Exception ex)
            {
                return new ErrorResponse(CustomStatusCodes.InternalServerError, ex.Message);
            }
        }
    }
}
