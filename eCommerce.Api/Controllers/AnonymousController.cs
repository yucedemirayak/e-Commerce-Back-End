using AutoMapper;
using eCommerce.Api.DTOs;
using eCommerce.Api.DTOs.ShopOwner;
using eCommerce.Api.DTOs.User;
using eCommerce.Api.Validations;
using eCommerce.Core.Models;
using eCommerce.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnonymousController : Controller
    {
        private readonly IAdminService _adminService;
        private readonly ICartDetailService _cartDetailService;
        private readonly ICartService _cartService;
        private readonly ICategoryService _categoryService;
        private readonly IFavouriteListService _favouriteListService;
        private readonly IOrderDetailService _orderDetailService;
        private readonly IOrderService _orderService;
        private readonly IProductImageService _productImageService;
        private readonly IProductService _productService;
        private readonly IShopOwnerAdressService _shopOwnerAdressService;
        private readonly IShopOwnerService _shopOwnerService;
        private readonly ISubCategoryService _subCategoryService;
        private readonly IUserAdressService _userAdressService;
        private readonly IUserService _userService;

        private readonly IMapper _mapper;

        //calling the services we will use in the project
        public AnonymousController(
            IAdminService adminService,
            ICartDetailService cartDetailService,
            ICartService cartService,
            ICategoryService categoryService,
            IFavouriteListService favouriteListService,
            IOrderDetailService orderDetailService,
            IOrderService orderService,
            IProductImageService productImageService,
            IProductService productService,
            IShopOwnerAdressService shopOwnerAdressService,
            IShopOwnerService shopOwnerService,
            ISubCategoryService subCategoryService,
            IUserAdressService userAdressService,
            IUserService userService,
            IMapper mapper)
        {
            _adminService = adminService;
            _cartDetailService = cartDetailService;
            _cartService = cartService;
            _categoryService = categoryService;
            _favouriteListService = favouriteListService;
            _orderDetailService = orderDetailService;
            _orderService = orderService;
            _productImageService = productImageService;
            _productService = productService;
            _shopOwnerAdressService = shopOwnerAdressService;
            _shopOwnerService = shopOwnerService;
            _subCategoryService = subCategoryService;
            _userAdressService = userAdressService;
            _userService = userService;

            _mapper = mapper;
        }
        //Create new Shop owner
        [HttpPost("newShopOwner")]
        public async Task<ActionResult<ShopOwnerDTO>> PostShopOwner([FromBody] SaveShopOwnerDTO shopOwner)
        {
            var validator = new SaveShopOwnerDTOValidator();
            var validationResult = await validator.ValidateAsync(shopOwner);

            if (!validationResult.IsValid)
                return BadRequest(ResponseDTO.GenerateResponse(null, false, validationResult.Errors.ToString()));

            var createdShopOwner = _mapper.Map<SaveShopOwnerDTO, ShopOwner>(shopOwner);
            var addedShopOwner = await _shopOwnerService.CreateNew(createdShopOwner);

            var shopOwnerDTO = _mapper.Map<ShopOwner, ShopOwnerDTO>(addedShopOwner);

            return Ok(ResponseDTO.GenerateResponse(shopOwnerDTO));
        }

        //Create new user
        [HttpPost("newUser")]
        public async Task<ActionResult<UserDTO>> PostUser([FromBody] SaveUserDTO user)
        {
            var validator = new SaveUserDTOValidator();
            var validationResult = await validator.ValidateAsync(user);

            if (!validationResult.IsValid)
                return BadRequest(ResponseDTO.GenerateResponse(null, false, validationResult.Errors.ToString()));

            var createdUser = _mapper.Map<SaveUserDTO, User>(user);
            var addedUser = await _userService.CreateNew(createdUser);

            var userDTO = _mapper.Map<User, UserDTO>(addedUser);

            return Ok(ResponseDTO.GenerateResponse(userDTO));
        }

        //Get All Products
    }
}
