using HRM.Application.Abstractions.Data;
using HRM.Domain.Employees;
using HRM.Domain.Organizations;
using Microsoft.EntityFrameworkCore;

namespace HRM.Infrastructure.Data;

public sealed class HRMDbContext : DbContext, IUnitOfWork, IHRMDbContext
{
    public HRMDbContext(DbContextOptions<HRMDbContext> options)
        : base(options)
    {

    }

    public DbSet<Organization> Organizations => Set<Organization>();

    public DbSet<Employee> Employees => Set<Employee>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(HRMDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
