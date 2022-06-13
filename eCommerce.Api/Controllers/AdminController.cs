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
  //  [Authorize(AuthenticationSchemes = "Bearer", Policy = "AdminPolicy")]
    public class AdminController : Controller
    {
        private readonly Core.IServiceProvider _serviceProvider;
        private readonly IMapper _mapper;
        public AdminController(Core.IServiceProvider serviceProvider, IMapper mapper)
        {
            _serviceProvider = serviceProvider;
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
            var addedAdmin = await _serviceProvider.AdminServices.Create(createdAdmin);

            var adminDTO = _mapper.Map<Admin, AdminDTO>(addedAdmin);

            return Ok(ResponseDTO.GenerateResponse(adminDTO));
        }

        //Delete Admin
        [HttpDelete("deleteAdmin")]
        public async Task<ActionResult<ResponseDTO>> Delete(int id)
        {
            var deletedExam = await _serviceProvider.AdminServices.DeleteById(id);
            return Ok(ResponseDTO.GenerateResponse(deletedExam));
        }

        //Update Admin
        [HttpPut("updateAdmin")]
        public async Task<ActionResult<SaveAdminDTO>> UpdateAdmin(int id,[FromBody] SaveAdminDTO admin)
        {
            var validator = new SaveAdminDTOValidator();
            var validationResult = await validator.ValidateAsync(admin);

            if (!validationResult.IsValid)
            {
                return BadRequest(ResponseDTO.GenerateResponse(null, false, validationResult.Errors.ToString()));
            }

            var updatedAdmin = _mapper.Map<SaveAdminDTO, Admin>(admin);

            await _serviceProvider.AdminServices.UpdateById(id, updatedAdmin);

            return Ok(ResponseDTO.GenerateResponse(updatedAdmin));
        }

        //Get all admins list
        [HttpGet("getAdmins")]
        public async Task<ActionResult<IEnumerable<AdminDTO>>> GetAllAdmins()
        {
            var admins = await _serviceProvider.AdminServices.GetAll();
            var adminDTOs = _mapper.Map<IEnumerable<Admin>, IEnumerable<AdminDTO>>(admins);

            return Ok(ResponseDTO.GenerateResponse(adminDTOs));
        }

        /*-----------------------------------------------------------END OF ADMIN SECTION------------------------------------------------------------------ */





        /*---------------------------------------------------------------CART SECTION------------------------------------------------------------------*/

        //Show User Cart

        /*-------------------------------------------------------------END OF CART SECTION------------------------------------------------------------------*/





        /*-------------------------------------------------------------CATEGORY SECTION------------------------------------------------------------------*/

        //Create New Category
        [HttpPost("newCategory")]
        public async Task<ActionResult<CategoryDTO>> CraeateNewCategory([FromBody] CategoryDTO category)
        {
            var validator = new CategoryDTOValidator();
            var validationResult = await validator.ValidateAsync(category);

            if (!validationResult.IsValid)
                return BadRequest(ResponseDTO.GenerateResponse(null, false, validationResult.Errors.ToString()));

            var createdCategory = _mapper.Map<CategoryDTO, Category>(category);
            var addedCategory = await _serviceProvider.CategoryServices.Create(createdCategory);

            var categoryDTO = _mapper.Map<Category, CategoryDTO>(addedCategory);

            return Ok(ResponseDTO.GenerateResponse(categoryDTO));
        }


        /*-------------------------------------------------------------END OF CATEGORY SECTION------------------------------------------------------------------*/





        /*-------------------------------------------------------------SUBCATEGORY SECTION------------------------------------------------------------------*/

        //New SubCategory
        [HttpPost("newSubCategory")]
        public async Task<ActionResult<CategoryDTO>> CraeateNewSubCategory([FromBody] SubCategoryDTO subCategory)
        {
            var validator = new SubCategoryDTOValidator();
            var validationResult = await validator.ValidateAsync(subCategory);

            if (!validationResult.IsValid)
                return BadRequest(ResponseDTO.GenerateResponse(null, false, validationResult.Errors.ToString()));

            var createdSubCategory = _mapper.Map<SubCategoryDTO, SubCategory>(subCategory);
            var addedSubCategory = await _serviceProvider.SubCategoryServices.Create(createdSubCategory);

            var subCategoryDTO = _mapper.Map<SubCategory, SubCategoryDTO>(addedSubCategory);

            return Ok(ResponseDTO.GenerateResponse(subCategoryDTO));
        }

        /*-------------------------------------------------------------END OF SUBCATEGORY SECTION------------------------------------------------------------------*/





        /*-------------------------------------------------------------ORDER SECTION------------------------------------------------------------------*/

        //Get User's & ShopOwners Orders and Details

        /*-------------------------------------------------------------END OF ORDER SECTION------------------------------------------------------------------*/





        /*-------------------------------------------------------------FAVOURITELIST SECTION------------------------------------------------------------------*/

        //Get User's Favourite List

        /*-------------------------------------------------------------END OF FAVOURITELIST SECTION------------------------------------------------------------------*/





        /*-------------------------------------------------------------PRODUCT SECTION------------------------------------------------------------------*/

        //Get all products

        //Get Product's images

        /*-------------------------------------------------------------END OF PRODUCT SECTION------------------------------------------------------------------*/





        /*-----------------------------------------------------------SHOPOWNER SECTION---------------------------------------------------------------- */

        //Get all shop owner list
        [HttpGet("getShopOwners")]
        public async Task<ActionResult<IEnumerable<ShopOwnerDTO>>> GetAllShopOwners()
        {
            var shopOwners = await _serviceProvider.ShopOwnerServices.GetAll();
            var shopOwnerDTOs = _mapper.Map<IEnumerable<ShopOwner>, IEnumerable<ShopOwnerDTO>>(shopOwners);

            return Ok(ResponseDTO.GenerateResponse(shopOwnerDTOs));
        }

        //Validate ShopOwner


        //Get ShopOwner's Products

        /*-------------------------------------------------------END OF SHOPOWNER SECTION----------------------------------------------------------- */





        /*-----------------------------------------------------------USER SECTION------------------------------------------------------------------ */

        //Get all users list
        [HttpGet("getUsers")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllUsers()
        {
            var users = await _serviceProvider.UserServices.GetAll();
            var userDTOs = _mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(users);

            return Ok(ResponseDTO.GenerateResponse(userDTOs));
        }

        //Get User's Adresses

        /*-----------------------------------------------------------END OF USER SECTION--------------------------------------------------------------- */
    }
}
