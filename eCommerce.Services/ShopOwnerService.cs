using eCommerce.Core;
using eCommerce.Core.Enums;
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

        public async Task<ShopOwner> CreateNew(ShopOwner newShopOwner)
        {
            newShopOwner.Role = UserRole.SHOPOWNER;
            newShopOwner.PasswordSalt = PasswordHelper.GenerateSalt();
            newShopOwner.Password = PasswordHelper.HashPassword(newShopOwner.Password, newShopOwner.PasswordSalt);
            await _unitOfWork.ShopOwners.AddAsync(newShopOwner);
            await _unitOfWork.CommitAsync();
            return newShopOwner;
        }

        public async Task<IEnumerable<ShopOwner>> GetAll()
        {
            return await _unitOfWork.ShopOwners.GetAllAsync();
        }
        public async Task<ShopOwner> GetByEmail(string email)
        {
            return await _unitOfWork.ShopOwners.GetByEmailAsync(x => x.Email == email);
        }
    }
}
