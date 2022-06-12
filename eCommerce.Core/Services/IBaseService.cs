namespace eCommerce.Core.Services
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
        Task<TEntity> Delete(int id);
        Task<TEntity> Create(TEntity entity);
        Task<TEntity> Update(int id,TEntity entity);
    }
}