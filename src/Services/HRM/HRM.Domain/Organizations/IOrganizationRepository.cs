namespace HRM.Domain.Organizations;

public interface IOrganizationRepository
{
    Task<Organization?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    Task AddAsync(Organization organization, CancellationToken cancellationToken = default);

    void Remove(Organization organization);
}