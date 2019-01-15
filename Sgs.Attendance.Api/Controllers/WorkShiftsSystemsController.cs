using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sgs.Attendance.Api.Models;
using Sgs.Attendance.BusinessLogic;
using Sgs.Attendance.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace Sgs.Attendance.Api.Controllers
{
    [EnableCors("Any")]
    public class WorkShiftsSystemsController : GeneralApiController<WorkShiftsSystem, WorkShiftsSystemModel>
    {
        public WorkShiftsSystemsController(WorkShiftsSystemsManager dataManager,
            IMapper mapper, ILogger<WorkShiftsSystemsController> logger) : base(dataManager, mapper, logger)
        {
        }

        [HttpGet("{code}", Name = "[controller]_[action]")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public virtual async Task<ActionResult<WorkShiftsSystemModel>> GetByCodeAsync(string code)
        {
            try
            {
                using (_dataManager)
                {
                    var currentData = await ((WorkShiftsSystemsManager)_dataManager).GetSingleItemAsync(s => s.Code.Trim().ToUpper() == code.Trim().ToUpper());

                    if (currentData == null)
                        return BadRequest(NOTFOUND_MESSAGE);

                    return await fillItemMissingData(_mapper.Map<WorkShiftsSystemModel>(currentData));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while getting data by code !. error message : {ex.Message}");
            }

            return BadRequest();
        }
    }
}
