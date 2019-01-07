using AutoMapper;
using Microsoft.Extensions.Logging;
using Sameer.Shared;
using Sgs.Attendance.Mvc.Models;
using Sgs.Attendance.Mvc.ViewModels;

namespace Sgs.Attendance.Mvc.Controllers
{
    public class DepartmentsController : GeneralMvcController<DepartmentModel, DepartmentViewModel>
    {
        public DepartmentsController(IDataManager<DepartmentModel> dataManager, IMapper mapper
            , ILogger<DepartmentsController> logger) : base(dataManager, mapper, logger)
        {
        }


    }
}
