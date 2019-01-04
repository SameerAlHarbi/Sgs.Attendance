using AutoMapper;
using Microsoft.Extensions.Logging;
using Sgs.Attendance.Api.Models;
using Sgs.Attendance.BusinessLogic;
using Sgs.Attendance.Model;

namespace Sgs.Attendance.Api.Controllers
{
    public class WorkShiftsCalendarsController : GeneralApiController<WorkShiftsCalendar, WorkShiftsCalendarModel>
    {
        public WorkShiftsCalendarsController(WorkShiftsCalendarsManagers dataManager, IMapper mapper
            , ILogger<WorkShiftsCalendarsController> logger) : base(dataManager, mapper, logger)
        {
        }
    }
}
