using FluentResults;
using HRM.Application.Abstractions.CQRS;
using HRM.Application.Abstractions.Data;
using HRM.Domain.Organizations;

namespace HRM.Application.UseCases.Organizations.CreateOrganization;

internal sealed class CreateOrganizationCommandHandler(IOrganizationRepository organizationRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<CreateOrganizationCommand, Result<int>>
{
    public async Task<Result<int>> Handle(CreateOrganizationCommand command, CancellationToken cancellationToken)
    {
        var result = Organization.Create(command.Name,
            command.Location,
            command.IsActive,
            command.Description,
            command.ParentId);

        if(result.IsFailed)
            return result.ToResult();

        await organizationRepository.AddAsync(result.Value, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok(result.Value.Id);
    }
}
