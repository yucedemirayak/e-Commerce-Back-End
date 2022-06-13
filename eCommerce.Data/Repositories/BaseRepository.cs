using eCommerce.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;

namespace eCommerce.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly eCommerceDbContext Context;
        public BaseRepository(eCommerceDbContext context)
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

        public async Task<TEntity> UpdateByIdAsync(int id, TEntity entity)
        {
            TEntity existingEntity = await GetByIdAsync(id);

            var properties = entity.GetType().GetProperties();

            for (int i = 0; i < properties.Length; i++)
            {

                var result = entity?.GetType()?.GetProperty(properties[i].Name)?.GetValue(entity);

                string[] sameProperties = new string[] { "Id", "CreatedTime" };

                if (!sameProperties.Contains(properties[i].Name))
                {
                    existingEntity?.GetType()?.GetProperty(properties[i].Name)?.SetValue(existingEntity, result);
                }
            }
            Context.Set<TEntity>().Update(existingEntity);
            return existingEntity;
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
