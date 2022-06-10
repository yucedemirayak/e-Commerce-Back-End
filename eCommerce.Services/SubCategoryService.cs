using eCommerce.Core;
using eCommerce.Core.Models;
using eCommerce.Core.Services;

namespace eCommerce.Services
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SubCategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<SubCategory> Create(SubCategory newSubCategory)
        {
            await _unitOfWork.SubCategories.AddAsync(newSubCategory);
            await _unitOfWork.CommitAsync();
            return newSubCategory;
        }

        public async Task<SubCategory> Delete(int id)
        {
            var deletedSubCategory = await GetById(id);
            _unitOfWork.SubCategories.Remove(deletedSubCategory);
            await _unitOfWork.CommitAsync();
            return deletedSubCategory;
        }

        public async Task<IEnumerable<SubCategory>> GetAll()
        {
            return await _unitOfWork.SubCategories.GetAllAsync();
        }

        public async Task<SubCategory> GetById(int id)
        {
            return await _unitOfWork.SubCategories.GetByIdAsync(id);
        }
    }
}
