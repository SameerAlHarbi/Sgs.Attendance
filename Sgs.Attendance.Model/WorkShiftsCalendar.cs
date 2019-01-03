using Sameer.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sgs.Attendance.Model
{
    public abstract class WorkShiftsCalendar : ISameerObject, IValidatableObject, IComparable<WorkShiftsCalendar>
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string Note { get; set; }

        public int CompareTo(WorkShiftsCalendar other)
        {
            return this.StartDate.Date.CompareTo(other.StartDate.Date);
        }

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (this.EndDate.HasValue && StartDate > EndDate.Value)
            {
                results.Add(new ValidationResult("Calendar start date can't be after end date !", new string[] { "StartDate", "EndDate" }));
            }

            return results;
        }
    }
}
