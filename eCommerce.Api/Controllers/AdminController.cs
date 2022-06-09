using AutoMapper;
using eCommerce.Api.DTOs;
using eCommerce.Api.DTOs.Admin;
using eCommerce.Api.DTOs.Category;
using eCommerce.Api.DTOs.ShopOwner;
using eCommerce.Api.DTOs.SubCategory;
using eCommerce.Api.DTOs.User;
using eCommerce.Api.Validations;
using eCommerce.Core;
using eCommerce.Core.Enums;
using eCommerce.Core.Models;
using eCommerce.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer", Policy = "AdminPolicy")]
    public class AdminController : Controller
    {
        private readonly Core.IServiceProvider _servicesPipeline;
        private readonly IMapper _mapper;
        public AdminController(Core.IServiceProvider servicesPipeline, IMapper mapper)
        {
            _servicesPipeline = servicesPipeline;
            _mapper = mapper;
        }

        /*-----------------------------------------------------------ADMIN SECTION------------------------------------------------------------------ */

        //Create a new admin
        [HttpPost("newAdmin")]
        public async Task<ActionResult<AdminDTO>> PostAdmin([FromBody] SaveAdminDTO admin)
        {
            var validator = new SaveAdminDTOValidator();
            var validationResult = await validator.ValidateAsync(admin);

            if (!validationResult.IsValid)
                return BadRequest(ResponseDTO.GenerateResponse(null, false, validationResult.Errors.ToString()));

            var createdAdmin = _mapper.Map<SaveAdminDTO, Admin>(admin);
            var addedAdmin = await _servicesPipeline.AdminServices.CreateNew(createdAdmin);

            var adminDTO = _mapper.Map<Admin, AdminDTO>(addedAdmin);

            return Ok(ResponseDTO.GenerateResponse(adminDTO));
        }

        //Get all admins list
        [HttpGet("getAdmins")]
        public async Task<ActionResult<IEnumerable<AdminDTO>>> GetAllAdmins()
        {
            var admins = await _servicesPipeline.AdminServices.GetAll();
            var adminDTOs = _mapper.Map<IEnumerable<Admin>, IEnumerable<AdminDTO>>(admins);

            return Ok(ResponseDTO.GenerateResponse(adminDTOs));
        }

        /*-----------------------------------------------------------END OF ADMIN SECTION------------------------------------------------------------- */



        //private readonly IAdminService _adminService;
        //private readonly ICartDetailService _cartDetailService;
        //private readonly ICartService _cartService;
        //private readonly ICategoryService _categoryService;
        //private readonly IFavouriteListService _favouriteListService;
        //private readonly IOrderDetailService _orderDetailService;
        //private readonly IOrderService _orderService;
        //private readonly IProductImageService _productImageService;
        //private readonly IProductService _productService;
        //private readonly IShopOwnerAdressService _shopOwnerAdressService;
        //private readonly IShopOwnerService _shopOwnerService;
        //private readonly ISubCategoryService _subCategoryService;
        //private readonly IUserAdressService _userAdressService;
        //private readonly IUserService _userService;

        //private readonly IMapper _mapper;

        ////calling the services we will use in the project
        //public AdminController(IAdminService adminService, 
        //    ICartDetailService cartDetailService,
        //    ICartService cartService,
        //    ICategoryService categoryService, 
        //    IFavouriteListService favouriteListService, 
        //    IOrderDetailService orderDetailService, 
        //    IOrderService orderService, 
        //    IProductImageService productImageService,
        //    IProductService productService,
        //    IShopOwnerAdressService shopOwnerAdressService,
        //    IShopOwnerService shopOwnerService, 
        //    ISubCategoryService subCategoryService,
        //    IUserAdressService userAdressService,
        //    IUserService userService, 
        //    IMapper mapper)
        //{
        //    _adminService = adminService;
        //    _cartDetailService = cartDetailService;
        //    _cartService = cartService;
        //    _categoryService = categoryService;
        //    _favouriteListService = favouriteListService;
        //    _orderDetailService = orderDetailService;
        //    _orderService = orderService;
        //    _productImageService = productImageService;
        //    _productService = productService;
        //    _shopOwnerAdressService = shopOwnerAdressService;
        //    _shopOwnerService = shopOwnerService;
        //    _subCategoryService = subCategoryService;
        //    _userAdressService = userAdressService;
        //    _userService = userService;

        //    _mapper = mapper;
        //}

        ///*-----------------------------------------------------------ADMIN SECTION------------------------------------------------------------------ */

        ////Create a new admin
        //[HttpPost("newAdmin")]
        //public async Task<ActionResult<AdminDTO>> PostAdmin([FromBody] SaveAdminDTO admin)
        //{
        //    var validator = new SaveAdminDTOValidator();
        //    var validationResult = await validator.ValidateAsync(admin);

        //    if (!validationResult.IsValid)
        //        return BadRequest(ResponseDTO.GenerateResponse(null, false, validationResult.Errors.ToString()));

        //    var createdAdmin = _mapper.Map<SaveAdminDTO, Admin>(admin);
        //    var addedAdmin = await _adminService.CreateNew(createdAdmin);

        //    var adminDTO = _mapper.Map<Admin, AdminDTO>(addedAdmin);

        //    return Ok(ResponseDTO.GenerateResponse(adminDTO));
        //}

        ////Get all admins list
        //[HttpGet("getAdmins")]
        //public async Task<ActionResult<IEnumerable<AdminDTO>>> GetAllAdmins()
        //{
        //    var admins = await _adminService.GetAll();
        //    var adminDTOs = _mapper.Map<IEnumerable<Admin>, IEnumerable<AdminDTO>>(admins);

        //    return Ok(ResponseDTO.GenerateResponse(adminDTOs));
        //}

        ///*-----------------------------------------------------------END OF ADMIN SECTION------------------------------------------------------------- */



        ///*---------------------------------------------------------------CART SECTION------------------------------------------------------------------*/

        ////Show User Cart

        ///*-------------------------------------------------------------END OF CART SECTION------------------------------------------------------------------*/



        ///*-------------------------------------------------------------CATEGORY SECTION------------------------------------------------------------------*/

        ////Create New Category
        //[HttpPost("newCategory")]
        //public async Task<ActionResult<CategoryDTO>> CraeateNewCategory([FromBody] CategoryDTO category)
        //{
        //    var validator = new CategoryDTOValidator();
        //    var validationResult = await validator.ValidateAsync(category);

        //    if (!validationResult.IsValid)
        //        return BadRequest(ResponseDTO.GenerateResponse(null, false, validationResult.Errors.ToString()));

        //    var createdCategory = _mapper.Map<CategoryDTO, Category>(category);
        //    var addedCategory = await _categoryService.CreateNew(createdCategory);

        //    var categoryDTO = _mapper.Map<Category, CategoryDTO>(addedCategory);

        //    return Ok(ResponseDTO.GenerateResponse(categoryDTO));
        //}

        ///*-------------------------------------------------------------END OF CATEGORY SECTION------------------------------------------------------------------*/



        ///*-------------------------------------------------------------SUBCATEGORY SECTION------------------------------------------------------------------*/

        ////New SubCategory
        //[HttpPost("newSubCategory")]
        //public async Task<ActionResult<CategoryDTO>> CraeateNewSubCategory([FromBody] SubCategoryDTO subCategory)
        //{
        //    var validator = new SubCategoryDTOValidator();
        //    var validationResult = await validator.ValidateAsync(subCategory);

        //    if (!validationResult.IsValid)
        //        return BadRequest(ResponseDTO.GenerateResponse(null, false, validationResult.Errors.ToString()));

        //    var createdSubCategory = _mapper.Map<SubCategoryDTO, SubCategory>(subCategory);
        //    var addedSubCategory = await _subCategoryService.CreateNew(createdSubCategory);

        //    var subCategoryDTO = _mapper.Map<SubCategory, SubCategoryDTO>(addedSubCategory);

        //    return Ok(ResponseDTO.GenerateResponse(subCategoryDTO));
        //}

        ///*-------------------------------------------------------------END OF SUBCATEGORY SECTION------------------------------------------------------------------*/



        ///*-------------------------------------------------------------ORDER SECTION------------------------------------------------------------------*/

        ////Get User's & ShopOwners Orders and Details


        ///*-------------------------------------------------------------END OF ORDER SECTION------------------------------------------------------------------*/



        ///*-------------------------------------------------------------FAVOURITELIST SECTION------------------------------------------------------------------*/

        ////Get User's Favourite List

        ///*-------------------------------------------------------------END OF FAVOURITELIST SECTION------------------------------------------------------------------*/



        ///*-------------------------------------------------------------PRODUCT SECTION------------------------------------------------------------------*/

        ////Get all products



        ////Get Product's images

        ///*-------------------------------------------------------------END OF PRODUCT SECTION------------------------------------------------------------------*/

        ///*-----------------------------------------------------------SHOPOWNER SECTION---------------------------------------------------------------- */



        ////Get all shop owner list
        //[HttpGet("getShopOwners")]
        //public async Task<ActionResult<IEnumerable<ShopOwnerDTO>>> GetAllShopOwners()
        //{
        //    var shopOwners = await _shopOwnerService.GetAll();
        //    var shopOwnerDTOs = _mapper.Map<IEnumerable<ShopOwner>, IEnumerable<ShopOwnerDTO>>(shopOwners);

        //    return Ok(ResponseDTO.GenerateResponse(shopOwnerDTOs));
        //}

        ////Validate ShopOwner

        ////Get ShopOwner's Products

        ///*-------------------------------------------------------END OF SHOPOWNER SECTION----------------------------------------------------------- */

        ///*-----------------------------------------------------------USER SECTION------------------------------------------------------------------ */

        ////Get all users list
        //[HttpGet("getUsers")]
        //public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllUsers()
        //{
        //    var users = await _userService.GetAll();
        //    var userDTOs = _mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(users);

        //    return Ok(ResponseDTO.GenerateResponse(userDTOs));
        //}

        //Get User's Adresses

        /*-----------------------------------------------------------END OF USER SECTION--------------------------------------------------------------- */
    }
}
