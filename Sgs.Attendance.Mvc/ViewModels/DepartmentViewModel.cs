using Sgs.Attendance.Mvc.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sgs.Attendance.Mvc.ViewModels
{
    public class DepartmentViewModel
    {
        public string Url { get; set; }

        public int Id { get; set; }

        [Required(ErrorMessage = "Code is Required !")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Please Code must be between {2} And {1} Charachters !")]
        public string Code { get; set; }

        public string Name { get; set; }

        public string ParentCode { get; set; }

        public string ParentName { get; set; }

        public int Depth { get; set; }

        public int ChildsCount { get; set; }

        public int? ManagerId { get; set; }

        public string ManagerName { get; set; }

        public AttendanceProof ManagerAttendanceProof { get; set; }

        public List<DepartmentViewModel> ChildDepartmentsList { get; set; }

        public DepartmentViewModel()
        {
            ChildDepartmentsList = new List<DepartmentViewModel>();
        }
    }
}
