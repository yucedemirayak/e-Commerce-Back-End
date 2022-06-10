﻿using eCommerce.Core.Models;

namespace eCommerce.Core.Services
{
    public interface IUserService : IBaseService<User>
    {
        Task<User> Create(User entity);
        Task<User> GetByEmail(string email);
        Task<IEnumerable<User>> GetAll();
    }
}
