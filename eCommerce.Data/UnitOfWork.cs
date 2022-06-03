using eCommerce.Core;
using eCommerce.Core.Repositories;
using eCommerce.Data.Repositories;

namespace eCommerce.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly eCommerceDbContext _context;
        private AdminRepository _adminRepository;
        private UserRepository _userRepository;
        private ShopOwnerRepository _shopOwnerRepository;

        public UnitOfWork(eCommerceDbContext context)
        {
            _context = context;
        }
        public IAdminRepository Admins => _adminRepository ?? new AdminRepository(_context);

        public IUserRepository Users => _userRepository ?? new UserRepository(_context);

        public IShopOwnerRepository ShopOwners => _shopOwnerRepository ?? new ShopOwnerRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
