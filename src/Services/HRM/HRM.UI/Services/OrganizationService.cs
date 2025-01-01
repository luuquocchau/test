using HRM.UI.Models;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
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

        public async Task<OrganizationVM> GetOrganizationAsync(int id, CancellationToken cancellationToken = default)
        {
            OrganizationVM organization = await _httpClient.GetFromJsonAsync<OrganizationVM>($"/api/organizations/id/{id}", cancellationToken);

            return organization;
        }

        public async Task<bool> CreateOrganizationAsync(OrganizationVM organization, CancellationToken cancellationToken = default)
        {
            string jsonData = JsonSerializer.Serialize(organization);

            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync("/api/organizations", content);

            response.EnsureSuccessStatusCode();

            return true;
        }

        public async Task<bool> UpdateOrganizationAsync(OrganizationVM organization, CancellationToken cancellationToken = default)
        {
            string jsonData = JsonSerializer.Serialize(organization);

            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PutAsync("/api/organizations", content);

            response.EnsureSuccessStatusCode();

            return true;
        }

        public async Task<bool> DeleteOrganizationAsync(int id, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"/api/organizations/id/{id}");

            response.EnsureSuccessStatusCode();

            return true;
        }
    }
}
