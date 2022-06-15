using eCommerce.Core;
using eCommerce.Core.Models;
using eCommerce.Core.Services;
using System.Linq.Expressions;

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

        public async Task<SubCategory> DeleteById(int id)
        {
            var deletedSubCategory = await ReceiveById(id);
            _unitOfWork.SubCategories.Remove(deletedSubCategory);
            await _unitOfWork.CommitAsync();
            return deletedSubCategory;
        }

        public async Task<IEnumerable<SubCategory>> ReceiveAll()
        {
            return await _unitOfWork.SubCategories.GetAllAsync();
        }

        public async Task<SubCategory> ReceiveById(int id)
        {
            return await _unitOfWork.SubCategories.GetByIdAsync(id);
        }

        public async Task<SubCategory> ChangeById(int id, SubCategory updatedSubCategory)
        {
            await _unitOfWork.SubCategories.UpdateByIdAsync(id, updatedSubCategory);
            await _unitOfWork.CommitAsync();
            return await ReceiveById(id);
        }

        public async Task<SubCategory> ChangeValueById(int id, object value, string propName)
        {
            await _unitOfWork.SubCategories.UpdateValueByIdAsync(id, value, propName);
            await _unitOfWork.CommitAsync();
            return await ReceiveById(id);
        }
    }
}
