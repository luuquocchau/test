using FluentResults;
using HRM.Application.Abstractions.CQRS;
using HRM.Application.Abstractions.Data;
using Microsoft.EntityFrameworkCore;

namespace HRM.Application.UseCases.Employees.GetEmployees;

internal sealed class GetEmployeesQueryHandler(IHRMDbContext hrmDbContext)
    : IQueryHandler<GetEmployeesQuery, Result<List<EmployeeDto>>>
{
    public async Task<Result<List<EmployeeDto>>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
    {
        var employees = await hrmDbContext.Employees.Include(p => p.Organization)
            .OrderBy(o => o.FullName)
            .Select(p => new EmployeeDto(
                p.Id,
                p.FullName,
                p.DateOfBirth,
                p.Title,
                p.Description,
                p.OrganizationId,
                p.Organization.ParentId,
                p.Organization.Name))
            .ToListAsync(cancellationToken);

        return Result.Ok(employees);
    }
}
