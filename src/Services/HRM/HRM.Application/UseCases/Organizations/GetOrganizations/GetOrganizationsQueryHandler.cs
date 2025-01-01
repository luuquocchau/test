using FluentResults;
using HRM.Application.Abstractions.CQRS;
using HRM.Application.Abstractions.Data;
using Microsoft.EntityFrameworkCore;

namespace HRM.Application.UseCases.Organizations.GetOrganizations;

internal sealed class GetOrganizationsQueryHandler(IHRMDbContext hrmDbContext)
    : IQueryHandler<GetOrganizationsQuery, Result<List<OrganizationDto>>>
{
    public async Task<Result<List<OrganizationDto>>> Handle(GetOrganizationsQuery request, CancellationToken cancellationToken)
    {
        var organizations = await hrmDbContext.Organizations
            .OrderBy(o => o.Name)
            .Select(p => new OrganizationDto(p.Id,
                p.Name,
                p.Location,
                p.IsActive,
                p.Description,
                p.ParentId))
            .ToListAsync(cancellationToken);

        return Result.Ok(organizations);
    }
}
