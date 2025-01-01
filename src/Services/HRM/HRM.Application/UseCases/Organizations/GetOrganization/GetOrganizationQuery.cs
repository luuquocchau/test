using FluentResults;
using HRM.Application.Abstractions.CQRS;

namespace HRM.Application.UseCases.Organizations.GetOrganization;

public sealed record GetOrganizationQuery(int Id) : IQuery<Result<OrganizationDto>>;
