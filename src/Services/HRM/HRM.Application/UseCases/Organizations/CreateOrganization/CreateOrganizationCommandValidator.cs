using FluentValidation;

namespace HRM.Application.UseCases.Organizations.CreateOrganization;

internal sealed class CreateOrganizationCommandValidator : AbstractValidator<CreateOrganizationCommand>
{
    public CreateOrganizationCommandValidator()
    {
        RuleFor(e => e.Name).NotEmpty().MaximumLength(256);
        RuleFor(e => e.Location).NotEmpty().MaximumLength(256);
        RuleFor(e => e.Description).MaximumLength(256);
    }
}
