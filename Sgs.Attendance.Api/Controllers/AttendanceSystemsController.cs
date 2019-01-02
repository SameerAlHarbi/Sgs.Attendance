using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sameer.Shared;
using Sameer.Shared.Data;
using Sgs.Attendance.Api.Models;
using Sgs.Attendance.BusinessLogic;
using Sgs.Attendance.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Sgs.Attendance.Api.Controllers
{
    [EnableCors("Any")]
    [Route("api/[controller]")]
    public class AttendanceSystemsController : BaseController
    {
        private readonly WorkShiftsSystemsManager _attendanceSystemsManager;

        public AttendanceSystemsController(WorkShiftsSystemsManager attendanceSystemsManager, IMapper mapper, ILogger<AttendanceSystemsController> logger) : base(mapper, logger)
        {
            _attendanceSystemsManager = attendanceSystemsManager;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<List<WorkShiftsSystemModel>>> GetAsync()
        {
            try
            {
                using (_attendanceSystemsManager)
                {
                    var attendanceSystemsList = await _attendanceSystemsManager.GetAllAsNoTrackingListAsync();
                    return _mapper.Map<List<WorkShiftsSystemModel>>(attendanceSystemsList);
                }
            }
            catch (Exception)
            {
            }

            return BadRequest();
        }

        [HttpGet("{code}", Name = "AttendanceSystemGetByCode")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<WorkShiftsSystemModel>> GetByCodeAsync(string code)
        {
            try
            {
                using (_attendanceSystemsManager)
                {
                    var attendanceSystem = await _attendanceSystemsManager.GetSingleItemAsync(s => s.Code.Trim().ToUpper() == code.Trim().ToUpper());

                    if (attendanceSystem == null)
                        return BadRequest(NOTFOUND_MESSAGE);

                    return _mapper.Map<WorkShiftsSystemModel>(attendanceSystem);
                }
            }
            catch (Exception)
            {
            }

            return BadRequest();
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<WorkShiftsSystemModel>> PostAsync(WorkShiftsSystemModel model)
        {
            try
            {
                _logger.LogInformation("Creating a new attendance system !");

                var newData = _mapper.Map<WorkShiftsSystem>(model);

                using (_attendanceSystemsManager)
                {
                    var saveResult = await _attendanceSystemsManager.InsertNewAsync(newData);

                    if (saveResult.Status == RepositoryActionStatus.Created)
                    {
                        return CreatedAtAction(nameof(GetByCodeAsync),
                            new { code = model.Code },
                            _mapper.Map<WorkShiftsSystemModel>(newData));
                    }
                    else
                    {
                        _logger.LogWarning("Could not save attendance system to the database");
                    }
                }

            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.ValidationResult.ErrorMessage);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Throw exception while save : {ex}");
            }

            return BadRequest();
        }

        [HttpPut("{code}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<WorkShiftsSystemModel>> PutAsync(string code, WorkShiftsSystemModel model)
        {
            try
            {
                _logger.LogInformation($"Updating attendance system with code of {code}");

                using (_attendanceSystemsManager)
                {
                    var currentData = await _attendanceSystemsManager.GetSingleItemAsync(s => s.Code.Trim().ToUpper() == code.Trim().ToUpper());
                    if (currentData == null)
                    {
                        _logger.LogWarning($"Could not find a attendance system of an code of {code}");
                        return BadRequest(NOTFOUND_MESSAGE);
                    }

                    _mapper.Map(model, currentData);

                    var updateResult = await _attendanceSystemsManager.UpdateItemAsync(currentData);
                    if (updateResult.Status == RepositoryActionStatus.Updated)
                    {
                        return _mapper.Map<WorkShiftsSystemModel>(currentData);
                    }
                    else
                    {
                        _logger.LogWarning("Could not update attendance system to the database");
                    }
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Throw exception while update attendance system: {ex}");
            }

            return BadRequest("Couldn't update attendance system info");
        }

        [HttpDelete("{code}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteAsync(string code)
        {
            try
            {
                _logger.LogInformation($"Deleting attendance system of an code of {code}");
                using (_attendanceSystemsManager)
                {
                    var currentData = await _attendanceSystemsManager.GetSingleItemAsync(s => s.Code.Trim().ToUpper() == code.Trim().ToUpper());
                    if (currentData == null)
                    {
                        _logger.LogWarning($"Could not find a attendance system of an code of {code}");
                        return BadRequest(NOTFOUND_MESSAGE);
                    }

                    var deleteResult = await _attendanceSystemsManager.DeleteItemAsync(currentData.Id);
                    if (deleteResult.Status == RepositoryActionStatus.Deleted)
                    {
                        return NoContent();
                    }
                    else
                    {
                        _logger.LogWarning("Could not delete attendance system from the database");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Throw exception while delete attendance system: {ex}");
            }

            return BadRequest("Couldn't delete attendance system");
        }

    }
}
