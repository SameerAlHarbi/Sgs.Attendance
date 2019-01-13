using AutoMapper;
using Microsoft.Extensions.Logging;
using Sameer.Shared;
using Sgs.Attendance.Mvc.Models;
using Sgs.Attendance.Mvc.ViewModels;

namespace Sgs.Attendance.Mvc.Controllers
{
    public class WorkShiftsSystemsController : GeneralMvcController<WorkShiftsSystemModel, WorkShiftsSystemViewModel>
    {
        public WorkShiftsSystemsController(IDataManager<WorkShiftsSystemModel> dataManager, IMapper mapper, ILogger<WorkShiftsSystemsController> logger) 
            : base(dataManager, mapper, logger)
        {
        }
    }
}
