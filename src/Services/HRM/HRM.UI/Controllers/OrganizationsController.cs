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

namespace HRM_UI.Controllers {

    [Route("api/[controller]")]
    public class OrganizationsController : Controller {

        private readonly OrganizationService _organizationService;

        public OrganizationsController(OrganizationService organizationService)
        {
            _organizationService = organizationService;
        }

        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            var data = _organizationService.GetOrganizationsAsync().Result;

            return DataSourceLoader.Load(data, loadOptions);
        }

    }
}