using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using HRM_UI.Models;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using HRM.UI.Services;
using System.Xml.Linq;
using Newtonsoft.Json;
using HRM.UI.Models;

namespace HRM_UI.Controllers {

    [Route("api/[controller]")]
    public class OrganizationsController : Controller {

        private readonly IOrganizationService _organizationService;

        public OrganizationsController(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }

        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            var data = _organizationService.GetOrganizations().Result;

            return DataSourceLoader.Load(data, loadOptions);
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values)
        {
            var organization = new OrganizationVM();
            JsonConvert.PopulateObject(values, organization);

            if (!TryValidateModel(organization))
                return BadRequest();

            await _organizationService.CreateOrganization(organization);
            
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(int key, string values)
        {
            var organization = await _organizationService.GetOrganization(key);
            if (organization == null)
                return NotFound();

            JsonConvert.PopulateObject(values, organization);

            if (!TryValidateModel(organization))
                return BadRequest();

            await _organizationService.UpdateOrganization(organization);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int key)
        {
            await _organizationService.DeleteOrganization(key);

            return Ok();
        }
    }
}