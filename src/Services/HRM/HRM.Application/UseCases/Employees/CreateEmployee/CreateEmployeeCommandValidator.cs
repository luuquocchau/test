using FluentValidation;

namespace HRM.Application.UseCases.Employees.CreateEmployee;

internal sealed class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
{
    public CreateEmployeeCommandValidator()
    {
        RuleFor(e => e.FullName).NotEmpty().MaximumLength(256);
        RuleFor(e => e.DateOfBirth).NotEmpty();
        RuleFor(e => e.Title).NotEmpty().MaximumLength(256);
        RuleFor(e => e.Description).MaximumLength(256);
        RuleFor(e => e.OrganizationId).NotEmpty();
    }
}
