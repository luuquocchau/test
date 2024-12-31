using BuildingBlocks.SharedKernel;
using HRM.Domain.Employees;

namespace HRM.Domain.Organizations;

public sealed class Organization : AggregateRoot<int>
{
    public string Name { get; private set; }

    public string Location { get; private set; }

    public bool? IsActive { get; private set; }

    public string? Description { get; private set; }

    public int? ParentId { get; set; }

    public Organization? Parent { get; set; }

    public ICollection<Organization> Children { get; set; } = new List<Organization>();

    public ICollection<Employee> Employees { get; set; } = new List<Employee>();

    private Organization()
    {
        // Only EF.
    }

    private Organization(
        string name,
        string location,
        bool? isActive,
        string? description,
        int? parentId)
    {
        Name = name;
        Location = location;
        IsActive = isActive;
        Description = description;
        ParentId = parentId;
    }

    public static Organization Create(
        string name,
        string location,
        bool? isActive,
        string? description,
        int? parentId)
    {
        var organization = new Organization(name, location, isActive, description, parentId);
        return organization;
    }

    public void Update(string name,
        string location,
        bool? isActive,
        string? description,
        int? parentId)
    {
        Name = name;
        Location = location;
        IsActive = isActive;
        Description = description;
        ParentId = parentId;
    }
}
