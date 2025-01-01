using HRM.UI.Models;
using Refit;

namespace HRM.UI.Services
{
    public interface IEmployeeService
    {
        [Get("/api/employees")]
        Task<List<EmployeeVM>> GetEmployees();

        [Get("/api/employees/id/{id}")]
        Task<EmployeeVM> GetEmployee(int id);

        [Post("/api/employees")]
        Task<int> CreateEmployee(EmployeeVM employee);

        [Put("/api/employees")]
        Task<bool> UpdateEmployee(EmployeeVM employee);

        [Delete("/api/employees/id/{id}")]
        Task<bool> DeleteEmployee(int id);
    }
}