
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.GetProducts.Queries;
using Bogus;
using Domain.Products.Queries.GetProducts;
using Domain.Products.Queries.GetProducts.Services;
using Moq;
using Xunit;

namespace UnitTests.Application.Features.GetProducts.Queries
{
    public class GetProductsQueryHandlerTest
    {
        private readonly Mock<IGetProductsService> getProductsService;

        public GetProductsQueryHandlerTest()
        {
            getProductsService = new Mock<IGetProductsService>();
        }

        [Fact]
        public async Task Handle_Query_ReturnProducts()
        {
            //Arrange

            var productsCount = 10;

            var query = new GetProductsQuery
            {
                Asc = false,
                OrderBy = "price",
                PageSize = 12,
                Term = "pepe",
                PageNumber = 1
            };

            var products = new Faker<Product>()
                    .RuleFor(p => p.Id, f => f.Random.Hexadecimal(24))
                    .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                    .RuleFor(p => p.Price, f => f.Commerce.Random.Decimal(999.99m))
                    .RuleFor(p => p.Description, f => f.Commerce.ProductDescription())
                .Generate(productsCount);

            getProductsService
                .Setup(gps => gps.GetByAsync(It.IsAny<IGetProductsService.SearchParams>()))
                .ReturnsAsync(products);

            var handler = new GetProductsQueryHandler(getProductsService.Object);

            //Act
            var result = await handler.Handle(query, CancellationToken.None);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(productsCount, result.Count());

            getProductsService.Verify(gps => gps.GetByAsync(It.Is<IGetProductsService.SearchParams>(
                p => p.Term == query.Term &&
                p.Page.PageNumber == query.PageNumber &&
                p.Page.PageSize == query.PageSize &&
                p.Order.Asc == query.Asc &&
                p.Order.SortBy == query.OrderBy)),
                Times.Once);

        }
    }
}
