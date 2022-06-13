namespace eCommerce.Core.Services
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
        Task<TEntity> DeleteById(int id);
        Task<TEntity> Create(TEntity entity);
        Task<TEntity> UpdateById(int id,TEntity entity);
    }
}