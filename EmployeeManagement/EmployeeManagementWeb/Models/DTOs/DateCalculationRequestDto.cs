using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManagementWeb.Models.DTOs
{
    public class DateCalculationRequestDto
    {
        public string FromDate {  get; set; }
        public string ToDate { get; set; }
    }
}