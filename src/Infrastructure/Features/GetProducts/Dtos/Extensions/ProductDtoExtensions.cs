using System.Collections.Generic;
using System;
using Domain.Products.Queries.GetProducts;
using System.Linq;

namespace Infrastructure.Features.GetProducts.Dtos.Extensions
{
    public static class ProductDtoExtensions
    {
        public static Product ToDomain(this ProductDto productDto) =>
            new()
            {
                Id = productDto.Id.ToString(),
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price
            };

        public static IEnumerable<Product> ToDomain(this IEnumerable<ProductDto> productDtos) =>
            productDtos.Select(ToDomain);
    }
}
