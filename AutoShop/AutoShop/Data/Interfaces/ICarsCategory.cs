using System.Collections.Generic;
using AutoShop.Models;

namespace AutoShop.Data.Interfaces
{
    public interface ICarsCategory
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
