using System.Linq;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Domain.Products.Queries.GetProducts.Services;

namespace Application.Features.GetProducts.Queries
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<GetProductsQuery.Product>>
    {
        private readonly IGetProductsService getProductsService;

        public GetProductsQueryHandler(IGetProductsService getProductsService)
        {
            this.getProductsService = getProductsService ?? throw new System.ArgumentNullException(nameof(getProductsService));
        }

        public async Task<IEnumerable<GetProductsQuery.Product>> Handle(
            GetProductsQuery request,
            CancellationToken cancellationToken) =>
            (await getProductsService.GetByAsync(new IGetProductsService.SearchParams(
                    request.Term,
                    new(request.PageNumber, request.PageSize),
                    new(request.Asc, request.OrderBy))))
                .Select(p =>
                    new GetProductsQuery.Product
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Price = p.Price,
                        Description = p.Description,
                    });
    }
}
