using EmployeeManagementWeb.Models;
using EmployeeManagementWeb.Models.DTOs;
using EmployeeManagementWeb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeManagementWeb.Controllers
{
    public class WorkingDayCalculationsController : ApiController
    {
        private readonly WorkingDayCalculationService calculationService;

        public WorkingDayCalculationsController(WorkingDayCalculationService calculationService)
        {
            this.calculationService = calculationService;
        }

        [ActionName("WorkingDayCalculation")]
        [HttpGet]
        public IHttpActionResult WorkingDayCalculation(string fromDate,string toDate)
        {
            var from = DateTime.Parse(fromDate);
            var to = DateTime.Parse(toDate);
            var result = calculationService.CalculateWorkingDays(from,to);
            return Ok(result);
        }
    }
}
