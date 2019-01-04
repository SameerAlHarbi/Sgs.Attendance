using Sameer.Shared.Data;
using Sgs.Attendance.Model;

namespace Sgs.Attendance.BusinessLogic
{
    public class DevicesInfoManager : GeneralManager<DeviceInfo>
    {
        public DevicesInfoManager(IRepository repo) : base(repo)
        {
        }
    }
}
