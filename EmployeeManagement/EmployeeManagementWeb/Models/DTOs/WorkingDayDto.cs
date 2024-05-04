using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManagementWeb.Models.DTOs
{
    public class WorkingDayDto
    {
        public int NoOfWorkingDay { get; set; }
        public string Error { get; set; } = null;
    }
}