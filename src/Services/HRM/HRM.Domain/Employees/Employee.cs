using BuildingBlocks.SharedKernel;
using HRM.Domain.Organizations;

namespace HRM.Domain.Employees;

public sealed class Employee : AggregateRoot<int>
{
    public string FullName { get; private set; }

    public DateTime DateOfBirth { get; private set; }

    public string Title { get; private set; }

    public string? Description { get; private set; }

    public int OrganizationId { get; set; }

    public Organization Organization { get; set; }

    private Employee()
    {
        // Only EF.
    }

    private Employee(
        string fullName,
        DateTime dateOfBirth,
        string title,
        string? description,
        int organizationId)
    {
        FullName = fullName;
        DateOfBirth = dateOfBirth;
        Title = title;
        Description = description;
        OrganizationId = organizationId;
    }

    public static Employee Create(
        string fullName,
        DateTime dateOfBirth,
        string title,
        string? description,
        int organizationId)
    {
        var employee = new Employee(fullName, dateOfBirth, title, description, organizationId);
        return employee;
    }

    public void Update(string fullName,
        DateTime dateOfBirth,
        string title,
        string? description,
        int organizationId)
    {
        FullName = fullName;
        DateOfBirth = dateOfBirth;
        Title = title;
        Description = description;
        OrganizationId = organizationId;
    }
}
