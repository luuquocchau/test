using Carter;
using HRM.Application.UseCases.Organizations.UpdateOrganization;
using Mapster;
using MediatR;

namespace HRM.API.Endpoints.Organizations;

public sealed record UpdateOrganizationRequest(int Id,
    string Name,
    string Location,
    bool? IsActive,
    string? Description,
    int? ParentId);

public class UpdateOrganizationEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/api/organizations",
            async (UpdateOrganizationRequest request, ISender sender) =>
        {
            var command = request.Adapt<UpdateOrganizationCommand>();

            var result = await sender.Send(command);

            return Results.Ok(result.Value);
        })
        .WithName("UpdateOrganizations")
        .Produces(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .ProducesProblem(StatusCodes.Status500InternalServerError);
    }
}
