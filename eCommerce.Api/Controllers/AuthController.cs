﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using eCommerce.Api.DTOs;
using eCommerce.Core.Services;

namespace eCommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAdminService _adminService;
        private readonly IUserService _userService;
        
        private readonly IConfiguration _config;

        public AuthController(IAdminService adminService,  IConfiguration config, IUserService userService)
        {
            _adminService = adminService;
            _config = config;
            _userService = userService;
        }

        [HttpPost("loginAdmin")]
        public async Task<IActionResult> LoginAdmin([FromBody] LoginDTO loginResource)
        {
            var findedAdmin = await _adminService.GetAdminByEmail(loginResource.Email);
            if (findedAdmin == null)
                return BadRequest(ResponseDTO.GenerateResponse(null, false, "Admin not found"));

            if (!BCrypt.Net.BCrypt.Verify(loginResource.Password + findedAdmin.PasswordSalt, findedAdmin.Password))
                return BadRequest(ResponseDTO.GenerateResponse(null, false, "Admin name or password incorrect."));

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

        //[HttpPost("loginUser")]
        //public async Task<IActionResult> LoginUser([FromBody] LoginDTO loginResource)
        //{
        //    var findedUser = await _userService.GetUserByEmail(loginResource.Email);
        //    if (findedUser == null)
        //        return BadRequest(ResponseDTO.GenerateResponse(null, false, "User not found"));

        //    if (!BCrypt.Net.BCrypt.Verify(loginResource.Password + findedUser.PasswordSalt, findedUser.Password))
        //        return BadRequest(ResponseDTO.GenerateResponse(null, false, "User name or password incorrect."));

        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.ASCII.GetBytes(_config["Application:Secret"]);
        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Audience = "eCommerce",
        //        Issuer = "issuer",
        //        Subject = new ClaimsIdentity(
        //            new Claim[]{
        //                     new Claim(ClaimTypes.Name, findedUser.FullName),
        //                     new Claim(ClaimTypes.Email, findedUser.Email),
        //                     new Claim("Role", findedUser.Role.ToString())
        //            }
        //        ),
        //        Expires = DateTime.UtcNow.AddDays(1),

        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        //    };

        //    var token = tokenHandler.CreateToken(tokenDescriptor);
        //    var tokenString = tokenHandler.WriteToken(token);

        //    return Ok(ResponseDTO.GenerateResponse(new LoginResponseDTO() { Token = tokenString, Role = (int)findedAdmin.Role }));
        //}
    }
}
