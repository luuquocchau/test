using Carter;
using HRM.Application.UseCases.Employees.UpdateEmployee;
using Mapster;
using MediatR;

namespace HRM.API.Endpoints.Employees;

public sealed record UpdateEmployeeRequest(int Id,
    string FullName,
    DateTime DateOfBirth,
    string Title,
    string? Description,
    int OrganizationId);

public class UpdateEmployeeEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/api/employees",
            async (UpdateEmployeeRequest request, ISender sender) =>
        {
            var command = request.Adapt<UpdateEmployeeCommand>();

            var result = await sender.Send(command);

            return Results.Ok(result.Value);
        })
        .WithName("UpdateEmployees")
        .Produces(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .ProducesProblem(StatusCodes.Status500InternalServerError);
    }
}
