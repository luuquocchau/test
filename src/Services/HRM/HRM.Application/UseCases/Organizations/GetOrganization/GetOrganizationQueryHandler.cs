using FluentResults;
using HRM.Application.Abstractions.CQRS;
using HRM.Domain.Organizations;

namespace HRM.Application.UseCases.Organizations.GetOrganization;

internal sealed class GetOrganizationQueryHandler(IOrganizationRepository organizationRepository)
    : IQueryHandler<GetOrganizationQuery, Result<OrganizationDto>>
{
    public async Task<Result<OrganizationDto>> Handle(GetOrganizationQuery query, CancellationToken cancellationToken)
    {
        var organization = await organizationRepository.GetByIdAsync(query.Id, cancellationToken);

        if (organization == null)
            return Result.Fail(new Error($"The organization with the id '{query.Id}' was not found"));

        var organizationDto = new OrganizationDto(organization.Id,
            organization.Name,
            organization.Location,
            organization.IsActive,
            organization.Description,
            organization.ParentId
        );

        return Result.Ok(organizationDto);
    }
}
