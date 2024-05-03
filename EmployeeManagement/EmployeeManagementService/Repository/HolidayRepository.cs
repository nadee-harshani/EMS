using EmployeeManagementService.Database;
using EmployeeManagementService.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementService.Repository
{
    public class HolidayRepository : IHolidayRepository
    {
        private readonly EMSDBEntities dbContext;

        public HolidayRepository(EMSDBEntities dbContext)
        {
            this.dbContext = dbContext;
        }
        public IEnumerable<Holiday> GetAll()
        {
            return dbContext.Holidays.ToList();
        }

        public bool IsHoliday(DateTime date)
        {
            var holiday = dbContext.Holidays.Find(date.Date);
            return holiday != null;
        }
    }
}
