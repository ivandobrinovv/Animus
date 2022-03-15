using Animus.Business.Models.Photos;

namespace Animus.Business.Services.Intrefaces
{
    public interface IPhotoService
    {
        Task Create(PhotoModel model);
        Task<bool> Delete(Guid id);
        ValueTask<PhotoModel> GetById(Guid id);
        Task<bool> Update(PhotoModel model);
    }
}