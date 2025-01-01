using Carter;
using HRM.Application.UseCases.Organizations.DeleteOrganization;
using MediatR;

namespace HRM.API.Endpoints.Organizations;

public class DeleteOrganizationEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/api/organizations/id/{id}",
            async (int id, ISender sender) =>
        {
            var command = new DeleteOrganizationCommand(id);

            var result = await sender.Send(command);

            return Results.Ok(result.Value);
        })
        .WithName("DeleteOrganization")
        .Produces(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status500InternalServerError);
    }
}
