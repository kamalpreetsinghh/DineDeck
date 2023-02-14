using Microsoft.Extensions.DependencyInjection;
using DineDeck.Application.Services.Authentication;

namespace DineDeck.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services.AddScoped<IAuthenticationService, AuthenticationService>();
    }
}