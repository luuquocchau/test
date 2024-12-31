using Microsoft.EntityFrameworkCore;
using HRM.Domain.Employees;

namespace HRM.Infrastructure.Data.Repositories;

internal sealed class EmployeeRepository : Repository<Employee, int>, IEmployeeRepository
{
    public EmployeeRepository(HRMDbContext dbContext) : base(dbContext)
    {
    }
}
