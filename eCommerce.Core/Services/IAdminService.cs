using eCommerce.Core.Models;

namespace eCommerce.Core.Services
{
    public interface IAdminService : IBaseService<Admin>
    {
        Task<Admin> Create(Admin entity);
        Task<Admin> GetByEmail(string email);
        Task<IEnumerable<Admin>> GetAll();
    }
}
