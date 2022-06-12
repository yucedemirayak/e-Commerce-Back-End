using eCommerce.Core.Models;

namespace eCommerce.Core.Services
{
    public interface IAdminService : IBaseService<Admin>
    {
        Task<Admin> GetByEmail(string email);
    }
}
