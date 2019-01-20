using System;
using System.ComponentModel.DataAnnotations;

namespace Sgs.Attendance.Api.Models
{
    public class WorkShiftsSystemModel : ISameerApiViewModel
    {
        public string Url { get; set; }

        public int Id { get; set; }

        [Required(ErrorMessage = "{0} is required !")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "{0} must be of {1} characters !")]
        public string Code { get; set; }

        [Required(ErrorMessage = "{0} is required !")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "{0} must be between {2} And {1} characters long !")]
        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public AttendanceProof AttendanceProof { get; set; }

        public bool IsDefaultWorkShiftsSystem { get; set; }

        public string Note { get; set; }
    }
}
