using HRM.Domain.Employees;
using HRM.Domain.Organizations;
using Microsoft.EntityFrameworkCore;

namespace HRM.Application.Abstractions.Data;

public interface IHRMDbContext
{
    DbSet<Organization> Organizations { get; }

    DbSet<Employee> Employees { get; }
}
