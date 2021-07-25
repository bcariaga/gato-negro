
using MediatR;
using System.Collections.Generic;

namespace Application.Features.GetProducts.Queries
{
    /// <summary>
    /// Find products by filters
    /// </summary>
    public class GetProductsQuery : IRequest<IEnumerable<GetProductsQuery.Product>>
    {
        public string Term { get; init; }

        /// <summary>
        /// Result of Query <see cref="GetProducts"/>
        /// </summary>
        public class Product
        {
            public string Id { get; init; }
            public string Name { get; init; }
            public decimal Price { get; init; } //TODO: format
            public string Description { get; init; }
        }
    }
}
