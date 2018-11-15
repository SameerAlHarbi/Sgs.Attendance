using Sameer.Shared.Data;
using Sgs.Attendance.Model;

namespace Sgs.Attendance.BusinessLogic
{
    public class AttendanceSystemsManager : GeneralManager<AttendanceSystem>
    {
        public AttendanceSystemsManager(IRepository repo) : base(repo)
        {
        }
    }
}
