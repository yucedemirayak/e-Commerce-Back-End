using eCommerce.Core;
using eCommerce.Core.Models;
using eCommerce.Core.Services;
using System.Linq.Expressions;

namespace eCommerce.Services
{
    public class ProductImageService : IProductImageService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductImageService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ProductImage> Create(ProductImage newProductImage)
        {
            await _unitOfWork.ProductImages.AddAsync(newProductImage);
            await _unitOfWork.CommitAsync();
            return newProductImage;
        }

        public async Task<ProductImage> DeleteById(int id)
        {
            var deletedProductImage = await ReceiveById(id);
            _unitOfWork.ProductImages.Remove(deletedProductImage);
            await _unitOfWork.CommitAsync();
            return deletedProductImage;
        }

        public async Task<IEnumerable<ProductImage>> ReceiveAll()
        {
            return await _unitOfWork.ProductImages.GetAllAsync();
        }

        public async Task<ProductImage> ReceiveById(int id)
        {
            return await _unitOfWork.ProductImages.GetByIdAsync(id);
        }

        public async Task<ProductImage> ChangeById(int id, ProductImage updatedProductImage)
        {
            await _unitOfWork.ProductImages.UpdateByIdAsync(id, updatedProductImage);
            await _unitOfWork.CommitAsync();
            return await ReceiveById(id);

        }

        public async Task<ProductImage> ChangeValueById(int id, object value, string propName)
        {
            await _unitOfWork.ProductImages.UpdateValueByIdAsync(id, value, propName);
            await _unitOfWork.CommitAsync();
            return await ReceiveById(id);
        }
    }
}
