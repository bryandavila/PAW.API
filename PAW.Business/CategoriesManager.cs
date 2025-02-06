using PAW.Models;
using System.Collections.Generic;

namespace PAW.Business
{
    public interface ICategoriesManager
    {
        IEnumerable<Categories> GetCategories();
    }

    public class CategoriesManager : ICategoriesManager
    {
        public IEnumerable<Categories> GetCategories()
        {
            var categories = new List<Categories>();
            for (var i = 0; i < 10; i++)
            {
                categories.Add(new Categories
                {
                    CategoryId = i,
                    CategoryName = $"CAT-001 {i}",
                    Description = $"La mejor categoria {i}"
                });
            }

            return categories;
        }
    }
}