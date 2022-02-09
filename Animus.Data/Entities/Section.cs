namespace Animus.Data.Entities
{
    public class Section : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public ICollection<Post> Posts { get; set; } = new List<Post>();
    }
}
