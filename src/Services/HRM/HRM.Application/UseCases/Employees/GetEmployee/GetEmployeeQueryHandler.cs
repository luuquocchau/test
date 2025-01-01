using FluentResults;
using HRM.Application.Abstractions.CQRS;
using HRM.Domain.Employees;

namespace HRM.Application.UseCases.Employees.GetEmployee;

internal sealed class GetEmployeeQueryHandler(IEmployeeRepository employeeRepository)
    : IQueryHandler<GetEmployeeQuery, Result<EmployeeDto>>
{
    public async Task<Result<EmployeeDto>> Handle(GetEmployeeQuery query, CancellationToken cancellationToken)
    {
        var employee = await employeeRepository.GetByIdAsync(query.Id, cancellationToken);

        if (employee == null)
            return Result.Fail(new Error($"The employee with the id '{query.Id}' was not found"));

        var employeeDto = new EmployeeDto(employee.Id,
            employee.FullName,
            employee.DateOfBirth,
            employee.Title,
            employee.Description,
            employee.OrganizationId,
            employee.Organization?.ParentId,
            employee.Organization?.Name
        );

        return Result.Ok(employeeDto);
    }
}
