using HRM.UI.Models;
using System.Net.Http;
using System.Threading;

namespace HRM.UI.Services
{
    public class EmployeeService
    {
        private readonly HttpClient _httpClient;

        public EmployeeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<EmployeeVM>> GetEmployeesAsync(CancellationToken cancellationToken = default)
        {
            List<EmployeeVM> organizations = await _httpClient.GetFromJsonAsync<List<EmployeeVM>>("/api/employees", cancellationToken);

            return organizations;
        }
    }
}
