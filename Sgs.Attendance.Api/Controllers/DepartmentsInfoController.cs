using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Logging;
using Sgs.Attendance.Api.Models;
using Sgs.Attendance.BusinessLogic;
using Sgs.Attendance.Model;

namespace Sgs.Attendance.Api.Controllers
{
    [EnableCors("Any")]
    public class DepartmentsInfoController : GeneralApiController<DepartmentInfo, DepartmentInfoModel>
    {
        public DepartmentsInfoController(DepartmentsInfoManager dataManager,
            IMapper mapper, ILogger<DepartmentsInfoController> logger) 
            : base(dataManager, mapper, logger)
        {
        }
    }
}
