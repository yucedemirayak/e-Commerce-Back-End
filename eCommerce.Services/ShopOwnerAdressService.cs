using eCommerce.Core;
using eCommerce.Core.Models;
using eCommerce.Core.Services;

namespace eCommerce.Services
{
    public class ShopOwnerAdressService : IShopOwnerAdressService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ShopOwnerAdressService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
