using Sameer.Shared;
using System.ComponentModel.DataAnnotations;

namespace Sgs.Attendance.Model
{
    public class AttendanceSystem : ISameerObject
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="{0} is required !")]
        [Unique(ErrorMessage ="Attendance system code is already exist !")]
        [StringLength(4,MinimumLength = 4,ErrorMessage = "{0} must be of {1} characters !")]
        [Display(Name = "Attendance system code")]
        public string Code { get; set; }

        [Required(ErrorMessage = "{0} is required !")]
        [Unique(ErrorMessage = "Attendance system name is already exist !")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "{0} must be between {2} And {1} characters long !")]
        [Display(Name = "Attendance system name")]
        public string Name { get; set; }

        public string Note { get; set; }
    }
}
