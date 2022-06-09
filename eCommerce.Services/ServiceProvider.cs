using eCommerce.Core;
using eCommerce.Core.Services;

namespace eCommerce.Services
{
    public class ServiceProvider : Core.IServiceProvider
    {
        private readonly IUnitOfWork _unitOfWork;
        

        private AdminService _adminService;
        private CartDetailService _cartDetailService;
        private CartService _cartService;
        private CategoryService _categoryService;
        private FavouriteListService _favouriteListService;
        private OrderDetailService _orderDetailService;
        private OrderService _orderService;
        private ProductImageService _productImageService;
        private ProductService _productService;
        private ShopOwnerAdressService _shopOwnerAdressService;
        private ShopOwnerService _shopOwnerService;
        private SubCategoryService _subCategoryService;
        private UserAdressService _userAdressService;
        private UserService _userService;

        public ServiceProvider(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IAdminService AdminServices => _adminService ?? new AdminService(_unitOfWork);

        public ICartDetailService CartDetailServices => _cartDetailService ?? new CartDetailService(_unitOfWork);

        public ICartService CartServices => _cartService ?? new CartService(_unitOfWork);

        public ICategoryService CategoryServices => _categoryService ?? new CategoryService(_unitOfWork);

        public IFavouriteListService FavoriteListServices => _favouriteListService ?? new FavouriteListService(_unitOfWork);

        public IOrderDetailService OrderDetailServices => _orderDetailService ?? new OrderDetailService(_unitOfWork);

        public IOrderService OrderServices => _orderService ?? new OrderService(_unitOfWork);

        public IProductImageService ProductImageServices => _productImageService ?? new ProductImageService(_unitOfWork);

        public IProductService ProductServices => _productService ?? new ProductService(_unitOfWork);

        public IShopOwnerAdressService ShopOwnerAdressServices => _shopOwnerAdressService ?? new ShopOwnerAdressService(_unitOfWork);

        public IShopOwnerService ShopOwnerServices => _shopOwnerService ?? new ShopOwnerService(_unitOfWork);

        public ISubCategoryService SubCategoryServices => _subCategoryService ?? new SubCategoryService(_unitOfWork);

        public IUserAdressService UserAdressServices => _userAdressService ?? new UserAdressService(_unitOfWork);

        public IUserService UserServices => _userService ?? new UserService(_unitOfWork);
    }
}
