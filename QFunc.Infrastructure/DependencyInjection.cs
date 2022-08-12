using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QFunc.Application.Common.Interfaces.Identity;
using QFunc.Application.Common.Interfaces.Persistence;
using QFunc.Application.Common.Interfaces.Services;
using QFunc.Infrastructure.Identity;
using QFunc.Infrastructure.Persistence;
using QFunc.Infrastructure.Services;

namespace QFunc.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddScoped<IUserRepository, UserRepository>();
        
        return services;
    }
}