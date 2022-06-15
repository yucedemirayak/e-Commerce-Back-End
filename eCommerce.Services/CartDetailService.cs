using eCommerce.Core;
using eCommerce.Core.Models;
using eCommerce.Core.Services;
using System.Linq.Expressions;

namespace eCommerce.Services
{
    public class CartDetailService : ICartDetailService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CartDetailService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CartDetail> Create(CartDetail newCartDetail)
        {
            await _unitOfWork.CartDetails.AddAsync(newCartDetail);
            await _unitOfWork.CommitAsync();
            return newCartDetail;
        }

        public async Task<CartDetail> DeleteById(int id)
        {
            var deletedCartDetail = await ReceiveById(id);
            _unitOfWork.CartDetails.Remove(deletedCartDetail);
            await _unitOfWork.CommitAsync();
            return deletedCartDetail;
        }

        public async Task<IEnumerable<CartDetail>> ReceiveAll()
        {
            return await _unitOfWork.CartDetails.GetAllAsync();
        }

        public async Task<CartDetail> ReceiveById(int id)
        {
            return await _unitOfWork.CartDetails.GetByIdAsync(id);
        }

        public async Task<CartDetail> ChangeById(int id, CartDetail updatedCartDetail)
        {
            await _unitOfWork.CartDetails.UpdateByIdAsync(id, updatedCartDetail);
            await _unitOfWork.CommitAsync();
            return await ReceiveById(id);
        }

        public async Task<CartDetail> ChangeValueById(int id, object value, string propName)
        {
            await _unitOfWork.CartDetails.UpdateValueByIdAsync(id, value, propName);
            await _unitOfWork.CommitAsync();
            return await ReceiveById(id);
        }
    }
}
