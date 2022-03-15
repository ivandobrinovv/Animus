using System.ComponentModel.DataAnnotations;

namespace Animus.Business.Models.Photos
{
    public class PhotoModel
    {
        [Required]
        public string? Path { get; set; }
    }
}
