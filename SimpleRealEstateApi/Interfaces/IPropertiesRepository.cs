﻿using SimpleRealEstateApi.Models;

namespace SimpleRealEstateApi.Interfaces
{
    public interface IPropertiesRepository
    {
        ICollection<Property> GetProperties();
        Property GetProperty(int id);
        Property GetPropertyByCategory(int categoryId);
        ICollection<Property> GetTrendingProperties();
        ICollection<Property> GetSearchProperties(string address);
        Property CreateProperty(Property property);
        Property UpdateProperty(Property property);
        bool DeleteProperty(int id);
    }
}