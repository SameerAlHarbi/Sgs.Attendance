using Sameer.Shared;

namespace Sgs.Attendance.Model
{
    public class EmployeeWorkShiftsCalendar : ISameerObject
    {
        public int Id { get; set; }

        [Unique(nameof(WorkShiftsCalendarId),ErrorMessage ="Employee is already added to this calendar !")]
        public int EmployeeInfoId { get; set; }

        public EmployeeInfo EmployeeInfo { get; set; }

        public int WorkShiftsCalendarId { get; set; }

        public WorkShiftsCalendar WorkShiftsCalendar { get; set; }

        public string Note { get; set; }
    }
}
