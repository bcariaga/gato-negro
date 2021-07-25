using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Domain.Products.Queries.GetProducts;
using Domain.Products.Queries.GetProducts.Services;

namespace Infraestructure.Features.GetProducts
{
    public class GetProductsService : IGetProductsService
    {
        private readonly List<Product> products = new()
        {
            new()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Book",
                Price = 10m,
                Description = "lorem Ipsum"
            },
            new()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Toy Car",
                Price = 101m,
                Description = "lorem Ipsum"
            },
            new()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Super Duper Article",
                Price = 105m,
                Description = "lorem Ipsum"
            }
        };

        /// <summary>
        /// Get the products
        /// </summary>
        /// <param name="term"> product name's contanins this term</param>
        /// <returns>products matching with the search filters</returns>
        public async Task<IEnumerable<Product>> GetByAsync(string term) =>
           string.IsNullOrEmpty(term) ? products : products.Where(p => p.Name.ToLowerInvariant().Contains(term.ToLowerInvariant()));
    }
}
