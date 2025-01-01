using Carter;
using HRM.Application.UseCases.Employees.DeleteEmployee;
using MediatR;

namespace HRM.API.Endpoints.Employees;

public class DeleteEmployeeEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/api/employees/id/{id}",
            async (int id, ISender sender) =>
        {
            var command = new DeleteEmployeeCommand(id);

            var result = await sender.Send(command);

            return Results.Ok(result.Value);
        })
        .WithName("DeleteEmployee")
        .Produces(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status500InternalServerError);
    }
}
