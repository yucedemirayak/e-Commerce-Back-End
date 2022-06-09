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

        public ICartDetailService CartDetailServices => throw new NotImplementedException();

        public ICartService CartServices => throw new NotImplementedException();

        public ICategoryService CategoryServices => throw new NotImplementedException();

        public IFavouriteListService FavoriteListServices => throw new NotImplementedException();

        public IOrderDetailService OrderDetailServices => throw new NotImplementedException();

        public IOrderService OrderServices => throw new NotImplementedException();

        public IProductImageService ProductImageServices => throw new NotImplementedException();

        public IProductService ProductServices => throw new NotImplementedException();

        public IShopOwnerAdressService ShopOwnerAdressServices => throw new NotImplementedException();

        public IShopOwnerService ShopOwnerServices => throw new NotImplementedException();

        public ISubCategoryService SubCategoryServices => throw new NotImplementedException();

        public IUserAdressService UserAdressServices => throw new NotImplementedException();

        public IUserService UserServices => throw new NotImplementedException();
    }
}
