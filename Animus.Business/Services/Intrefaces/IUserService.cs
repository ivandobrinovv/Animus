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

        List<UserModel> GetAll();

        List<UserModel> GetAll(Expression<Func<UserModel, bool>> filter);
    }
}
