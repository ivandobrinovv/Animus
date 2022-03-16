using Animus.Business.Models.Sections;

namespace Animus.Business.Services.Intrefaces
{
    public interface ISectionService
    {
        Task Create(SectionModel model);
        Task Delete(Guid id);
        Task<SectionModel> GetById(Guid id);
        Task Update(SectionModel model);
    }
}