using Microsoft.Extensions.DependencyInjection;
using MediatR;
using DineDeck.Application.Services.Authentication.Command;
using FluentResults;
using DineDeck.Application.Authentication.Common;
using DineDeck.Application.Common.Behaviors;
using FluentValidation;
using System.Reflection;

namespace DineDeck.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return services;
    }
}