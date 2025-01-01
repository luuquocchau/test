using Carter;
using HRM.Application.UseCases.Organizations.CreateOrganization;
using Mapster;
using MediatR;

namespace HRM.API.Endpoints.Organizations;

public sealed record CreateOrganizationRequest(string Name,
    string Location,
    bool? IsActive,
    string? Description,
    int? ParentId);

public class CreateOrganizationEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/organizations",
            async (CreateOrganizationRequest request, ISender sender) =>
        {
            var command = request.Adapt<CreateOrganizationCommand>();

            var result = await sender.Send(command);

            return Results.Ok(result.Value);
        })
        .WithName("CreateOrganization")
        .Produces(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status500InternalServerError);
    }
}
