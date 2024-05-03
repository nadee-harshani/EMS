using EmployeeManagementService.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementService.Repository.Interface
{
    public interface IGenericRepository<T>
    {
        IEnumerable<T> GetAll();
        T Create(T entity);
        T GetById(int id);
        T Update(T  entity);
        T Delete(int id);
    }
}
