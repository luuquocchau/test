using HRM.Application.Abstractions.CQRS;
using HRM.Application.Abstractions.Data;
using Microsoft.EntityFrameworkCore;

namespace HRM.Application.UseCases.Organizations.GetOrganizations;

internal sealed class GetOrganizationsQueryHandler(IHRMDbContext hrmDbContext)
    : IQueryHandler<GetOrganizationsQuery, List<OrganizationResponse>>
{
    public async Task<List<OrganizationResponse>> Handle(GetOrganizationsQuery request, CancellationToken cancellationToken)
    {
        var organizations = await hrmDbContext.Organizations
            .OrderBy(o => o.Name)
            .Select(p => new OrganizationResponse(p.Id, 
                p.Name, 
                p.Location, 
                p.IsActive, 
                p.Description, 
                p.ParentId))
            .ToListAsync(cancellationToken);
        return organizations;
    }
}
