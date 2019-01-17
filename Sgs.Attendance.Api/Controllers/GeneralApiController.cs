using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Sameer.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Sgs.Attendance.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public abstract class GeneralApiController<M, VM> : Controller where M : class, ISameerObject, new() where VM : class, new()
    {
        protected virtual string _objectTypeName { get; set; } = typeof(M).Name;

        public const string URLHELPER = "URLHELPER";
        public const string CONTROLLER_NAME = "CONTROLLER_NAME";
        public const string NOTFOUND_MESSAGE = "Not Found";

        protected readonly IMapper _mapper;
        protected readonly ILogger _logger;
        protected readonly IDataManager<M> _dataManager;

        public GeneralApiController(IDataManager<M> dataManager,IMapper mapper, ILogger<GeneralApiController<M,VM>> logger)
        {
            _dataManager = dataManager;
            _mapper = mapper;
            _logger = logger;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            context.HttpContext.Items[URLHELPER] = this.Url;
            context.HttpContext.Items[CONTROLLER_NAME] = ControllerContext.ActionDescriptor.ControllerName;
        }

        protected virtual async Task<List<VM>> fillItemsListMissingData(List<VM> resultData)
        {
            return await Task.FromResult(resultData);
        }

        protected virtual async Task<VM> fillItemMissingData(VM dataItem)
        {
            var resultDataItem = await fillItemsListMissingData(new List<VM>() { dataItem });
            return resultDataItem.First();
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public virtual async Task<ActionResult<List<VM>>> GetAsync()
        {
            try
            {
                using (_dataManager)
                {
                    var allDataList = await _dataManager.GetAllDataList();
                    return await fillItemsListMissingData(_mapper.Map<List<VM>>(allDataList));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while getting all data !. error message : {ex.Message}");
            }

            return BadRequest();
        }

        [HttpGet("GetBy")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public virtual async Task<ActionResult<List<VM>>> GetByAsync(string fieldName, string fieldValue)
        {
            try
            {
                using (_dataManager)
                {
                    var parameter = Expression.Parameter(typeof(M), "x");
                    var member = Expression.Property(parameter, fieldName);
                    var left = Expression.Call(member, typeof(string).GetMethod("Trim", Type.EmptyTypes));
                    var left2 = Expression.Call(left, typeof(string).GetMethod("ToLower", Type.EmptyTypes));
                    var constant = Expression.Constant(fieldValue);
                    var right = Expression.Call(constant, typeof(string).GetMethod("Trim", Type.EmptyTypes));
                    var right2 = Expression.Call(right, typeof(string).GetMethod("ToLower", Type.EmptyTypes));
                    var body = Expression.Equal(left2, right2);
                    var finalExpression = Expression.Lambda<Func<M, bool>>(body, parameter);

                    //TODO:Update idata manager to accept expression
                    var allDataList = await _dataManager.GetAllDataList();
                    return await fillItemsListMissingData(_mapper.Map<List<VM>>(allDataList.Where(finalExpression.Compile())));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while getting All data !. error message : {ex.Message}");
            }

            return BadRequest();
        }

        [HttpGet("paged")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public virtual async Task<ActionResult<List<VM>>> GetPagedAsync(string sort = "id",int pageNumber=1,int pageSize=100)
        {
            try
            {
                using (_dataManager)
                {
                    PagedDataResult<M> pagedDataList = await _dataManager.GetPagedDataList(pageNumber,pageSize,sort);
                    AddPaginationHeader(pagedDataList);
                    return await fillItemsListMissingData(_mapper.Map<List<VM>>(pagedDataList.DataList));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while getting All data !. error message : {ex.Message}");
            }

            return BadRequest();
        }

        protected virtual void AddPaginationHeader(PagedDataResult<M> pagedData)
        {
            var paginationHeader = new
            {
                currentPage = pagedData.PageNumber,
                pageSize = pagedData.PageSize,
                totalCount = pagedData.DataCount,
                totalPages = pagedData.PagesCount
            };

            HttpContext.Response.Headers.Add(key: "X-Pagination", value: Newtonsoft.Json.JsonConvert.SerializeObject(paginationHeader));
        }

        [HttpGet("{id}", Name = "[controller]_[action]")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public virtual async Task<ActionResult<VM>> GetByIdAsync(int id)
        {
            try
            {
                using (_dataManager)
                {
                    var currentData = await _dataManager.GetDataById(id);

                    if (currentData == null)
                        return BadRequest(new { title = NOTFOUND_MESSAGE });

                    return await fillItemMissingData(_mapper.Map<VM>(currentData));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while getting data !. error message : {ex.Message}");
            }

            return BadRequest();
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public virtual async Task<ActionResult<VM>> PostAsync(VM model)
        {
            try
            {
                _logger.LogInformation($"Creating a new {_objectTypeName} !");

                var validationResults = await checkNewData(model);
                if (validationResults.Any())
                {
                    foreach (var vr in validationResults)
                    {
                        foreach (var mn in vr.MemberNames)
                        {
                            _logger.LogWarning($"validation exception while saving new {_objectTypeName} :member name : {mn} error : {vr.ErrorMessage}");
                            ModelState.AddModelError(mn, vr.ErrorMessage);
                        }
                    }
                }
                else
                {
                    var newData = _mapper.Map<M>(model);

                    using (_dataManager)
                    {
                        var saveResult = await _dataManager.InsertNewDataItem(newData);

                        if (saveResult.Status == RepositoryActionStatus.Created)
                        {
                            _logger.LogInformation($"{_objectTypeName} created successfully.");

                            return CreatedAtAction(nameof(GetByIdAsync),
                                new { id = saveResult.Entity.Id },
                                _mapper.Map<VM>(newData));
                        }
                        else
                        {
                            _logger.LogWarning($"Could not save {_objectTypeName} to the database");
                            ModelState.AddModelError(string.Empty, "Can't save please try again later !");
                        }
                    }
                }
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning($"validation exception while saving new {_objectTypeName} : {ex.ValidationResult.ErrorMessage}");
                ModelState.AddModelError(ex.ValidationResult.MemberNames.FirstOrDefault()??"", ex.ValidationResult.ErrorMessage);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Throw exception while save new {_objectTypeName} : {ex}");
                return BadRequest();
            }

            return BadRequest();
        }

        protected virtual async Task<List<ValidationResult>> checkNewData(VM newData)
        {
            return await Task.FromResult(new List<ValidationResult>());
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public virtual async Task<ActionResult<VM>> PutAsync(int id, VM model)
        {
            try
            {
                _logger.LogInformation($"Updating {_objectTypeName} with an id of {id}");

                using (_dataManager)
                {
                    var currentData = await _dataManager.GetDataById(id);
                    if (currentData == null)
                    {
                        _logger.LogWarning($"Could not find a {_objectTypeName} of an id of {id}");
                        return BadRequest(new { title = NOTFOUND_MESSAGE });
                    }

                    var validationResults = await checkUpdateData(currentData, model);
                    if (validationResults.Any())
                    {
                        foreach (var vr in validationResults)
                        {
                            foreach (var mn in vr.MemberNames)
                            {
                                _logger.LogWarning($"validation exception while updating {_objectTypeName} :member name : {mn} error : {vr.ErrorMessage}");
                                ModelState.AddModelError(mn, vr.ErrorMessage);
                            }
                        }
                    }
                    else
                    {
                        _mapper.Map(model, currentData);

                        var updateResult = await _dataManager.UpdateDataItem(currentData);
                        if (updateResult.Status == RepositoryActionStatus.Updated)
                        {
                            _logger.LogInformation($"{_objectTypeName} updated successfully.");
                            return _mapper.Map<VM>(currentData);
                        }
                        else
                        {
                            _logger.LogWarning($"Could not update {_objectTypeName} to the database");
                            ModelState.AddModelError(string.Empty, "Can't save please try again later !");
                        }
                    }
                }
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning($"validation exception while updating {_objectTypeName} : {ex.ValidationResult.ErrorMessage}");
                ModelState.AddModelError(ex.ValidationResult.MemberNames.FirstOrDefault() ?? string.Empty, ex.ValidationResult.ErrorMessage);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Throw exception while updating {_objectTypeName} : {ex}");
                return BadRequest();
            }

            return BadRequest(ModelState);
        }

        protected virtual async Task<List<ValidationResult>> checkUpdateData(M currentData, VM newData)
        {
            return await Task.FromResult(new List<ValidationResult>());
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                _logger.LogInformation($"Deleting {_objectTypeName} of an id of {id}");

                using (_dataManager)
                {
                    var currentData = await _dataManager.GetDataById(id);
                    if (currentData == null)
                    {
                        _logger.LogWarning($"Could not find a {_objectTypeName} of an id of {id}");
                        return BadRequest(new { title = NOTFOUND_MESSAGE });
                    }

                    var validationResults = await checkDeleteData(currentData);
                    if (validationResults.Any())
                    {
                        foreach (var vr in validationResults)
                        {
                            foreach (var mn in vr.MemberNames)
                            {
                                _logger.LogWarning($"validation exception while deleting {_objectTypeName} :member name : {mn} error : {vr.ErrorMessage}");
                                ModelState.AddModelError(mn, vr.ErrorMessage);
                            }
                        }
                    }
                    else
                    {
                        var deleteResult = await _dataManager.DeleteDataItem(currentData.Id);
                        if (deleteResult.Status == RepositoryActionStatus.Deleted)
                        {
                            _logger.LogInformation($"{_objectTypeName} deleted successfully.");
                            return NoContent();
                        }
                        else
                        {
                            _logger.LogWarning($"Could not delete {_objectTypeName} from the database");
                            ModelState.AddModelError(string.Empty, "Can't delete please try again later !");
                        }
                    }
                }
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning($"validation exception while deleting {_objectTypeName} : {ex.ValidationResult.ErrorMessage}");
                ModelState.AddModelError(ex.ValidationResult.MemberNames.FirstOrDefault() ?? string.Empty, ex.ValidationResult.ErrorMessage);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Throw exception while deleting {_objectTypeName} : {ex}");
                return BadRequest();
            }

            return BadRequest(ModelState);
        }

        protected virtual async Task<List<ValidationResult>> checkDeleteData(M currentData)
        {
            return await Task.FromResult(new List<ValidationResult>());
        }

    }
}
