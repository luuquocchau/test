using HRM.UI.Models;
using Refit;

namespace HRM.UI.Services
{
    public interface IOrganizationService
    {
        [Get("/api/organizations")]
        Task<List<OrganizationVM>> GetOrganizations();

        [Get("/api/organizations/id/{id}")]
        Task<OrganizationVM> GetOrganization(int id);

        [Post("/api/organizations")]
        Task<int> CreateOrganization(OrganizationVM organization);

        [Put("/api/organizations")]
        Task<bool> UpdateOrganization(OrganizationVM organization);

        [Delete("/api/organizations/id/{id}")]
        Task<bool> DeleteOrganization(int id);
    }
}