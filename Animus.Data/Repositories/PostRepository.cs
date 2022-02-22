using Animus.Data.Entities;
using Animus.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Animus.Data.Repositories
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(AnimusDbContext context) : base(context)
        {
        }

        public async Task<ICollection<Post>> GetAllPostsByUserId(Guid userId)
        {
            return await context.Posts.Where(x => x.AuthorId == userId).ToListAsync();
        }
    }
}
