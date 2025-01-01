namespace HRM.Application.UseCases.Organizations;

public record OrganizationDto(int Id, 
    string Name, 
    string Location, 
    bool? IsActive, 
    string? Description, 
    int? ParentId);
