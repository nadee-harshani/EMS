using EmployeeManagementWeb.Models.DTOs;
using EmployeeManagementWeb.Services;
using EmployeeManagementWeb.Services.Interfaces;
using System.Net;
using System.Web.Mvc;

namespace EmployeeManagementWeb.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}
