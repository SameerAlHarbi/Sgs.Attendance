using Sameer.Shared.Data;
using Sgs.Attendance.Model;

namespace Sgs.Attendance.BusinessLogic
{
    public class WorkShiftsSystemsManager : GeneralManager<WorkShiftsSystem>
    {
        public WorkShiftsSystemsManager(IRepository repo) : base(repo)
        {
        }
    }
}
