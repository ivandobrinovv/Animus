using Animus.Data.Entities;
using System.Linq.Expressions;

namespace Animus.Data.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task Create(T entity);
        Task Delete(Guid id);
        Task<ICollection<T>> GetAll();
        Task<ICollection<T>> GetAll(Expression<Func<T, bool>> filter);
        ValueTask<T?> GetById(Guid id);
        Task Update(T entity);
    }
}