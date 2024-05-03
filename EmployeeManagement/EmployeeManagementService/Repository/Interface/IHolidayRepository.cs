using EmployeeManagementService.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementService.Repository.Interface
{
    public interface IHolidayRepository
    {
        IEnumerable<Holiday> GetAll();
        bool IsHoliday(DateTime date);
    }
}
