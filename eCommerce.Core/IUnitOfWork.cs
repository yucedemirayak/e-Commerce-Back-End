﻿using eCommerce.Core.Repositories;

namespace eCommerce.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IAdminRepository Admins { get; }
        IUserRepository Users { get; }
        IShopOwnerRepository ShopOwners { get; }
        Task<int> CommitAsync();
    }
}
