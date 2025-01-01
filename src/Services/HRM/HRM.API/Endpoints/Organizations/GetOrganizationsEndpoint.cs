using Carter;
using HRM.Application.UseCases.Organizations.GetOrganizations;
using MediatR;

namespace HRM.API.Endpoints.Organizations;

public class GetOrganizationsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/organizations",
            async (ISender sender) =>
        {
            var query = new GetOrganizationsQuery();

            var result = await sender.Send(query);

            return Results.Ok(result.Value);
        })
        .WithName("GetOrganizations")
        .Produces(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .ProducesProblem(StatusCodes.Status500InternalServerError);
    }
}
