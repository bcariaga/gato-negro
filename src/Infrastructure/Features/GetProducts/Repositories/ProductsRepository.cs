using System;
using MongoDB.Driver;
using System.Threading.Tasks;
using System.Collections.Generic;
using Infrastructure.Features.GetProducts.Dtos;
using Infrastructure.Features.GetProducts.Repositories.Abstractions;

namespace Infrastructure.Features.GetProducts.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly IMongoCollection<ProductDto> collection;

        public ProductsRepository(IMongoCollection<ProductDto> collection)
        {
            this.collection = collection ?? throw new ArgumentNullException(nameof(collection));
        }

        public async Task<IEnumerable<ProductDto>> Get(IProductsRepository.GetQuery getQuery)
        {
            (string term, int pageNumber, int pageSize, string sortBy, bool asc) = getQuery;

            var findBuilder = new FilterDefinitionBuilder<ProductDto>();
            sortBy ??= nameof(ProductDto.Name); //"Name"
            var data = await collection.FindAsync(
                string.IsNullOrEmpty(term)
                    ? findBuilder.Empty
                    : findBuilder.Regex(p => p.Name, new MongoDB.Bson.BsonRegularExpression($".*{term}.*", "i")),
                    new FindOptions<ProductDto, ProductDto>
                    {
                        Sort = asc
                            ? Builders<ProductDto>.Sort.Ascending(sortBy)
                            : Builders<ProductDto>.Sort.Descending(sortBy),
                        Skip = (pageNumber - 1) * pageSize,
                        Limit = pageSize
                    });


            return await data.ToListAsync();
        }
    }
}
