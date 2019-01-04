using Sameer.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sgs.Attendance.Model
{
    public class EmployeeWorkShiftsSystem : ISameerObject,IValidatableObject
    {

        public int Id { get; set; }

        [MinimumValue(1, ErrorMessage = "Employee Id can't be less than 1")]
        [Unique(nameof(StartDate), ErrorMessage = "Employee is already assigned to work shifts system in this date !")]
        public int EmployeeInfoId { get; set; }

        public EmployeeInfo EmployeeInfo { get; set; }

        public int WorkShiftsSystemId { get; set; }

        public WorkShiftsSystem WorkShiftsSystem { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string Note { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var result = new List<ValidationResult>();

            if(this.EndDate.HasValue && this.StartDate > this.EndDate.Value)
            {
                result.Add(new ValidationResult("End date can't be before start date",new string[] { nameof(StartDate),nameof(EndDate)}));
            }

            return result;
        }
    }
}
