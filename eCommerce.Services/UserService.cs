﻿

using eCommerce.Core;
using eCommerce.Core.Enums;
using eCommerce.Core.Helpers;
using eCommerce.Core.Models;
using eCommerce.Core.Services;

namespace eCommerce.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<User> CreateNew(User newUser)
        {
            newUser.Role = UserRole.USER;
            newUser.PasswordSalt = PasswordHelper.GenerateSalt();
            newUser.Password = PasswordHelper.HashPassword(newUser.Password, newUser.PasswordSalt);
            await _unitOfWork.Users.AddAsync(newUser);
            await _unitOfWork.CommitAsync();
            return newUser;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _unitOfWork.Users.GetAllAsync();
        }
        public async Task<User> GetByEmail(string email)
        {
            return await _unitOfWork.Users.GetByEmailAsync(x => x.Email == email);
        }
    }
}