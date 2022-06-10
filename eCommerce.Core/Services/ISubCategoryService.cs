using eCommerce.Core.Models;

namespace eCommerce.Core.Services
{
    public interface ISubCategoryService : IBaseService<SubCategory>
    {
        Task<SubCategory> Create(SubCategory entity);
    }
}
