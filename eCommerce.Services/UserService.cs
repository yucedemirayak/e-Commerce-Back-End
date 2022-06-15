using eCommerce.Core;
using eCommerce.Core.Enums;
using eCommerce.Core.Helpers;
using eCommerce.Core.Models;
using eCommerce.Core.Services;
using System.Linq.Expressions;

namespace eCommerce.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User> Create(User newUser)
        {
            newUser.Role = UserRole.USER;
            newUser.PasswordSalt = PasswordHelper.GenerateSalt();
            newUser.Password = PasswordHelper.HashPassword(newUser.Password, newUser.PasswordSalt);
            await _unitOfWork.Users.AddAsync(newUser);
            await _unitOfWork.CommitAsync();
            return newUser;
        }

        public async Task<User> DeleteById(int id)
        {
            var deletedUser = await ReceiveById(id);
            _unitOfWork.Users.Remove(deletedUser);
            _unitOfWork.CommitAsync();
            return deletedUser;
        }

        public async Task<IEnumerable<User>> ReceiveAll()
        {
            return await _unitOfWork.Users.GetAllAsync();
        }
        public async Task<User> ReceiveByEmail(string email)
        {
            return await _unitOfWork.Users.GetByEmailAsync(x => x.Email == email);
        }

        public async Task<User> ReceiveById(int id)
        {
            return await _unitOfWork.Users.GetByIdAsync(id);
        }

        public async Task<User> ChangeById(int id, User updatedUser)
        {
            var existingUser = await ReceiveById(id);

            if (!BCrypt.Net.BCrypt.Verify(updatedUser.Password + existingUser.PasswordSalt, existingUser.Password))
            {
                updatedUser.PasswordSalt = PasswordHelper.GenerateSalt();
                updatedUser.Password = PasswordHelper.HashPassword(updatedUser.Password, updatedUser.PasswordSalt);
            }

            await _unitOfWork.Users.UpdateByIdAsync(id, updatedUser);
            await _unitOfWork.CommitAsync();
            return await ReceiveById(id);
        }

        public async Task<User> ChangeValueById(int id, object value, string propName)
        {
            var existingUser = await ReceiveById(id);

            if (propName == "Password")
            {
                if (existingUser == null)
                {
                    throw new ArgumentOutOfRangeException("Entity Id:" + id + " not found.");
                }
                var newPassword = value.GetType().GetProperty("Value").GetValue(value).ToString();

                if (!BCrypt.Net.BCrypt.Verify(newPassword + existingUser.PasswordSalt, existingUser.Password))
                {
                    string newHashedPassword = PasswordHelper.HashPassword(newPassword, existingUser.PasswordSalt);
                    await _unitOfWork.Users.UpdateValueByIdAsync(id, newHashedPassword, propName);
                }
            }
            else
            {
                await _unitOfWork.Users.UpdateValueByIdAsync(id, value, propName);
            }

            await _unitOfWork.CommitAsync();
            return await ReceiveById(id);
        }
    }
}
