﻿using eCommerce.Core;
using eCommerce.Core.Models;
using eCommerce.Core.Services;

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

        public async Task<Product> Delete(int id)
        {
            var deletedProduct = await GetById(id);
            _unitOfWork.Products.Remove(deletedProduct);
            await _unitOfWork.CommitAsync();
            return deletedProduct;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _unitOfWork.Products.GetAllAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return await _unitOfWork.Products.GetByIdAsync(id);
        }
    }
}
