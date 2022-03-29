using Animus.Data.Entities;

namespace Animus.Data.Repositories.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User? GetUserByEmail(string email);
    }
}
