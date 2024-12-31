using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HRM.Infrastructure.Data.Extensions;

public static class DatabaseExtentions
{
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<HRMDbContext>();

        context.Database.MigrateAsync().GetAwaiter().GetResult();

        await SeedAsync(context, scope);
    }

    private static async Task SeedAsync(HRMDbContext context, IServiceScope scope)
    {
        await SeedOrganizationsAsync(context);
        await SeedEmployeesAsync(context);
    }

    private static async Task SeedOrganizationsAsync(HRMDbContext context)
    {
        if (!await context.Organizations.AnyAsync())
        {
            await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT dbo.Organizations ON");
            var data = InitialData.Organizations();
            await context.Organizations.AddRangeAsync(data);
            await context.SaveChangesAsync();
            await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT dbo.Organizations OFF");
        }
    }

    private static async Task SeedEmployeesAsync(HRMDbContext context)
    {
        if (!await context.Employees.AnyAsync())
        {
            await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT dbo.Employees ON");
            var data = InitialData.Employees();
            await context.Employees.AddRangeAsync(data);
            await context.SaveChangesAsync();
            await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT dbo.Employees OFF");
        }
    }
}
