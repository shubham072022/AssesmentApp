using Todo.Domain.Common;
using Todo.Domain.Entities;

namespace Todo.Domain.Events.TodoEvents
{
    public class TodoDeletedEvent : BaseEvent
    {
        public TodoM Todo { get; set; }
        public TodoDeletedEvent(TodoM Todo) 
        {
            this.Todo = Todo;
        }
    }
}
