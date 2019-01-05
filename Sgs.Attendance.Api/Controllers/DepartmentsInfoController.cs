using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sgs.Attendance.Api.Models;
using Sgs.Attendance.BusinessLogic;
using Sgs.Attendance.ERP;
using Sgs.Attendance.Model;

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

        protected override async Task<List<DepartmentInfoModel>> fillMissingData(List<DepartmentInfoModel> resultData)
        {
            var allErpDepartments = await _erpManager.GetAllErpDepartmentsInfo();

            if(allErpDepartments != null && allErpDepartments.Count() > 0)
            {
                var allErpDepartmentsModels = _mapper.Map<List<DepartmentInfoModel>>(allErpDepartments);

                foreach (var dataItem in resultData)
                {
                    var erpDeptModel = allErpDepartmentsModels.FirstOrDefault(d => d.Code == dataItem.Code);
                    _mapper.Map(dataItem, erpDeptModel);
                }
            }

            return  resultData;
        }

    }
}
