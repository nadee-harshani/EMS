using EmployeeManagementService.Database;
using EmployeeManagementService.Repository.Interface;
using EmployeeManagementService.Repository;
using EmployeeManagementWeb.Services.Interfaces;
using EmployeeManagementWeb.Services;
using System.Web.Http;
using System.Web.Mvc;
using Unity;
using Unity.WebApi;

namespace EmployeeManagementWeb
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // Register your interfaces and implementations
            container.RegisterType<EMSDBEntities>();
            container.RegisterType<IEmployeeService, EmployeeService>();
            container.RegisterType<IGenericRepository<Employee>, EmployeeRepository>();
            container.RegisterSingleton<IHolidayRepository, HolidayRepository>();
            container.RegisterType<WorkingDayCalculationService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));
        }
    }
}