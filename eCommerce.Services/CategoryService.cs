using eCommerce.Core;
using eCommerce.Core.Models;
using eCommerce.Core.Services;
using System.Linq.Expressions;

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
            var deletedCategory = await ReceiveById(id);
            _unitOfWork.Categories.Remove(deletedCategory);
            await _unitOfWork.CommitAsync();
            return deletedCategory;
        }

        public async Task<IEnumerable<Category>> ReceiveAll()
        {
            return await _unitOfWork.Categories.GetAllAsync();
        }

        public async Task<Category> ReceiveById(int id)
        {
            return await _unitOfWork.Categories.GetByIdAsync(id);
        }

        public async Task<Category> ChangeById(int id, Category updatedCategory)
        {
            await _unitOfWork.Categories.UpdateByIdAsync(id, updatedCategory);
            await _unitOfWork.CommitAsync();
            return await ReceiveById(id);
        }

        public async Task<Category> ChangeValueById(int id, object value, string propName)
        {
            await _unitOfWork.Categories.UpdateValueByIdAsync(id, value, propName);
            await _unitOfWork.CommitAsync();
            return await ReceiveById(id);
        }
    }
}
