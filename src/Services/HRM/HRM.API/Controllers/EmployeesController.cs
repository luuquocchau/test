using HRM.Application.UseCases.Employees.GetEmployees;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

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

            var result = await _sender.Send(query, cancellationToken);

            return Ok(result.Value);
        }
    }
}
