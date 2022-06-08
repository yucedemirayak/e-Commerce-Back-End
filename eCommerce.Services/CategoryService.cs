using eCommerce.Core;
using eCommerce.Core.Models;
using eCommerce.Core.Services;

namespace eCommerce.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Category> CreateNew(Category newCategory)
        {
            await _unitOfWork.Categories.AddAsync(newCategory);
            await _unitOfWork.CommitAsync();
            return newCategory;
        }
    }
}
