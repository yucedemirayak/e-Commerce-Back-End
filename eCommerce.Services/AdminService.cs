using eCommerce.Core;
using eCommerce.Core.Helpers;
using eCommerce.Core.Models;
using eCommerce.Core.Services;

namespace eCommerce.Services
{
    public class AdminService : IAdminService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdminService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Admin> CreateAdmin(Admin newAdmin)
        {
            newAdmin.PasswordSalt = PasswordHelper.GenerateSalt();
            newAdmin.Password = PasswordHelper.HashPassword(newAdmin.Password, newAdmin.PasswordSalt);
            await _unitOfWork.Admins.AddAsync(newAdmin);
            await _unitOfWork.CommitAsync();
            return newAdmin;
        }

        public async Task<IEnumerable<Admin>> GetAll()
        {
            return await _unitOfWork.Admins.GetAllAsync();
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _unitOfWork.Users.GetAllAsync();
        }
    }
}
