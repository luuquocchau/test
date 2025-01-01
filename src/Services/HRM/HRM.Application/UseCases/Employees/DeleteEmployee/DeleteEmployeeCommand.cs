using FluentResults;
using HRM.Application.Abstractions.CQRS;

namespace HRM.Application.UseCases.Employees.DeleteEmployee;

public sealed record DeleteEmployeeCommand(int Id) : ICommand<Result<bool>>;
