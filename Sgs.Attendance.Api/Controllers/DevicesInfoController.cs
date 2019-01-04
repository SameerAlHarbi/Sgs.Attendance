using AutoMapper;
using Microsoft.Extensions.Logging;
using Sgs.Attendance.Api.Models;
using Sgs.Attendance.BusinessLogic;
using Sgs.Attendance.Model;

namespace Sgs.Attendance.Api.Controllers
{
    public class DevicesInfoController : GeneralApiController<DeviceInfo, DeviceInfoModel>
    {
        public DevicesInfoController(DevicesInfoManager dataManager,
            IMapper mapper, ILogger<GeneralApiController<DeviceInfo, DeviceInfoModel>> logger) : base(dataManager, mapper, logger)
        {
        }
    }
}
