using FluentResults;
using HRM.Application.Abstractions.CQRS;

namespace HRM.Application.UseCases.Employees.CreateEmployee;

public sealed record CreateEmployeeCommand(string FullName,
    DateTime DateOfBirth,
    string Title,
    string? Description,
    int OrganizationId
    ) : ICommand<Result<int>>;
