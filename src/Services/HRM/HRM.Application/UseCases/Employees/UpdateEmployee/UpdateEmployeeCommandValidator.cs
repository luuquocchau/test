using FluentValidation;

namespace HRM.Application.UseCases.Employees.UpdateEmployee;

internal sealed class UpdateEmployeeCommandValidator : AbstractValidator<UpdateEmployeeCommand>
{
    public UpdateEmployeeCommandValidator()
    {
        RuleFor(e => e.Id).NotEmpty();
        RuleFor(e => e.FullName).NotEmpty().MaximumLength(256);
        RuleFor(e => e.DateOfBirth).NotEmpty();
        RuleFor(e => e.Title).NotEmpty().MaximumLength(256);
        RuleFor(e => e.Description).MaximumLength(256);
    }
}
