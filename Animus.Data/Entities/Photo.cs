using System.ComponentModel.DataAnnotations;

namespace Animus.Data.Entities
{
    public class Photo : BaseEntity
    {
        [Required]
        public string? Path { get; set; }
    }
}
