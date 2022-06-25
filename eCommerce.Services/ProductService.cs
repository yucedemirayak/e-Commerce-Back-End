using eCommerce.Core;
using eCommerce.Core.Models;
using eCommerce.Core.Services;
using System.Linq.Expressions;

namespace eCommerce.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Product> Create(Product newProduct)
        {
            await _unitOfWork.Products.AddAsync(newProduct);
            await _unitOfWork.CommitAsync();
            return newProduct;
        }

        public async Task<Product> DeleteById(int id)
        {
            var deletedProduct = await ReceiveById(id);
            _unitOfWork.Products.Remove(deletedProduct);
            await _unitOfWork.CommitAsync();
            return deletedProduct;
        }

        public async Task<IEnumerable<Product>> ReceiveAll()
        {
            return await _unitOfWork.Products.GetAllAsync();
        }

        public async Task<Product> ReceiveById(int id)
        {
            return await _unitOfWork.Products.GetByIdAsync(id);
        }

        public async Task<Product> ChangeById(int id, Product updatedProduct)
        {
            await _unitOfWork.Products.UpdateByIdAsync(id, updatedProduct);
            await _unitOfWork.CommitAsync();
            return await ReceiveById(id);
        }

        public async Task<Product> ChangeValueById(int id, object value, string propName)
        {
            await _unitOfWork.Products.UpdateValueByIdAsync(id, value, propName);
            await _unitOfWork.CommitAsync();
            return await ReceiveById(id);
        }

        public async Task<IEnumerable<Product>> ReceiveBatch(int count, int qty)
        {
            return await _unitOfWork.Products.GetBatch(count, qty);
        }
    }
}
