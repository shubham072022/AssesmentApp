using Shouldly;
using Todo.Application.Repositories.Commands;
using Todo.Domain.Entities;
using Todo.Persistence.Repositories.Commands;
using Todo.UnitTest.Mocks;

namespace Todo.UnitTest.Todo.Commands
{
    public class TodoCreateCommandHandlerTest : MockTodoContext
    {
        private readonly TodoCommandRepository _repository;

        public TodoCreateCommandHandlerTest()
        {
            _repository = new TodoCommandRepository(mockContext.Object);
        }

        [Fact]
        public async Task Create_Task_Success()
        {
            var todo = new TodoM
            {
                Id = 1,
                Title = "Test",
                IsCompleted = false,
                UserId = 1,
                CreatedBy = 1,
                CreatedDate = DateTime.Now,
                ModifiedBy = 1,
                ModifiedDate = DateTime.Now
            };
            var result = await _repository.AddAsync(todo, CancellationToken.None);
            result.ShouldBeOfType<TodoM>();
        }
    }
}
