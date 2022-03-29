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
        public async Task LikePost(Guid postId,Guid userId)
        {
            await context.Likes.AddAsync(new Like() { PostId = postId, UserId = userId });
            await context.SaveChangesAsync();
        }
        public async Task Like(Guid postId,Guid userId)
        {
            var post=await context.Posts.FirstOrDefaultAsync(c => c.Id == postId);
            if(post==null)
            {
                throw new ArgumentException("No such post exists");
            }
            await context.Likes.AddAsync(new Like() { PostId = postId, UserId = userId });
            post.Likes++;
            context.Posts.Update(post);
            await context.SaveChangesAsync();
        }
        public async Task Unlike(Guid postId,Guid userId)
        {
            var post=await context.Posts.FirstOrDefaultAsync(c => c.Id == postId);
            if(post==null)
            {
                throw new ArgumentException("No such post exists");
            }
            var like = await context.Likes.FirstOrDefaultAsync(c => c.PostId == postId && c.UserId == userId);
            context.Likes.Remove(like);
            post.Likes--;
            context.Posts.Update(post);
            await context.SaveChangesAsync();
        }
    }
}
