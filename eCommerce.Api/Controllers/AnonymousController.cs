using AutoMapper;
using eCommerce.Api.DTOs;
using eCommerce.Api.DTOs.Category;
using eCommerce.Api.DTOs.Product;
using eCommerce.Api.DTOs.ShopOwner;
using eCommerce.Api.DTOs.SubCategory;
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
        private readonly Core.IServiceProvider _serviceProvider;
        private readonly IMapper _mapper;

        public AnonymousController(Core.IServiceProvider serviceProvider, IMapper mapper)
        {
            _serviceProvider = serviceProvider;
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
            var addedShopOwner = await _serviceProvider.ShopOwnerServices.Create(createdShopOwner);

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
            var addedUser = await _serviceProvider.UserServices.Create(createdUser);

            var userDTO = _mapper.Map<User, UserDTO>(addedUser);

            return Ok(ResponseDTO.GenerateResponse(userDTO));
        }

        //Get All Categories
        [HttpGet("allCategories")]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetAllCategories()
        {
            var categories = await _serviceProvider.CategoryServices.GetAll();
            var categoryDTOs = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(categories);

            return Ok(ResponseDTO.GenerateResponse(categoryDTOs));
        }

        //Get All SubCategories
        [HttpGet("allSubCategories")]
        public async Task<ActionResult<IEnumerable<SubCategoryDTO>>> GetAllSubCategories()
        {
            var subCategories = await _serviceProvider.SubCategoryServices.GetAll();
            var subCategoryDTOs = _mapper.Map<IEnumerable<SubCategory>, IEnumerable<SubCategoryDTO>>(subCategories);;

            return Ok(ResponseDTO.GenerateResponse(subCategoryDTOs));
        }

        //Get All Products
        [HttpGet("allProducts")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllProducts()
        {
            var products = await _serviceProvider.ProductServices.GetAll();
            var productDTOs = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(products);

            return Ok(ResponseDTO.GenerateResponse(productDTOs));
        }

    }
}
