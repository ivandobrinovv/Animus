using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animus.Business.Models.Users
{
    public class UserModel
    {
        public Guid Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
