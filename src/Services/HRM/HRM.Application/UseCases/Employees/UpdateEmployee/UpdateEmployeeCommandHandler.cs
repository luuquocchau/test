using FluentResults;
using HRM.Application.Abstractions.CQRS;
using HRM.Application.Abstractions.Data;
using HRM.Domain.Employees;

namespace HRM.Application.UseCases.Employees.UpdateEmployee;

internal sealed class UpdateEmployeeCommandHandler(IEmployeeRepository employeeRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<UpdateEmployeeCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(UpdateEmployeeCommand command, CancellationToken cancellationToken)
    {
        var employee = await employeeRepository.GetByIdAsync(command.Id, cancellationToken);
        if (employee == null)
            return Result.Fail(new Error($"The employee with the id '{command.Id}' was not found"));

        var result = employee.Update(command.FullName,
            command.DateOfBirth,
            command.Title,
            command.Description,
            command.OrganizationId);

        if (result.IsFailed)
            return result;

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok(true);
    }
}
