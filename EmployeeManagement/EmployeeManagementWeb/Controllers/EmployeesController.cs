using EmployeeManagementWeb.Models.DTOs;
using EmployeeManagementWeb.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeManagementWeb.Controllers
{
    
    public class EmployeesController : ApiController
    {
        private readonly IEmployeeService employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        // GET: api/Employees
        [ActionName("GetAll")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Ok(employeeService.GetAllEmployee());
        }

        [Route("{id:int}")]
        [ActionName("GetEmployeeById")]
        [HttpGet]
        public IHttpActionResult GetEmployeeById(int id)
        {
            var employee = employeeService.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        // POST: api/Employees
        public IHttpActionResult PostEmployee([FromBody]EmployeeDto request)
        {
            var response =employeeService.CreateEmployee(request);
            return Ok(response);
        }

        // PUT: api/Employees/5
        public IHttpActionResult PutEmployee([FromBody]EmployeeDto request)
        {
            if (ModelState.IsValid)
            {
                var employee = employeeService.UpdateEmployee(request);
                if(employee == null)
                    return NotFound();
                return Ok(employee);
            }
            return BadRequest();
        }

        // DELETE: api/Employees/5
        public IHttpActionResult DeleteEmployee(int id)
        {
            var employee = employeeService.DeleteEmployee(id);
            if(employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }
    }
}
