namespace Sgs.Attendance.Model
{
    public class WorkShiftsSystemCycle : WorkShiftCycle
    {
        public int WorkShiftsSystemId { get; set; }

        public WorkShiftsSystem WorkShiftsSystem { get; set; }
    }
}
