using Animus.Business.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animus.Business.Services.Intrefaces
{
    public interface IUserService
    {
        UserModel GetUserByEmail(string email);
    }
}
