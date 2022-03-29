using Animus.Business.Models.Posts;
using Animus.Business.Services.Intrefaces;
using Animus.Data.Entities;
using Animus.Data.Repositories.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Animus.Business.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _repository;
        private readonly IMapper _mapper;
        public PostService(IPostRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task AddAsync(PostModel model)
        {
            Post post = _mapper.Map<Post>(model);
            await _repository.CreateAsync(post);
        }
        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }
        public async void UpdateAsync(PostModel model)
        {
            Post post = _mapper.Map<Post>(model);

            await _repository.UpdateAsync(post);
        }
        public async Task<IEnumerable<PostModel>> GetAllAsync(Expression<Func<Post, bool>> filter)
        {
            return await _repository
                .GetAll(filter)
                .Select(x => _mapper.Map<PostModel>(x))
                .ToListAsync();
        }
        public async Task<PostModel> GetByIdAsync(Guid id)
        {
            var post = await _repository.GetByIdAsync(id);
            if (post is null)
            {
                throw new ArgumentException("No such post exists!");
            }
            return _mapper.Map<PostModel>(post);
        }

        public async Task AddCommentAsync(PostModel model)
        {
            Post post = _mapper.Map<Post>(model);
            await _repository.CreateAsync(post);
        }
    }
}
