using eCommerce.Core;
using eCommerce.Core.Enums;
using eCommerce.Core.Helpers;
using eCommerce.Core.Models;
using eCommerce.Core.Services;
using System.Linq.Expressions;

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

        public async Task<ShopOwner> DeleteById(int id)
        {
            var deletedShopOwner = await ReceiveById(id);
            _unitOfWork.ShopOwners.Remove(deletedShopOwner);
            await _unitOfWork.CommitAsync();
            return deletedShopOwner;
        }

        public async Task<IEnumerable<ShopOwner>> ReceiveAll()
        {
            return await _unitOfWork.ShopOwners.GetAllAsync();
        }
        public async Task<ShopOwner> ReceiveByEmail(string email)
        {
            return await _unitOfWork.ShopOwners.GetByEmailAsync(x => x.Email == email);
        }

        public async Task<ShopOwner> ReceiveById(int id)
        {
            return await _unitOfWork.ShopOwners.GetByIdAsync(id);
        }

        public async Task<ShopOwner> ChangeById(int id, ShopOwner updatedShopOwner)
        {
            var existingShopOwner = await ReceiveById(id);

            if (!BCrypt.Net.BCrypt.Verify(updatedShopOwner.Password + existingShopOwner.PasswordSalt, existingShopOwner.Password))
            {
                updatedShopOwner.PasswordSalt = PasswordHelper.GenerateSalt();
                updatedShopOwner.Password = PasswordHelper.HashPassword(updatedShopOwner.Password, updatedShopOwner.PasswordSalt);
            }

            await _unitOfWork.ShopOwners.UpdateByIdAsync(id, updatedShopOwner);
            await _unitOfWork.CommitAsync();
            return await ReceiveById(id);
        }

        public async Task<ShopOwner> ChangeValueById(int id, object value, string propName)
        {
            var existingShopOwner = await ReceiveById(id);

            if (propName == "Password")
            {
                if (existingShopOwner == null)
                {
                    throw new ArgumentOutOfRangeException("Entity Id:" + id + " not found.");
                }
                var newPassword = value.GetType().GetProperty("Value").GetValue(value).ToString();

                if (!BCrypt.Net.BCrypt.Verify(newPassword + existingShopOwner.PasswordSalt, existingShopOwner.Password))
                {
                    string newHashedPassword = PasswordHelper.HashPassword(newPassword, existingShopOwner.PasswordSalt);
                    await _unitOfWork.ShopOwners.UpdateValueByIdAsync(id, newHashedPassword, propName);
                }
            }
            else
            {
                await _unitOfWork.ShopOwners.UpdateValueByIdAsync(id, value, propName);
            }

            await _unitOfWork.CommitAsync();
            return await ReceiveById(id);
        }

        public async Task<IEnumerable<ShopOwner>> ReceiveBatch(int count, int qty)
        {
            return await _unitOfWork.ShopOwners.GetBatch(count, qty);
        }
    }
}
