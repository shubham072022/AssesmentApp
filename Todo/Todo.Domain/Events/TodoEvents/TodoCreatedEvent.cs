using Todo.Domain.Common;
using Todo.Domain.Entities;

namespace Todo.Domain.Events.TodoEvents
{
    public class TodoCreatedEvent : BaseEvent
    {
        public TodoM Todo { get; set; }
        public TodoCreatedEvent(TodoM Todo)
        {
            this.Todo = Todo;
        }
    }
}
