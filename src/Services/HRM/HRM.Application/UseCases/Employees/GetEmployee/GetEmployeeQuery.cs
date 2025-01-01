using FluentResults;
using HRM.Application.Abstractions.CQRS;

namespace HRM.Application.UseCases.Employees.GetEmployee;

public sealed record GetEmployeeQuery(int Id) : IQuery<Result<EmployeeDto>>;
