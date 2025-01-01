using Carter;
using HRM.Application.UseCases.Employees.GetEmployees;
using MediatR;

namespace HRM.API.Endpoints.Employees;

public class GetEmployeesEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/employees",
            async (ISender sender) =>
        {
            var query = new GetEmployeesQuery();

            var result = await sender.Send(query);

            return Results.Ok(result.Value);
        })
        .WithName("GetEmployees")
        .Produces(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .ProducesProblem(StatusCodes.Status500InternalServerError);
    }
}
