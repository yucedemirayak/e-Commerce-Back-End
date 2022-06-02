using eCommerce.Core.Models;

namespace eCommerce.Core.Services
{
    public interface IAdminService
    {
        Task<Admin> CreateAdmin(Admin newAdmin);
        Task<Admin> GetAdminByEmail(string email);
        Task<IEnumerable<Admin>> GetAll();
        Task<IEnumerable<User>> GetAllUsers();
    }
}
