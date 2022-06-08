﻿using AutoMapper;
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
        private readonly IShopOwnerService _shopOwnerService;
        private readonly IMapper _mapper;

        public ShopOwnerController(
            IShopOwnerService shopOwnerService, 
            IMapper mapper)
        {
            _shopOwnerService = shopOwnerService;
            _mapper = mapper;
        }


    }
}