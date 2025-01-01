using FluentValidation;

namespace HRM.Application.UseCases.Organizations.UpdateOrganization;

internal sealed class UpdateOrganizationCommandValidator : AbstractValidator<UpdateOrganizationCommand>
{
    public UpdateOrganizationCommandValidator()
    {
        RuleFor(e => e.Id).NotEmpty();
        RuleFor(e => e.Name).NotEmpty().MaximumLength(256);
        RuleFor(e => e.Location).NotEmpty().MaximumLength(256);
        RuleFor(e => e.Description).MaximumLength(256);
    }
}
