using eCommerce.Core.Models;

namespace eCommerce.Core.Services
{
    public interface IUserService : IBaseService<User>
    {
        Task<User> GetByEmail(string email);
    }
}
