using eCommerce.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace eCommerce.Data.Repositories
{
    public class RepositoryProvider<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly eCommerceDbContext Context;
        public RepositoryProvider(eCommerceDbContext context)
        {
            this.Context = context;
        }

        public async Task AddAsync(TEntity entity)
        {
            await Context.Set<TEntity>().AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await Context.Set<TEntity>().AddRangeAsync(entities);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetByEmailAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Context.Set<TEntity>().SingleOrDefaultAsync(predicate);
        }

        public async ValueTask<TEntity> GetByIdAsync(int id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }

        public void Remove(TEntity entity)
        {
           Context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }

        public async Task<TEntity> SignleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
           return await Context.Set<TEntity>().SingleOrDefaultAsync(predicate);
        }

        public async Task<TEntity> UpdateByIdAsync(int id, TEntity updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ArgumentNullException(nameof(updatedEntity));
            }

            TEntity existingEntity = await Context.Set<TEntity>().FindAsync(id);
            
            if (existingEntity != null)
            {
                existingEntity = updatedEntity;

                return existingEntity;
            }

            throw new ArgumentNullException(nameof(existingEntity));
        }

        public async Task<TEntity> UpdateValueByIdAsync(int id, Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            TEntity existingEntity = await Context.Set<TEntity>().FindAsync(id);

            if (existingEntity != null)
            {
               Expression<Func<TEntity, bool>> expression = predicate;
               return await Context.Set<TEntity>().FindAsync(id);
            }

            throw new ArgumentNullException(nameof(existingEntity));
        }
    }
}
