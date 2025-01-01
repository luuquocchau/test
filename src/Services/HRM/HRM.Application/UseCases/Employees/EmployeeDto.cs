namespace HRM.Application.UseCases.Employees;

public record EmployeeDto(int Id, 
    string FullName, 
    DateTime DateOfBirth,
    string Title, 
    string? Description, 
    int OrganizationId,
    int? ParentOrganizationId,
    string? OrganizationName);
