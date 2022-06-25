using eCommerce.Core;
using eCommerce.Core.Models;
using eCommerce.Core.Services;
using System.Linq.Expressions;

namespace eCommerce.Services
{
    public class FavouriteListService : IFavouriteListService
    {
        private readonly IUnitOfWork _unitOfWork;
        public FavouriteListService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<FavouriteList> Create(FavouriteList newFavouriteList)
        {
            await _unitOfWork.FavoriteLists.AddAsync(newFavouriteList);
            await _unitOfWork.CommitAsync();
            return newFavouriteList;
        }

        public async Task<FavouriteList> DeleteById(int id)
        {
            var deletedFavouriteList = await ReceiveById(id);
            _unitOfWork.FavoriteLists.Remove(deletedFavouriteList);
            await _unitOfWork.CommitAsync();
            return deletedFavouriteList;
        }

        public async Task<IEnumerable<FavouriteList>> ReceiveAll()
        {
            return await _unitOfWork.FavoriteLists.GetAllAsync();
        }

        public async Task<FavouriteList> ReceiveById(int id)
        {
            return await _unitOfWork.FavoriteLists.GetByIdAsync(id);
        }

        public async Task<FavouriteList> ChangeById(int id, FavouriteList updatedFavouriteList)
        {
            await _unitOfWork.FavoriteLists.UpdateByIdAsync(id, updatedFavouriteList);
            await _unitOfWork.CommitAsync();
            return await ReceiveById(id);
        }

        public async Task<FavouriteList> ChangeValueById(int id, object value, string propName)
        {
            await _unitOfWork.FavoriteLists.UpdateValueByIdAsync(id, value, propName);
            await _unitOfWork.CommitAsync();
            return await ReceiveById(id);
        }

        public async Task<IEnumerable<FavouriteList>> ReceiveBatch(int count, int qty)
        {
            return await _unitOfWork.FavoriteLists.GetBatch(count, qty);
        }
    }
}
