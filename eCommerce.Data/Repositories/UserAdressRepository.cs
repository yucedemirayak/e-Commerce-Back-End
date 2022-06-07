using eCommerce.Core.Models;
using eCommerce.Core.Repositories;

namespace eCommerce.Data.Repositories
{
    public class UserAdressRepository : Repository<UserAdress>, IUserAdressRepository
    {
        public UserAdressRepository(eCommerceDbContext context) : base(context)
        {
        }
    }
}
