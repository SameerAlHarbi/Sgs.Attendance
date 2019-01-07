using Sameer.Shared;
using System.Collections.Generic;

namespace Sgs.Attendance.Mvc.Models
{
    public class DepartmentModel:ISameerObject
    {
        public string Url { get; set; }

        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string ParentCode { get; set; }

        public string ParentName { get; set; }

        public int Depth { get; set; }

        public int ChildsCount { get; set; }

        public int? ManagerId { get; set; }

        public string ManagerName { get; set; }

        public AttendanceProof ManagerAttendanceProof { get; set; }

        public List<DepartmentModel> ChildDepartmentsList { get; set; }

        public DepartmentModel()
        {
            ChildDepartmentsList = new List<DepartmentModel>();
        }
    }
}
