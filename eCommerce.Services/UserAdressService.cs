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

        public async Task<UserAdress> Create(UserAdress newUserAdress)
        {
            await _unitOfWork.UserAdresses.AddAsync(newUserAdress);
            await _unitOfWork.CommitAsync();
            return newUserAdress;
        }

        public async Task<UserAdress> Delete(int id)
        {
            var deletedUserAdress = await GetById(id);
            _unitOfWork.UserAdresses.Remove(deletedUserAdress);
            await _unitOfWork.CommitAsync();
            return deletedUserAdress;
        }

        public async Task<IEnumerable<UserAdress>> GetAll()
        {
            return await _unitOfWork.UserAdresses.GetAllAsync();
        }

        public async Task<UserAdress> GetById(int id)
        {
            return await _unitOfWork.UserAdresses.GetByIdAsync(id);
        }

        public async Task<UserAdress> Update(int id, UserAdress updatedUserAdress)
        {
            return await _unitOfWork.UserAdresses.UpdateByIdAsync(id, updatedUserAdress);
        }
    }
}
