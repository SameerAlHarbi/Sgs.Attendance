using System;

namespace Sgs.Attendance.Api.Models
{
    public class EmployeeInfoModel : ISameerApiViewModel
    {
        public string Url { get; set; }

        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public bool Exempted { get; set; }

        public DateTime? ExemptedDate { get; set; }

        public string ExemptedResone { get; set; }

        public string Note { get; set; }
    }
}
