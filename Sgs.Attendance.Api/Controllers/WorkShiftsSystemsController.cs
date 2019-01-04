using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Logging;
using Sameer.Shared;
using Sgs.Attendance.Api.Models;
using Sgs.Attendance.Model;

namespace Sgs.Attendance.Api.Controllers
{
    [EnableCors("Any")]
    public class WorkShiftsSystemsController : GeneralApiController<WorkShiftsSystem, WorkShiftsSystemModel>
    {
        public WorkShiftsSystemsController(IDataManager<WorkShiftsSystem> dataManager, IMapper mapper, ILogger<WorkShiftsSystemsController> logger)
            : base(dataManager, mapper, logger)
        {
        }
    }
}
