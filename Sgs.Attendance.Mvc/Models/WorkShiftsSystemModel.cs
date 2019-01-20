using Sameer.Shared;
using System;

namespace Sgs.Attendance.Mvc.Models
{
    public class WorkShiftsSystemModel : ISameerObject
    {
        public string Url { get; set; }

        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public bool IsDefaultWorkShiftsSystem { get; set; }

        public AttendanceProof AttendanceProof { get; set; }

        public string Note { get; set; }
    }
}
