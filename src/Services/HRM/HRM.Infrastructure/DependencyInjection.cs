using HRM.Application.Abstractions.Data;
using HRM.Domain.Organizations;
using HRM.Infrastructure.Data;
using HRM.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using HRM.Domain.Employees;
using HRM.Application.UseCases.Employees.GetEmployees;

namespace HRM.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices
        (this IServiceCollection services, IConfiguration configuration)
    {
        AddPersistence(services, configuration);

        AddHealthChecks(services, configuration);

        return services;
    }

    private static void AddPersistence
        (IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("Database") ??
            throw new ArgumentNullException(nameof(configuration));

        services.AddDbContext<HRMDbContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
            options.UseSqlServer(connectionString);
        });

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<HRMDbContext>());

        services.AddScoped<IHRMDbContext>(sp => sp.GetRequiredService<HRMDbContext>());

        services.AddSingleton<ISqlConnectionFactory>(_ => new SqlConnectionFactory(connectionString));

        services.AddScoped<IOrganizationRepository, OrganizationRepository>();

        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
    }

    private static void AddHealthChecks
        (IServiceCollection services, IConfiguration configuration)
    {
        services.AddHealthChecks()
            .AddSqlServer(configuration.GetConnectionString("Database")!);
    }
}
