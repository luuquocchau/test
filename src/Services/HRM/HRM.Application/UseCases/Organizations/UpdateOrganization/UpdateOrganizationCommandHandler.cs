using FluentResults;
using HRM.Application.Abstractions.CQRS;
using HRM.Application.Abstractions.Data;
using HRM.Domain.Organizations;

namespace HRM.Application.UseCases.Organizations.UpdateOrganization;

internal sealed class UpdateOrganizationCommandHandler(IOrganizationRepository organizationRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<UpdateOrganizationCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(UpdateOrganizationCommand command, CancellationToken cancellationToken)
    {
        var organization = await organizationRepository.GetByIdAsync(command.Id, cancellationToken);
        if (organization == null)
            return Result.Fail(new Error($"The organization with the id '{command.Id}' was not found"));

        var result = organization.Update(command.Name,
            command.Location,
            command.IsActive,
            command.Description,
            command.ParentId,
            organizationRepository);

        if (result.IsFailed)
            return result;

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok(true);
    }
}
