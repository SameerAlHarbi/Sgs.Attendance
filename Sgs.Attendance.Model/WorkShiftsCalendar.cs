using Sameer.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sgs.Attendance.Model
{
    public class WorkShiftsCalendar : ISameerObject, IValidatableObject, IComparable<WorkShiftsCalendar>
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Calendar name is required !")]
        [Unique(ErrorMessage ="Calendar name is already exist !")]
        [StringLength(100,ErrorMessage ="Calendar name can't be more than {1} characters !")]
        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public AttendanceProof AttendanceProof { get; set; }

        public bool IsVacationCalendar { get; set; }

        public string VacationDescription { get; set; }

        public string Note { get; set; }

        public List<WorkShiftsCalendarCycle> WorkShiftsCycles { get; set; }

        public List<EmployeeWorkShiftsCalendar> EmployeesCalendars { get; set; }

        public List<WorkShiftsSystemCalendar> WorkShiftsSystems { get; set; }

        public WorkShiftsCalendar()
        {
            this.WorkShiftsCycles = new List<WorkShiftsCalendarCycle>();
            this.EmployeesCalendars = new List<EmployeeWorkShiftsCalendar>();
            this.WorkShiftsSystems = new List<WorkShiftsSystemCalendar>();
        }

        public int CompareTo(WorkShiftsCalendar other)
        {
            return this.StartDate.CompareTo(other.StartDate);
        }

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (StartDate > EndDate)
            {
                results.Add(new ValidationResult("Calendar start date can't be after end date !", new string[] { "StartDate", "EndDate" }));
            }

            return results;
        }

    }
}
