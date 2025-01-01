using FluentValidation;

namespace HRM.Application.UseCases.Organizations.DeleteOrganization;

internal sealed class DeleteOrganizationCommandValidator : AbstractValidator<DeleteOrganizationCommand>
{
    public DeleteOrganizationCommandValidator()
    {
        RuleFor(e => e.Id).GreaterThan(0);
    }
}
