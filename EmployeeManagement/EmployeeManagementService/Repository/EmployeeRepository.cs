using EmployeeManagementService.Database;
using EmployeeManagementService.Repository.Interface;
using System;
using System.Collections.Generic;
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
            var employees = dbContext.Employees.Where(x => x.DeletedDateTime==null).ToList();
            return employees;
        }

        //Create Employee
        public Employee Create(Employee employee)
        {
            dbContext.Employees.Add(employee);
            dbContext.SaveChanges();

            return employee;
        }

        //Get Employee By Id
        public Employee GetById(int id)
        {
            return dbContext.Employees.Find(id);
            
        }

        //Update Employee data
        public Employee Update(Employee employee)
        {
            var existingEmp = dbContext.Employees.Find(employee.Id);
            if (existingEmp != null)
            {
                existingEmp.Name = employee.Name;
                existingEmp.Email = employee.Email;
                existingEmp.Designation = employee.Designation;

                dbContext.SaveChanges();
                return employee;
            }
            return null;
        }

        //Delete Employee
        public Employee Delete(int id)
        {
            var existingEmp = dbContext.Employees.Find(id);
            if (existingEmp != null)
            {
                existingEmp.DeletedDateTime = DateTime.Now;
                dbContext.SaveChanges();
                return existingEmp;
            }
            return null;
        }
    }
}
