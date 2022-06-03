using eCommerce.Core.Models;

namespace eCommerce.Core.Services
{
    public interface IUserService : IService<User>
    {
        Task<User> CreateUser(User newUser);
    }
}
