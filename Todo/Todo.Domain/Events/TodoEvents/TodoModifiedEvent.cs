using Todo.Domain.Common;
using Todo.Domain.Entities;

namespace Todo.Domain.Events.TodoEvents
{
    public class TodoModifiedEvent : BaseEvent
    {
        public TodoM Todo { get; set; }
        public TodoModifiedEvent(TodoM Todo)
        {
            this.Todo = Todo;
        }
    }
}
