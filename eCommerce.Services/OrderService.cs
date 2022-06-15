using eCommerce.Core;
using eCommerce.Core.Models;
using eCommerce.Core.Services;
using System.Linq.Expressions;

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

        public async Task<Order> DeleteById(int id)
        {
            var deletedOrder = await ReceiveById(id);
            _unitOfWork.Orders.Remove(deletedOrder);
            await _unitOfWork.CommitAsync();
            return deletedOrder;
        }

        public async Task<IEnumerable<Order>> ReceiveAll()
        {
            return await _unitOfWork.Orders.GetAllAsync();
        }

        public async Task<Order> ReceiveById(int id)
        {
            return await _unitOfWork.Orders.GetByIdAsync(id);
        }

        public async Task<Order> ChangeById(int id, Order updatedOrder)
        {
            await _unitOfWork.Orders.UpdateByIdAsync(id, updatedOrder);
            await _unitOfWork.CommitAsync();
            return await ReceiveById(id);

        }

        public async Task<Order> ChangeValueById(int id, object value, string propName)
        {
            await _unitOfWork.Orders.UpdateValueByIdAsync(id, value, propName);
            await _unitOfWork.CommitAsync();
            return await ReceiveById(id);
        }
    }
}
