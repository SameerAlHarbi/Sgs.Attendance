using System;

namespace Sgs.Attendance.Api.Models
{
    public class EmployeeWorkShiftsSystemModel : ISameerApiViewModel
    {
        public string Url { get; set; }

        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public int WorkShiftsSystemId { get; set; }

        public string WorkShiftsSystemCode { get; set; }

        public string WorkShiftsSystemName { get; set; }

        public DateTime StartDate { get; set; }

        public string Note { get; set; }
    }
}
