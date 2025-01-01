using Microsoft.EntityFrameworkCore;
using HRM.Domain.Organizations;

namespace HRM.Infrastructure.Data.Repositories;

internal sealed class OrganizationRepository : Repository<Organization, int>, IOrganizationRepository
{
    public OrganizationRepository(HRMDbContext dbContext) : base(dbContext)
    {
    }

    public bool CheckValidParentOrganizationId(int id, int? parentId)
    {
        bool isValid = true;
        if (parentId > 0 && id > 0)
        {
            var parent = DbContext.Organizations.Find(parentId);
            while (parent != null)
            {
                if (parent.Id == id)
                {
                    isValid = false;
                    break;
                }
                parent = parent.Parent;
            }
        }

        return isValid;
    }
}
