using eCommerce.Core;
using eCommerce.Core.Repositories;
using eCommerce.Data.Repositories;

namespace eCommerce.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly eCommerceDbContext _context;
        private AdminRepository _adminRepository;
        private CartDetailRepository _cartDetailRepository;
        private CartRepository _cartRepository;
        private CategoryRepository _categoryRepository;
        private FavouriteListRepository _favouriteListRepository;
        private OrderDetailRepository _orderDetailRepository;
        private OrderRepository _orderRepository;
        private ProductImageRepository _productImageRepository;
        private ProductRepository _productRepository;
        private ShopOwnerAdressRepository _shopOwnerAdressRepository;
        private ShopOwnerRepository _shopOwnerRepository;
        private SubCategoryRepository _subCategoryRepository;
        private UserAdressRepository _userAdressRepository;
        private UserRepository _userRepository;

        public UnitOfWork(eCommerceDbContext context)
        {
            _context = context;
        }
        public IAdminRepository Admins => _adminRepository ?? new AdminRepository(_context);

        public IShopOwnerRepository ShopOwners => _shopOwnerRepository ?? new ShopOwnerRepository(_context);

        public ICartDetailRepository CartDetails => _cartDetailRepository ?? new CartDetailRepository(_context);

        public ICartRepository Carts => _cartRepository ?? new CartRepository(_context);

        public ICategoryRepository Categories => _categoryRepository ?? new CategoryRepository(_context);

        public IFavouriteListRepository FavoriteLists => _favouriteListRepository ?? new FavouriteListRepository(_context);

        public IOrderDetailRepository OrderDeatils => _orderDetailRepository ?? new OrderDetailRepository(_context);

        public IOrderRepository Orders => _orderRepository ?? new OrderRepository(_context);

        public IProductImageRepository ProductImages => _productImageRepository ?? new ProductImageRepository(_context);

        public IProductRepository Products => _productRepository ?? new ProductRepository(_context);

        public IShopOwnerAdressRepository ShopOwnerAdresses => _shopOwnerAdressRepository ?? new ShopOwnerAdressRepository(_context);

        public ISubCategoryRepository SubCategories => _subCategoryRepository ?? new SubCategoryRepository(_context);

        public IUserAdressRepository UserAdresses => _userAdressRepository ?? new UserAdressRepository(_context);
        public IUserRepository Users => _userRepository ?? new UserRepository(_context);

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
