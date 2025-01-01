using Carter;
using HRM.Application.UseCases.Employees.CreateEmployee;
using Mapster;
using MediatR;

namespace HRM.API.Endpoints.Employees;

public sealed record CreateEmployeeRequest(string FullName,
    DateTime DateOfBirth,
    string Title,
    string? Description,
    int OrganizationId);

public class CreateEmployeeEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/employees",
            async (CreateEmployeeRequest request, ISender sender) =>
        {
            var command = request.Adapt<CreateEmployeeCommand>();

            var result = await sender.Send(command);

            return Results.Ok(result.Value);
        })
        .WithName("CreateEmployee")
        .Produces(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status500InternalServerError);
    }
}
