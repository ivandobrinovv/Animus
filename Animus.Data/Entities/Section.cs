using System.ComponentModel.DataAnnotations;

namespace Animus.Data.Entities
{
    public class Section : BaseEntity
    {
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Name { get; set; }
        public ICollection<Post> Posts { get; set; } = new List<Post>();
    }
}
