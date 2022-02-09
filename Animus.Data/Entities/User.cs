namespace Animus.Data.Entities
{
    public class User : BaseEntity
    {
        public string Email { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public ICollection<Post> Posts { get; set; } = new List<Post>();
    }
}
