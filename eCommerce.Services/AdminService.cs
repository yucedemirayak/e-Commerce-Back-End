using eCommerce.Core;
using eCommerce.Core.Enums;
using eCommerce.Core.Helpers;
using eCommerce.Core.Models;
using eCommerce.Core.Services;
using System.Dynamic;
using System.Linq.Expressions;

namespace eCommerce.Services
{
    public class AdminService : IAdminService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdminService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Admin> Create(Admin newAdmin)
        {
            newAdmin.Role = UserRole.ADMIN;
            newAdmin.PasswordSalt = PasswordHelper.GenerateSalt();
            newAdmin.Password = PasswordHelper.HashPassword(newAdmin.Password, newAdmin.PasswordSalt);
            await _unitOfWork.Admins.AddAsync(newAdmin);
            await _unitOfWork.CommitAsync();
            return newAdmin;
        }

        public async Task<Admin> DeleteById(int id)
        {
            var deletedAdmin = await ReceiveById(id);
            _unitOfWork.Admins.Remove(deletedAdmin);
            await _unitOfWork.CommitAsync();
            return deletedAdmin;
        }

        public async Task<IEnumerable<Admin>> ReceiveAll()
        {
            return await _unitOfWork.Admins.GetAllAsync();
        }
        public async Task<Admin> ReceiveByEmail(string email)
        {
            return await _unitOfWork.Admins.GetByEmailAsync(x => x.Email == email);
        }

        public async Task<Admin> ReceiveById(int id)
        {
            return await _unitOfWork.Admins.GetByIdAsync(id);
        }

        public async Task<Admin> ChangeById(int id, Admin updatedAdmin)
        {
            var existingAdmin = await ReceiveById(id);

            if (!BCrypt.Net.BCrypt.Verify(updatedAdmin.Password + existingAdmin.PasswordSalt, existingAdmin.Password))
            {
                updatedAdmin.PasswordSalt = PasswordHelper.GenerateSalt();
                updatedAdmin.Password = PasswordHelper.HashPassword(updatedAdmin.Password, updatedAdmin.PasswordSalt);
            }

            await _unitOfWork.Admins.UpdateByIdAsync(id, updatedAdmin);
            await _unitOfWork.CommitAsync();
            return await ReceiveById(id);
        }

        public async Task<Admin> ChangeValueById(int id, object value, string propName)
        {
            var existingAdmin = await ReceiveById(id);

            if (propName == "Password")
            {
                if (existingAdmin == null)
                {
                    throw new ArgumentOutOfRangeException("Entity Id:" + id + " not found.");
                }
                var newPassword = value.GetType().GetProperty("Value").GetValue(value).ToString();

                if (!BCrypt.Net.BCrypt.Verify(newPassword + existingAdmin.PasswordSalt, existingAdmin.Password))
                {
                    string newHashedPassword = PasswordHelper.HashPassword(newPassword, existingAdmin.PasswordSalt);
                    await _unitOfWork.Admins.UpdateValueByIdAsync(id , newHashedPassword , propName);
                }
            }
            else
            {
                await _unitOfWork.Admins.UpdateValueByIdAsync(id, value, propName);
            }

            await _unitOfWork.CommitAsync();
            return await ReceiveById(id);
        }
    }
}