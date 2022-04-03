using Graph.Core.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Graph.Core.Services;

public static class ServicesCollectionExtension
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        services.AddScoped<IGraphService, GraphService>();
        return services;
    }
}