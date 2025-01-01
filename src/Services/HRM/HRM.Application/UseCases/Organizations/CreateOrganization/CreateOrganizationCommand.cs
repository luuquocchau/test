using FluentResults;
using HRM.Application.Abstractions.CQRS;

namespace HRM.Application.UseCases.Organizations.CreateOrganization;

public sealed record CreateOrganizationCommand(string Name,
    string Location,
    bool? IsActive,
    string? Description,
    int? ParentId) : ICommand<Result<int>>;
