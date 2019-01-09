using AutoMapper;
using Microsoft.Extensions.Logging;
using Sameer.Shared;
using Sgs.Attendance.Mvc.Models;
using Sgs.Attendance.Mvc.ViewModels;

namespace Sgs.Attendance.Mvc.Controllers
{
    public class DevicesInfoController : GeneralMvcController<DeviceInfoModel, DeviceInfoViewModel>
    {
        public DevicesInfoController(IDataManager<DeviceInfoModel> dataManager, IMapper mapper
            , ILogger<GeneralMvcController<DeviceInfoModel, DeviceInfoViewModel>> logger) : base(dataManager, mapper, logger)
        {
        }
    }
}
