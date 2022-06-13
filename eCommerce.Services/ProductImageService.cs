using eCommerce.Core;
using eCommerce.Core.Models;
using eCommerce.Core.Services;

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
            var deletedProductImage = await GetById(id);
            _unitOfWork.ProductImages.Remove(deletedProductImage);
            await _unitOfWork.CommitAsync();
            return deletedProductImage;
        }

        public async Task<IEnumerable<ProductImage>> GetAll()
        {
            return await _unitOfWork.ProductImages.GetAllAsync();
        }

        public async Task<ProductImage> GetById(int id)
        {
            return await _unitOfWork.ProductImages.GetByIdAsync(id);
        }

        public async Task<ProductImage> UpdateById(int id, ProductImage updatedProductImage)
        {
            return await _unitOfWork.ProductImages.UpdateByIdAsync(id, updatedProductImage);
        }
    }
}
