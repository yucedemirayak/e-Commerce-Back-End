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

        public async Task AddRangeAsync(IEnumerable<TEntity> entities) => await Context.Set<TEntity>().AddRangeAsync(entities);

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate) => Context.Set<TEntity>().AsNoTracking().Where(predicate);

        public async Task<IEnumerable<TEntity>> GetAllAsync() => await Context.Set<TEntity>().AsNoTracking().ToListAsync();

        public async Task<IEnumerable<TEntity>> GetBatch(int order, int qty)
        {
            //FIXME: Need fixes for out of range
            int index = ((order - 1) * qty);
            int listCount = Context.Set<TEntity>().ToList().Count();
            int lastItem = index + qty;

            if (lastItem > listCount)
            {
                qty = qty - (lastItem - listCount);
            }

            return Context.Set<TEntity>().ToList().GetRange(index, qty);
        }

        public async Task<TEntity> GetByEmailAsync(Expression<Func<TEntity, bool>> predicate) => await Context.Set<TEntity>().AsNoTracking().SingleOrDefaultAsync(predicate);

        public async ValueTask<TEntity> GetByIdAsync(int id) => await Context.Set<TEntity>().FindAsync(id);

        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }

        public async Task<TEntity> SignleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate) => await Context.Set<TEntity>().SingleOrDefaultAsync(predicate);

        public async Task<TEntity> UpdateByIdAsync(int id, TEntity entity)
        {
            TEntity existingEntity = await GetByIdAsync(id);

            var properties = entity.GetType().GetProperties();

            for (int i = 0; i < properties.Length; i++)
            {
                var value = entity?.GetType()?.GetProperty(properties[i].Name)?.GetValue(entity);

                string[] staticProperties = new string[] { "Id", "CreatedTime" };

                if (!staticProperties.Contains(properties[i].Name))
                {
                    existingEntity?.GetType()?.GetProperty(properties[i].Name)?.SetValue(existingEntity, value);
                }
            }
            Context.Set<TEntity>().Update(existingEntity);
            return existingEntity;
        }

        public async Task<TEntity> UpdateValueByIdAsync(int id, object value, string propName)
        {
            string[] staticProperties = new string[] { "Id", "CreatedTime", "PasswordSalt" };
            if (staticProperties.Contains(propName))
            {
                throw new ArgumentException(propName + " cannot be changed");
            }

            TEntity existingEntity = await GetByIdAsync(id);

            if (existingEntity == null)
            {
                throw new ArgumentOutOfRangeException("Entity Id:" + id + " not found.");
            }

            var property = existingEntity.GetType().GetProperty(propName);
            if (property == null)
            {
                throw new ArgumentOutOfRangeException(propName + " not found");
            }

            if (propName == "Password")
            {
                var newValue = value;
                existingEntity.GetType().GetProperty(propName).SetValue(existingEntity, newValue);
            }
            else
            {
                var newValue = value.GetType().GetProperty("Value").GetValue(value);
                existingEntity.GetType().GetProperty(propName).SetValue(existingEntity, newValue);
            }

            Context.Set<TEntity>().Update(existingEntity);
            return (existingEntity);
        }
    }
}
