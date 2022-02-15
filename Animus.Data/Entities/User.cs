using System.ComponentModel.DataAnnotations;

namespace Animus.Data.Entities
{
    public class User : BaseEntity
    {
        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Username { get; set; }
        public string Password { get; set; } = string.Empty;
        public ICollection<Post> Posts { get; set; } = new List<Post>();
    }
}
