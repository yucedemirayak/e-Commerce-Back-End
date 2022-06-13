using eCommerce.Core.Models;
using eCommerce.Core.Repositories;

namespace eCommerce.Data.Repositories
{
    public class UserAdressRepository : BaseRepository<UserAdress>, IUserAdressRepository
    {
        public UserAdressRepository(eCommerceDbContext context) : base(context)
        {
        }
    }
}
