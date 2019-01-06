using Sameer.Shared;
using System.ComponentModel.DataAnnotations;

namespace Sgs.Attendance.Model
{
    public class DepartmentInfo : ISameerObject
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Code Required !")]
        [Unique(ErrorMessage ="Code is already exist !")]
        [StringLength(20,MinimumLength =4,ErrorMessage ="Please Code must be between {2} And {1} Charachters !")]
        public string Code { get; set; }

        public AttendanceProof ManagerAttendanceProof { get; set; }

    }
}
