using AutoMapper;
using eCommerce.Api.DTOs;
using eCommerce.Api.DTOs.Admin;
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
        private readonly IMapper _mapper;

        //calling the services we will use in the project
        public AdminController(IAdminService adminService, IUserService userService, IMapper mapper)
        {
            _adminService = adminService;
            _userService = userService;
            _mapper = mapper;
        }

        //Create a new admin
        [HttpPost]
        public async Task<ActionResult<AdminDTO>> Post([FromBody] SaveAdminDTO admin)
        {
            var validator = new SaveAdminDTOValidator();
            admin.Role = UserRole.ADMIN;
            var validationResult = await validator.ValidateAsync(admin);

            if (!validationResult.IsValid)
                return BadRequest(ResponseDTO.GenerateResponse(null, false, validationResult.Errors.ToString()));

            var createdAdmin = _mapper.Map<SaveAdminDTO, Admin>(admin);
            var addedAdmin = await _adminService.CreateAdmin(createdAdmin);

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


        //Get all shop owner list


        //Create new user
        [HttpPost]
        public async Task<ActionResult<UserDTO>> Post([FromBody] SaveUserDTO user)
        {
            var validator = new SaveUserDTOValidator();
            var validationResult = await validator.ValidateAsync(user);

            if (!validationResult.IsValid)
                return BadRequest(ResponseDTO.GenerateResponse(null, false, validationResult.Errors.ToString()));

            var createdUser = _mapper.Map<SaveUserDTO, User>(user);
            var addedUser = await _userService.CreateUser(createdUser);

            var userResource = _mapper.Map<User, UserDTO>(addedUser);

            return Ok(ResponseDTO.GenerateResponse(userResource));
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
