using MockQueryable.Moq;
using Moq;
using Shouldly;
using Todo.Application.Common.Constants;
using Todo.Application.Common.Interfaces;
using Todo.Application.Common.Wrapper.Concrete;
using Todo.Application.Features.TodoModule.Commands.CreateTodo;
using Todo.Application.UnitTest.Mocks;
using Todo.Domain.Entities;

namespace Todo.Application.UnitTest.Todo.Commands
{
    public class TodoCreateCommandHandlerTest : TodoMockContext
    {
        private readonly TodoCreateCommandHandler _handler;
        public TodoCreateCommandHandlerTest()
        {
            _handler = new TodoCreateCommandHandler(_mockContext.Object, _currentUserServiceMock.Object);
        }

        [Fact]
        public async Task Handle_Should_ReturnSuccessResult_WhenCreatingNewTask()
        {
            var command = new TodoCreateCommandRequest
            {
                Title = "Test",
                IsCompleted = true,
            };

            var result = await _handler.Handle(command, default);

            result.ShouldBeOfType<SuccessResponse>();
            result.Success.ShouldBeTrue();
            result.StatusCode.ShouldBe(CustomStatusCodes.Accepted);

        }
    }
}
