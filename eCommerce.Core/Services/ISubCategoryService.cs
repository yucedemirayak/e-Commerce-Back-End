using eCommerce.Core.Models;

namespace eCommerce.Core.Services
{
    public interface ISubCategoryService : IService<SubCategory>
    {
        Task<SubCategory> CreateNew(SubCategory entity);
    }
}
