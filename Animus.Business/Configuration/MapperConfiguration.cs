using Animus.Business.Models.Users;
using Animus.Data.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animus.Business.Configuration
{
    public class MapperConfiguration : Profile
    {
        public MapperConfiguration()
        {
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<Post, PostModel>().ReverseMap();
        }


    }
}
