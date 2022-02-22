using Animus.Data.Entities;
using Animus.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Animus.Data.Repositories
{
    public class SectionRepository : BaseRepository<Section>, ISectionRepository
    {
        public SectionRepository(AnimusDbContext context) : base(context)
        {
            
        }

        public override async ValueTask<Section?> GetById(Guid id)
        {
            return await context.Sections
                .Include(x => x.Posts)
                .FirstOrDefaultAsync(x => x.Id == id);
            
        }
        
        public override async Task<ICollection<Section>> GetAll()
        {
            return await context.Sections
                .Include(x => x.Posts)
                .ToListAsync();
        }
        public override async Task<ICollection<Section>> GetAll(Expression<Func<Section, bool>> filter)
        {
            return await context.Sections
                .Include(x => x.Posts)
                .Where(filter)
                .ToListAsync();
        }

        

    }
}
