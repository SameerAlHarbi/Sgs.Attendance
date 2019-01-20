using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sgs.Attendance.Api.Models;
using Sgs.Attendance.BusinessLogic;
using Sgs.Attendance.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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

        protected override async Task<List<ValidationResult>> checkNewData(WorkShiftsSystemModel newData)
        {
            var results = await base.checkNewData(newData);

            var currentItem =  ((WorkShiftsSystemsManager)_dataManager).GetAll()
                .Where(e => e.IsDefaultWorkShiftsSystem == newData.IsDefaultWorkShiftsSystem && e.Id != newData.Id && e.IsDefaultWorkShiftsSystem== true).FirstOrDefault();


            return results;
        }

        [HttpGet("ByCode/{code}", Name = "[controller]_[action]")]
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
