using Animus.Business.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Animus.Business.Services.Intrefaces
{
    public interface IUserService
    {
        UserModel GetUserByEmail(string email);

        Task<List<UserModel>> GetAll();

        Task<List<UserModel>> GetAll(Expression<Func<UserModel, bool>> filter);

        Task<UserModel> GetUserAsync(Guid id);

        Task AddAsync(UserModel model);

        Task DeleteAsync(Guid id);
    }
}
