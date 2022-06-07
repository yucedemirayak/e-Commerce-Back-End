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
    }
}
