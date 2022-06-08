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

        public async Task<SubCategory> CreateNew(SubCategory newSubCategory)
        {
            await _unitOfWork.SubCategories.AddAsync(newSubCategory);
            await _unitOfWork.CommitAsync();
            return newSubCategory;
        }
    }
}
