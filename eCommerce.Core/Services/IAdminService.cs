using eCommerce.Core.Models;

namespace eCommerce.Core.Services
{
    public interface IAdminService : IService<Admin>
    {
        Task<Admin> CreateAdmin(Admin newAdmin);
        Task<Admin> GetAdminByEmail(string email);
    }
}
