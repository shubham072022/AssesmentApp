using Shouldly;
using Todo.Application.Common.Constants;
using Todo.Application.Common.Wrapper.Concrete;
using Todo.Application.Features.TodoModule.Commands.DeleteTodo;
using Todo.Application.UnitTest.Mocks;

namespace Todo.Application.UnitTest.Todo.Commands
{
    public class TodoDeleteCommandHandlerTest : TodoMockContext
    {
        private readonly TodoDeleteCommandHandler _handler;
        public TodoDeleteCommandHandlerTest()
        {
            _handler = new TodoDeleteCommandHandler(_mockContext.Object);
        }

        [Fact]
        public async Task Handle_Should_ReturnSuccessResponse_WhenDeletingExistingTask()
        {
            var result = await _handler.Handle(new TodoDeleteComandRequest(1), default);

            result.ShouldBeOfType<SuccessResponse>();
            result.Success.ShouldBeTrue();
            result.StatusCode.ShouldBe(CustomStatusCodes.Accepted);
        }

        [Fact]
        public async Task Handle_Should_ReturnErrorResponse_WhenDeletingNonExistingTask()
        {
            var result = await _handler.Handle(new TodoDeleteComandRequest(23), default);

            result.ShouldBeOfType<ErrorResponse>();
            result.Success.ShouldBeFalse();
            result.StatusCode.ShouldBe(CustomStatusCodes.NotFound);
        }
    }
}
