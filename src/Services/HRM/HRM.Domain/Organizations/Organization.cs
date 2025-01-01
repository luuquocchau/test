using BuildingBlocks.SharedKernel;
using FluentResults;
using HRM.Domain.Employees;
using HRM.Domain.Organizations.Rules;

namespace HRM.Domain.Organizations;

public sealed class Organization : AggregateRoot<int>
{
    public string Name { get; private set; }

    public string Location { get; private set; }

    public bool? IsActive { get; private set; }

    public string? Description { get; private set; }

    public int? ParentId { get; private set; }

    public Organization? Parent { get; private set; }

    public ICollection<Organization> Children { get; private set; } = new List<Organization>();

    public ICollection<Employee> Employees { get; private set; } = new List<Employee>();

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

    public static Result<Organization> Create(
        string name,
        string location,
        bool? isActive,
        string? description,
        int? parentId)
    {
        var organization = new Organization(name, location, isActive, description, parentId);
        return Result.Ok(organization);
    }

    public Result Update(string name,
        string location,
        bool? isActive,
        string? description,
        int? parentId,
        IOrganizationRepository organizationRepository)
    {
        CheckRule(new ParentOrganizationIdMustBeValidRule(Id, parentId, organizationRepository));
        //var result = Result.Merge(
        //    Result.FailIf(organizationRepository.CheckValidParentOrganizationId(Id, parentId), new Error("Parent Organization Id must be valid"))
        //);

        Name = name;
        Location = location;
        IsActive = isActive;
        Description = description;
        ParentId = parentId;

        return Result.Ok();
    }
}
