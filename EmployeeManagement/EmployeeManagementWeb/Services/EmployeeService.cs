using EmployeeManagementService.Database;
using EmployeeManagementService.Repository.Interface;
using EmployeeManagementWeb.Models.DTOs;
using EmployeeManagementWeb.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
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

        //get all employee list
        public IEnumerable<EmployeeDto> GetAllEmployee()
        {
            try
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
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", "An error occurred: " + ex.Message, EventLogEntryType.Error);
            }
            return null;
        }

        //Get employee details by employee id
        public EmployeeDto GetEmployeeById(int id) {

            try
            {
                var employee = employeeRepository.GetById(id);
                //map domain model to dto
                if (employee != null)
                {
                    return new EmployeeDto()
                    {
                        Id = employee.Id,
                        Name = employee.Name,
                        Email = employee.Email,
                        Designation = employee.Designation
                    };
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", "An error occurred: " + ex.Message, EventLogEntryType.Error);
            }
            return null;
        }

        //Create new employee
        public EmployeeDto CreateEmployee(EmployeeDto employeeDto)
        {
            try
            {
                //map dto object to domain model
                var employee = new Employee()
                {
                    Name = employeeDto.Name,
                    Email = employeeDto.Email,
                    Designation = employeeDto.Designation,
                    CreatedDateTime = DateTime.Now,
                };
                employee = employeeRepository.Create(employee);
                if (employee != null)
                {
                    employeeDto.Id = employee.Id;
                }
                return employeeDto;
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", "An error occurred: " + ex.Message, EventLogEntryType.Error);
            }
            return null;
        }

        //Update Employee record
        public EmployeeDto UpdateEmployee(EmployeeDto employeeDto)
        {
            try
            {
                //map dto object to domain model
                var employee = new Employee()
                {
                    Id = employeeDto.Id,
                    Name = employeeDto.Name,
                    Email = employeeDto.Email,
                    Designation = employeeDto.Designation,
                };

                employee = employeeRepository.Update(employee);
                if (employee != null)
                {
                    return employeeDto;
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", "An error occurred: " + ex.Message, EventLogEntryType.Error);
            }
            return null;
        }

        //Delete employee
        public EmployeeDto DeleteEmployee(int id)
        {
            try
            {
                var employee = employeeRepository.Delete(id);
                if (employee != null)
                {
                    return new EmployeeDto()
                    {
                        Id = employee.Id,
                        Name = employee.Name,
                        Email = employee.Email,
                        Designation = employee.Designation
                    };
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", "An error occurred: " + ex.Message, EventLogEntryType.Error);
            }
            return null;
        }
    }
}