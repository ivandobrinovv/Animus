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

        public override async ValueTask<Section?> GetByIdAsync(Guid id)
        {
            return await context.Sections
                .Include(x => x.Posts)
                .FirstOrDefaultAsync(x => x.Id == id);
            
        }
        
        public override IQueryable<Section> GetAll()
        {
            return context.Sections
                .Include(x => x.Posts);
                
        }
        public override IQueryable<Section> GetAll(Expression<Func<Section, bool>> filter)
        {
            return context.Sections
                .Include(x => x.Posts)
                .Where(filter);
        }

        

    }
}
