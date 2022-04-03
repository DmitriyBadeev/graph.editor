namespace Graph.Api.Mappings;

public static class ServicesCollectionExtension
{
    public static IServiceCollection AddMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(EntitiesToDtoProfile));
        return services;
    }
}