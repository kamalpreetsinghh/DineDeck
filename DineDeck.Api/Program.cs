using DineDeck.Api.Filters;
using DineDeck.Api.Middleware;
using DineDeck.Application;
using DineDeck.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);
    builder.Services.AddControllers();
    // builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());
}

var app = builder.Build();
{
    // app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
