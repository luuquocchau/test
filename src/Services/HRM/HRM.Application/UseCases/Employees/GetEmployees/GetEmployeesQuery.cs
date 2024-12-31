using HRM.Application.Abstractions.CQRS;

namespace HRM.Application.UseCases.Employees.GetEmployees;

public sealed record GetEmployeesQuery() : IQuery<List<EmployeeResponse>>;

public record EmployeeResponse(int Id, 
    string FullName, 
    DateTime DateOfBirth,
    string Title, 
    string? Description, 
    int OrganizationId,
    int? ParentOrganizationId,
    string? OrganizationName);
