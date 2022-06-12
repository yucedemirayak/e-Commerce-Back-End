using eCommerce.Core;
using eCommerce.Core.Models;
using eCommerce.Core.Services;

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

        public async Task<CartDetail> Delete(int id)
        {
            var deletedCartDetail = await GetById(id);
            _unitOfWork.CartDetails.Remove(deletedCartDetail);
            await _unitOfWork.CommitAsync();
            return deletedCartDetail;
        }

        public async Task<IEnumerable<CartDetail>> GetAll()
        {
            return await _unitOfWork.CartDetails.GetAllAsync();
        }

        public async Task<CartDetail> GetById(int id)
        {
            return await _unitOfWork.CartDetails.GetByIdAsync(id);
        }

        public async Task<CartDetail> Update(int id, CartDetail updatedCartDetail)
        {
            return await _unitOfWork.CartDetails.UpdateByIdAsync(id, updatedCartDetail);
        }
    }
}
