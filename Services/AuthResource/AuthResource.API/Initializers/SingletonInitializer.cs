
using AuthResource.API.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BuildingBlocks.SeedWork;
using BuildingBlocks.Common.Events;
using AuthResource.Domain.Events;

namespace AuthResource.API.Initializers
{

    /**
     * Class that initializes singletons neccesary for DI
     */
    public class SingletonInitializer : IInitializer {

        public void InitializeServices(IServiceCollection services, IConfiguration configuration) {

            services.AddTransient<JwtGenerator>();
            services.AddTransient<IDatabaseContext, MongoDbContext>();
        }
    }
}
