using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sgs.Attendance.Api.Models;
using Sgs.Attendance.BusinessLogic;
using Sgs.Attendance.Model;
using System;
using System.Threading.Tasks;

namespace Sgs.Attendance.Api.Controllers
{
    public class EmployeesInfoController : GeneralApiController<EmployeeInfo, EmployeeInfoModel>
    {
        public EmployeesInfoController(EmployeesInfoManager dataManager, IMapper mapper, ILogger<EmployeesInfoController> logger)
            : base(dataManager, mapper, logger)
        {
        }

        [HttpGet("ByEmployeeId/{employeeId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<EmployeeInfoModel>> GetByEmployeeIdAsync(int employeeId)
        {
            try
            {
                using (_dataManager)
                {
                    var currentData = await ((EmployeesInfoManager)_dataManager).GetSingleItemAsync(e => e.EmployeeId == employeeId);

                    if (currentData == null)
                        return BadRequest(NOTFOUND_MESSAGE);

                    return _mapper.Map<EmployeeInfoModel>(currentData);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while getting data !. error message : {ex.Message}");
            }

            return BadRequest();
        }
    }
}
