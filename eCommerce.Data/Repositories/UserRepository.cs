
using eCommerce.Core.Models;
using eCommerce.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(eCommerceDbContext context) : base(context) { }
        public async Task<User> GetUserByEmail(string email)
        {
            return await Context.Users.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
