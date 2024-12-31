using HRM.Application.Abstractions.CQRS;

namespace HRM.Application.UseCases.Organizations.GetOrganizations;

public sealed record GetOrganizationsQuery() : IQuery<List<OrganizationResponse>>;

public record OrganizationResponse(int Id, 
    string Name, 
    string Location, 
    bool? IsActive, 
    string? Description, 
    int? ParentId);
