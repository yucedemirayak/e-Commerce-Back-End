using System.Linq.Expressions;

namespace eCommerce.Core.Services
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> ReceiveAll();
        Task<IEnumerable<TEntity>> ReceiveBatch(int count, int order);
        Task<TEntity> ReceiveById(int id);
        Task<TEntity> DeleteById(int id);
        Task<TEntity> Create(TEntity entity);
        Task<TEntity> ChangeById(int id,TEntity entity);
        Task<TEntity> ChangeValueById(int id, object value , string propName);
    }
}