using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using eCommerce.Api.DTOs;
using eCommerce.Core.Services;
using eCommerce.Api.DTOs.Auth;

namespace eCommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAdminService _adminService;
        private readonly IUserService _userService;
        private readonly IShopOwnerService _shopOwnerService;
        private readonly IConfiguration _config;

        public AuthController(IAdminService adminService, IShopOwnerService shopOwnerService, IUserService userService, IConfiguration config)
        {
            _adminService = adminService;
            _shopOwnerService = shopOwnerService;
            _userService = userService;
            _config = config;
        }

        //Admin Login Action
        [HttpPost("loginAdmin")]
        public async Task<IActionResult> LoginAdmin([FromBody] LoginDTO loginResource)
        {
            var findedAdmin = await _adminService.GetByEmail(loginResource.Email);
            if (findedAdmin == null)
                return BadRequest(ResponseDTO.GenerateResponse(null, false, "Admin not found"));

            if (!BCrypt.Net.BCrypt.Verify(loginResource.Password + findedAdmin.PasswordSalt, findedAdmin.Password))
                return BadRequest(ResponseDTO.GenerateResponse(null, false, "Admin e-mail or password incorrect."));

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["Application:Secret"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = "eCommerce",
                Issuer = "issuer",
                Subject = new ClaimsIdentity(
                    new Claim[]{
                             new Claim(ClaimTypes.Name, findedAdmin.FullName),
                             new Claim(ClaimTypes.Email, findedAdmin.Email),
                             new Claim("Role", findedAdmin.Role.ToString())
                    }
                ),
                Expires = DateTime.UtcNow.AddDays(1),

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(ResponseDTO.GenerateResponse(new LoginResponseDTO() { Token = tokenString, Role = (int)findedAdmin.Role }));
        }

        //ShopOwner Login Action
        [HttpPost("loginShopOwner")]
        public async Task<IActionResult> LoginShopOwner([FromBody] LoginDTO loginResource)
        {
            var findedShopOwner = await _shopOwnerService.GetByEmail(loginResource.Email);
            if (findedShopOwner == null)
                return BadRequest(ResponseDTO.GenerateResponse(null, false, "Shop not found"));

            if (!BCrypt.Net.BCrypt.Verify(loginResource.Password + findedShopOwner.PasswordSalt, findedShopOwner.Password))
                return BadRequest(ResponseDTO.GenerateResponse(null, false, "Shop e-mail or password incorrect."));

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["Application:Secret"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = "eCommerce",
                Issuer = "issuer",
                Subject = new ClaimsIdentity(
                    new Claim[]{
                             new Claim(ClaimTypes.Name, findedShopOwner.ShopName),
                             new Claim(ClaimTypes.Email, findedShopOwner.Email),
                             new Claim("Role", findedShopOwner.Role.ToString())
                    }
                ),
                Expires = DateTime.UtcNow.AddDays(1),

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(ResponseDTO.GenerateResponse(new LoginResponseDTO() { Token = tokenString, Role = (int)findedShopOwner.Role }));
        }

        //User Login Action
        [HttpPost("loginUser")]
        public async Task<IActionResult> LoginUser([FromBody] LoginDTO loginResource)
        {
            var findedUser = await _userService.GetByEmail(loginResource.Email);
            if (findedUser == null)
                return BadRequest(ResponseDTO.GenerateResponse(null, false, "User not found"));

            if (!BCrypt.Net.BCrypt.Verify(loginResource.Password + findedUser.PasswordSalt, findedUser.Password))
                return BadRequest(ResponseDTO.GenerateResponse(null, false, "User e-mail or password incorrect."));

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["Application:Secret"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = "eCommerce",
                Issuer = "issuer",
                Subject = new ClaimsIdentity(
                    new Claim[]{
                             new Claim(ClaimTypes.Name, findedUser.FirstName),
                             new Claim(ClaimTypes.Email, findedUser.Email),
                             new Claim("Role", findedUser.Role.ToString())
                    }
                ),
                Expires = DateTime.UtcNow.AddDays(1),

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(ResponseDTO.GenerateResponse(new LoginResponseDTO() { Token = tokenString, Role = (int)findedUser.Role }));
        }
    }
}
