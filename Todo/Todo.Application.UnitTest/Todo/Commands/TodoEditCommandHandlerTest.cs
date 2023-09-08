using Shouldly;
using Todo.Application.Common.Constants;
using Todo.Application.Common.Wrapper.Concrete;
using Todo.Application.Features.TodoModule.Commands.EditTodo;
using Todo.Application.UnitTest.Mocks;

namespace Todo.Application.UnitTest.Todo.Commands
{
    public class TodoEditCommandHandlerTest : TodoMockContext
    {
        private readonly TodoEditCommandHandler _handler;
        public TodoEditCommandHandlerTest()
        {
            _handler = new TodoEditCommandHandler(_mockContext.Object);
        }

        [Fact]
        public async Task Handle_Should_ReturnSuccessResponse_WhenEditingExistingData()
        {
            var command = new TodoEditCommandRequest
            {
                Id = 1,
                Title = "New Test",
                IsCompleted = true,
            };

            var result = await _handler.Handle(command, default);

            result.ShouldBeOfType<SuccessResponse>();
            result.Success.ShouldBeTrue();
            result.StatusCode.ShouldBe(CustomStatusCodes.Accepted);
        }

        [Fact]
        public async Task Handle_Should_ReturnErrorResponse_WhenEditingNonExistingData()
        {
            var command = new TodoEditCommandRequest
            {
                Id = 14,
                Title = "New Test",
                IsCompleted = true,
            };

            var result = await _handler.Handle(command, default);

            result.ShouldBeOfType<ErrorResponse>();
            result.Success.ShouldBeFalse();
            result.StatusCode.ShouldBe(CustomStatusCodes.NotFound);
        }
    }
}
