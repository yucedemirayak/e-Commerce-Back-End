using eCommerce.Core;
using eCommerce.Core.Helpers;
using eCommerce.Core.Models;
using eCommerce.Core.Services;

namespace eCommerce.Services
{
    public class ShopOwnerService : IShopOwnerService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ShopOwnerService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public Task<IEnumerable<ShopOwner>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
