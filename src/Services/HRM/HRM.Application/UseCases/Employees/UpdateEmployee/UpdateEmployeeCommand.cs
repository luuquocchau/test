using FluentResults;
using HRM.Application.Abstractions.CQRS;

namespace HRM.Application.UseCases.Employees.UpdateEmployee;

public sealed record UpdateEmployeeCommand(int Id,
    string FullName,
    DateTime DateOfBirth,
    string Title,
    string? Description,
    int OrganizationId) : ICommand<Result<bool>>;
