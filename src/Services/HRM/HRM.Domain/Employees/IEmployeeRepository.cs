namespace HRM.Domain.Employees;

public interface IEmployeeRepository
{
    Task<Employee?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    Task AddAsync(Employee organization, CancellationToken cancellationToken = default);

    void Remove(Employee organization);
}