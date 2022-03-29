using Animus.Business.Models.Photos;
using Animus.Business.Services.Intrefaces;
using Animus.Data.Entities;
using Animus.Data.Repositories.Interfaces;
using AutoMapper;

namespace Animus.Business.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly IPhotoRepository _repository;
        private readonly IMapper _mapper;

        public PhotoService(IPhotoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Create(PhotoModel model)
        {
            var entity = _mapper.Map<Photo>(model);
            await _repository.CreateAsync(entity);
        }

        public async Task<bool> Delete(Guid id)
        {
            try
            {
                await _repository.DeleteAsync(id);
                return true;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async ValueTask<PhotoModel> GetById(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);

            if (entity == null)
            {
                throw new ArgumentException("No such photo exists");
            }

            return _mapper.Map<PhotoModel>(entity);
        }

        public async Task<bool> Update(PhotoModel model)
        {
            var entity = _mapper.Map<Photo>(model);

            try
            {
                await _repository.UpdateAsync(entity);
                return true;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
