using HRM.UI.Models;
using System.Net.Http;
using System.Threading;

namespace HRM.UI.Services
{
    public class OrganizationService
    {
        private readonly HttpClient _httpClient;

        public OrganizationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<OrganizationVM>> GetOrganizationsAsync(CancellationToken cancellationToken = default)
        {
            List<OrganizationVM> organizations = await _httpClient.GetFromJsonAsync<List<OrganizationVM>>("/api/organizations", cancellationToken);

            return organizations;
        }
    }
}
