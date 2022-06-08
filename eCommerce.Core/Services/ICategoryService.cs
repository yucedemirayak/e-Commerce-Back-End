﻿using eCommerce.Core.Models;

namespace eCommerce.Core.Services
{
    public interface ICategoryService : IService<Category>
    {
        Task<Category> CreateNew(Category entity);
    }
}