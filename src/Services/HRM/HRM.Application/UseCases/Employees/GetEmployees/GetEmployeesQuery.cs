using FluentResults;
using HRM.Application.Abstractions.CQRS;

namespace HRM.Application.UseCases.Employees.GetEmployees;

public sealed record GetEmployeesQuery() : IQuery<Result<List<EmployeeDto>>>;
