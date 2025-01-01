using Carter;
using HRM.Application.UseCases.Employees.GetEmployee;
using MediatR;

namespace HRM.API.Endpoints.Employees;

public class GetEmployeeEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/employees/id/{id}",
            async (int id, ISender sender) =>
        {
            var query = new GetEmployeeQuery(id);

            var result = await sender.Send(query);

            return Results.Ok(result.Value);
        })
        .WithName("GetEmployee")
        .Produces(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .ProducesProblem(StatusCodes.Status500InternalServerError);
    }
}
