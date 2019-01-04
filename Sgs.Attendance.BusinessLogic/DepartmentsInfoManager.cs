using Sameer.Shared.Data;
using Sgs.Attendance.Model;

namespace Sgs.Attendance.BusinessLogic
{
    public class DepartmentsInfoManager : GeneralManager<DepartmentInfo>
    {
        public DepartmentsInfoManager(IRepository repo) : base(repo)
        {
        }
    }
}
