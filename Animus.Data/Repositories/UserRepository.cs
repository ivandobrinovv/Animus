using Animus.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animus.Data.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(AnimusDbContext context) : base(context)
        {
        }

        
    }
}
