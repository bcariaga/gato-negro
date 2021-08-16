using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.SeedWork;

namespace Domain.Products.Queries.GetProducts.Services
{
    public interface IGetProductsService
    {
        Task<IEnumerable<Product>> GetByAsync(SearchParams searchParams);

        public record SearchParams(string Term, Page Page, Order Order);
    }
}