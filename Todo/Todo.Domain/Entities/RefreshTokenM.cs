using System.ComponentModel.DataAnnotations;

namespace Todo.Domain.Entities
{
    public class RefreshTokenM
    {
        [Key]
        public int Id { get; set; }
        public string RefreshToken { get; set; }
        public int UserId { get; set; }
        public DateTime RefreshTokenExpiration { get; set; }
    }
}
