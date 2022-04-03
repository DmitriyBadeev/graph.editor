using Graph.Core.Interfaces.Repositories;
using Graph.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Graph.Infrastructure.Services;

public static class ServicesCollectionExtension
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddSingleton<IGraphRepository, InMemoryGraphRepository>();
        return services;
    }
}