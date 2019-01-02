using Sameer.Shared;
using System.ComponentModel.DataAnnotations;

namespace Sgs.Attendance.Model
{
    public class WorkShiftsSystem : ISameerObject
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Code is required !")]
        [Unique(ErrorMessage ="Code is already exist !")]
        [StringLength(4,MinimumLength = 4,ErrorMessage = "Code must be of {1} characters !")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Name is required !")]
        [Unique(ErrorMessage = "Name is already exist !")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "Name must be between {2} And {1} characters long !")]
        public string Name { get; set; }

        public string Note { get; set; }
    }
}
