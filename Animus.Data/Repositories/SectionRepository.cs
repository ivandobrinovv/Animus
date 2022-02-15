using Animus.Data.Entities;
using Animus.Data.Repositories.Interfaces;

namespace Animus.Data.Repositories
{
    public class SectionRepository : BaseRepository<Section>, ISectionRepository
    {
        public SectionRepository(AnimusDbContext context) : base(context)
        {

        }
    }
}
