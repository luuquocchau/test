using FluentResults;
using HRM.Application.Abstractions.CQRS;

namespace HRM.Application.UseCases.Organizations.GetOrganizations;

public sealed record GetOrganizationsQuery() : IQuery<Result<List<OrganizationDto>>>;
