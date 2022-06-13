using eCommerce.Core;
using eCommerce.Core.Models;
using eCommerce.Core.Services;

namespace eCommerce.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderDetailService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OrderDetail> Create(OrderDetail newOrderDetail)
        {
            await _unitOfWork.OrderDetails.AddAsync(newOrderDetail);
            await _unitOfWork.CommitAsync();
            return newOrderDetail;
        }

        public async Task<OrderDetail> DeleteById(int id)
        {
            var deletedOrderDetail = await GetById(id);
            _unitOfWork.OrderDetails.Remove(deletedOrderDetail);
            await _unitOfWork.CommitAsync();
            return deletedOrderDetail;
        }

        public async Task<IEnumerable<OrderDetail>> GetAll()
        {
            return await _unitOfWork.OrderDetails.GetAllAsync();
        }

        public async Task<OrderDetail> GetById(int id)
        {
            return await _unitOfWork.OrderDetails.GetByIdAsync(id);
        }

        public async Task<OrderDetail> UpdateById(int id, OrderDetail updatedOrderDetail)
        {
            return await _unitOfWork.OrderDetails.UpdateByIdAsync(id, updatedOrderDetail);
        }
    }
}
