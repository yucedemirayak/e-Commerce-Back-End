using AutoMapper;
using eCommerce.Api.DTOs;
using eCommerce.Api.DTOs.ShopOwner;
using eCommerce.Api.Validations;
using eCommerce.Core.Models;
using eCommerce.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer", Policy = "ShopOwnerPolicy")]

    public class ShopOwnerController : Controller
    {
        private readonly Core.IServiceProvider _serviceProvider;
        private readonly IMapper _mapper;

        public ShopOwnerController(Core.IServiceProvider serviceProvider, IMapper mapper)
        {
            _serviceProvider = serviceProvider;
            _mapper = mapper;
        }

        //Create Product
        
    }
}
