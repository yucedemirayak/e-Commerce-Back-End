using eCommerce.Core;
using eCommerce.Core.Models;
using eCommerce.Core.Services;
using System.Linq.Expressions;

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

        public async Task<Cart> DeleteById(int id)
        {
            var deletedCart = await ReceiveById(id);
            _unitOfWork.Carts.Remove(deletedCart);
            await _unitOfWork.CommitAsync();
            return deletedCart;
        }

        public async Task<IEnumerable<Cart>> ReceiveAll()
        {
            return await _unitOfWork.Carts.GetAllAsync();
        }

        public async Task<Cart> ReceiveById(int id)
        {
            return await _unitOfWork.Carts.GetByIdAsync(id);
        }

        public async Task<Cart> ChangeById(int id, Cart updatedCart)
        {
            await _unitOfWork.Carts.UpdateByIdAsync(id, updatedCart);
            await _unitOfWork.CommitAsync();
            return await ReceiveById(id);
        }

        public async Task<Cart> ChangeValueById(int id, object value, string propName)
        {
            await _unitOfWork.Carts.UpdateValueByIdAsync(id, value, propName);
            await _unitOfWork.CommitAsync();
            return await ReceiveById(id);
        }

        public async Task<IEnumerable<Cart>> ReceiveBatch(int count, int qty)
        {
            return await _unitOfWork.Carts.GetBatch(count, qty);
        }
    }
}
