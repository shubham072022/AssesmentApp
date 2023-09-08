using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Todo.Application.Common.Constants;
using Todo.Application.Common.Interfaces;
using Todo.Application.Common.Wrapper.Abstract;
using Todo.Application.Common.Wrapper.Concrete;
using Todo.Application.Dtos;

namespace Todo.Application.Features.TodoModule.Queries.GetAllTodos
{
    public class TodoGetAllQueryHandler : IRequestHandler<TodoGetAllQueryRequest,IResponse>
    {
        private readonly ITodoDbContext _db;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        public TodoGetAllQueryHandler(ITodoDbContext db
            , IMapper mapper
            , ICurrentUserService currentUserService)
        {
            _db = db;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<IResponse> Handle(TodoGetAllQueryRequest request
            ,CancellationToken cancellationToken)
        {
            try
            {
                List<TodoDTO> todos = new List<TodoDTO>();
                var user = await _currentUserService.GetCurrentUser();

                //Only user specific tasks will appear
                todos = await _db.TodoM
                    .Where(t => t.UserId == user.UserId)
                    .AsNoTracking()
                    .ProjectTo<TodoDTO>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);
                if(!todos.Any())
                {
                    return new ErrorResponse(CustomStatusCodes.NotFound,Messages.NoDataFound);
                }
                return new DataResponse<List<TodoDTO>>(todos, CustomStatusCodes.Accepted);
            }
            catch (Exception ex)
            {
                return new ErrorResponse(CustomStatusCodes.InternalServerError, ex.Message);
            }
            
        }
    }
}
