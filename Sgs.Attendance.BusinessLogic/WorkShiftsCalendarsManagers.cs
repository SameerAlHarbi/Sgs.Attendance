using Sameer.Shared.Data;
using Sgs.Attendance.Model;

namespace Sgs.Attendance.BusinessLogic
{
    public class WorkShiftsCalendarsManagers : GeneralManager<WorkShiftsCalendar>
    {
        public WorkShiftsCalendarsManagers(IRepository repo) : base(repo)
        {
        }
    }
}
