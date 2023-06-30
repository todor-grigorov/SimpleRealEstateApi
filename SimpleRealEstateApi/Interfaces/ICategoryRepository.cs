﻿using SimpleRealEstateApi.Models;

namespace SimpleRealEstateApi.Interfaces
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();
    }
}
