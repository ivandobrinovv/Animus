using Animus.Business.Models.Sections;
using Animus.Business.Services.Intrefaces;
using Animus.Data.Entities;
using Animus.Data.Repositories.Interfaces;
using AutoMapper;


namespace Animus.Business.Services
{
    public class SectionService : ISectionService
    {
        private readonly ISectionRepository _repository;
        private readonly IMapper _mapper;
        public SectionService(ISectionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Create(SectionModel model)
        {
            Section section = _mapper.Map<Section>(model);
            await _repository.CreateAsync(section);
        }

        public async Task<SectionModel> GetById(Guid id)
        {
            var section = await _repository.GetByIdAsync(id);
            if (section is null)
            {
                throw new ArgumentException("No such section exists!");
            }

            return _mapper.Map<SectionModel>(section);
        }

        public async Task Delete(Guid id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task Update(SectionModel model)
        {
            var entity = _mapper.Map<Section>(model);

            await _repository.UpdateAsync(entity);
        }
    }
}
