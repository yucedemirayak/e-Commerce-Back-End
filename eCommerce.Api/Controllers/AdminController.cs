using AutoMapper;
using eCommerce.Api.DTOs;
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
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public AdminController(IAdminService adminService, IUserService userService, IMapper mapper)
        {
            _adminService = adminService;
            _userService = userService;
            _mapper = mapper;
        }

        [Authorize("Role")]


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
    }
}
