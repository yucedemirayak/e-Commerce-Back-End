using AutoMapper;
using eCommerce.Api.DTOs.User;
using eCommerce.Api.Validations;
using eCommerce.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using eCommerce.Api.DTOs;
using eCommerce.Core.Models;

namespace eCommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

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
    }
}
