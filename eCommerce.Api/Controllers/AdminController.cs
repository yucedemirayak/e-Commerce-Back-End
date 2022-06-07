using AutoMapper;
using eCommerce.Api.DTOs;
using eCommerce.Api.DTOs.Admin;
using eCommerce.Api.DTOs.ShopOwner;
using eCommerce.Api.DTOs.User;
using eCommerce.Api.Validations;
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
        private readonly IAdminService _adminService;
        private readonly IUserService _userService;
        private readonly IShopOwnerService _shopOwnerService;
        private readonly IMapper _mapper;

        //calling the services we will use in the project
        public AdminController(IAdminService adminService, IShopOwnerService shopOwnerService, IUserService userService,  IMapper mapper)
        {
            _adminService = adminService;
            _userService = userService;
            _shopOwnerService = shopOwnerService;
            _mapper = mapper;
        }

        //Create a new admin
        [HttpPost("newAdmin")]
        public async Task<ActionResult<AdminDTO>> PostAdmin([FromBody] SaveAdminDTO admin)
        {
            var validator = new SaveAdminDTOValidator();
            var validationResult = await validator.ValidateAsync(admin);

            if (!validationResult.IsValid)
                return BadRequest(ResponseDTO.GenerateResponse(null, false, validationResult.Errors.ToString()));

            var createdAdmin = _mapper.Map<SaveAdminDTO, Admin>(admin);
            var addedAdmin = await _adminService.CreateNew(createdAdmin);

            var adminDTO = _mapper.Map<Admin, AdminDTO>(addedAdmin);

            return Ok(ResponseDTO.GenerateResponse(adminDTO));
        }

        //Get all admins list
        [HttpGet("getAdmins")]
        public async Task<ActionResult<IEnumerable<AdminDTO>>> GetAllAdmins()
        {
            var admins = await _adminService.GetAll();
            var adminDTOs = _mapper.Map<IEnumerable<Admin>, IEnumerable<AdminDTO>>(admins);

            return Ok(ResponseDTO.GenerateResponse(adminDTOs));
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

        //Get all shop owner list
        [HttpGet("getShopOwners")]
        public async Task<ActionResult<IEnumerable<ShopOwnerDTO>>> GetAllShopOwners()
        {
            var shopOwners = await _shopOwnerService.GetAll();
            var shopOwnerDTOs = _mapper.Map<IEnumerable<ShopOwner>, IEnumerable<ShopOwnerDTO>>(shopOwners);

            return Ok(ResponseDTO.GenerateResponse(shopOwnerDTOs));
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

        //Get all users list
        [HttpGet("getUsers")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllUsers()
        {
            var users = await _userService.GetAll();
            var userDTOs = _mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(users);

            return Ok(ResponseDTO.GenerateResponse(userDTOs));
        }
    }
}
