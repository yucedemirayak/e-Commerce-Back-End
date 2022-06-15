using System.Linq.Expressions;

namespace eCommerce.Core.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        ValueTask<TEntity> GetByIdAsync(int id);
        Task<TEntity> GetByEmailAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> GetAllAsync();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> SignleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        Task<TEntity> UpdateByIdAsync(int id, TEntity entity);
        Task<TEntity> UpdateValueByIdAsync(int id, object value, string propName);
    }
}
