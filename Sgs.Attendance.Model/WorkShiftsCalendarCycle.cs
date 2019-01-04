namespace Sgs.Attendance.Model
{
    public class WorkShiftsCalendarCycle : WorkShiftCycle
    {
        public int WorkShiftsCalendarId { get; set; }

        public WorkShiftsCalendar WorkShiftsCalendar { get; set; }
    }
}
