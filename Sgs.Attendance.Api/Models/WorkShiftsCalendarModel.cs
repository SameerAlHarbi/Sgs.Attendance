using System;

namespace Sgs.Attendance.Api.Models
{
    public class WorkShiftsCalendarModel : ISameerApiViewModel
    {
        public string Url { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public AttendanceProof AttendanceProof { get; set; }

        public bool IsVacationCalendar { get; set; }

        public string VacationDescription { get; set; }

        public string Note { get; set; }
    }
}
