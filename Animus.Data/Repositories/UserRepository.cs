using Animus.Data.Entities;
using Animus.Data.Repositories.Interfaces;

namespace Animus.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AnimusDbContext context) : base(context)
        {
        }

        public User? GetUserByEmail(string email)
        {
            return context.Users.SingleOrDefault(x => x.Email == email);
        }
    }
}
