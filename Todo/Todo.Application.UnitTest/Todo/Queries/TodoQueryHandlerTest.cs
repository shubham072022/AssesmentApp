using Shouldly;
using Todo.Application.Common.Constants;
using Todo.Application.Common.Wrapper.Concrete;
using Todo.Application.Dtos;
using Todo.Application.Features.TodoModule.Queries.GetAllTodos;
using Todo.Application.UnitTest.Mocks;

namespace Todo.Application.UnitTest.Todo.Queries
{
    public class TodoQueryHandlerTest : TodoMockContext
    {
        private readonly TodoGetAllQueryHandler _handler;
        public TodoQueryHandlerTest()
        {
            _handler = new TodoGetAllQueryHandler(_mockContext.Object, _mapper, _currentUserServiceMock.Object);
        }

        [Fact]
        public async Task Handle_Should_ReturnDataResponse_WhenSettingCurrentUserExisting()
        {
            var result = await _handler.Handle(new TodoGetAllQueryRequest(), default);

            result.ShouldBeOfType<DataResponse<List<TodoDTO>>>();

            result.Success.ShouldBeTrue();
            result.StatusCode.ShouldBe(CustomStatusCodes.Accepted);

            DataResponse<List<TodoDTO>> response = (DataResponse<List<TodoDTO>>)result;

            response.Data.Count.ShouldBeGreaterThanOrEqualTo(1);
        }

        [Fact]
        public async Task Handle_Should_ReturnErrorResponse_WhenSettingWrongUserAsCurrentUser()
        {
            _currentUserServiceMock.Setup(t => t.GetCurrentUser().Result)
                .Returns(new Dtos.LoggedInUserDTO
                {
                    UserId = 3,
                    UserName = "shubham@atharvasystem.com",
                    Email = "shubham@atharvasystem.com",
                    Token = "123",
                });

            var result = await _handler.Handle(new TodoGetAllQueryRequest(), default);

            result.ShouldBeOfType<ErrorResponse>();

            result.Success.ShouldBeFalse();
            result.StatusCode.ShouldBe(CustomStatusCodes.NotFound);
            ErrorResponse response = (ErrorResponse)result;
            response.Errors.Count.ShouldBeGreaterThanOrEqualTo(1);
        }
    }
}
