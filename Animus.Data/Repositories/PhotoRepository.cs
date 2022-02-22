using Animus.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animus.Data.Repositories
{
    public class PhotoRepository:BaseRepository<Photo>
    {
        public PhotoRepository(AnimusDbContext context) : base(context) { }
    }
}
