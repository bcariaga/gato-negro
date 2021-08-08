using Autofac;
using Infrastructure.Features.GetProducts;

namespace Bootstrap.Modules.Products
{
    public class ProductsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            _ = builder.RegisterType<GetProductsService>()
                .AsImplementedInterfaces();
        }
    }
}
