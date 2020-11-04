using System.Collections.Generic;
using AutoShop.Data.Interfaces;
using AutoShop.Models;

namespace AutoShop.Data.Repository
{
    public class CategoryRepository : ICarsCategory
    {
        private readonly AutoShopDbContext autoShopDbContext;

        public CategoryRepository(AutoShopDbContext autoShopDbContext)
        {
            this.autoShopDbContext = autoShopDbContext;
        }

        public IEnumerable<Category> AllCategories => autoShopDbContext.Category;
    }
}
