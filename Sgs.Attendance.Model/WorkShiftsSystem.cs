using Sameer.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sgs.Attendance.Model
{
    public class WorkShiftsSystem : ISameerObject
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="{0} is required !")]
        [Unique(ErrorMessage ="Code is already exist !")]
        [StringLength(4,MinimumLength = 4,ErrorMessage = "{0} must be of {1} characters !")]
        public string Code { get; set; }

        [Required(ErrorMessage = "{0} is required !")]
        [Unique(ErrorMessage = "Name is already exist !")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "{0} must be between {2} And {1} characters long !")]
        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public AttendanceProof AttendanceProof { get; set; }

        [Unique(UniqueValue = true,ErrorMessage ="Default WorkShiftsSystem is already exist !")]
        public bool IsDefaultWorkShiftsSystem { get; set; }

        public string Note { get; set; }

        public List<WorkShiftsSystemCycle> WorkShiftsSystemCycles { get; set; }

        public List<EmployeeWorkShiftsSystem> EmployeesInfo { get; set; }

        public List<WorkShiftsSystemCalendar> WorkShiftsCalendars { get; set; }

        public WorkShiftsSystem()
        {
            this.WorkShiftsSystemCycles = new List<WorkShiftsSystemCycle>();
            this.EmployeesInfo = new List<EmployeeWorkShiftsSystem>();
            this.WorkShiftsCalendars = new List<WorkShiftsSystemCalendar>();
        }
    }
}
