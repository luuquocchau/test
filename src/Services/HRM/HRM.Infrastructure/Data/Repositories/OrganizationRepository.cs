using Microsoft.EntityFrameworkCore;
using HRM.Domain.Organizations;

namespace HRM.Infrastructure.Data.Repositories;

internal sealed class OrganizationRepository : Repository<Organization, int>, IOrganizationRepository
{
    public OrganizationRepository(HRMDbContext dbContext) : base(dbContext)
    {
    }
}
