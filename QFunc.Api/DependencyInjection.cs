using QFunc.Api.Common.Mapping;

namespace QFunc.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddMappings();
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        
        return services;
    }
}