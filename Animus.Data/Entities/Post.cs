namespace Animus.Data.Entities
{
    public class Post : BaseEntity
    {
        public string? Title { get; set; }
        public string Content { get; set; } = string.Empty;
        public Guid AuthorId { get; set; }
        public User Author { get; set; }
        public ICollection<Photo> Photos { get; set; } = new List<Photo>();
        public Guid SectionId { get; set; }
        public Guid? ParentId { get; set; }
        public Post? Parent { get; set; }
        public ICollection<Post> Comments { get; set; } = new List<Post>();
    }
}
