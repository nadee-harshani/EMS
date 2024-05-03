using EmployeeManagementService.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManagementWeb.Services
{

    public class WorkingDayCalculationService
    {
        private readonly IHolidayRepository holidayRepository;
        public delegate bool WeekendCheckerDelegate(DateTime date);

        public WorkingDayCalculationService(IHolidayRepository holidayRepository)
        {
            this.holidayRepository = holidayRepository;
        }


        public int CalculateWorkingDays(DateTime fromDate, DateTime toDate)
        {
            int days = 0;
            WeekendCheckerDelegate weekendChecker = IsWeekend;
            var startDate = fromDate;
            //check start date is weekend
            if (weekendChecker(startDate))
            {
                return -1;
            }

            while (startDate <= toDate)
            {
                if (!weekendChecker(startDate) && !holidayRepository.IsHoliday(startDate))
                {
                    days++;
                }
                startDate = startDate.AddDays(1);
            }
            return days;
        }

        static bool IsWeekend(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
        }

    }
}