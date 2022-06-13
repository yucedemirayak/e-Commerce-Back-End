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
        public async Task<Category> Create(Category newCategory)
        {
            await _unitOfWork.Categories.AddAsync(newCategory);
            await _unitOfWork.CommitAsync();
            return newCategory;
        }

        public async Task<Category> DeleteById(int id)
        {
            var deletedCategory = await GetById(id);
            _unitOfWork.Categories.Remove(deletedCategory);
            await _unitOfWork.CommitAsync();
            return deletedCategory;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _unitOfWork.Categories.GetAllAsync();
        }

        public async Task<Category> GetById(int id)
        {
            return await _unitOfWork.Categories.GetByIdAsync(id);
        }

        public async Task<Category> UpdateById(int id, Category updatedCategory)
        {
            return await _unitOfWork.Categories.UpdateByIdAsync(id , updatedCategory);
        }
    }
}
