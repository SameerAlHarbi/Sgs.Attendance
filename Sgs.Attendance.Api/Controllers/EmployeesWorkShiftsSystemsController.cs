using AutoMapper;
using Microsoft.Extensions.Logging;
using Sameer.Shared;
using Sgs.Attendance.Api.Models;
using Sgs.Attendance.Model;

namespace Sgs.Attendance.Api.Controllers
{
    public class EmployeesWorkShiftsSystemsController : GeneralApiController<EmployeeWorkShiftsSystem, EmployeeWorkShiftsSystemModel>
    {
        public EmployeesWorkShiftsSystemsController(IDataManager<EmployeeWorkShiftsSystem> dataManager, IMapper mapper
            , ILogger<EmployeesWorkShiftsSystemsController> logger) 
            : base(dataManager, mapper, logger)
        {
        }
    }
}
