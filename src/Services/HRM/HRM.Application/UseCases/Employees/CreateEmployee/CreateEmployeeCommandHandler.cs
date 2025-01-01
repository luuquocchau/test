using FluentResults;
using HRM.Application.Abstractions.CQRS;
using HRM.Application.Abstractions.Data;
using HRM.Domain.Employees;

namespace HRM.Application.UseCases.Employees.CreateEmployee;

internal sealed class CreateEmployeeCommandHandler(IEmployeeRepository employeeRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<CreateEmployeeCommand, Result<int>>
{
    public async Task<Result<int>> Handle(CreateEmployeeCommand command, CancellationToken cancellationToken)
    {
        var result = Employee.Create(command.FullName,
            command.DateOfBirth,
            command.Title,
            command.Description,
            command.OrganizationId);

        if(result.IsFailed)
            return result.ToResult();

        await employeeRepository.AddAsync(result.Value, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok(result.Value.Id);
    }
}
