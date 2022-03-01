using Animus.Data.Entities;
using System.Linq.Expressions;

namespace Animus.Data.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task CreateAsync(T entity);
        Task DeleteAsync(Guid id);
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Expression<Func<T, bool>> filter);
        ValueTask<T?> GetByIdAsync(Guid id);
        Task UpdateAsync(T entity);
    }
}