using eCommerce.Core.Models;
using eCommerce.Core.Repositories;

namespace eCommerce.Data.Repositories
{
    public class UserAdressRepository : RepositoryProvider<UserAdress>, IUserAdressRepository
    {
        public UserAdressRepository(eCommerceDbContext context) : base(context)
        {
        }
    }
}
