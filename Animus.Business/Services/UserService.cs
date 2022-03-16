using Animus.Business.Models.Users;
using Animus.Business.Services.Intrefaces;
using Animus.Data.Entities;
using Animus.Data.Repositories.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Animus.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddAsync(UserModel model)
        {
            User user = _mapper.Map<User>(model);
            user.Password = BCrypt.Net.BCrypt.HashPassword(model.Password);
               
            await _repository.CreateAsync(user);
        }
        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }
        public async Task UpdateAsync(UserModel model)
        {

            User user = _mapper.Map<User>(model);

            await _repository.UpdateAsync(user);
        }
        public async Task<UserModel> GetUserAsync(Guid id)
        {
            User? user = await _repository.GetByIdAsync(id);
            if (user is null)
            {
                throw new ArgumentException("No such user exists!");
            }
            return _mapper.Map<UserModel>(user);
        }
        public async Task<ICollection<UserModel>> GetAllUsersAsync(Expression<Func<User, bool>> filter)
        {            
            return await _repository
                .GetAll(filter)
                .Select(x => _mapper.Map<UserModel>(x))
                .ToListAsync();
        }
        public UserModel GetUserByEmail(string email)
        {
            User? user = _repository.GetUserByEmail(email);
            if (user is null)
            {
                throw new ArgumentException();
            }
            return _mapper.Map<UserModel>(user);
        }

        public List<UserModel> GetAll()
        {
            List<User> users = _repository.GetAll().ToList();
            return _mapper.Map<List<UserModel>>(users);
        }

        public List<UserModel> GetAll(Expression<Func<UserModel, bool>> filter)
        {
            var userFilter = _mapper.Map<Expression<Func<User, bool>>>(filter);
            List<User> users = _repository.GetAll(userFilter).ToList();
            return _mapper.Map<List<UserModel>>(users);
        }
    }
}
