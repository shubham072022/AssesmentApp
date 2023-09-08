using MockQueryable.Moq;
using Moq;
using Todo.Application.Common.Interfaces;
using Todo.Domain.Entities;

namespace Todo.Application.UnitTest.Mocks
{
    public class TodoMockContext : BaseMockContext
    {
        protected readonly Mock<ITodoDbContext> _mockContext;
        protected readonly Mock<ICurrentUserService> _currentUserServiceMock;

        public TodoMockContext()
        {
            _mockContext = GetTodoMockContext();
            _currentUserServiceMock = GetCurrentUserServiceMock();
        }

        public Mock<ICurrentUserService> GetCurrentUserServiceMock()
        {
            var currentUserServiceMock = new Mock<ICurrentUserService>();

            currentUserServiceMock.Setup(t => t.GetCurrentUser().Result)
                .Returns(new Dtos.LoggedInUserDTO
                {
                    UserId = 1,
                    UserName = "shubham@atharvasystem.com",
                    Email = "shubham@atharvasystem.com",
                    Token = "123",
                });
            return currentUserServiceMock;
        }

        protected Mock<ITodoDbContext> GetTodoMockContext()
        {
            var mockContext = new Mock<ITodoDbContext>();
            var taskList = GetTasks();

            mockContext.Setup(r => r.TodoM).Returns(taskList.AsQueryable().BuildMockDbSet().Object);
            mockContext.Setup(m => m.TodoM.AddAsync(It.IsAny<TodoM>(), It.IsAny<CancellationToken>()))
                .Callback<TodoM, CancellationToken>((s, token) =>
                {
                    taskList.Add(s);
                });

            mockContext.Setup(m => m.TodoM.Remove(It.IsAny<TodoM>()))
                .Callback<TodoM>((s) =>
                {
                    taskList.Remove(s);
                });

            mockContext.Setup(r => r.TodoM).Returns(GetTasks().AsQueryable().BuildMockDbSet().Object);

            return mockContext;
        }

        protected List<TodoM> GetTasks()
        {
            return new List<TodoM>
            {
                new TodoM
                {
                    Id=1,
                    Title="Test",
                    IsCompleted=true,
                    UserId=1,
                    CreatedBy=1,
                    CreatedDate=DateTime.Now,
                    ModifiedBy = 1,
                    ModifiedDate = DateTime.Now
                },
                new TodoM
                {
                    Id=2,
                    Title="Test",
                    IsCompleted=true,
                    UserId=2,
                    CreatedBy=2,
                    CreatedDate=DateTime.Now,
                    ModifiedBy = 2,
                    ModifiedDate = DateTime.Now
                }
            };
        }
    }
}
