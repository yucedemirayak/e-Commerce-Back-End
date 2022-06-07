﻿using eCommerce.Core.Models;
using eCommerce.Core.Repositories;

namespace eCommerce.Data.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(eCommerceDbContext context) : base(context)
        {
        }
    }
}
