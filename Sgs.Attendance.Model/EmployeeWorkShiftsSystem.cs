using Sameer.Shared;
using System;

namespace Sgs.Attendance.Model
{
    public class EmployeeWorkShiftsSystem : ISameerObject
    {
        public int Id { get; set; }

        [MinimumValue(1, ErrorMessage = "Employee Id can't be less than 1")]
        [Unique(nameof(StartDate), ErrorMessage = "Employee id already assigned to work shifts system in this date !")]
        public int EmployeeId { get; set; }

        public int WorkShiftsSystemId { get; set; }

        public WorkShiftsSystem WorkShiftsSystem { get; set; }

        public DateTime StartDate { get; set; }

        public string Note { get; set; }
    }
}
