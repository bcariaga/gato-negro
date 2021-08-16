using Autofac;
using Bootstrap.Modules.Infrastructure;
using Infrastructure.Features.GetProducts.Dtos;
using Infrastructure.Features.GetProducts.Repositories;
using Infrastructure.Features.GetProducts.Services;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Bootstrap.Modules.Products
{
    public class ProductsModule : Module
    {
        private readonly IConfiguration configuration;

        public ProductsModule(IConfiguration configuration)
        {
            this.configuration = configuration ?? throw new System.ArgumentNullException(nameof(configuration));
        }

        protected override void Load(ContainerBuilder builder)
        {
            _ = builder.RegisterType<GetProductsService>()
                .AsImplementedInterfaces();

            _ = builder.Register(ctx =>
                ctx.Resolve<IMongoDatabase>()
                    .GetCollection<ProductDto>(
                        configuration[$"{InfrastructureModule.DATABASE_CONFIG}:collectionNames:products"]));

            _ = builder.RegisterType<ProductsRepository>()
                .AsImplementedInterfaces();
        }
    }
}
