using eCommerce.Core;
using eCommerce.Core.Models;
using eCommerce.Core.Services;

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

        public async Task<FavouriteList> Delete(int id)
        {
            var deletedFavouriteList = await GetById(id);
            _unitOfWork.FavoriteLists.Remove(deletedFavouriteList);
            await _unitOfWork.CommitAsync();
            return deletedFavouriteList;
        }

        public async Task<IEnumerable<FavouriteList>> GetAll()
        {
            return await _unitOfWork.FavoriteLists.GetAllAsync();
        }

        public async Task<FavouriteList> GetById(int id)
        {
            return await _unitOfWork.FavoriteLists.GetByIdAsync(id);
        }

        public async Task<FavouriteList> Update(int id, FavouriteList updatedFavouriteList)
        {
            return await _unitOfWork.FavoriteLists.UpdateByIdAsync(id , updatedFavouriteList);
        }
    }
}
