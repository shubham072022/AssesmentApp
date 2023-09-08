using MockQueryable.Moq;
using Moq;
using Todo.Application.Common.Interfaces;
using Todo.Domain.Entities;

namespace Todo.UnitTest.Mocks
{
    public class MockTodoContext : BaseMockContext
    {
        protected readonly Mock<ITodoDbContext> mockContext;

        public MockTodoContext()
        {
            mockContext = GetTodoDbContext();
        }

        protected Mock<ITodoDbContext> GetTodoDbContext()
        {
            var mockContext = new Mock<ITodoDbContext>();

            var taskList = GetAllTasks();
            mockContext.Setup(r => r.TodoM).Returns(taskList.AsQueryable().BuildMockDbSet().Object);
            mockContext.Setup(m => m.TodoM.AddAsync(It.IsAny<TodoM>(), default))
                .Callback<TodoM, CancellationToken>((s, token) =>
                {
                    taskList.Add(s);
                });
            return mockContext;
        }

        protected List<TodoM> GetAllTasks()
        {
            return new List<TodoM>()
            {
                new TodoM()
                {
                    Id = 1,
                    UserId = 1,
                    Title = "Test",
                    IsCompleted = false,
                    CreatedBy = 1,
                    CreatedDate = DateTime.Now,
                    ModifiedBy = 1,
                    ModifiedDate = DateTime.Now,
                }
            };
        }
    }
}
