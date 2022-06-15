using eCommerce.Core;
using eCommerce.Core.Models;
using eCommerce.Core.Services;
using System.Linq.Expressions;

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

        public async Task<UserAdress> DeleteById(int id)
        {
            var deletedUserAdress = await ReceiveById(id);
            _unitOfWork.UserAdresses.Remove(deletedUserAdress);
            await _unitOfWork.CommitAsync();
            return deletedUserAdress;
        }

        public async Task<IEnumerable<UserAdress>> ReceiveAll()
        {
            return await _unitOfWork.UserAdresses.GetAllAsync();
        }

        public async Task<UserAdress> ReceiveById(int id)
        {
            return await _unitOfWork.UserAdresses.GetByIdAsync(id);
        }

        public async Task<UserAdress> ChangeById(int id, UserAdress updatedUserAdress)
        {
            await _unitOfWork.UserAdresses.UpdateByIdAsync(id, updatedUserAdress);
            await _unitOfWork.CommitAsync();
            return await ReceiveById(id);
        }

        public async Task<UserAdress> ChangeValueById(int id, object value, string propName)
        {
            await _unitOfWork.UserAdresses.UpdateValueByIdAsync(id, value, propName);
            await _unitOfWork.CommitAsync();
            return await ReceiveById(id);
        }
    }
}
