using BuildingBlocks.SharedKernel;
using FluentResults;
using HRM.Domain.Organizations;

namespace HRM.Domain.Employees;

public sealed class Employee : AggregateRoot<int>
{
    public string FullName { get; private set; }

    public DateTime DateOfBirth { get; private set; }

    public string Title { get; private set; }

    public string? Description { get; private set; }

    public int OrganizationId { get; private set; }

    public Organization Organization { get; private set; }

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

    public static Result<Employee> Create(
        string fullName,
        DateTime dateOfBirth,
        string title,
        string? description,
        int organizationId)
    {
        var employee = new Employee(fullName, dateOfBirth, title, description, organizationId);
        return Result.Ok(employee);
    }

    public Result Update(string fullName,
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

        return Result.Ok();
    }
}
