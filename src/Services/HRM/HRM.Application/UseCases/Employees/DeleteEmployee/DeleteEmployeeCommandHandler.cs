using FluentResults;
using HRM.Application.Abstractions.CQRS;
using HRM.Application.Abstractions.Data;
using HRM.Domain.Employees;

namespace HRM.Application.UseCases.Employees.DeleteEmployee;

internal sealed class DeleteEmployeeCommandHandler(IEmployeeRepository employeeRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<DeleteEmployeeCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(DeleteEmployeeCommand command, CancellationToken cancellationToken)
    {
        var employee = await employeeRepository.GetByIdAsync(command.Id, cancellationToken);
        if (employee == null)
            return Result.Fail(new Error($"The employee with the id '{command.Id}' was not found"));

        employeeRepository.Remove(employee);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok(true);
    }
}
