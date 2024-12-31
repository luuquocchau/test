using HRM.Application.UseCases.Employees.GetEmployees;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HRM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ISender _sender;

        public EmployeesController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees(CancellationToken cancellationToken)
        {
            var query = new GetEmployeesQuery();

            List<EmployeeResponse> result = await _sender.Send(query, cancellationToken);

            return Ok(result);
        }
    }
}
