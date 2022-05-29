using eCommerce.Core.Models;

namespace eCommerce.Core.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAll();
    }
}
