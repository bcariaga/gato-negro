using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Products.Queries.GetProducts.Services
{
    public interface IGetProductsService
    {
        Task<IEnumerable<Product>> GetByAsync(string term);
    }
}
