using eCommerce.Core.Models;
using eCommerce.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(eCommerceDbContext context) : base(context) { }

    }
}
