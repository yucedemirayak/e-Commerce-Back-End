using eCommerce.Core.Models;

namespace eCommerce.Core.Services
{
    public interface ICategoryService : IBaseService<Category>
    {
        Task<Category> Create(Category entity);
    }
}
