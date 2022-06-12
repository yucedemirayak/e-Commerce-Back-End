using AutoMapper;
using eCommerce.Api.DTOs.User;
using eCommerce.Api.Validations;
using eCommerce.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using eCommerce.Api.DTOs;
using eCommerce.Core.Models;
using Microsoft.AspNetCore.Authorization;

namespace eCommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer", Policy = "UserPolicy")]
    public class UserController : Controller
    {
        private readonly Core.IServiceProvider _serviceProvider;
        private readonly IMapper _mapper;

        public UserController(Core.IServiceProvider serviceProvider, IMapper mapper)
        {
            _serviceProvider = serviceProvider;
            _mapper = mapper;
        }


    }
}
