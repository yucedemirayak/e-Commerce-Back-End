using eCommerce.Core.Models;

namespace eCommerce.Core.Services
{
    public interface IUserService : IService<User>
    {
        Task<User> CreateNew(User entity);
        Task<User> GetByEmail(string email);
        Task<IEnumerable<User>> GetAll();
    }
}
