
namespace eCommerce.Core.Services
{
    public interface IService<TEntity> where TEntity : class
    {
        Task<TEntity> GetByEmail(string email);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> CreateNew(TEntity entity);

    }
}
