using FluentResults;
using HRM.Application.Abstractions.CQRS;
using HRM.Application.Abstractions.Data;
using HRM.Domain.Organizations;

namespace HRM.Application.UseCases.Organizations.DeleteOrganization;

internal sealed class DeleteOrganizationCommandHandler(IOrganizationRepository organizationRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<DeleteOrganizationCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(DeleteOrganizationCommand command, CancellationToken cancellationToken)
    {
        var organization = await organizationRepository.GetByIdAsync(command.Id, cancellationToken);
        if (organization == null)
            return Result.Fail(new Error($"The organization with the id '{command.Id}' was not found"));

        organizationRepository.Remove(organization);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok(true);
    }
}
