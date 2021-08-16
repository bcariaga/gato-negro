using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Features.GetProducts.Dtos;

namespace Infrastructure.Features.GetProducts.Repositories.Abstractions
{
    public interface IProductsRepository
    {
        public Task<IEnumerable<ProductDto>> Get(GetQuery getQuery);

        public record GetQuery(string Term, int PageNumber, int PageSize, string SortBy, bool Asc);
    }
}
