using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Logging;
using Sgs.Attendance.Api.Models;
using Sgs.Attendance.BusinessLogic;
using Sgs.Attendance.ERP;
using Sgs.Attendance.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sgs.Attendance.Api.Controllers
{
    [EnableCors("Any")]
    public class DepartmentsInfoController : GeneralApiController<DepartmentInfo, DepartmentInfoModel>
    {
        private readonly IErpManager _erpManager;

        public DepartmentsInfoController(IErpManager erpManager,DepartmentsInfoManager dataManager,
            IMapper mapper, ILogger<DepartmentsInfoController> logger) 
            : base(dataManager, mapper, logger)
        {
            _erpManager = erpManager;
        }

        protected override async Task<List<DepartmentInfoModel>> fillItemsListMissingData(List<DepartmentInfoModel> resultData)
        {
            try
            {
                this._logger.LogInformation("Getting all ERP departments data ...");

                var allErpDepartments = await _erpManager.GetAllErpDepartmentsInfo();

                if (allErpDepartments != null && allErpDepartments.Count() > 0)
                {
                    var allErpDepartmentsModels = _mapper.Map<List<DepartmentInfoModel>>(allErpDepartments);

                    foreach (var item in allErpDepartmentsModels)
                    {
                        item.Url = string.Empty;
                    }

                    foreach (var dataItem in resultData)
                    {

                        var erpDeptModel = allErpDepartmentsModels.FirstOrDefault(d => d.Code == dataItem.Code);

                        erpDeptModel.Id = dataItem.Id;
                        erpDeptModel.Url = dataItem.Url;
                        erpDeptModel.ManagerAttendanceProof = dataItem.ManagerAttendanceProof;

                    }

                    return allErpDepartmentsModels;
                }

                return resultData;
            }
            catch (System.Exception)
            {
                _logger.LogError("Error while getting ERP departments data ...");
                throw;
            }
        }
    }
}