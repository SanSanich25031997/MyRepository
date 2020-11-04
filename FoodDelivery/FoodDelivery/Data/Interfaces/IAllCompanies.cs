using System.Collections.Generic;
using FoodDelivery.Models;

namespace FoodDelivery.Data.Interfaces
{
    public interface IAllCompanies
    {
        IEnumerable<Company> AllCompanies { get; }
    }
}
