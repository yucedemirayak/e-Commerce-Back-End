using eCommerce.Core.Models;

namespace eCommerce.Core.Services
{
    public interface IAdminService : IService<Admin>
    {
        Task<Admin> CreateNew(Admin entity);
        Task<Admin> GetByEmail(string email);
        Task<IEnumerable<Admin>> GetAll();
    }
}
