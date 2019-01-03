using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Logging;
using Sameer.Shared;
using Sgs.Attendance.Api.Models;
using Sgs.Attendance.Model;

namespace Sgs.Attendance.Api.Controllers
{
    [EnableCors("Any")]
    public class DepartmentsInfoController : GeneralApiController<DepartmentInfo, DepartmentInfoModel>
    {
        public DepartmentsInfoController(IDataManager<DepartmentInfo> dataManager, IMapper mapper, ILogger<DepartmentsInfoController> logger) 
            : base(dataManager, mapper, logger)
        {
        }
    }
}
