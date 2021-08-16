using System;
using Autofac;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Bootstrap.Modules.Infrastructure
{
    public class InfrastructureModule : Module
    {
        private readonly IConfiguration configuration;
        private const string DATABASE_NAME = "gato-negro";
        public const string DATABASE_CONFIG = "DbConfigs:" + DATABASE_NAME;

        public InfrastructureModule(IConfiguration configuration)
        {
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        protected override void Load(ContainerBuilder builder)
        {
            _ = builder
                .Register(ctx => new MongoClient(configuration.GetConnectionString(DATABASE_NAME)))
                .SingleInstance();

            _ = builder
                .Register(ctx =>
                     ctx.Resolve<MongoClient>()
                        .GetDatabase(configuration[$"{DATABASE_CONFIG}:database"]));
        }
    }
}
