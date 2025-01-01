using Carter;
using HRM.Application.UseCases.Organizations.GetOrganization;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HRM.API.Endpoints.Organizations;

public class GetOrganizationEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/organizations/id/{id}",
            async (int id, ISender sender) =>
        {
            var query = new GetOrganizationQuery(id);

            var result = await sender.Send(query);

            return Results.Ok(result.Value);
        })
        .WithName("GetOrganization")
        .Produces(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .ProducesProblem(StatusCodes.Status500InternalServerError);
    }
}
