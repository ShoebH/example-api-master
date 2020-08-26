using ExampleDomain.Repositories;
using ExampleDomain.Services.Clients;
using Microsoft.Extensions.DependencyInjection;

namespace ExampleAPI.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddDependencies(this IServiceCollection serviceCollection)
        {
            //REPOSITORIES
            serviceCollection.AddTransient<IExampleRepository, ExampleRepository>();

            //SUPPORTING SERVICES
            serviceCollection.AddTransient<IExampleClient, ExampleClient>();
        }
    }
}
