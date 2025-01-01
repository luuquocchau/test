using Carter;
using HRM.Infrastructure.Data.Extensions;

namespace HRM.API;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();

        services.AddOpenApi();

        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen();

        services.AddCarter();

        return services;
    }

    public static WebApplication UseApiServices(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.MapOpenApi();

            app.InitialiseDatabaseAsync().GetAwaiter().GetResult();
        }

        //app.UseHttpsRedirection();

        //app.UseAuthentication();

        //app.UseAuthorization();

        app.MapControllers();

        app.MapCarter();

        return app;
    }
}
