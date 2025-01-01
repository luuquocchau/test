using FluentResults;
using HRM.Application.Abstractions.CQRS;

namespace HRM.Application.UseCases.Organizations.DeleteOrganization;

public sealed record DeleteOrganizationCommand(int Id) : ICommand<Result<bool>>;
