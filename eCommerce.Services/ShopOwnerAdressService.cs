using eCommerce.Core;
using eCommerce.Core.Models;
using eCommerce.Core.Services;
using System.Linq.Expressions;

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
            var deletedShopOwnerAdress = await ReceiveById(id);
            _unitOfWork.ShopOwnerAdresses.Remove(deletedShopOwnerAdress);
            await _unitOfWork.CommitAsync();
            return deletedShopOwnerAdress;
        }

        public async Task<IEnumerable<ShopOwnerAdress>> ReceiveAll()
        {
            return await _unitOfWork.ShopOwnerAdresses.GetAllAsync();
        }

        public async Task<ShopOwnerAdress> ReceiveById(int id)
        {
            return await _unitOfWork.ShopOwnerAdresses.GetByIdAsync(id);
        }

        public async Task<ShopOwnerAdress> ChangeById(int id, ShopOwnerAdress updatedShopOwnerAdress)
        {
            await _unitOfWork.ShopOwnerAdresses.UpdateByIdAsync(id, updatedShopOwnerAdress);
            await _unitOfWork.CommitAsync();
            return await ReceiveById(id);
        }

        public async Task<ShopOwnerAdress> ChangeValueById(int id, object value, string propName)
        {
            await _unitOfWork.ShopOwnerAdresses.UpdateValueByIdAsync(id, value, propName);
            await _unitOfWork.CommitAsync();
            return await ReceiveById(id);
        }
    }
}
