using Sameer.Shared;

namespace Sgs.Attendance.Model
{
    public class WorkShiftsSystemCalendar : ISameerObject
    {
        public int Id{ get; set; }

        [Unique(nameof(WorkShiftsCalendarId),ErrorMessage ="Work shifts system already added to this calendar !")]
        public int WorkShiftsSystemId { get; set; }

        public WorkShiftsSystem WorkShiftsSystem { get; set; }

        public int WorkShiftsCalendarId {get; set; }

        public WorkShiftsCalendar WorkShiftsCalendar { get; set; }

        public string Note { get; set; }
    }
}
