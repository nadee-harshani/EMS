using EmployeeManagementService.Database;
using EmployeeManagementService.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementService.Repository
{
    public class EmployeeRepository : IGenericRepository<Employee>
    {
        private readonly EMSDBEntities dbContext;

        public EmployeeRepository(EMSDBEntities dbContext)
        {
            //initialize db context
            this.dbContext = dbContext;
        }

        //Get All Active Employees
        public IEnumerable<Employee> GetAll()
        {
            try
            {
                var employees = dbContext.Employees.Where(x => x.DeletedDateTime == null).ToList();
                return employees;
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", "An error occurred: " + ex.Message, EventLogEntryType.Error);
            }
            return null;
        }

        //Create Employee
        public Employee Create(Employee employee)
        {
            try
            {
                dbContext.Employees.Add(employee);
                dbContext.SaveChanges();
                return employee;
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", "An error occurred: " + ex.Message, EventLogEntryType.Error);
            }
            return null;
        }

        //Get Employee By Id
        public Employee GetById(int id)
        {
            try
            {
                return dbContext.Employees.Find(id);
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", "An error occurred: " + ex.Message, EventLogEntryType.Error);
            }
            return null;

        }

        //Update Employee data
        public Employee Update(Employee employee)
        {
            try
            {
                var existingEmp = dbContext.Employees.Find(employee.Id);
                if (existingEmp != null)
                {
                    existingEmp.Name = employee.Name;
                    existingEmp.Email = employee.Email;
                    existingEmp.Designation = employee.Designation;

                    dbContext.SaveChanges();
                }
                return existingEmp;
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", "An error occurred: " + ex.Message, EventLogEntryType.Error);
            }
            return null;
        }

        //Delete Employee
        public Employee Delete(int id)
        {
            try
            {
                var existingEmp = dbContext.Employees.Find(id);
                if (existingEmp != null)
                {
                    existingEmp.DeletedDateTime = DateTime.Now;
                    dbContext.SaveChanges();
                }
                return existingEmp;
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", "An error occurred: " + ex.Message, EventLogEntryType.Error);
            }
            return null;
        }
    }
}
