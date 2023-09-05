using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Todo.Application.Common.Constants;
using Todo.Application.Common.Interfaces;
using Todo.Application.Common.Wrapper.Abstract;
using Todo.Application.Common.Wrapper.Concrete;
using Todo.Application.Dtos;
using Todo.Application.UnitOfWork;

namespace Todo.Application.Features.TodoModule.Queries.GetAllTodos
{
    public class TodoGetAllQueryHandler : IRequestHandler<TodoGetAllQueryRequest,IResponse>
    {
        private readonly IQueryUnitOfWork _query;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        public TodoGetAllQueryHandler(IQueryUnitOfWork query
            , IMapper mapper
            , ICurrentUserService currentUserService)
        {
            _query = query;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<IResponse> Handle(TodoGetAllQueryRequest request
            ,CancellationToken cancellationToken)
        {
            List<TodoDTO> todos = new List<TodoDTO>();
            var user = await _currentUserService.GetCurrentUser();

            //Only user specific tasks will appear
            todos = await (await _query.TodoQueryRepository.GetAllAsyn())
                .Where(t => t.UserId == user.UserId)
                .AsNoTracking()
                .ProjectTo<TodoDTO>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return new DataResponse<List<TodoDTO>>(todos, CustomStatusCodes.Accepted);
        }
    }
}
