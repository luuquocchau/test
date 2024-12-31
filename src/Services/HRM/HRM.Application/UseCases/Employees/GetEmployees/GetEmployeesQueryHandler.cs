using HRM.Application.Abstractions.CQRS;
using HRM.Application.Abstractions.Data;
using Microsoft.EntityFrameworkCore;

namespace HRM.Application.UseCases.Employees.GetEmployees;

internal sealed class GetEmployeesQueryHandler(IHRMDbContext hrmDbContext)
    : IQueryHandler<GetEmployeesQuery, List<EmployeeResponse>>
{
    public async Task<List<EmployeeResponse>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
    {
        var employees = await hrmDbContext.Employees.Include(p => p.Organization)
            .OrderBy(o => o.FullName)
            .Select(p => new EmployeeResponse(
                p.Id,
                p.FullName,
                p.DateOfBirth,
                p.Title,
                p.Description,
                p.OrganizationId,
                p.Organization.ParentId,
                p.Organization.Name))
            .ToListAsync(cancellationToken);
        return employees;
    }
}
