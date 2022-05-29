using eCommerce.Core.Repositories;

namespace eCommerce.Core
{
    public interface IUnitOfWork
    {
        IAdminRepository Admins { get; }
        IUserRepository Users { get; }
        Task<int> CommitAsync();
    }
}
