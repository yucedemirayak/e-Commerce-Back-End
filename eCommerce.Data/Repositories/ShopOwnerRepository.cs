using eCommerce.Core.Models;
using eCommerce.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Data.Repositories
{
    public class ShopOwnerRepository : Repository<ShopOwner>, IShopOwnerRepository
    {
        public ShopOwnerRepository(eCommerceDbContext context) : base(context) { }
    }
}
