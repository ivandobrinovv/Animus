using Animus.Data.Entities;
using Animus.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Animus.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly AnimusDbContext context;

        public BaseRepository(AnimusDbContext context)
        {
            this.context = context;
        }

        public virtual async Task<ICollection<T>> GetAll()
        {
            return await context.Set<T>().ToListAsync();
        }

        public virtual async Task<ICollection<T>> GetAll(Expression<Func<T, bool>> filter)
        {
            return await context.Set<T>().Where(filter).ToListAsync();
        }

        public virtual async ValueTask<T?> GetById(Guid id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public virtual async Task Create(T entity)
        {
            context.Set<T>().Add(entity);
            await context.SaveChangesAsync();
        }

        public virtual async Task Update(T entity)
        {
            var dbEntity = await GetById(entity.Id);

            if (dbEntity == null)
            {
                throw new ArgumentException();
            }

            context.Entry(dbEntity).CurrentValues.SetValues(entity);

            await context.SaveChangesAsync();
        }

        public virtual async Task Delete(Guid id)
        {
            var entity = await GetById(id);

            if (entity == null)
            {
                throw new ArgumentException();
            }

            context.Remove(entity);

            await context.SaveChangesAsync();
        }
    }
}
