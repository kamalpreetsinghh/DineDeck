using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using DineDeck.Application.Common.Interfaces.Authentication;
using DineDeck.Infrastructure.Authentication;
using DineDeck.Application.Common.Interfaces.Services;
using DineDeck.Infrastructure.Services;

namespace DineDeck.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton<IJWTTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        return services;
    }
}