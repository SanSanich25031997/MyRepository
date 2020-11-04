using System.Collections.Generic;
using FoodDelivery.Models;
using FoodDelivery.Data.Interfaces;

namespace FoodDelivery.Data.Repositories
{
    public class CompanyRepository : IAllCompanies
    {
        private readonly FoodDeliveryDbContext foodDeliveryDbContext;
        
        public CompanyRepository(FoodDeliveryDbContext foodDeliveryDbContext)
        {
            this.foodDeliveryDbContext = foodDeliveryDbContext;
        }

        public IEnumerable<Company> AllCompanies => foodDeliveryDbContext.Company;
    }
}
