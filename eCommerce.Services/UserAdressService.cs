using eCommerce.Core;
using eCommerce.Core.Models;
using eCommerce.Core.Services;

namespace eCommerce.Services
{
    public class UserAdressService : IUserAdressService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserAdressService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
