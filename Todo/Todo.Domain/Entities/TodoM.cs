using Todo.Domain.Common;

namespace Todo.Domain.Entities
{
    public class TodoM : BaseAuditableEntity
    {
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
        public int UserId { get; set; }
    }
}
