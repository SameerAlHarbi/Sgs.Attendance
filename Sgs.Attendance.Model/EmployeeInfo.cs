using Sameer.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sgs.Attendance.Model
{
    public class EmployeeInfo : ISameerObject,IValidatableObject
    {
        public int Id { get; set; }

        [MinimumValue(1,ErrorMessage ="Employee Id can't be less than 1")]
        [Unique(ErrorMessage = "Employee id already assigned in this date !")]
        public int EmployeeId { get; set; }

        public bool Exempted { get; set; }

        public DateTime? ExemptedDate { get; set; }

        [MaxLength(100,ErrorMessage = "{0} can't be more than {1} characters !")]
        public string ExemptedResone { get; set; }

        public string Note { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var result = new List<ValidationResult>();

            if(this.Exempted)
            {
                if (string.IsNullOrWhiteSpace(ExemptedResone))
                {
                    result.Add(new ValidationResult($"{nameof(ExemptedResone)} is required !", new string[] { nameof(Exempted), nameof(ExemptedResone) })); 
                }
                if (!ExemptedDate.HasValue)
                {
                    result.Add(new ValidationResult($"{nameof(ExemptedDate)} is required !", new string[] { nameof(Exempted), nameof(ExemptedDate) }));
                }
            }

            return result;
        }

    }
}