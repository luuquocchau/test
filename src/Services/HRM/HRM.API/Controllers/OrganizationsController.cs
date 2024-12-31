using HRM.Application.UseCases.Organizations.GetOrganizations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HRM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationsController : ControllerBase
    {
        private readonly ISender _sender;

        public OrganizationsController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrganizations(CancellationToken cancellationToken)
        {
            var query = new GetOrganizationsQuery();

            List<OrganizationResponse> result = await _sender.Send(query, cancellationToken);

            return Ok(result);
        }
    }
}
