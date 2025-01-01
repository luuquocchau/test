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
    public class EmployeesController : Controller {

        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            var data = _employeeService.GetEmployees().Result;

            return DataSourceLoader.Load(data, loadOptions);
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values)
        {
            var employee = new EmployeeVM();
            JsonConvert.PopulateObject(values, employee);

            if (!TryValidateModel(employee))
                return BadRequest();

            await _employeeService.CreateEmployee(employee);
            
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(int key, string values)
        {
            var employee = await _employeeService.GetEmployee(key);
            if (employee == null)
                return NotFound();

            JsonConvert.PopulateObject(values, employee);

            if (!TryValidateModel(employee))
                return BadRequest();

            await _employeeService.UpdateEmployee(employee);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int key)
        {
            await _employeeService.DeleteEmployee(key);

            return Ok();
        }
    }
}