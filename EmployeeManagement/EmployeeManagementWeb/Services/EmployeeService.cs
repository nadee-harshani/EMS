using EmployeeManagementService.Database;
using EmployeeManagementService.Repository.Interface;
using EmployeeManagementWeb.Models.DTOs;
using EmployeeManagementWeb.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManagementWeb.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IGenericRepository<Employee> employeeRepository;

        public EmployeeService(IGenericRepository<Employee> employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public IEnumerable<EmployeeDto> GetAllEmployee()
        {
            var employeeList = employeeRepository.GetAll();
            var employees = new List<EmployeeDto>();
            //map domain model to dto
            foreach (var employee in employeeList)
            {
                employees.Add(new EmployeeDto()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Email = employee.Email,
                    Designation = employee.Designation
                });
            }
            return employees;
        }

        public EmployeeDto GetEmployeeById(int id) {

            var employee = employeeRepository.GetById(id);
            //map domain model to dto
            if(employee != null) {
                return new EmployeeDto()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Email = employee.Email,
                    Designation = employee.Designation
                };
            }
            return null;
        }

        public EmployeeDto CreateEmployee(EmployeeDto employeeDto)
        {
            //map dto object to domain model
            var employee = new Employee()
            {
                Name = employeeDto.Name,
                Email = employeeDto.Email,
                Designation = employeeDto.Designation,
                CreatedDateTime = DateTime.Now,
            };

            employeeRepository.Create(employee);
            return employeeDto;
        }

        public EmployeeDto UpdateEmployee(EmployeeDto employeeDto)
        {
            //map dto object to domain model
            var employee = new Employee()
            {
                Id = employeeDto.Id,
                Name = employeeDto.Name,
                Email = employeeDto.Email,
                Designation = employeeDto.Designation,
            };

            employeeRepository.Update(employee);
            return employeeDto;
        }

        public EmployeeDto DeleteEmployee(int id)
        {
            var employee = employeeRepository.Delete(id);
            if(employee != null)
            {
                return new EmployeeDto()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Email = employee.Email,
                    Designation = employee.Designation
                };
            }
            return null;
        }
    }
}