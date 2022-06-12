using eCommerce.Core;
using eCommerce.Core.Models;
using eCommerce.Core.Services;

namespace eCommerce.Services
{
    public class CartService : ICartService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CartService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Cart> Create(Cart newCart)
        {
            await _unitOfWork.Carts.AddAsync(newCart);
            await _unitOfWork.CommitAsync();
            return newCart;
        }

        public async Task<Cart> Delete(int id)
        {
            var deletedCart = await GetById(id);
            _unitOfWork.Carts.Remove(deletedCart);
            await _unitOfWork.CommitAsync();
            return deletedCart;
        }

        public async Task<IEnumerable<Cart>> GetAll()
        {
            return await _unitOfWork.Carts.GetAllAsync();
        }

        public async Task<Cart> GetById(int id)
        {
            return await _unitOfWork.Carts.GetByIdAsync(id);
        }

        public async Task<Cart> Update(int id, Cart updatedCart)
        {
            return await _unitOfWork.Carts.UpdateByIdAsync(id, updatedCart);
        }
    }
}
