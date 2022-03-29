using Animus.Business.Models.Posts;
using Animus.Business.Models.Users;
using Animus.Data.Entities;
using AutoMapper;

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
