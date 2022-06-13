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

        public async Task<ShopOwnerAdress> Create(ShopOwnerAdress newShopOwnerAdress)
        {
            await _unitOfWork.ShopOwnerAdresses.AddAsync(newShopOwnerAdress);
            await _unitOfWork.CommitAsync();
            return newShopOwnerAdress;
        }

        public async Task<ShopOwnerAdress> DeleteById(int id)
        {
            var deletedShopOwnerAdress = await GetById(id);
            _unitOfWork.ShopOwnerAdresses.Remove(deletedShopOwnerAdress);
            await _unitOfWork.CommitAsync();
            return deletedShopOwnerAdress;
        }

        public async Task<IEnumerable<ShopOwnerAdress>> GetAll()
        {
            return await _unitOfWork.ShopOwnerAdresses.GetAllAsync();
        }

        public async Task<ShopOwnerAdress> GetById(int id)
        {
            return await _unitOfWork.ShopOwnerAdresses.GetByIdAsync(id);
        }

        public async Task<ShopOwnerAdress> UpdateById(int id, ShopOwnerAdress updatedShopOwnerAdress)
        {
            return await _unitOfWork.ShopOwnerAdresses.UpdateByIdAsync(id, updatedShopOwnerAdress);
        }
    }
}
