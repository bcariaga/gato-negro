using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Domain.Products.Queries.GetProducts;
using Domain.Products.Queries.GetProducts.Services;
using Infrastructure.Features.GetProducts.Dtos.Extensions;
using Infrastructure.Features.GetProducts.Repositories.Abstractions;

namespace Infrastructure.Features.GetProducts.Services
{
    public class GetProductsService : IGetProductsService
    {
        private readonly IProductsRepository productsRepository;
        public GetProductsService(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository ?? throw new ArgumentNullException(nameof(productsRepository));
        }

        public async Task<IEnumerable<Product>> GetByAsync(IGetProductsService.SearchParams searchParams)
        {
            (string term, (int pageNumber, int pageSize), (bool asc, string orderBy)) = searchParams;

            var productDtos = await productsRepository.Get(new IProductsRepository.GetQuery(
                term, pageNumber, pageSize, orderBy, asc
            ));

            return productDtos.ToDomain();
        }
    }
}
