using eCommerce.Core;
using eCommerce.Core.Models;
using eCommerce.Core.Services;
using System.Linq.Expressions;

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
            var deletedOrderDetail = await ReceiveById(id);
            _unitOfWork.OrderDetails.Remove(deletedOrderDetail);
            await _unitOfWork.CommitAsync();
            return deletedOrderDetail;
        }

        public async Task<IEnumerable<OrderDetail>> ReceiveAll()
        {
            return await _unitOfWork.OrderDetails.GetAllAsync();
        }

        public async Task<OrderDetail> ReceiveById(int id)
        {
            return await _unitOfWork.OrderDetails.GetByIdAsync(id);
        }

        public async Task<OrderDetail> ChangeById(int id, OrderDetail updatedOrderDetail)
        {
            await _unitOfWork.OrderDetails.UpdateByIdAsync(id, updatedOrderDetail);
            await _unitOfWork.CommitAsync();
            return await ReceiveById(id);
        }

        public async Task<OrderDetail> ChangeValueById(int id, object value, string propName)
        {
            await _unitOfWork.OrderDetails.UpdateValueByIdAsync(id, value, propName);
            await _unitOfWork.CommitAsync();
            return await ReceiveById(id);
        }
    }
}
