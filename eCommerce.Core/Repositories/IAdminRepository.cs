﻿using eCommerce.Core.Models;

namespace eCommerce.Core.Repositories
{
    public interface IAdminRepository: IRepository<Admin>
    {
        Task<Admin> GetAdminByName(string name);

    }
}