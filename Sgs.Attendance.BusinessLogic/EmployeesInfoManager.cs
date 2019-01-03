using Sameer.Shared.Data;
using Sgs.Attendance.Model;

namespace Sgs.Attendance.BusinessLogic
{
    public class EmployeesInfoManager : GeneralManager<EmployeeInfo>
    {
        public EmployeesInfoManager(IRepository repo) : base(repo)
        {
        }
    }
}
