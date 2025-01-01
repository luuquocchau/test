using FluentValidation;

namespace HRM.Application.UseCases.Employees.DeleteEmployee;

internal sealed class DeleteEmployeeCommandValidator : AbstractValidator<DeleteEmployeeCommand>
{
    public DeleteEmployeeCommandValidator()
    {
        RuleFor(e => e.Id).GreaterThan(0);
    }
}
