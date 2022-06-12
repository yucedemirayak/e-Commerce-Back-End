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
            _unitOfWork = unitOfWork;
        }

        public async Task<ShopOwner> Create(ShopOwner newShopOwner)
        {
            newShopOwner.Role = UserRole.SHOPOWNER;
            newShopOwner.IsValidated = false;
            newShopOwner.PasswordSalt = PasswordHelper.GenerateSalt();
            newShopOwner.Password = PasswordHelper.HashPassword(newShopOwner.Password, newShopOwner.PasswordSalt);
            await _unitOfWork.ShopOwners.AddAsync(newShopOwner);
            await _unitOfWork.CommitAsync();
            return newShopOwner;
        }

        public async Task<ShopOwner> Delete(int id)
        {
            var deletedShopOwner = await GetById(id);
            _unitOfWork.ShopOwners.Remove(deletedShopOwner);
            await _unitOfWork.CommitAsync();
            return deletedShopOwner;
        }

        public async Task<IEnumerable<ShopOwner>> GetAll()
        {
            return await _unitOfWork.ShopOwners.GetAllAsync();
        }
        public async Task<ShopOwner> GetByEmail(string email)
        {
            return await _unitOfWork.ShopOwners.GetByEmailAsync(x => x.Email == email);
        }

        public async Task<ShopOwner> GetById(int id)
        {
            return await _unitOfWork.ShopOwners.GetByIdAsync(id);
        }

        public async Task<ShopOwner> Update(int id, ShopOwner updatedShopOwner)
        {
            return await _unitOfWork.ShopOwners.UpdateByIdAsync(id, updatedShopOwner);
        }
    }
}
