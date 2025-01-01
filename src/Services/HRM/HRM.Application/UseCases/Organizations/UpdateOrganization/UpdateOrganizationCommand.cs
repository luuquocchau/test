using FluentResults;
using HRM.Application.Abstractions.CQRS;

namespace HRM.Application.UseCases.Organizations.UpdateOrganization;

public sealed record UpdateOrganizationCommand(int Id,
    string Name,
    string Location,
    bool? IsActive,
    string? Description,
    int? ParentId) : ICommand<Result<bool>>;
