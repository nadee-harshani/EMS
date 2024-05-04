using EmployeeManagementService.Repository.Interface;
using EmployeeManagementWeb.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace EmployeeManagementWeb.Services
{

    public class WorkingDayCalculationService
    {
        private readonly IHolidayRepository holidayRepository;
        //define a deligate
        public delegate bool WeekendCheckerDelegate(DateTime date);

        public WorkingDayCalculationService(IHolidayRepository holidayRepository)
        {
            this.holidayRepository = holidayRepository;
        }

        //Get holidays form cache
        public List<string> GetHolidays()
        {
            //check the chach for getting holiday list
            var holidays = CacheManagementService.GetFromCache<List<string>>("holidays");
            if (holidays == null)
            {
                var holidayList = holidayRepository.GetAll().Select(x => x.HolidayDate.Date.ToString()).ToList();
                //add holiday list to memory for 30 mins
                CacheManagementService.AddToCache("holidays", holidayList, DateTimeOffset.Now.AddMinutes(30));
                holidays = CacheManagementService.GetFromCache<List<string>>("holidays");
            }
            return holidays;
        }

        //check date is holiday or not
        public bool IsHoliday(DateTime date)
        {
            var holidays = GetHolidays();
            return holidays.Any(x => x == date.Date.ToString());
        }

        //working day calculation for given two dates
        public WorkingDayDto CalculateWorkingDays(DateTime fromDate, DateTime toDate)
        {
            WorkingDayDto workingDay = new WorkingDayDto();
            try
            {
                int days = 0;
                //create reference for delegate
                WeekendCheckerDelegate weekendChecker = IsWeekend;
                var startDate = fromDate;
                //check start date is weekend
                if (weekendChecker(startDate))
                {
                    workingDay.Error = "From Date Should be a Week Day.";
                }
                else {
                    while (startDate <= toDate)
                    {
                        //check date is weekend or holiday
                        if (!weekendChecker(startDate) && !IsHoliday(startDate))
                        {
                            days++;
                        }
                        startDate = startDate.AddDays(1);
                    }
                    workingDay.NoOfWorkingDay = days;
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", "An error occurred: " + ex.Message, EventLogEntryType.Error);
                workingDay.Error = ex.Message;
            }
            return workingDay;
        }

        //check the date is weekend or not
        static bool IsWeekend(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
        }

    }
}