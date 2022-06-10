using eCommerce.Core;
using eCommerce.Core.Models;
using eCommerce.Core.Services;

namespace eCommerce.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Order> Create(Order newOrder)
        {
            await _unitOfWork.Orders.AddAsync(newOrder);
            await _unitOfWork.CommitAsync();
            return newOrder;
        }

        public async Task<Order> Delete(int id)
        {
            var deletedOrder = await GetById(id);
            _unitOfWork.Orders.Remove(deletedOrder);
            await _unitOfWork.CommitAsync();
            return deletedOrder;
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            return await _unitOfWork.Orders.GetAllAsync();
        }

        public async Task<Order> GetById(int id)
        {
            return await _unitOfWork.Orders.GetByIdAsync(id);
        }
    }
}
