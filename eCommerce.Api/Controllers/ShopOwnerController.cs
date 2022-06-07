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
        private readonly IShopOwnerService _shopOwnerService;
        private readonly IMapper _mapper;

        public ShopOwnerController(IShopOwnerService shopOwnerService, IMapper mapper)
        {
            _shopOwnerService = shopOwnerService;
            _mapper = mapper;
        }

        [HttpPost("newShopOwner")]
        [AllowAnonymous]
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
    }
}
