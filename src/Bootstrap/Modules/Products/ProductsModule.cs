using Autofac;
using Infraestructure.Features.GetProducts;

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
