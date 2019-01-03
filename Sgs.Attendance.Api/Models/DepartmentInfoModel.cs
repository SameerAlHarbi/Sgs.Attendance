using System.ComponentModel.DataAnnotations;

namespace Sgs.Attendance.Api.Models
{
    public class DepartmentInfoModel : ISameerApiViewModel
    {
        public string Url { get; set; }

        public int Id { get; set; }

        [Required(ErrorMessage = "Code Required !")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Please Code must be between {2} And {1} Charachters !")]
        public string Code { get; set; }

        public bool ManagerExempted { get; set; }
    }
}
